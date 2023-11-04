using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTOGO.Web.Migrations
{
    /// <inheritdoc />
    public partial class ThirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_address_AddressId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_address",
                schema: "dbo",
                table: "address");

            migrationBuilder.RenameTable(
                name: "address",
                schema: "dbo",
                newName: "Address",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                schema: "dbo",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_AddressId",
                table: "Order",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_AddressId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                schema: "dbo",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "dbo",
                newName: "address",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_address",
                schema: "dbo",
                table: "address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_address_AddressId",
                table: "Order",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
