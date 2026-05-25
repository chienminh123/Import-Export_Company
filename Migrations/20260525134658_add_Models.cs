using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Import_Export_Company.Migrations
{
    /// <inheritdoc />
    public partial class add_Models : Migration
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
                name: "Sales_Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    So_number = table.Column<string>(type: "text", nullable: false),
                    Customer_id = table.Column<int>(type: "integer", nullable: false),
                    Order_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Total_amount = table.Column<decimal>(type: "numeric", nullable: false),
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
                    WareHouse_id = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_Inventory_WareHouses_WareHouse_id",
                        column: x => x.WareHouse_id,
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
                    Warehouse_id = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_Inventory_Transactions_WareHouses_Warehouse_id",
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
                    Sales_order_id = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_Sales_Order_Details_Sales_Orders_Sales_order_id",
                        column: x => x.Sales_order_id,
                        principalTable: "Sales_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Inventory_WareHouse_id",
                table: "Inventory",
                column: "WareHouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Transactions_Product_id",
                table: "Inventory_Transactions",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Transactions_User_id",
                table: "Inventory_Transactions",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Transactions_Warehouse_id",
                table: "Inventory_Transactions",
                column: "Warehouse_id");

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
                name: "IX_Sales_Order_Details_Sales_order_id",
                table: "Sales_Order_Details",
                column: "Sales_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Orders_Created_by",
                table: "Sales_Orders",
                column: "Created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Orders_Customer_id",
                table: "Sales_Orders",
                column: "Customer_id");

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
                name: "WareHouses");

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
        }
    }
}
