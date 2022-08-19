using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCare.Infra.Data.Migrations
{
    public partial class Seed_Usuario_Adm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "AcademiaId", "CPF", "EnderecoId", "Nome" },
                values: new object[] { new Guid("c1f75045-3c5d-40bc-9443-f6b0cf65016c"), null, "45894916054", null, "Administrador" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: new Guid("c1f75045-3c5d-40bc-9443-f6b0cf65016c"));
        }
    }
}
