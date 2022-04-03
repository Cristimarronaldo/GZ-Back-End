using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gazin.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "DesenvolvedorSequencia");

            migrationBuilder.CreateSequence<int>(
                name: "NiveisSequencia");

            migrationBuilder.CreateTable(
                name: "Niveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR NiveisSequencia"),
                    Nivel = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desenvolvedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR DesenvolvedorSequencia"),
                    NivelId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Sexo = table.Column<string>(type: "char(1)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Hobby = table.Column<string>(type: "Varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desenvolvedores_Niveis_NivelId",
                        column: x => x.NivelId,
                        principalTable: "Niveis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desenvolvedores_NivelId",
                table: "Desenvolvedores",
                column: "NivelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desenvolvedores");

            migrationBuilder.DropTable(
                name: "Niveis");

            migrationBuilder.DropSequence(
                name: "DesenvolvedorSequencia");

            migrationBuilder.DropSequence(
                name: "NiveisSequencia");
        }
    }
}
