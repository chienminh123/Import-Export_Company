namespace Import_Export_Company.DTOs.Request
{
    public class CreateImportDocumentDTO
    {
        public string Bill_of_lading { get; set; }
        public string Commercial_invoice { get; set; }
        public string Customs_declaration { get; set; }
        public DateTime? Etd { get; set; }
        public DateTime? Eta { get; set; }
        public string Document_url { get; set; }
    }
}
