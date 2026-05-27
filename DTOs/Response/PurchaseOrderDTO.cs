namespace Import_Export_Company.DTOs.Response
{
    public class PurchaseOrderDTO
    {
        public int Id { get; set; }
        public string Po_Number { get; set; }
        public int Supplier_id { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Expected_Delivery { get; set; }
        public decimal Total_Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public int Created_by { get; set; }
        public List<PurchaseOrderDetailDTO> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetailDTO>();
        public List<ImportDocumentDTO> ImportDocuments { get; set; } = new List<ImportDocumentDTO>();
    }
}
