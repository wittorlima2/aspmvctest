using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroVeiculos.Infra.Data.Migrations
{
    public partial class AlterTableProprietarioAddCep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "nb_cep",
                table: "proprietario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nb_cep",
                table: "proprietario");
        }
    }
}
