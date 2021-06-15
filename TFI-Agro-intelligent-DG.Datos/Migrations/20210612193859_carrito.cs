using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFIAgrointelligentDG.Datos.Migrations.Servicio
{
    public partial class carrito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "PackServicios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.CarritoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackServicios_CarritoId",
                table: "PackServicios",
                column: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackServicios_Carritos_CarritoId",
                table: "PackServicios",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "CarritoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackServicios_Carritos_CarritoId",
                table: "PackServicios");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_PackServicios_CarritoId",
                table: "PackServicios");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "PackServicios");
        }
    }
}
