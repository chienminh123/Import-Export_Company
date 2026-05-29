using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Import_Export_Company.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Customer_name = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Delivery_address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partner_Debts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Partner_type = table.Column<string>(type: "text", nullable: false),
                    Partner_id = table.Column<int>(type: "integer", nullable: false),
                    Total_debt = table.Column<decimal>(type: "numeric", nullable: false),
                    Paid_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Remaining_debt = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner_Debts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sku = table.Column<string>(type: "text", nullable: false),
                    Barcode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: true),
                    Volume = table.Column<decimal>(type: "numeric", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role_name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Company_name = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Contact_name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Full_name = table.Column<string>(type: "text", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WareHouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Financial_Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Voucher_number = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Reference_type = table.Column<string>(type: "text", nullable: false),
                    Reference_id = table.Column<int>(type: "integer", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Payment_method = table.Column<string>(type: "text", nullable: false),
                    Payment_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    User_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financial_Vouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financial_Vouchers_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Po_Number = table.Column<string>(type: "text", nullable: false),
                    Supplier_id = table.Column<int>(type: "integer", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Expected_Delivery = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Total_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Created_by = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Orders_Suppliers_Supplier_id",
                        column: x => x.Supplier_id,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Orders_Users_Created_by",
                        column: x => x.Created_by,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Warehouse_id = table.Column<int>(type: "integer", nullable: false),
                    Product_id = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Reserved_quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Products_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_WareHouses_Warehouse_id",
                        column: x => x.Warehouse_id,
                        principalTable: "WareHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory_Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WareHouse_id = table.Column<int>(type: "integer", nullable: false),
                    Product_id = table.Column<int>(type: "integer", nullable: false),
                    Transaction_type = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Reference_id = table.Column<int>(type: "integer", nullable: true),
                    User_id = table.Column<int>(type: "integer", nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Transactions_Products_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Transactions_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Transactions_WareHouses_WareHouse_id",
                        column: x => x.WareHouse_id,
                        principalTable: "WareHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales_Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    So_Number = table.Column<string>(type: "text", nullable: false),
                    Customer_id = table.Column<int>(type: "integer", nullable: false),
                    Warehouse_id = table.Column<int>(type: "integer", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Total_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Created_by = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Orders_Customers_Customer_id",
                        column: x => x.Customer_id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Orders_Users_Created_by",
                        column: x => x.Created_by,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Orders_WareHouses_Warehouse_id",
                        column: x => x.Warehouse_id,
                        principalTable: "WareHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Import_Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Purchase_Order_id = table.Column<int>(type: "integer", nullable: false),
                    Bill_of_lading = table.Column<string>(type: "text", nullable: false),
                    Commercial_invoice = table.Column<string>(type: "text", nullable: false),
                    Customs_declaration = table.Column<string>(type: "text", nullable: false),
                    Etd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Eta = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Document_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Import_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Import_Documents_Purchase_Orders_Purchase_Order_id",
                        column: x => x.Purchase_Order_id,
                        principalTable: "Purchase_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_Order_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Purchase_Order_id = table.Column<int>(type: "integer", nullable: false),
                    Product_id = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Unit_price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_Order_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Order_Details_Products_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Order_Details_Purchase_Orders_Purchase_Order_id",
                        column: x => x.Purchase_Order_id,
                        principalTable: "Purchase_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales_Order_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sales_Order_id = table.Column<int>(type: "integer", nullable: false),
                    Product_id = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Unit_price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales_Order_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Order_Details_Products_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Order_Details_Sales_Orders_Sales_Order_id",
                        column: x => x.Sales_Order_id,
                        principalTable: "Sales_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Customer_name", "Delivery_address", "Email", "Phone" },
                values: new object[] { 1, "Đại lý Thế Giới Số", "Đống Đa, Hà Nội", "contact@tgs.vn", "0988111222" });

            migrationBuilder.InsertData(
                table: "Partner_Debts",
                columns: new[] { "Id", "Paid_amount", "Partner_id", "Partner_type", "Remaining_debt", "Total_debt" },
                values: new object[,]
                {
                    { 1, 0m, 1, "Customer", 7000m, 7000m },
                    { 2, 20000m, 1, "Supplier", 30000m, 50000m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Description", "Name", "Sku", "Unit", "Volume", "Weight" },
                values: new object[,]
                {
                    { 2, "8901234567890", "Laptop cao cấp từ Dell", "Laptop Dell XPS 15", "LAP-DELL-01", "Cái", 0.1m, 2.5m },
                    { 3, "8901234567891", "Điện thoại thông minh cao cấp từ Apple", "iPhone 15 Pro Max 256GB", "IPHONE-15-PRM", "Cái", 0.05m, 0.2m }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Role_name" },
                values: new object[,]
                {
                    { 1, "Quản trị viên toàn quyền", "Admin" },
                    { 2, "Nhân viên kinh doanh", "Sales" },
                    { 3, "Thủ kho", "Warehouse" },
                    { 4, "Kế toán", "Accountant" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "Company_name", "Contact_name", "Country", "Email", "Phone" },
                values: new object[] { 1, "Texas, USA", "Dell Technologies US", "NMC", "USA", "partner@dell.com", "1800123456" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created_at", "Department", "Email", "Full_name", "Password", "PhoneNumber", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 29, 9, 49, 32, 649, DateTimeKind.Utc).AddTicks(212), "Ban Giám Đốc", "admin@company.com", "Nguyễn Minh Chiến", "$2a$11$ungZzQNMURplBUa73PPESO0WW6TZTP3.02OE2BoeceAoeTQv16SUW", "0900000001", "Active", "admin" },
                    { 2, new DateTime(2026, 5, 29, 9, 49, 32, 787, DateTimeKind.Utc).AddTicks(325), "Kinh Doanh", "sales@company.com", "N V Sales", "$2a$11$JGDEdfdVLmoDfl.K0bWQPOX31Ech0DR5UaLWV8Yx3ERQVR03CIXsO", "0900000002", "Active", "sales" },
                    { 3, new DateTime(2026, 5, 29, 9, 49, 32, 924, DateTimeKind.Utc).AddTicks(6954), "Kho Bãi", "kho@company.com", "N V Kho", "$2a$11$/TGH8jmshOqW9YA4idsCa.NwhwbNxl3MKN9s4HYtPYb9wNk1fjqDC", "0900000003", "Active", "kho" },
                    { 4, new DateTime(2026, 5, 29, 9, 49, 33, 61, DateTimeKind.Utc).AddTicks(9449), "Kế Toán", "keToan@company.com", "N V Kế Toán", "$2a$11$8fQF8IvS1PKb21M0UeW8POfYDslymHfny9tjBzTMAL6MUHo9HjgLC", "0900000004", "Active", "keToan" }
                });

            migrationBuilder.InsertData(
                table: "WareHouses",
                columns: new[] { "Id", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "Kho Tổng Miền Bắc", "0243111222" },
                    { 2, "Hải Phòng", "Kho Cảng Hải Phòng", "0225111333" }
                });

            migrationBuilder.InsertData(
                table: "Financial_Vouchers",
                columns: new[] { "Id", "Amount", "Payment_date", "Payment_method", "Reference_id", "Reference_type", "Type", "User_id", "Voucher_number" },
                values: new object[] { 1, 20000m, new DateTime(2026, 5, 26, 9, 49, 33, 62, DateTimeKind.Utc).AddTicks(1134), "BankTransfer", 1, "PurchaseOrder", "PAYMENT", 4, "FV-2026-0001" });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "Product_id", "Quantity", "Reserved_quantity", "Warehouse_id" },
                values: new object[,]
                {
                    { 1, 2, 50, 5, 1 },
                    { 2, 3, 30, 2, 1 },
                    { 3, 2, 20, 0, 2 },
                    { 4, 3, 15, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Inventory_Transactions",
                columns: new[] { "Id", "Created_at", "Product_id", "Quantity", "Reference_id", "Transaction_type", "User_id", "WareHouse_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 29, 9, 49, 33, 62, DateTimeKind.Utc).AddTicks(712), 2, 50, 1, "IMPORT", 1, 1 },
                    { 2, new DateTime(2026, 5, 29, 9, 49, 33, 62, DateTimeKind.Utc).AddTicks(715), 3, 30, 1, "IMPORT", 1, 1 },
                    { 3, new DateTime(2026, 5, 29, 9, 49, 33, 62, DateTimeKind.Utc).AddTicks(717), 2, 5, 1, "RESERVE", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Purchase_Orders",
                columns: new[] { "Id", "Created_by", "Currency", "Expected_Delivery", "Order_Date", "Po_Number", "Status", "Supplier_id", "Total_Amount" },
                values: new object[] { 1, 1, "USD", new DateTime(2026, 6, 3, 9, 49, 33, 62, DateTimeKind.Utc).AddTicks(757), new DateTime(2026, 5, 19, 9, 49, 33, 62, DateTimeKind.Utc).AddTicks(750), "PO-2026-0001", "SHIPPING", 1, 50000m });

            migrationBuilder.InsertData(
                table: "Sales_Orders",
                columns: new[] { "Id", "Created_by", "Currency", "Customer_id", "Order_Date", "So_Number", "Status", "Total_Amount", "Warehouse_id" },
                values: new object[] { 1, 2, "USD", 1, new DateTime(2026, 5, 27, 9, 49, 33, 62, DateTimeKind.Utc).AddTicks(881), "SO-2026-0001", "PENDING", 7000m, 1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Import_Documents",
                columns: new[] { "Id", "Bill_of_lading", "Commercial_invoice", "Customs_declaration", "Document_url", "Eta", "Etd", "Purchase_Order_id" },
                values: new object[] { 1, "BOL-0001", "CI-0001", "CD-0001", "https://docs.example.com/imports/1", new DateTime(2026, 6, 1, 9, 49, 33, 62, DateTimeKind.Utc).AddTicks(851), new DateTime(2026, 5, 22, 9, 49, 33, 62, DateTimeKind.Utc).AddTicks(848), 1 });

            migrationBuilder.InsertData(
                table: "Purchase_Order_Details",
                columns: new[] { "Id", "Product_id", "Purchase_Order_id", "Quantity", "Unit_price" },
                values: new object[,]
                {
                    { 1, 2, 1, 10, 2000m },
                    { 2, 3, 1, 5, 3000m }
                });

            migrationBuilder.InsertData(
                table: "Sales_Order_Details",
                columns: new[] { "Id", "Product_id", "Quantity", "Sales_Order_id", "Unit_price" },
                values: new object[,]
                {
                    { 1, 2, 2, 1, 2000m },
                    { 2, 3, 1, 1, 3000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Financial_Vouchers_User_id",
                table: "Financial_Vouchers",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Import_Documents_Purchase_Order_id",
                table: "Import_Documents",
                column: "Purchase_Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Product_id",
                table: "Inventory",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Warehouse_id",
                table: "Inventory",
                column: "Warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Transactions_Product_id",
                table: "Inventory_Transactions",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Transactions_User_id",
                table: "Inventory_Transactions",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Transactions_WareHouse_id",
                table: "Inventory_Transactions",
                column: "WareHouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Order_Details_Product_id",
                table: "Purchase_Order_Details",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Order_Details_Purchase_Order_id",
                table: "Purchase_Order_Details",
                column: "Purchase_Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Orders_Created_by",
                table: "Purchase_Orders",
                column: "Created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Orders_Supplier_id",
                table: "Purchase_Orders",
                column: "Supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Order_Details_Product_id",
                table: "Sales_Order_Details",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Order_Details_Sales_Order_id",
                table: "Sales_Order_Details",
                column: "Sales_Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Orders_Created_by",
                table: "Sales_Orders",
                column: "Created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Orders_Customer_id",
                table: "Sales_Orders",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Orders_Warehouse_id",
                table: "Sales_Orders",
                column: "Warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financial_Vouchers");

            migrationBuilder.DropTable(
                name: "Import_Documents");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Inventory_Transactions");

            migrationBuilder.DropTable(
                name: "Partner_Debts");

            migrationBuilder.DropTable(
                name: "Purchase_Order_Details");

            migrationBuilder.DropTable(
                name: "Sales_Order_Details");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Purchase_Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales_Orders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WareHouses");
        }
    }
}
