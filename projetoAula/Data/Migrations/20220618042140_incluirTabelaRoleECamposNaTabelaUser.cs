using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class incluirTabelaRoleECamposNaTabelaUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "user",
                newName: "username");

            migrationBuilder.AddColumn<string>(
                name: "bio",
                table: "user",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "user",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "user",
                type: "VARCHAR",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    slug = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    role_id = table.Column<long>(type: "INTEGER", nullable: false),
                    user_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role", x => new { x.role_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_user_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_role_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_slug",
                table: "user",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_role_user_id",
                table: "user_role",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropIndex(
                name: "IX_user_slug",
                table: "user");

            migrationBuilder.DropColumn(
                name: "bio",
                table: "user");

            migrationBuilder.DropColumn(
                name: "image",
                table: "user");

            migrationBuilder.DropColumn(
                name: "slug",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "user",
                newName: "name");
        }
    }
}
