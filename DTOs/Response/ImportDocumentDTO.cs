namespace Import_Export_Company.DTOs.Response
{
    public class ImportDocumentDTO
    {
        public int Id { get; set; }
        public int Purchase_Order_id { get; set; }
        public string Bill_of_lading { get; set; }
        public string Commercial_invoice { get; set; }
        public string Customs_declaration { get; set; }
        public DateTime? Etd { get; set; }
        public DateTime? Eta { get; set; }
        public string Document_url { get; set; }
    }
}
