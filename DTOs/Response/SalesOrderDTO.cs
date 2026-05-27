namespace Import_Export_Company.DTOs.Response
{
    public class SalesOrderDTO
    {
        public int Id { get; set; }
        public string So_Number { get; set; }
        public int Customer_id { get; set; }
        public int Warehouse_id { get; set; }
        public DateTime Order_Date { get; set; }
        public decimal Total_Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public int Created_by { get; set; }
        public List<SalesOrderDetailDTO> SalesOrderDetails { get; set; } = new List<SalesOrderDetailDTO>();
    }

    public class SalesOrderDetailDTO
    {
        public int Id { get; set; }
        public int Sales_Order_id { get; set; }
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public decimal Unit_price { get; set; }
    }
}

