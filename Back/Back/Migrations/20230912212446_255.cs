﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    public partial class _255 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quimicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAS = table.Column<int>(type: "int", nullable: false),
                    NumeroOnu = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Combustion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnteIncendio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrevencionIncendio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeligrosFisicos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeligrosQuimicos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnteDerramesyFugas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LimitesdeExposicionLaboral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimerosAuxilios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClasedePeligroONU = table.Column<int>(type: "int", nullable: false),
                    InformacionFisicoQuimica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Almacenamiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aspecto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quimicos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quimicos");
        }
    }
}
