namespace Import_Export_Company.DTOs.Response
{
    public class PurchaseOrderDetailDTO
    {
        public int Id { get; set; }
        public int Purchase_Order_id { get; set; }
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public decimal Unit_price { get; set; }
    }
}
