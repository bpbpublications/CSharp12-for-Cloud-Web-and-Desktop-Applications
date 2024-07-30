using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppEFCoreCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class optOneToManyApplied : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_NewProductTable_ProductId",
                table: "ProductCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductCategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_NewProductTable_ProductId",
                table: "ProductCategories",
                column: "ProductId",
                principalTable: "NewProductTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_NewProductTable_ProductId",
                table: "ProductCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_NewProductTable_ProductId",
                table: "ProductCategories",
                column: "ProductId",
                principalTable: "NewProductTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
