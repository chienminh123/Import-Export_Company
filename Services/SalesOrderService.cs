using Import_Export_Company.Data;
using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;
using Import_Export_Company.Models;
using Import_Export_Company.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Import_Export_Company.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly ISalesOrderRepository _soRepository;
        private readonly AppDbContext _context;

        public SalesOrderService(ISalesOrderRepository soRepository, AppDbContext context)
        {
            _soRepository = soRepository;
            _context = context;
        }

        public async Task<IEnumerable<SalesOrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _soRepository.GetAllAsync();
            return orders.Select(o => new SalesOrderDTO
            {
                Id = o.Id,
                So_Number = o.So_Number,
                Customer_id = o.Customer_id,
                Warehouse_id = o.Warehouse_id,
                Order_Date = o.Order_Date,
                Total_Amount = o.Total_Amount,
                Currency = o.Currency,
                Status = o.Status,
                Created_by = o.Created_by,
                SalesOrderDetails = o.SalesOrderDetails.Select(d => new SalesOrderDetailDTO
                {
                    Id = d.Id,
                    Sales_Order_id = d.Sales_Order_id,
                    Product_id = d.Product_id,
                    Quantity = d.Quantity,
                    Unit_price = d.Unit_price
                }).ToList()
            });
        }

        public async Task<SalesOrderDTO> GetOrderByIdAsync(int id)
        {
            var o = await _soRepository.GetByIdAsync(id);
            if (o == null) throw new Exception("Order not found.");

            return new SalesOrderDTO
            {
                Id = o.Id,
                So_Number = o.So_Number,
                Customer_id = o.Customer_id,
                Warehouse_id = o.Warehouse_id,
                Order_Date = o.Order_Date,
                Total_Amount = o.Total_Amount,
                Currency = o.Currency,
                Status = o.Status,
                Created_by = o.Created_by,
                SalesOrderDetails = o.SalesOrderDetails.Select(d => new SalesOrderDetailDTO
                {
                    Id = d.Id,
                    Sales_Order_id = d.Sales_Order_id,
                    Product_id = d.Product_id,
                    Quantity = d.Quantity,
                    Unit_price = d.Unit_price
                }).ToList()
            };
        }

        public async Task<SalesOrderDTO> CreateOrderAsync(CreateSalesOrderDTO dto)
        {
            using var dbTransaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var existing = await _soRepository.GetBySoNumberAsync(dto.So_Number);
                if (existing != null) throw new Exception("SO_NUMBER_EXISTS");

                var order = new Sales_Orders
                {
                    So_Number = dto.So_Number,
                    Customer_id = dto.Customer_id,
                    Warehouse_id = dto.Warehouse_id,
                    Order_Date = dto.Order_Date,
                    Total_Amount = dto.Total_Amount,
                    Currency = dto.Currency,
                    Status = "PENDING",
                    Created_by = dto.Created_by,
                    SalesOrderDetails = dto.SalesOrderDetails.Select(d => new Sales_Order_Details
                    {
                        Product_id = d.Product_id,
                        Quantity = d.Quantity,
                        Unit_price = d.Unit_price
                    }).ToList()
                };

                await _soRepository.AddAsync(order);

                foreach (var detail in dto.SalesOrderDetails)
                {
                    var stock = await _context.Set<Inventory>()
                        .FirstOrDefaultAsync(i => i.Warehouse_id == dto.Warehouse_id && i.Product_id == detail.Product_id);

                    if (stock == null) throw new Exception($"STOCK_NOT_FOUND_{detail.Product_id}");

                    decimal availableStock = stock.Quantity - stock.Reserved_quantity;
                    if (availableStock < detail.Quantity) throw new Exception($"NOT_ENOUGH_STOCK_{detail.Product_id}");

                    stock.Reserved_quantity += detail.Quantity;
                    _context.Set<Inventory>().Update(stock);
                }

                await _context.SaveChangesAsync();
                await dbTransaction.CommitAsync();

                return await GetOrderByIdAsync(order.Id);
            }
            catch (Exception)
            {
                await dbTransaction.RollbackAsync();
                throw;
            }
        }

        public async Task<SalesOrderDTO> ConfirmExportAsync(int id)
        {
            var order = await _soRepository.GetByIdAsync(id);
            if (order == null) throw new Exception("Order not found.");
            if (order.Status != "PENDING") throw new Exception("INVALID_STATUS");

            using var dbTransaction = await _context.Database.BeginTransactionAsync();
            try
            {
                order.Status = "COMPLETED";
                _soRepository.Update(order);

                foreach (var detail in order.SalesOrderDetails)
                {
                    var inventoryLog = new Inventory_Transactions
                    {
                        WareHouse_id = order.Warehouse_id,
                        Product_id = detail.Product_id,
                        Transaction_type = "EXPORT",
                        Quantity = detail.Quantity,
                        Reference_id = order.Id,
                        User_id = order.Created_by,
                        Created_at = DateTime.UtcNow
                    };
                    await _context.Set<Inventory_Transactions>().AddAsync(inventoryLog);

                    var stock = await _context.Set<Inventory>()
                        .FirstOrDefaultAsync(i => i.Warehouse_id == order.Warehouse_id && i.Product_id == detail.Product_id);

                    stock.Quantity -= detail.Quantity;
                    stock.Reserved_quantity -= detail.Quantity;
                    _context.Set<Inventory>().Update(stock);
                }

                var debt = await _context.Set<Partner_Debts>()
                    .FirstOrDefaultAsync(d => d.Partner_type == "CUSTOMER" && d.Partner_id == order.Customer_id);

                if (debt == null)
                {
                    var newDebt = new Partner_Debts
                    {
                        Partner_type = "CUSTOMER",
                        Partner_id = order.Customer_id,
                        Total_debt = order.Total_Amount,
                        Paid_amount = 0,
                        Remaining_debt = order.Total_Amount
                    };
                    await _context.Set<Partner_Debts>().AddAsync(newDebt);
                }
                else
                {
                    debt.Total_debt += order.Total_Amount;
                    debt.Remaining_debt = debt.Total_debt - debt.Paid_amount;
                    _context.Set<Partner_Debts>().Update(debt);
                }

                await _context.SaveChangesAsync();
                await dbTransaction.CommitAsync();

                return await GetOrderByIdAsync(id);
            }
            catch (Exception)
            {
                await dbTransaction.RollbackAsync();
                throw;
            }
        }

        public async Task<SalesOrderDTO> CancelOrderAsync(int id)
        {
            var order = await _soRepository.GetByIdAsync(id);
            if (order == null) throw new Exception("Order not found.");
            if (order.Status != "PENDING") throw new Exception("INVALID_STATUS_FOR_CANCEL");

            using var dbTransaction = await _context.Database.BeginTransactionAsync();
            try
            {
                order.Status = "CANCELLED";
                _soRepository.Update(order);

                foreach (var detail in order.SalesOrderDetails)
                {
                    var stock = await _context.Set<Inventory>()
                        .FirstOrDefaultAsync(i => i.Warehouse_id == order.Warehouse_id && i.Product_id == detail.Product_id);

                    stock.Reserved_quantity -= detail.Quantity;
                    _context.Set<Inventory>().Update(stock);
                }

                await _context.SaveChangesAsync();
                await dbTransaction.CommitAsync();

                return await GetOrderByIdAsync(id);
            }
            catch (Exception)
            {
                await dbTransaction.RollbackAsync();
                throw;
            }
        }
    }
}
