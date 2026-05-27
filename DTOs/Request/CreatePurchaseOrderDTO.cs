using System.ComponentModel.DataAnnotations;

namespace Import_Export_Company.DTOs.Request
{
    public class CreatePurchaseOrderDTO
    {
        [Required(ErrorMessage = "Mã đơn hàng PO không được để trống")]
        public string Po_Number { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn nhà cung cấp")]
        public int Supplier_id { get; set; }

        [Required(ErrorMessage = "Ngày lên đơn không được để trống")]
        public DateTime Order_Date { get; set; }

        [Required(ErrorMessage = "Ngày dự kiến hàng về không được để trống")]
        public DateTime Expected_Delivery { get; set; }

        [Required(ErrorMessage = "Tổng giá trị đơn hàng không được để trống")]
        public decimal Total_Amount { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại tiền tệ thanh toán")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Thông tin người tạo không được để trống")]
        public int Created_by { get; set; }

        public List<CreatePurchaseOrderDetailDTO> PurchaseOrderDetails { get; set; } = new List<CreatePurchaseOrderDetailDTO>();
    }
}
