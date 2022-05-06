using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    phone = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "charge",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    issuance_date = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2022, 4, 18, 4, 41, 59, 890, DateTimeKind.Utc).AddTicks(8100)),
                    due_date = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    payment_date = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    payment_status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    charge_amount = table.Column<double>(type: "REAL", nullable: false),
                    customer_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_charge", x => x.id);
                    table.ForeignKey(
                        name: "FK_Charge_Customer",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_charge_customer_id",
                table: "charge",
                column: "customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "charge");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
