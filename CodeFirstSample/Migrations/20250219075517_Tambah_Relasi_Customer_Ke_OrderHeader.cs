using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstSample.Migrations
{
    /// <inheritdoc />
    public partial class Tambah_Relasi_Customer_Ke_OrderHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "OrderHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_CustomerId",
                table: "OrderHeaders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_Customers_CustomerId",
                table: "OrderHeaders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_Customers_CustomerId",
                table: "OrderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeaders_CustomerId",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "OrderHeaders");
        }
    }
}
