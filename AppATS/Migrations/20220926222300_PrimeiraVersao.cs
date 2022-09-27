using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAts.Migrations
{
    public partial class PrimeiraVersao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    idCandidatos = table.Column<string>(maxLength: 36, nullable: false),
                    nome = table.Column<string>(maxLength: 100, nullable: true),
                    login = table.Column<string>(maxLength: 80, nullable: true),
                    senha = table.Column<string>(maxLength: 80, nullable: true),
                    ativo = table.Column<short>(type: "smallint", nullable: false),
                    email = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pkCandidato", x => x.idCandidatos);
                });

            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    idVaga = table.Column<string>(maxLength: 36, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    situacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pkVaga", x => x.idVaga);
                });

            migrationBuilder.CreateTable(
                name: "candidaturas",
                columns: table => new
                {
                    IdCandidatura = table.Column<string>(maxLength: 36, nullable: false),
                    IdCandidato = table.Column<string>(maxLength: 36, nullable: false),
                    idVaga = table.Column<string>(maxLength: 36, nullable: false),
                    IdCandidatoNavigationIdCandidato = table.Column<string>(nullable: true),
                    IdVagaNavigationIdVaga = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pkCandidatura", x => x.IdCandidatura);
                    table.ForeignKey(
                        name: "FK_candidaturas_Candidatos_IdCandidatoNavigationIdCandidato",
                        column: x => x.IdCandidatoNavigationIdCandidato,
                        principalTable: "Candidatos",
                        principalColumn: "idCandidatos",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_candidaturas_Vagas_IdVagaNavigationIdVaga",
                        column: x => x.IdVagaNavigationIdVaga,
                        principalTable: "Vagas",
                        principalColumn: "idVaga",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fkcandidato_idx",
                table: "candidaturas",
                column: "IdCandidato");

            migrationBuilder.CreateIndex(
                name: "IX_candidaturas_IdCandidatoNavigationIdCandidato",
                table: "candidaturas",
                column: "IdCandidatoNavigationIdCandidato");

            migrationBuilder.CreateIndex(
                name: "fkvaga_idx",
                table: "candidaturas",
                column: "idVaga");

            migrationBuilder.CreateIndex(
                name: "IX_candidaturas_IdVagaNavigationIdVaga",
                table: "candidaturas",
                column: "IdVagaNavigationIdVaga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidaturas");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Vagas");
        }
    }
}
