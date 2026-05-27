using System.ComponentModel.DataAnnotations;

namespace Import_Export_Company.DTOs.Request
{
    public class CreateSalesOrderDTO
    {
        [Required]
        public string So_Number { get; set; }

        [Required]
        public int Customer_id { get; set; }

        [Required]
        public int Warehouse_id { get; set; }

        [Required]
        public DateTime Order_Date { get; set; }

        [Required]
        public decimal Total_Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public int Created_by { get; set; }

        public List<CreateSalesOrderDetailDTO> SalesOrderDetails { get; set; } = new List<CreateSalesOrderDetailDTO>();
    }

    public class CreateSalesOrderDetailDTO
    {
        [Required]
        public int Product_id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Unit_price { get; set; }
    }
}

