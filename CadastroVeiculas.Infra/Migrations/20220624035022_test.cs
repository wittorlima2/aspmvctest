using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroVeiculos.Infra.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_veiculo_marca_marca_id",
                table: "veiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_veiculo_proprietario_proprietario_id",
                table: "veiculo");

            migrationBuilder.DropIndex(
                name: "IX_veiculo_marca_id",
                table: "veiculo");

            migrationBuilder.DropIndex(
                name: "IX_veiculo_proprietario_id",
                table: "veiculo");

            migrationBuilder.DropColumn(
                name: "marca_id",
                table: "veiculo");

            migrationBuilder.DropColumn(
                name: "proprietario_id",
                table: "veiculo");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_MarcaId",
                table: "veiculo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_ProprietarioId",
                table: "veiculo",
                column: "ProprietarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_veiculo_marca_MarcaId",
                table: "veiculo",
                column: "MarcaId",
                principalTable: "marca",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_veiculo_proprietario_ProprietarioId",
                table: "veiculo",
                column: "ProprietarioId",
                principalTable: "proprietario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_veiculo_marca_MarcaId",
                table: "veiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_veiculo_proprietario_ProprietarioId",
                table: "veiculo");

            migrationBuilder.DropIndex(
                name: "IX_veiculo_MarcaId",
                table: "veiculo");

            migrationBuilder.DropIndex(
                name: "IX_veiculo_ProprietarioId",
                table: "veiculo");

            migrationBuilder.AddColumn<Guid>(
                name: "marca_id",
                table: "veiculo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "proprietario_id",
                table: "veiculo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_marca_id",
                table: "veiculo",
                column: "marca_id");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_proprietario_id",
                table: "veiculo",
                column: "proprietario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_veiculo_marca_marca_id",
                table: "veiculo",
                column: "marca_id",
                principalTable: "marca",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_veiculo_proprietario_proprietario_id",
                table: "veiculo",
                column: "proprietario_id",
                principalTable: "proprietario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
