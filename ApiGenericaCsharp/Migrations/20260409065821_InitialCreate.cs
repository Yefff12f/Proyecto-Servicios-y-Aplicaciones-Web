using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiGenericaCsharp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_proyecto_linea",
                table: "proyecto_linea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_palabras_clave",
                table: "palabras_clave");

            migrationBuilder.DropPrimaryKey(
                name: "PK_docente_producto",
                table: "docente_producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_alianza",
                table: "alianza");

            migrationBuilder.DropColumn(
                name: "linea",
                table: "proyecto_linea");

            migrationBuilder.DropColumn(
                name: "palabra",
                table: "palabras_clave");

            migrationBuilder.DropColumn(
                name: "id",
                table: "alianza");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "proyecto_linea",
                newName: "linea_investigacion");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "palabras_clave",
                newName: "proyecto");

            migrationBuilder.RenameColumn(
                name: "fecha_ini",
                table: "alianza",
                newName: "fecha_inicio");

            migrationBuilder.AlterColumn<int>(
                name: "proyecto",
                table: "proyecto_linea",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "linea_investigacion",
                table: "proyecto_linea",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "proyecto",
                table: "palabras_clave",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "termino_clave",
                table: "palabras_clave",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "producto",
                table: "docente_producto",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "docente",
                table: "docente_producto",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "departamento",
                table: "alianza",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "aliado",
                table: "alianza",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_proyecto_linea",
                table: "proyecto_linea",
                columns: new[] { "proyecto", "linea_investigacion" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_palabras_clave",
                table: "palabras_clave",
                columns: new[] { "proyecto", "termino_clave" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_docente_producto",
                table: "docente_producto",
                columns: new[] { "docente", "producto" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_alianza",
                table: "alianza",
                columns: new[] { "aliado", "departamento" });

            migrationBuilder.CreateTable(
                name: "aa_rc",
                columns: table => new
                {
                    actv_academicas_idcurso = table.Column<int>(type: "integer", nullable: false),
                    registro_calificado_codigo = table.Column<int>(type: "integer", nullable: false),
                    componente = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    semestre = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aa_rc", x => new { x.actv_academicas_idcurso, x.registro_calificado_codigo });
                });

            migrationBuilder.CreateTable(
                name: "an_programa",
                columns: table => new
                {
                    aspecto_normativo = table.Column<int>(type: "integer", nullable: false),
                    programa = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_an_programa", x => new { x.aspecto_normativo, x.programa });
                });

            migrationBuilder.CreateTable(
                name: "apoyo_profesoral",
                columns: table => new
                {
                    estudios = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    con_apoyo = table.Column<bool>(type: "boolean", nullable: true),
                    institucion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    tipo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apoyo_profesoral", x => x.estudios);
                });

            migrationBuilder.CreateTable(
                name: "beca",
                columns: table => new
                {
                    estudios = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    institucion = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    fecha_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    pais = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beca", x => x.estudios);
                });

            migrationBuilder.CreateTable(
                name: "docente",
                columns: table => new
                {
                    cedula = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombres = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    apellidos = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    genero = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    cargo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    fecha_nacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    correo = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    telefono = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    url_cvlac = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    fecha_actualizacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    escalafon = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    perfil = table.Column<string>(type: "text", nullable: true),
                    cat_minciencia = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    conv_minciencia = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    nacionalidad = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    linea_investigacion_principal = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docente", x => x.cedula);
                });

            migrationBuilder.CreateTable(
                name: "enfoque_rc",
                columns: table => new
                {
                    enfoque = table.Column<int>(type: "integer", nullable: false),
                    registro_calificado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enfoque_rc", x => new { x.enfoque, x.registro_calificado });
                });

            migrationBuilder.CreateTable(
                name: "estudio_ac",
                columns: table => new
                {
                    estudio = table.Column<int>(type: "integer", nullable: false),
                    area_conocimiento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudio_ac", x => new { x.estudio, x.area_conocimiento });
                });

            migrationBuilder.CreateTable(
                name: "estudios_realizados",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titulo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    universidad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    tipo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    ciudad = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    docente = table.Column<int>(type: "integer", nullable: true),
                    ins_acreditada = table.Column<bool>(type: "boolean", nullable: true),
                    metodologia = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    perfil_egresado = table.Column<string>(type: "text", nullable: true),
                    pais = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudios_realizados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "evaluacion_docente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    calificacion = table.Column<float>(type: "real", nullable: true),
                    semestre = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    docente = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evaluacion_docente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "experiecia",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_cargo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    institucion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    nombre = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    tipo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    fecha_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    docente = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experiecia", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "intereses_futuros",
                columns: table => new
                {
                    docente = table.Column<int>(type: "integer", nullable: false),
                    termino_clave = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intereses_futuros", x => new { x.docente, x.termino_clave });
                });

            migrationBuilder.CreateTable(
                name: "ods_linea",
                columns: table => new
                {
                    linea_investigacion = table.Column<int>(type: "integer", nullable: false),
                    ods = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ods_linea", x => new { x.linea_investigacion, x.ods });
                });

            migrationBuilder.CreateTable(
                name: "ods_proyecto",
                columns: table => new
                {
                    proyecto = table.Column<int>(type: "integer", nullable: false),
                    ods = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ods_proyecto", x => new { x.proyecto, x.ods });
                });

            migrationBuilder.CreateTable(
                name: "programa_ac",
                columns: table => new
                {
                    programa = table.Column<int>(type: "integer", nullable: false),
                    area_conocimiento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programa_ac", x => new { x.programa, x.area_conocimiento });
                });

            migrationBuilder.CreateTable(
                name: "programa_ci",
                columns: table => new
                {
                    programa = table.Column<int>(type: "integer", nullable: false),
                    car_innovacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programa_ci", x => new { x.programa, x.car_innovacion });
                });

            migrationBuilder.CreateTable(
                name: "programa_pe",
                columns: table => new
                {
                    programa = table.Column<int>(type: "integer", nullable: false),
                    practica_estrategia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programa_pe", x => new { x.programa, x.practica_estrategia });
                });

            migrationBuilder.CreateTable(
                name: "reconocimiento",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    institucion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    nombre = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    ambito = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    docente = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reconocimiento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "red",
                columns: table => new
                {
                    idr = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    uri = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    pas = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_red", x => x.idr);
                });

            migrationBuilder.CreateTable(
                name: "red_docente",
                columns: table => new
                {
                    red = table.Column<int>(type: "integer", nullable: false),
                    docente = table.Column<int>(type: "integer", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    act_destacadas = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_red_docente", x => new { x.red, x.docente });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aa_rc");

            migrationBuilder.DropTable(
                name: "an_programa");

            migrationBuilder.DropTable(
                name: "apoyo_profesoral");

            migrationBuilder.DropTable(
                name: "beca");

            migrationBuilder.DropTable(
                name: "docente");

            migrationBuilder.DropTable(
                name: "enfoque_rc");

            migrationBuilder.DropTable(
                name: "estudio_ac");

            migrationBuilder.DropTable(
                name: "estudios_realizados");

            migrationBuilder.DropTable(
                name: "evaluacion_docente");

            migrationBuilder.DropTable(
                name: "experiecia");

            migrationBuilder.DropTable(
                name: "intereses_futuros");

            migrationBuilder.DropTable(
                name: "ods_linea");

            migrationBuilder.DropTable(
                name: "ods_proyecto");

            migrationBuilder.DropTable(
                name: "programa_ac");

            migrationBuilder.DropTable(
                name: "programa_ci");

            migrationBuilder.DropTable(
                name: "programa_pe");

            migrationBuilder.DropTable(
                name: "reconocimiento");

            migrationBuilder.DropTable(
                name: "red");

            migrationBuilder.DropTable(
                name: "red_docente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_proyecto_linea",
                table: "proyecto_linea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_palabras_clave",
                table: "palabras_clave");

            migrationBuilder.DropPrimaryKey(
                name: "PK_docente_producto",
                table: "docente_producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_alianza",
                table: "alianza");

            migrationBuilder.DropColumn(
                name: "termino_clave",
                table: "palabras_clave");

            migrationBuilder.RenameColumn(
                name: "linea_investigacion",
                table: "proyecto_linea",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "proyecto",
                table: "palabras_clave",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "fecha_inicio",
                table: "alianza",
                newName: "fecha_ini");

            migrationBuilder.AlterColumn<int>(
                name: "proyecto",
                table: "proyecto_linea",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "proyecto_linea",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<int>(
                name: "linea",
                table: "proyecto_linea",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "palabras_clave",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<string>(
                name: "palabra",
                table: "palabras_clave",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "producto",
                table: "docente_producto",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "docente",
                table: "docente_producto",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "departamento",
                table: "alianza",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "aliado",
                table: "alianza",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "alianza",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_proyecto_linea",
                table: "proyecto_linea",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_palabras_clave",
                table: "palabras_clave",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_docente_producto",
                table: "docente_producto",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_alianza",
                table: "alianza",
                column: "id");

            migrationBuilder.CreateTable(
                name: "ods",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ods", x => x.id);
                });
        }
    }
}
