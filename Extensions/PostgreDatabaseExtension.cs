using Import_Export_Company.Data;
using Import_Export_Company.Repositories;
using Import_Export_Company.Services;
using Microsoft.EntityFrameworkCore;

namespace Import_Export_Company.Extensions
{
    public static class PostgreDatabaseExtension
    {
        public static IServiceCollection AddPostgresInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IWareHouseRepository, WareHouseRepository>();
            services.AddScoped<IWareHouseService, WareHouseService>();

            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierService, SupplierService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();

            services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();

            services.AddScoped<IPartnerDebtRepository, PartnerDebtRepository>();
            services.AddScoped<IPartnerDebtService, PartnerDebtService>();

            return services;
        }
    }
}
