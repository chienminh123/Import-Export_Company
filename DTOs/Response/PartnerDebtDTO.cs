namespace Import_Export_Company.DTOs.Response
{
    public class PartnerDebtDTO
    {
        public int Id { get; set; }
        public string Partner_type { get; set; }
        public int Partner_id { get; set; }
        public decimal Total_debt { get; set; }
        public decimal Paid_amount { get; set; }
        public decimal Remaining_debt { get; set; }
    }
}
