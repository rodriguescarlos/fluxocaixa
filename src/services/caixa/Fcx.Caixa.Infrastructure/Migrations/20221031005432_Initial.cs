using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fcx.Caixa.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lancamento",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoLancamento = table.Column<short>(type: "smallint", nullable: false),
                    Finalidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipoDC = table.Column<string>(type: "char(1)", nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamento", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Movimento",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataMovimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    LancamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimento", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Movimento_Lancamento_LancamentoId",
                        column: x => x.LancamentoId,
                        principalTable: "Lancamento",
                        principalColumn: "Identificador");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_LancamentoId",
                table: "Movimento",
                column: "LancamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimento");

            migrationBuilder.DropTable(
                name: "Lancamento");
        }
    }
}
