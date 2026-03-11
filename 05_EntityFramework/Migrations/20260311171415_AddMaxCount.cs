using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _05_EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddMaxCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxCountPassangers",
                table: "Airplanes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxCountPassangers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaxCountPassangers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 3,
                column: "MaxCountPassangers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 4,
                column: "MaxCountPassangers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Airplanes",
                keyColumn: "Id",
                keyValue: 5,
                column: "MaxCountPassangers",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxCountPassangers",
                table: "Airplanes");
        }
    }
}
