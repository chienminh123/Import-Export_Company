using Import_Export_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Import_Export_Company.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Inventory> Inventorys { get; set; }
        public DbSet<Inventory_Transactions> InventoryTransactions { get; set; }
        public DbSet<Purchase_Orders> PurchaseOrders { get; set; }
        public DbSet<Purchase_Order_Details> PurchaseOrderDetails { get; set; }
        public DbSet<Import_Documents> ImportDocuments { get; set; }
        public DbSet<Sales_Orders> SalesOrders { get; set; }
        public DbSet<Sales_Order_Details> SalesOrderDetails { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Partner_Debts> PartnerDebts { get; set; }
        public DbSet<WareHouses> WareHouses { get; set; }
        public DbSet<Financial_Vouchers> FinancialVouchers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().HasData(
                new Users { Id = 1, UserName = "admin", Password = BCrypt.Net.BCrypt.HashPassword("Chien@12345"), FullName = "Nguyễn Minh Chiến", Email = "admin@company.com", PhoneNumber = "0900000001", Department = "Ban Giám Đốc", Status = "Active", Created_at = DateTime.UtcNow },
                new Users { Id = 2, UserName = "sales", Password = BCrypt.Net.BCrypt.HashPassword("Chien@12345"), FullName = "N V Sales", Email = "sales@company.com", PhoneNumber = "0900000002", Department = "Kinh Doanh", Status = "Active", Created_at = DateTime.UtcNow },
                new Users { Id = 3, UserName = "kho", Password = BCrypt.Net.BCrypt.HashPassword("Chien@12345"), FullName = "N V Kho", Email = "kho@company.com", PhoneNumber = "0900000003", Department = "Kho Bãi", Status = "Active", Created_at = DateTime.UtcNow },
                new Users
                {
                    Id = 4,
                    UserName = "keToan",
                    Password = BCrypt.Net.BCrypt.HashPassword("Chien@12345"),
                    FullName = "N V Kế Toán",
                    Email = "keToan@company.com",
                    PhoneNumber = "0900000004",
                    Department = "Kế Toán",
                    Status = "Active",
                    Created_at = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Roles>().HasData(
                new Roles { Id = 1, Role_name = "Admin", Description = "Quản trị viên toàn quyền" },
                new Roles { Id = 2, Role_name = "Sales", Description = "Nhân viên kinh doanh" },
                new Roles { Id = 3, Role_name = "Warehouse", Description = "Thủ kho" },
                new Roles { Id = 4, Role_name = "Accountant", Description = "Kế toán" }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, UserId = 1, RoleId = 1 }, 
                new UserRole { Id = 2, UserId = 2, RoleId = 2 }, 
                new UserRole { Id = 3, UserId = 3, RoleId = 3 }, 
                new UserRole { Id = 4, UserId = 4, RoleId = 4 }
            );

            modelBuilder.Entity<WareHouses>().HasData(
                new WareHouses { Id = 1, Name = "Kho Tổng Miền Bắc", Address = "Hà Nội", PhoneNumber = "0243111222" },
                new WareHouses { Id = 2, Name = "Kho Cảng Hải Phòng", Address = "Hải Phòng", PhoneNumber = "0225111333" }
            );

            modelBuilder.Entity<Products>().HasData(
                new Products { Id = 2, Sku = "LAP-DELL-01", Barcode = "8901234567890", Name = "Laptop Dell XPS 15", Unit = "Cái", Weight =(decimal) 2.5,Volume=(decimal) 0.1, Description = "Laptop cao cấp từ Dell" },
                new Products { Id = 3, Sku = "IPHONE-15-PRM", Barcode = "8901234567891", Name = "iPhone 15 Pro Max 256GB", Unit = "Cái", Weight = (decimal) 0.2,Volume=(decimal) 0.05, Description = "Điện thoại thông minh cao cấp từ Apple" }
            );

            modelBuilder.Entity<Suppliers>().HasData(
                new Suppliers { Id = 1, Company_name = "Dell Technologies US", Country = "USA", Contact_name="NMC", Email = "partner@dell.com", Phone = "1800123456", Address = "Texas, USA" }
            );

            modelBuilder.Entity<Customers>().HasData(
                new Customers { Id = 1, Customer_name = "Đại lý Thế Giới Số", Email = "contact@tgs.vn", Phone = "0988111222", Delivery_address = "Đống Đa, Hà Nội" }
            );

            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 1, Warehouse_id = 1, Product_id = 2, Quantity = 50, Reserved_quantity = 5 },
                new Inventory { Id = 2, Warehouse_id = 1, Product_id = 3, Quantity = 30, Reserved_quantity = 2 },
                new Inventory { Id = 3, Warehouse_id = 2, Product_id = 2, Quantity = 20, Reserved_quantity = 0 },
                new Inventory { Id = 4, Warehouse_id = 2, Product_id = 3, Quantity = 15, Reserved_quantity = 1 }
            );

            modelBuilder.Entity<Inventory_Transactions>().HasData(
                new Inventory_Transactions { Id = 1, WareHouse_id = 1, Product_id = 2, Transaction_type = "IMPORT", Quantity = 50, Reference_id = 1, User_id = 1, Created_at = DateTime.UtcNow },
                new Inventory_Transactions { Id = 2, WareHouse_id = 1, Product_id = 3, Transaction_type = "IMPORT", Quantity = 30, Reference_id = 1, User_id = 1, Created_at = DateTime.UtcNow },
                new Inventory_Transactions { Id = 3, WareHouse_id = 1, Product_id = 2, Transaction_type = "RESERVE", Quantity = 5, Reference_id = 1, User_id = 2, Created_at = DateTime.UtcNow }
            );

            modelBuilder.Entity<Purchase_Orders>().HasData(
                new Purchase_Orders { Id = 1, Po_Number = "PO-2026-0001", Supplier_id = 1, Order_Date = DateTime.UtcNow.AddDays(-10), Expected_Delivery = DateTime.UtcNow.AddDays(5), Total_Amount = 50000m, Currency = "USD", Status = "SHIPPING", Created_by = 1 }
            );

            modelBuilder.Entity<Purchase_Order_Details>().HasData(
                new Purchase_Order_Details { Id = 1, Purchase_Order_id = 1, Product_id = 2, Quantity = 10, Unit_price = 2000m },
                new Purchase_Order_Details { Id = 2, Purchase_Order_id = 1, Product_id = 3, Quantity = 5, Unit_price = 3000m }
            );

            modelBuilder.Entity<Import_Documents>().HasData(
                new Import_Documents { Id = 1, Purchase_Order_id = 1, Bill_of_lading = "BOL-0001", Commercial_invoice = "CI-0001", Customs_declaration = "CD-0001", Etd = DateTime.UtcNow.AddDays(-7), Eta = DateTime.UtcNow.AddDays(3), Document_url = "https://docs.example.com/imports/1" }
            );

            modelBuilder.Entity<Sales_Orders>().HasData(
                new Sales_Orders { Id = 1, So_Number = "SO-2026-0001", Customer_id = 1, Warehouse_id = 1, Order_Date = DateTime.UtcNow.AddDays(-2), Total_Amount = 7000m, Currency = "USD", Status = "PENDING", Created_by = 2 }
            );

            modelBuilder.Entity<Sales_Order_Details>().HasData(
                new Sales_Order_Details { Id = 1, Sales_Order_id = 1, Product_id = 2, Quantity = 2, Unit_price = 2000m },
                new Sales_Order_Details { Id = 2, Sales_Order_id = 1, Product_id = 3, Quantity = 1, Unit_price = 3000m }
            );

            modelBuilder.Entity<Partner_Debts>().HasData(
                new Partner_Debts { Id = 1, Partner_type = "Customer", Partner_id = 1, Total_debt = 7000m, Paid_amount = 0m, Remaining_debt = 7000m },
                new Partner_Debts { Id = 2, Partner_type = "Supplier", Partner_id = 1, Total_debt = 50000m, Paid_amount = 20000m, Remaining_debt = 30000m }
            );

            modelBuilder.Entity<Financial_Vouchers>().HasData(
                new Financial_Vouchers { Id = 1, Voucher_number = "FV-2026-0001", Type = "PAYMENT", Reference_type = "PurchaseOrder", Reference_id = 1, Amount = 20000m, Payment_method = "BankTransfer", Payment_date = DateTime.UtcNow.AddDays(-3), User_id = 4 }
            );
        }
    }
}
