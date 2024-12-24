using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLL.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Sales_SaleId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "ResidenceId",
                table: "Interviews");

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Sales_SaleId",
                table: "Interviews",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Sales_SaleId",
                table: "Interviews");

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "Interviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ResidenceId",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Sales_SaleId",
                table: "Interviews",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id");
        }
    }
}
