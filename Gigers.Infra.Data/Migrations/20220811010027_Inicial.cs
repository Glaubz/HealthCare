using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gigers.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    Endereco_Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Numero = table.Column<int>(type: "int", nullable: true),
                    Endereco_CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Giger",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    CPF = table.Column<string>(type: "CHAR(11)", fixedLength: true, maxLength: 11, nullable: false),
                    Endereco_Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Numero = table.Column<int>(type: "int", nullable: true),
                    Endereco_CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GigId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Giger_Gig_GigId",
                        column: x => x.GigId,
                        principalTable: "Gig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Giger_GigId",
                table: "Giger",
                column: "GigId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Giger");

            migrationBuilder.DropTable(
                name: "Gig");
        }
    }
}
