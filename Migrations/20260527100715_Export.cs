using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Import_Export_Company.Migrations
{
    /// <inheritdoc />
    public partial class Export : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_WareHouses_WareHouse_id",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Transactions_WareHouses_Warehouse_id",
                table: "Inventory_Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Order_Details_Sales_Orders_Sales_order_id",
                table: "Sales_Order_Details");

            migrationBuilder.RenameColumn(
                name: "Total_amount",
                table: "Sales_Orders",
                newName: "Total_Amount");

            migrationBuilder.RenameColumn(
                name: "So_number",
                table: "Sales_Orders",
                newName: "So_Number");

            migrationBuilder.RenameColumn(
                name: "Order_date",
                table: "Sales_Orders",
                newName: "Order_Date");

            migrationBuilder.RenameColumn(
                name: "Sales_order_id",
                table: "Sales_Order_Details",
                newName: "Sales_Order_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_Order_Details_Sales_order_id",
                table: "Sales_Order_Details",
                newName: "IX_Sales_Order_Details_Sales_Order_id");

            migrationBuilder.RenameColumn(
                name: "Warehouse_id",
                table: "Inventory_Transactions",
                newName: "WareHouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Transactions_Warehouse_id",
                table: "Inventory_Transactions",
                newName: "IX_Inventory_Transactions_WareHouse_id");

            migrationBuilder.RenameColumn(
                name: "WareHouse_id",
                table: "Inventory",
                newName: "Warehouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_WareHouse_id",
                table: "Inventory",
                newName: "IX_Inventory_Warehouse_id");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Sales_Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Warehouse_id",
                table: "Sales_Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Orders_Warehouse_id",
                table: "Sales_Orders",
                column: "Warehouse_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_WareHouses_Warehouse_id",
                table: "Inventory",
                column: "Warehouse_id",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Transactions_WareHouses_WareHouse_id",
                table: "Inventory_Transactions",
                column: "WareHouse_id",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Order_Details_Sales_Orders_Sales_Order_id",
                table: "Sales_Order_Details",
                column: "Sales_Order_id",
                principalTable: "Sales_Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Orders_WareHouses_Warehouse_id",
                table: "Sales_Orders",
                column: "Warehouse_id",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_WareHouses_Warehouse_id",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Transactions_WareHouses_WareHouse_id",
                table: "Inventory_Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Order_Details_Sales_Orders_Sales_Order_id",
                table: "Sales_Order_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Orders_WareHouses_Warehouse_id",
                table: "Sales_Orders");

            migrationBuilder.DropIndex(
                name: "IX_Sales_Orders_Warehouse_id",
                table: "Sales_Orders");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Sales_Orders");

            migrationBuilder.DropColumn(
                name: "Warehouse_id",
                table: "Sales_Orders");

            migrationBuilder.RenameColumn(
                name: "Total_Amount",
                table: "Sales_Orders",
                newName: "Total_amount");

            migrationBuilder.RenameColumn(
                name: "So_Number",
                table: "Sales_Orders",
                newName: "So_number");

            migrationBuilder.RenameColumn(
                name: "Order_Date",
                table: "Sales_Orders",
                newName: "Order_date");

            migrationBuilder.RenameColumn(
                name: "Sales_Order_id",
                table: "Sales_Order_Details",
                newName: "Sales_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_Order_Details_Sales_Order_id",
                table: "Sales_Order_Details",
                newName: "IX_Sales_Order_Details_Sales_order_id");

            migrationBuilder.RenameColumn(
                name: "WareHouse_id",
                table: "Inventory_Transactions",
                newName: "Warehouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Transactions_WareHouse_id",
                table: "Inventory_Transactions",
                newName: "IX_Inventory_Transactions_Warehouse_id");

            migrationBuilder.RenameColumn(
                name: "Warehouse_id",
                table: "Inventory",
                newName: "WareHouse_id");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Warehouse_id",
                table: "Inventory",
                newName: "IX_Inventory_WareHouse_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_WareHouses_WareHouse_id",
                table: "Inventory",
                column: "WareHouse_id",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Transactions_WareHouses_Warehouse_id",
                table: "Inventory_Transactions",
                column: "Warehouse_id",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Order_Details_Sales_Orders_Sales_order_id",
                table: "Sales_Order_Details",
                column: "Sales_order_id",
                principalTable: "Sales_Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
