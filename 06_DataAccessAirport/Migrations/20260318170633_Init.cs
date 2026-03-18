using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _06_DataAccessAirport.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxCountPassangers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credential",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credential", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartureCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirplaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Flights_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passangers",
                columns: table => new
                {
                    CredentialId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passangers", x => x.CredentialId);
                    table.ForeignKey(
                        name: "FK_Passangers_Credential_CredentialId",
                        column: x => x.CredentialId,
                        principalTable: "Credential",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "MaxCountPassangers", "Model" },
                values: new object[,]
                {
                    { 1, 0, "AN747" },
                    { 2, 0, "AN746" },
                    { 3, 0, "AN746" },
                    { 4, 0, "AN744" },
                    { 5, 0, "AN743" }
                });

            migrationBuilder.InsertData(
                table: "Credential",
                columns: new[] { "Id", "ClientId", "Login", "Password" },
                values: new object[,]
                {
                    { 1, null, "user1", "12345" },
                    { 2, null, "user2", "12345" },
                    { 3, null, "user3", "12345" },
                    { 4, null, "user4", "12345" },
                    { 5, null, "user5", "12345" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Number", "AirplaneId", "ArrivalCity", "ArrivalTime", "DepartureCity", "DepartureTime" },
                values: new object[,]
                {
                    { 1, 1, "Kyiv", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lviv", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Kyiv", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Praga", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, "Kyiv", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warshaw", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, "Kyiv", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kharkiv", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Passangers",
                columns: new[] { "CredentialId", "Birthdate", "Email", "FirstName", "Rating" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "vova@gmail.com", "Vova", 0 },
                    { 2, new DateTime(2000, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "ira@gmail.com", "Ira", 0 },
                    { 3, new DateTime(2001, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "nikita@gmail.com", "Nikita", 0 },
                    { 4, new DateTime(2003, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "sasha@gmail.com", "Sasha", 0 },
                    { 5, new DateTime(2005, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "dima@gmail.com", "Dima", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFlight_FlightsNumber",
                table: "ClientFlight",
                column: "FlightsNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirplaneId",
                table: "Flights",
                column: "AirplaneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFlight");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passangers");

            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.DropTable(
                name: "Credential");
        }
    }
}
