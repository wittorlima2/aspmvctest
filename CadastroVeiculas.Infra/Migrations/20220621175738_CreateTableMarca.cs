using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroVeiculos.Infra.Data.Migrations
{
    public partial class CreateTableMarca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tx_nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nb_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "marca");
        }
    }
}
