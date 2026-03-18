using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _06_DataAccessAirport.Migrations
{
    /// <inheritdoc />
    public partial class ClientFlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passangers_Credential_CredentialId",
                table: "Passangers");

            migrationBuilder.DropTable(
                name: "ClientFlight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Credential",
                table: "Credential");

            migrationBuilder.RenameTable(
                name: "Credential",
                newName: "Credentials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClientFlights",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFlights", x => new { x.ClientId, x.FlightId });
                    table.ForeignKey(
                        name: "FK_ClientFlights_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFlights_Passangers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Passangers",
                        principalColumn: "CredentialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientFlights",
                columns: new[] { "ClientId", "FlightId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFlights_FlightId",
                table: "ClientFlights",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passangers_Credentials_CredentialId",
                table: "Passangers",
                column: "CredentialId",
                principalTable: "Credentials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passangers_Credentials_CredentialId",
                table: "Passangers");

            migrationBuilder.DropTable(
                name: "ClientFlights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials");

            migrationBuilder.RenameTable(
                name: "Credentials",
                newName: "Credential");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credential",
                table: "Credential",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClientFlight",
                columns: table => new
                {
                    ClientsCredentialId = table.Column<int>(type: "int", nullable: false),
                    FlightsNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFlight", x => new { x.ClientsCredentialId, x.FlightsNumber });
                    table.ForeignKey(
                        name: "FK_ClientFlight_Flights_FlightsNumber",
                        column: x => x.FlightsNumber,
                        principalTable: "Flights",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFlight_Passangers_ClientsCredentialId",
                        column: x => x.ClientsCredentialId,
                        principalTable: "Passangers",
                        principalColumn: "CredentialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFlight_FlightsNumber",
                table: "ClientFlight",
                column: "FlightsNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Passangers_Credential_CredentialId",
                table: "Passangers",
                column: "CredentialId",
                principalTable: "Credential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
