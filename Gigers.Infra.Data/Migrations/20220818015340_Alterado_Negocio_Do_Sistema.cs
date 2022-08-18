using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare.Infra.Data.Migrations
{
    public partial class Alterado_Negocio_Do_Sistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Giger");

            migrationBuilder.DropTable(
                name: "Gig");

            migrationBuilder.CreateTable(
                name: "Academia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Academia_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    CPF = table.Column<string>(type: "CHAR(11)", fixedLength: true, maxLength: 11, nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AcademiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Academia_AcademiaId",
                        column: x => x.AcademiaId,
                        principalTable: "Academia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Academia_EnderecoId",
                table: "Academia",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_AcademiaId",
                table: "Usuario",
                column: "AcademiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Academia");

            migrationBuilder.CreateTable(
                name: "Gig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Titulo = table.Column<string>(type: "VARCHAR(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gig_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Giger",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPF = table.Column<string>(type: "CHAR(11)", fixedLength: true, maxLength: 11, nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GigId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nome = table.Column<string>(type: "VARCHAR(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Giger_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Giger_Gig_GigId",
                        column: x => x.GigId,
                        principalTable: "Gig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gig_EnderecoId",
                table: "Gig",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Giger_EnderecoId",
                table: "Giger",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Giger_GigId",
                table: "Giger",
                column: "GigId");
        }
    }
}
