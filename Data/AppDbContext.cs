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
        
    }
}
