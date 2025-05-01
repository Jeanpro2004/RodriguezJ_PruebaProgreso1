using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RodriguezJ_PruebaProgreso1.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuenoMascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoDisponible = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TieneMembresia = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuenoMascota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    PesoKg = table.Column<double>(type: "float", nullable: false),
                    DuenoMascotaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascota_DuenoMascota_DuenoMascotaId",
                        column: x => x.DuenoMascotaId,
                        principalTable: "DuenoMascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitaVeterinaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarifa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequiereMedicacion = table.Column<bool>(type: "bit", nullable: false),
                    MascotaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitaVeterinaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitaVeterinaria_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_DuenoMascotaId",
                table: "Mascota",
                column: "DuenoMascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitaVeterinaria_MascotaId",
                table: "VisitaVeterinaria",
                column: "MascotaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitaVeterinaria");

            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "DuenoMascota");
        }
    }
}
