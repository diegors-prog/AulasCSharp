using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class alterarNomeDaColunaParaAmountChargeAndSetarNuloNaColunaPaymentDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "charge_amount",
                table: "charge",
                newName: "amount_charge");

            migrationBuilder.AlterColumn<DateTime>(
                name: "issuance_date",
                table: "charge",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 22, 4, 30, 22, 457, DateTimeKind.Utc).AddTicks(810),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 18, 4, 41, 59, 890, DateTimeKind.Utc).AddTicks(8100));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount_charge",
                table: "charge",
                newName: "charge_amount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "issuance_date",
                table: "charge",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 18, 4, 41, 59, 890, DateTimeKind.Utc).AddTicks(8100),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2022, 4, 22, 4, 30, 22, 457, DateTimeKind.Utc).AddTicks(810));
        }
    }
}
