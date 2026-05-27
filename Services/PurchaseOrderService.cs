using Import_Export_Company.Data;
using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;
using Import_Export_Company.Models;
using Import_Export_Company.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Import_Export_Company.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _repository;
        private readonly AppDbContext _context;
        public PurchaseOrderService(IPurchaseOrderRepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }
        
        public async Task<IEnumerable<PurchaseOrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _repository.GetAllAsync();
            return orders.Select(o => new PurchaseOrderDTO
            {
                Id = o.Id,
                Po_Number = o.Po_Number,
                Supplier_id = o.Supplier_id,
                Order_Date = o.Order_Date,
                Expected_Delivery = o.Expected_Delivery,
                Total_Amount = o.Total_Amount,
                Currency = o.Currency,
                Status = o.Status,
                Created_by = o.Created_by,
                PurchaseOrderDetails = o.PurchaseOrderDetails.Select(d => new PurchaseOrderDetailDTO
                {
                    Id = d.Id,
                    Purchase_Order_id = d.Purchase_Order_id,
                    Product_id = d.Product_id,
                    Quantity = d.Quantity,
                    Unit_price = d.Unit_price
                }).ToList(),
                ImportDocuments = o.ImportDocuments.Select(doc => new ImportDocumentDTO
                {
                    Id = doc.Id,
                    Purchase_Order_id = doc.Purchase_Order_id,
                    Bill_of_lading = doc.Bill_of_lading,
                    Commercial_invoice = doc.Commercial_invoice,
                    Customs_declaration = doc.Customs_declaration,
                    Etd = doc.Etd,
                    Eta = doc.Eta,
                    Document_url = doc.Document_url
                }).ToList()
            });
        }
        public async Task<PurchaseOrderDTO> GetOrderByIdAsync(int id)
        {
            var o = await _repository.GetByIdAsync(id);
            if (o == null) throw new Exception("Order not found.");

            return new PurchaseOrderDTO
            {
                Id = o.Id,
                Po_Number = o.Po_Number,
                Supplier_id = o.Supplier_id,
                Order_Date = o.Order_Date,
                Expected_Delivery = o.Expected_Delivery,
                Total_Amount = o.Total_Amount,
                Currency = o.Currency,
                Status = o.Status,
                Created_by = o.Created_by,
                PurchaseOrderDetails = o.PurchaseOrderDetails.Select(d => new PurchaseOrderDetailDTO
                {
                    Id = d.Id,
                    Purchase_Order_id = d.Purchase_Order_id,
                    Product_id = d.Product_id,
                    Quantity = d.Quantity,
                    Unit_price = d.Unit_price
                }).ToList(),
                ImportDocuments = o.ImportDocuments.Select(doc => new ImportDocumentDTO
                {
                    Id = doc.Id,
                    Purchase_Order_id = doc.Purchase_Order_id,
                    Bill_of_lading = doc.Bill_of_lading,
                    Commercial_invoice = doc.Commercial_invoice,
                    Customs_declaration = doc.Customs_declaration,
                    Etd = doc.Etd,
                    Eta = doc.Eta,
                    Document_url = doc.Document_url
                }).ToList()
            };
        }

        public async Task<PurchaseOrderDTO> CreateOrderAsync(CreatePurchaseOrderDTO dto)
        {
            var existing = await _repository.GetByPoNumberAsync(dto.Po_Number);
            if (existing != null) throw new Exception("PO_NUMBER_EXISTS");

            var order = new Purchase_Orders
            {
                Po_Number = dto.Po_Number,
                Supplier_id = dto.Supplier_id,
                Order_Date = dto.Order_Date,
                Expected_Delivery = dto.Expected_Delivery,
                Total_Amount = dto.Total_Amount,
                Currency = dto.Currency,
                Status = "PENDING",
                Created_by = dto.Created_by,
                PurchaseOrderDetails = dto.PurchaseOrderDetails.Select(d => new Purchase_Order_Details
                {
                    Product_id = d.Product_id,
                    Quantity = d.Quantity,
                    Unit_price = d.Unit_price
                }).ToList()
            };

            await _repository.AddAsync(order);
            await _repository.SaveChangesAsync();

            return await GetOrderByIdAsync(order.Id);
        }

        public async Task<PurchaseOrderDTO> UpdateToShippingAsync(int id, ImportDocumentDTO docDto)
        {
            var order = await _repository.GetByIdAsync(id);
            if(order == null) throw new Exception("Order not found.");
            if(order.Status != "PENDING") throw new Exception("INVALID_STATUS");

            var doc = new Import_Documents
            {
                Purchase_Order_id = id,
                Bill_of_lading = docDto.Bill_of_lading,
                Commercial_invoice = docDto.Commercial_invoice,
                Customs_declaration = docDto.Customs_declaration,
                Etd = docDto.Etd,
                Eta = docDto.Eta,
                Document_url = docDto.Document_url
            };
            order.Status = "SHIPPING";

            await _repository.AddImportDocumentAsync(doc);
            _repository.Update(order);
            await _repository.SaveChangesAsync();

            return await GetOrderByIdAsync(id);

        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null) throw new Exception("Order not found.");
            if (order.Status != "PENDING") throw new Exception("INVALID_STATUS_FOR_DELETE");

            _repository.Delete(order);
            await _repository.SaveChangesAsync();
        }

        public async Task<PurchaseOrderDTO> CancelOrderAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null) throw new Exception("Order not found.");
            if (order.Status == "COMPLETED" || order.Status == "CANCELLED") throw new Exception("INVALID_STATUS_FOR_CANCEL");

            order.Status = "CANCELLED";
            _repository.Update(order);
            await _repository.SaveChangesAsync();

            return await GetOrderByIdAsync(id);
        }

        public async Task<PurchaseOrderDTO> ConfirmImportAsync(int id, int warehouseId)
        {
            var order = await _repository.GetByIdAsync(id);
            if(order == null) throw new Exception("Order not found.");
            if(order.Status != "SHIPPING") throw new Exception("INVALID_STATUS");

            using var dbTransaction = await _context.Database.BeginTransactionAsync();
            try
            {
                order.Status = "COMPLETED";
                _repository.Update(order);

                foreach (var detail in order.PurchaseOrderDetails)
                {
                    var inventoryLog = new Inventory_Transactions
                    {
                        WareHouse_id = warehouseId,
                        Product_id = detail.Product_id,
                        Transaction_type = "IMPORT",
                        Quantity = detail.Quantity,
                        Reference_id = order.Id,
                        User_id = order.Created_by,
                        Created_at = DateTime.UtcNow
                    };
                    await _context.Set<Inventory_Transactions>().AddAsync(inventoryLog);

                    var stock = await _context.Set<Inventory>()
                        .FirstOrDefaultAsync(i => i.Warehouse_id == warehouseId && i.Product_id == detail.Product_id);

                    if (stock == null)
                    {
                        var newStock = new Inventory
                        {
                            Warehouse_id = warehouseId,
                            Product_id = detail.Product_id,
                            Quantity = detail.Quantity,
                            Reserved_quantity = 0
                        };
                        await _context.Set<Inventory>().AddAsync(newStock);
                    }
                    else
                    {
                        stock.Quantity += detail.Quantity;
                        _context.Set<Inventory>().Update(stock);
                    }
                }

                var debt = await _context.Set<Partner_Debts>()
                    .FirstOrDefaultAsync(d => d.Partner_type == "SUPPLIER" && d.Partner_id == order.Supplier_id);

                if (debt == null)
                {
                    var newDebt = new Partner_Debts
                    {
                        Partner_type = "SUPPLIER",
                        Partner_id = order.Supplier_id,
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
        
    }
}
