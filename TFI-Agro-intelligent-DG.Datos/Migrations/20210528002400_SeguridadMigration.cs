using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFIAgrointelligentDG.Datos.Migrations
{
    public partial class SeguridadMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bitacoras",
                columns: table => new
                {
                    BitacoraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FechaHoraAcceso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacoras", x => x.BitacoraId);
                });

            migrationBuilder.CreateTable(
                name: "Familias",
                columns: table => new
                {
                    FamiliaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamiliaPadreId = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familias", x => x.FamiliaId);
                    table.ForeignKey(
                        name: "FK_Familias_Familias_FamiliaPadreId",
                        column: x => x.FamiliaPadreId,
                        principalTable: "Familias",
                        principalColumn: "FamiliaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patentes",
                columns: table => new
                {
                    PatenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patentes", x => x.PatenteId);
                });

            migrationBuilder.CreateTable(
                name: "FamiliaPatentesUsuarios",
                columns: table => new
                {
                    FamiliaPatenteUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamiliaId = table.Column<int>(type: "int", nullable: false),
                    PatenteId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliaPatentesUsuarios", x => x.FamiliaPatenteUsuarioId);
                    table.ForeignKey(
                        name: "FK_FamiliaPatentesUsuarios_Familias_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familias",
                        principalColumn: "FamiliaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamiliaPatentesUsuarios_Patentes_PatenteId",
                        column: x => x.PatenteId,
                        principalTable: "Patentes",
                        principalColumn: "PatenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bitacoras",
                columns: new[] { "BitacoraId", "Detalle", "FechaHoraAcceso", "UserId" },
                values: new object[] { 1, "ACCESO LOGIN", new DateTime(2021, 5, 27, 21, 23, 59, 569, DateTimeKind.Local).AddTicks(4180), 1 });

            migrationBuilder.InsertData(
                table: "Familias",
                columns: new[] { "FamiliaId", "Descripcion", "FamiliaPadreId" },
                values: new object[] { 1, "Rol Administrador", null });

            migrationBuilder.InsertData(
                table: "Patentes",
                columns: new[] { "PatenteId", "Descripcion" },
                values: new object[] { 1, "Acceso Bitacora" });

            migrationBuilder.InsertData(
                table: "FamiliaPatentesUsuarios",
                columns: new[] { "FamiliaPatenteUsuarioId", "FamiliaId", "PatenteId", "UserId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Familias",
                columns: new[] { "FamiliaId", "Descripcion", "FamiliaPadreId" },
                values: new object[] { 2, "Rol Sistemas", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_FamiliaPatentesUsuarios_FamiliaId",
                table: "FamiliaPatentesUsuarios",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_FamiliaPatentesUsuarios_PatenteId",
                table: "FamiliaPatentesUsuarios",
                column: "PatenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Familias_FamiliaPadreId",
                table: "Familias",
                column: "FamiliaPadreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacoras");

            migrationBuilder.DropTable(
                name: "FamiliaPatentesUsuarios");

            migrationBuilder.DropTable(
                name: "Familias");

            migrationBuilder.DropTable(
                name: "Patentes");
        }
    }
}
