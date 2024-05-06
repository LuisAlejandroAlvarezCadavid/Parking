using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ParkingFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Parking");

            migrationBuilder.CreateTable(
                name: "Logs",
                schema: "Parking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValuePay = table.Column<int>(type: "int", nullable: true),
                    LeaveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pay = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotorCycle",
                schema: "Parking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValuePay = table.Column<int>(type: "int", nullable: true),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pay = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorCycle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicule",
                schema: "Parking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValuePay = table.Column<int>(type: "int", nullable: true),
                    LeaveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pay = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicule", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs",
                schema: "Parking");

            migrationBuilder.DropTable(
                name: "MotorCycle",
                schema: "Parking");

            migrationBuilder.DropTable(
                name: "Vehicule",
                schema: "Parking");
        }
    }
}
