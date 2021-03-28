using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiGestao.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    IDSALA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.IDSALA);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    IDAGENDAMENTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TITULO = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: true),
                    DT_INICIO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DT_FIM = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SalaIDSALA = table.Column<int>(type: "int", nullable: true),
                    IDSALA = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.IDAGENDAMENTO);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Sala_SalaIDSALA",
                        column: x => x.SalaIDSALA,
                        principalTable: "Sala",
                        principalColumn: "IDSALA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Agendamentos",
                columns: new[] { "IDAGENDAMENTO", "DT_FIM", "DT_INICIO", "IDSALA", "SalaIDSALA", "TITULO" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 24, 11, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 24, 7, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, "Definir Scrum com Equipe" },
                    { 2, new DateTime(2021, 3, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), 2L, null, "Homologação dos requisitos com o cliente" },
                    { 3, new DateTime(2021, 3, 26, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), 3L, null, "contratação candidato" }
                });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "IDSALA", "NOME" },
                values: new object[,]
                {
                    { 1, "Reuniao Equipe Dev" },
                    { 2, "Departamento Pessoal" },
                    { 3, "Entrevistas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_SalaIDSALA",
                table: "Agendamentos",
                column: "SalaIDSALA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Sala");
        }
    }
}
