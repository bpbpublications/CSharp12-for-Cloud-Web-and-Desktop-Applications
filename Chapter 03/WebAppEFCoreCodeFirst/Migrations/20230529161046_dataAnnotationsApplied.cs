using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppEFCoreCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class dataAnnotationsApplied : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_CustomerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Supermarkets_SupermarketId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "NewProductTable");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "CustomerName");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SupermarketId",
                table: "NewProductTable",
                newName: "IX_NewProductTable_SupermarketId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CustomerId",
                table: "NewProductTable",
                newName: "IX_NewProductTable_CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "NewProductTable",
                type: "money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "NewProductTable",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewProductTable",
                table: "NewProductTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewProductTable_Customers_CustomerId",
                table: "NewProductTable",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewProductTable_Supermarkets_SupermarketId",
                table: "NewProductTable",
                column: "SupermarketId",
                principalTable: "Supermarkets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewProductTable_Customers_CustomerId",
                table: "NewProductTable");

            migrationBuilder.DropForeignKey(
                name: "FK_NewProductTable_Supermarkets_SupermarketId",
                table: "NewProductTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewProductTable",
                table: "NewProductTable");

            migrationBuilder.RenameTable(
                name: "NewProductTable",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Customers",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_NewProductTable_SupermarketId",
                table: "Products",
                newName: "IX_Products_SupermarketId");

            migrationBuilder.RenameIndex(
                name: "IX_NewProductTable_CustomerId",
                table: "Products",
                newName: "IX_Products_CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_CustomerId",
                table: "Products",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Supermarkets_SupermarketId",
                table: "Products",
                column: "SupermarketId",
                principalTable: "Supermarkets",
                principalColumn: "Id");
        }
    }
}
