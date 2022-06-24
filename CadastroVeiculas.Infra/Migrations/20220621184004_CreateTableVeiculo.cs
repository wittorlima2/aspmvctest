using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroVeiculos.Infra.Data.Migrations
{
    public partial class CreateTableVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProprietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    proprietario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    marca_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MarcaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tx_renavam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tx_modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nb_ano_fabricacao = table.Column<int>(type: "int", nullable: false),
                    nb_ano_modelo = table.Column<int>(type: "int", nullable: false),
                    nb_quilometragem = table.Column<int>(type: "int", nullable: false),
                    nb_valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nb_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.id);
                    table.ForeignKey(
                        name: "FK_veiculo_marca_marca_id",
                        column: x => x.marca_id,
                        principalTable: "marca",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_veiculo_proprietario_proprietario_id",
                        column: x => x.proprietario_id,
                        principalTable: "proprietario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_marca_id",
                table: "veiculo",
                column: "marca_id");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_proprietario_id",
                table: "veiculo",
                column: "proprietario_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "veiculo");
        }
    }
}
