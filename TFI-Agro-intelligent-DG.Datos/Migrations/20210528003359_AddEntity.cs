using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFIAgrointelligentDG.Datos.Migrations.Seguridad
{
    public partial class AddEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bitacoras",
                keyColumn: "BitacoraId",
                keyValue: 1,
                column: "FechaHoraAcceso",
                value: new DateTime(2021, 5, 27, 21, 33, 59, 383, DateTimeKind.Local).AddTicks(7513));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bitacoras",
                keyColumn: "BitacoraId",
                keyValue: 1,
                column: "FechaHoraAcceso",
                value: new DateTime(2021, 5, 27, 21, 23, 59, 569, DateTimeKind.Local).AddTicks(4180));
        }
    }
}
