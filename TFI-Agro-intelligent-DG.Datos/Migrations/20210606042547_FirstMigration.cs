using Microsoft.EntityFrameworkCore.Migrations;

namespace TFIAgrointelligentDG.Datos.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pack",
                columns: table => new
                {
                    PackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pack", x => x.PackId);
                });

            migrationBuilder.CreateTable(
                name: "Sensores",
                columns: table => new
                {
                    SensorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensores", x => x.SensorId);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SensorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServicioId);
                    table.ForeignKey(
                        name: "FK_Servicios_Sensores_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensores",
                        principalColumn: "SensorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackServicios",
                columns: table => new
                {
                    PackServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackServicios", x => x.PackServicioId);
                    table.ForeignKey(
                        name: "FK_PackServicios_Pack_PackId",
                        column: x => x.PackId,
                        principalTable: "Pack",
                        principalColumn: "PackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackServicios_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pack",
                columns: new[] { "PackId", "Descripcion" },
                values: new object[] { 1, "Pack Little" });

            migrationBuilder.InsertData(
                table: "Sensores",
                columns: new[] { "SensorId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Sensor Anti-Helada" },
                    { 2, "Sensor de Riego" },
                    { 3, "Sensor Anti-Plagas" }
                });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "ServicioId", "Descripcion", "SensorId" },
                values: new object[] { 1, "Sistema Anti-Helada", 1 });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "ServicioId", "Descripcion", "SensorId" },
                values: new object[] { 2, "Sistema Único de Riego", 2 });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "ServicioId", "Descripcion", "SensorId" },
                values: new object[] { 3, "Sistema Anti-Plaga", 3 });

            migrationBuilder.InsertData(
                table: "PackServicios",
                columns: new[] { "PackServicioId", "Cantidad", "PackId", "ServicioId" },
                values: new object[] { 2, 40, 1, 2 });

            migrationBuilder.InsertData(
                table: "PackServicios",
                columns: new[] { "PackServicioId", "Cantidad", "PackId", "ServicioId" },
                values: new object[] { 1, 20, 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_PackServicios_PackId",
                table: "PackServicios",
                column: "PackId");

            migrationBuilder.CreateIndex(
                name: "IX_PackServicios_ServicioId",
                table: "PackServicios",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_SensorId",
                table: "Servicios",
                column: "SensorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackServicios");

            migrationBuilder.DropTable(
                name: "Pack");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Sensores");
        }
    }
}
