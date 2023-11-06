using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTOGO.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRestaurantEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Restaurant",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_PhoneNumber",
                table: "Restaurant",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Restaurant_PhoneNumber",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Restaurant");
        }
    }
}
