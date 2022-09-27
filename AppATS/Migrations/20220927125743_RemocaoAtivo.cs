using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAts.Migrations
{
    public partial class RemocaoAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ativo",
                table: "Candidatos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "ativo",
                table: "Candidatos",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
