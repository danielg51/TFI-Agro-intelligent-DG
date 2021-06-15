using Microsoft.EntityFrameworkCore.Migrations;

namespace TFIAgrointelligentDG.Datos.Migrations.Servicio
{
    public partial class carrito2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackServicios_Carritos_CarritoId",
                table: "PackServicios");

            migrationBuilder.DropIndex(
                name: "IX_PackServicios_CarritoId",
                table: "PackServicios");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "PackServicios");

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Pack",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CarritoDetalles",
                columns: table => new
                {
                    CarritoDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackId = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CarritoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoDetalles", x => x.CarritoDetalleId);
                    table.ForeignKey(
                        name: "FK_CarritoDetalles_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarritoDetalles_Pack_PackId",
                        column: x => x.PackId,
                        principalTable: "Pack",
                        principalColumn: "PackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoDetalles_CarritoId",
                table: "CarritoDetalles",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoDetalles_PackId",
                table: "CarritoDetalles",
                column: "PackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoDetalles");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Pack");

            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "PackServicios",
                type: "int",
                nullable: true);

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
    }
}
