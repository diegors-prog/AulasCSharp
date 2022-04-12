using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaContatos.Migrations
{
    public partial class excluirColunaContatoAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContatoAtivo",
                table: "contatos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ContatoAtivo",
                table: "contatos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
