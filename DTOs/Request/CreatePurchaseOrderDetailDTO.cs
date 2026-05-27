namespace Import_Export_Company.DTOs.Request
{
    public class CreatePurchaseOrderDetailDTO
    {
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public decimal Unit_price { get; set; }
    }
}
