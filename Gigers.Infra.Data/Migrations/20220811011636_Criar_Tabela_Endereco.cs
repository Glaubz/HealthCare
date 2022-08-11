using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gigers.Infra.Data.Migrations
{
    public partial class Criar_Tabela_Endereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco_Bairro",
                table: "Giger");

            migrationBuilder.DropColumn(
                name: "Endereco_CEP",
                table: "Giger");

            migrationBuilder.DropColumn(
                name: "Endereco_Cidade",
                table: "Giger");

            migrationBuilder.DropColumn(
                name: "Endereco_Numero",
                table: "Giger");

            migrationBuilder.DropColumn(
                name: "Endereco_Rua",
                table: "Giger");

            migrationBuilder.DropColumn(
                name: "Endereco_Bairro",
                table: "Gig");

            migrationBuilder.DropColumn(
                name: "Endereco_CEP",
                table: "Gig");

            migrationBuilder.DropColumn(
                name: "Endereco_Cidade",
                table: "Gig");

            migrationBuilder.DropColumn(
                name: "Endereco_Numero",
                table: "Gig");

            migrationBuilder.DropColumn(
                name: "Endereco_Rua",
                table: "Gig");

            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "Giger",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "Gig",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Giger_EnderecoId",
                table: "Giger",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Gig_EnderecoId",
                table: "Gig",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gig_Endereco_EnderecoId",
                table: "Gig",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Giger_Endereco_EnderecoId",
                table: "Giger",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gig_Endereco_EnderecoId",
                table: "Gig");

            migrationBuilder.DropForeignKey(
                name: "FK_Giger_Endereco_EnderecoId",
                table: "Giger");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Giger_EnderecoId",
                table: "Giger");

            migrationBuilder.DropIndex(
                name: "IX_Gig_EnderecoId",
                table: "Gig");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Giger");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Gig");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Bairro",
                table: "Giger",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_CEP",
                table: "Giger",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Cidade",
                table: "Giger",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Endereco_Numero",
                table: "Giger",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Rua",
                table: "Giger",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Bairro",
                table: "Gig",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_CEP",
                table: "Gig",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Cidade",
                table: "Gig",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Endereco_Numero",
                table: "Gig",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Rua",
                table: "Gig",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
