using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGenericaCsharp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "grupo_investigacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    url_grupLAC = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    categoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    convocatoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    fecha_fundacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    universidad = table.Column<int>(type: "int", nullable: true),
                    interno = table.Column<bool>(type: "bit", nullable: true),
                    ambito = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_investigacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "linea_investigacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_linea_investigacion", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grupo_investigacion");

            migrationBuilder.DropTable(
                name: "linea_investigacion");
        }
    }
}
