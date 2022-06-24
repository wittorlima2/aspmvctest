using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroVeiculos.Infra.Data.Migrations
{
    public partial class CreateTableProprietario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "proprietario",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tx_nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nb_status = table.Column<int>(type: "int", nullable: false),
                    tx_documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tx_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tx_endereco = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proprietario", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "proprietario");
        }
    }
}
