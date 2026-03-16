using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _05_EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Passangers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Passangers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Passangers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Passangers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Passangers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Passangers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Passangers");
        }
    }
}
