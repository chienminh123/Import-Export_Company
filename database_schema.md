Bảng users (Nhân viên)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID duy nhất của nhân viên
username,VARCHAR(50),"Unique, Not Null",Tên đăng nhập
password,VARCHAR(255),Not Null,Mật khẩu (đã mã hóa)
email,VARCHAR(100),"Unique, Not Null",Email công ty
full_name,VARCHAR(100),Not Null,Họ và tên
department,VARCHAR(50),,"Phòng ban (Sales, Logistics, Kế toán, Kho)"
status,VARCHAR(20),Not Null,"Trạng thái (ACTIVE, INACTIVE)"
created_at,TIMESTAMP,Default CURRENT_TIMESTAMP,Thời gian tạo tài khoản

Bảng roles (Vai trò)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID vai trò
role_name,VARCHAR(50),"Unique, Not Null","Tên vai trò (ADMIN, LOGISTICS, ACCOUNTANT, WAREHOUSE)"
description,VARCHAR(255),,Mô tả chi tiết về quyền hạn

Bảng user_roles (Bảng trung gian phân quyền)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
user_id,BIGINT,Foreign Key -> users(id),ID nhân viên
role_id,BIGINT,Foreign Key -> roles(id),ID vai trò

Bảng products (Danh mục sản phẩm)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID sản phẩm
sku,VARCHAR(50),"Unique, Not Null",Mã quản lý hàng hóa
barcode,VARCHAR(50),,Mã vạch sản phẩm
name,VARCHAR(150),Not Null,Tên sản phẩm
unit,VARCHAR(20),Not Null,"Đơn vị tính (Thùng, Chiếc, Tấn...)"
weight,"DECIMAL(10,2)",,Trọng lượng (kg) phục vụ logistics
volume,"DECIMAL(10,2)",,Thể tích (m3) phục vụ xếp cont
description,TEXT,,Mô tả sản phẩm

Bảng warehouses (Danh mục kho)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID kho
name,VARCHAR(100),Not Null,"Tên kho (Ví dụ: Kho Hải Phòng, Kho Hà Nội)"
address,VARCHAR(255),,Địa chỉ kho

Bảng inventory (Quản lý tồn kho thực tế)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID bản ghi
warehouse_id,BIGINT,Foreign Key -> warehouses(id),Vị trí kho
product_id,BIGINT,Foreign Key -> products(id),Mã sản phẩm
quantity,INT,"Not Null, Default 0",Số lượng tồn kho vật lý hiện tại
reserved_quantity,INT,"Not Null, Default 0",Số lượng đã bị giữ chỗ cho các đơn hàng chờ xuất

Bảng inventory_transactions (Lịch sử biến động kho)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID giao dịch
warehouse_id,BIGINT,Foreign Key -> warehouses(id),Kho phát sinh biến động
product_id,BIGINT,Foreign Key -> products(id),Sản phẩm biến động
transaction_type,VARCHAR(20),Not Null,"Loại biến động (IMPORT, EXPORT, ADJUSTMENT)"
quantity,INT,Not Null,Số lượng thay đổi
reference_id,BIGINT,,ID của đơn mua hoặc đơn bán liên quan
user_id,BIGINT,Foreign Key -> users(id),Người thực hiện lệnh kho
created_at,TIMESTAMP,Default CURRENT_TIMESTAMP,Thời gian thực hiện

Bảng suppliers (Nhà cung cấp)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID nhà cung cấp
company_name,VARCHAR(150),Not Null,Tên công ty đối tác
country,VARCHAR(50),Not Null,Quốc gia xuất xứ
contact_name,VARCHAR(100),,Người đại diện liên hệ
email,VARCHAR(100),,Email giao dịch
phone,VARCHAR(30),,Số điện thoại quốc tế
address,TEXT,,Địa chỉ trụ sở

Bảng purchase_orders (Đơn mua hàng - PO)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID đơn hàng
po_number,VARCHAR(50),"Unique, Not Null",Mã đơn mua hàng (Ví dụ: PO-2026-001)
supplier_id,BIGINT,Foreign Key -> suppliers(id),Đối tác cung cấp
order_date,DATE,Not Null,Ngày lên đơn
expected_delivery,DATE,,Ngày dự kiến hàng về
total_amount,"DECIMAL(15,2)",Not Null,Tổng giá trị đơn hàng
currency,VARCHAR(10),Default 'USD',Loại tiền tệ thanh toán
status,VARCHAR(30),Not Null,"Trạng thái (DRAFT, PENDING, SHIPPING, COMPLETED)"
created_by,BIGINT,Foreign Key -> users(id),Nhân viên thu mua tạo đơn

Bảng purchase_order_details (Chi tiết mặt hàng trong PO)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID dòng
purchase_order_id,BIGINT,Foreign Key -> purchase_orders(id),Thu thuộc PO nào
product_id,BIGINT,Foreign Key -> products(id),Mặt hàng
quantity,INT,Not Null,Số lượng đặt mua
unit_price,"DECIMAL(15,2)",Not Null,Đơn giá mua

Bảng import_documents (Bộ chứng từ nhập khẩu & Vận tải)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID bộ chứng từ
purchase_order_id,BIGINT,Foreign Key -> purchase_orders(id),Đính kèm cho đơn PO nào
bill_of_lading,VARCHAR(100),,Mã vận đơn đường biển (B/L) hoặc hàng không (AWB)
commercial_invoice,VARCHAR(100),,Số hóa đơn thương mại
customs_declaration,VARCHAR(100),,Số tờ khai hải quan nhập khẩu
etd,DATE,,Ngày tàu chạy dự kiến
eta,DATE,,Ngày tàu cập cảng dự kiến
document_url,TEXT,,Đường dẫn lưu trữ file scan chứng từ

Bảng customers (Khách hàng)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID khách hàng
customer_name,VARCHAR(150),Not Null,Tên công ty hoặc cá nhân mua hàng
phone,VARCHAR(30),,Số điện thoại liên hệ
email,VARCHAR(100),,Email nhận báo giá/hóa đơn
delivery_address,TEXT,Not Null,Địa chỉ giao hàng

Bảng sales_orders (Đơn bán hàng - SO)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID đơn bán
so_number,VARCHAR(50),"Unique, Not Null",Mã đơn bán hàng (Ví dụ: SO-2026-001)
customer_id,BIGINT,Foreign Key -> customers(id),Khách hàng mua
order_date,DATE,Not Null,Ngày chốt đơn
total_amount,"DECIMAL(15,2)",Not Null,Tổng giá trị đơn bán
status,VARCHAR(30),Not Null,"Trạng thái (ORDERED, PROCESSING, DELIVERED, CANCELLED)"
created_by,BIGINT,Foreign Key -> users(id),Nhân viên Sales phụ trách

Bảng sales_order_details (Chi tiết mặt hàng trong SO)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID dòng
sales_order_id,BIGINT,Foreign Key -> sales_orders(id),Thuộc đơn SO nào
product_id,BIGINT,Foreign Key -> products(id),Mặt hàng bán
quantity,INT,Not Null,Số lượng bán
unit_price,"DECIMAL(15,2)",Not Null,Đơn giá bán

Bảng financial_vouchers (Phiếu thu / Phiếu chi)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID chứng từ tài chính
voucher_number,VARCHAR(50),"Unique, Not Null","Số phiếu (Ví dụ: PT-001 cho phiếu thu, PC-001 cho phiếu chi)"
type,VARCHAR(20),Not Null,"Loại chứng từ (RECEIPT - Thu, PAYMENT - Chi)"
reference_type,VARCHAR(20),,"Liên kết với phân hệ nào (PO, SO, CUSTOMS_FEE)"
reference_id,BIGINT,,ID của đơn PO hoặc SO tương ứng để đối chiếu
amount,"DECIMAL(15,2)",Not Null,Số tiền giao dịch
payment_method,VARCHAR(30),Not Null,"Hình thức (BANK_TRANSFER, CASH)"
payment_date,DATE,Not Null,Ngày thực hiện giao dịch
user_id,BIGINT,Foreign Key -> users(id),Kế toán thực hiện

Bảng partner_debts (Quản lý công nợ tổng hợp)
Trường (Field),Kiểu dữ liệu,Ràng buộc,Ý nghĩa
id,BIGINT,"Primary Key, Auto Increment",ID bản ghi công nợ
partner_type,VARCHAR(20),Not Null,Xác định đối tượng (SUPPLIER hoặc CUSTOMER)
partner_id,BIGINT,Not Null,ID lấy từ bảng suppliers hoặc customers
total_debt,"DECIMAL(15,2)",Default 0,Tổng số tiền phát sinh phải trả/phải thu
paid_amount,"DECIMAL(15,2)",Default 0,Số tiền thực tế đã thanh toán/đã thu
remaining_debt,"DECIMAL(15,2)",Default 0,Công nợ còn lại tích lũy (total_debt - paid_amount)


Mối quan hệ tương tác giữa các bảng (Luồng dữ liệu Database)
Khi Purchasing tạo một PO mới ở trạng thái SHIPPING:

Hệ thống ghi nhận một bộ chứng từ tương ứng trong bảng import_documents.

Khi hàng về tới kho thực tế (Thủ kho xác nhận nhập):

Một bản ghi được tạo trong inventory_transactions với loại IMPORT.

Số lượng trong bảng inventory tương ứng với product_id và warehouse_id sẽ được cộng thêm.

Bảng partner_debts (loại SUPPLIER) tự động tăng giá trị total_debt dựa trên tổng tiền của PO.

Khi Sales tạo một đơn SO mới ở trạng thái ORDERED:

Hệ thống kiểm tra bảng inventory. Nếu đủ hàng, cột reserved_quantity (số lượng giữ chỗ) tăng lên tương ứng để đảm bảo không bị bán trùng cho đơn khác.

Khi Thủ kho làm lệnh xuất hàng đi:

Bản ghi inventory_transactions loại EXPORT được tạo.

Cả hai cột quantity và reserved_quantity trong bảng inventory đều giảm xuống.

Bảng partner_debts (loại CUSTOMER) tăng giá trị total_debt để theo dõi khoản phải thu từ khách hàng.

Khi Kế toán thực hiện thu/chi tiền:

Tạo bản ghi trong financial_vouchers.

Hệ thống cập nhật cột paid_amount và tính lại remaining_debt trong bảng partner_debts.








