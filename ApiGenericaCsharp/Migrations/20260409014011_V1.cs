using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiGenericaCsharp.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aa_proyecto",
                columns: table => new
                {
                    proyecto = table.Column<int>(type: "integer", nullable: false),
                    area_aplicacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aa_proyecto", x => new { x.proyecto, x.area_aplicacion });
                });

            migrationBuilder.CreateTable(
                name: "ac_linea",
                columns: table => new
                {
                    linea_investigacion = table.Column<int>(type: "integer", nullable: false),
                    area_conocimiento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ac_linea", x => new { x.linea_investigacion, x.area_conocimiento });
                });

            migrationBuilder.CreateTable(
                name: "ac_proyecto",
                columns: table => new
                {
                    proyecto = table.Column<int>(type: "integer", nullable: false),
                    area_conocimiento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ac_proyecto", x => new { x.proyecto, x.area_conocimiento });
                });

            migrationBuilder.CreateTable(
                name: "acreditacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    resolucion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    tipo_situacion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    tipo_titulacion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    hora_accion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    fecha_ini = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    programa = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acreditacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "actv_academica",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    num_creditos = table.Column<int>(type: "integer", nullable: true),
                    tipo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    area_formacion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    idioma = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    h_acomp = table.Column<int>(type: "integer", nullable: true),
                    h_indep = table.Column<int>(type: "integer", nullable: true),
                    diploma = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    entidad_Espejo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    pais_apoyo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    dinero = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actv_academica", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aliado",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    apellidos = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    empresa = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    descripcion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    correo = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    contacto = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    ciudad = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aliado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aliado_proyecto",
                columns: table => new
                {
                    aliado = table.Column<int>(type: "integer", nullable: false),
                    proyecto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aliado_proyecto", x => new { x.aliado, x.proyecto });
                });

            migrationBuilder.CreateTable(
                name: "alianza",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    departamento = table.Column<int>(type: "integer", nullable: true),
                    aliado = table.Column<int>(type: "integer", nullable: true),
                    docente = table.Column<int>(type: "integer", nullable: true),
                    fecha_ini = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alianza", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "area_aplicacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    descripcion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area_aplicacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "area_conocimiento",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gran_area = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    area = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    disciplina = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area_conocimiento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "as_linea",
                columns: table => new
                {
                    linea_investigacion = table.Column<int>(type: "integer", nullable: false),
                    area_aplicacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_as_linea", x => new { x.linea_investigacion, x.area_aplicacion });
                });

            migrationBuilder.CreateTable(
                name: "aspecto_normativo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    aspecto_norm_ac = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    descripcion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspecto_normativo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "car_innovacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    longtext = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_innovacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "desarrolla",
                columns: table => new
                {
                    docente = table.Column<int>(type: "integer", nullable: false),
                    proyecto = table.Column<int>(type: "integer", nullable: false),
                    rol = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    descripcion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desarrolla", x => new { x.docente, x.proyecto });
                });

            migrationBuilder.CreateTable(
                name: "docente_departamento",
                columns: table => new
                {
                    docente = table.Column<int>(type: "integer", nullable: false),
                    departamento = table.Column<int>(type: "integer", nullable: false),
                    dedicacion = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    modalidad = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    fecha_ingreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_salida = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docente_departamento", x => new { x.docente, x.departamento });
                });

            migrationBuilder.CreateTable(
                name: "docente_producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    docente = table.Column<int>(type: "integer", nullable: true),
                    producto = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docente_producto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enfoque",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    descripcion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enfoque", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "facultad",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    universidad = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facultad", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grupo_investigacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    url_grupLAC = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    categoria = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    convocatoria = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    fecha_fundacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    universidad = table.Column<int>(type: "integer", nullable: true),
                    interno = table.Column<bool>(type: "boolean", nullable: true),
                    ambito = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_investigacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grupo_linea",
                columns: table => new
                {
                    grupo_investigacion = table.Column<int>(type: "integer", nullable: false),
                    linea_investigacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_linea", x => new { x.grupo_investigacion, x.linea_investigacion });
                });

            migrationBuilder.CreateTable(
                name: "linea_investigacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_linea_investigacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "objetivos_desarrollo_sostenible",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    descripcion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objetivos_desarrollo_sostenible", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "palabras_clave",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    palabra = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_palabras_clave", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "participa_grupo",
                columns: table => new
                {
                    docente = table.Column<int>(type: "integer", nullable: false),
                    grupo_investigacion = table.Column<int>(type: "integer", nullable: false),
                    categoria = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    convocatoria = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    fecha_ini = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participa_grupo", x => new { x.docente, x.grupo_investigacion });
                });

            migrationBuilder.CreateTable(
                name: "participa_semillero",
                columns: table => new
                {
                    docente = table.Column<int>(type: "integer", nullable: false),
                    semillero = table.Column<int>(type: "integer", nullable: false),
                    rol = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    fecha_ini = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participa_semillero", x => new { x.docente, x.semillero });
                });

            migrationBuilder.CreateTable(
                name: "pasantia",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    pais = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    empresa = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    descripcion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    programa = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pasantia", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "practica_estrategia",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    descripcion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_practica_estrategia", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "premio",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    descripcion = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    entidad_otorgante = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    valor = table.Column<double>(type: "double precision", nullable: true),
                    pais = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    tipo_producto = table.Column<int>(type: "integer", nullable: true),
                    proyecto = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "programa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    tipo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    num_creditos = table.Column<int>(type: "integer", nullable: true),
                    cant_semestres = table.Column<int>(type: "integer", nullable: true),
                    fecha_actualizacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    pais = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    ciudad = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    facultad = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "proyecto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    fecha_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyecto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "proyecto_linea",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    proyecto = table.Column<int>(type: "integer", nullable: true),
                    linea = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyecto_linea", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "registro_calificado",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cant_preg = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    calif_preg = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    h_actv_academica = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    programa = table.Column<int>(type: "integer", nullable: true),
                    fecha_ini = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    duracion_anios = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    docente_semestres = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    metodologia = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    tipo_titulacion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registro_calificado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "semillero",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    fecha_fundacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    universidad = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_semillero", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "semillero_linea",
                columns: table => new
                {
                    semillero = table.Column<int>(type: "integer", nullable: false),
                    linea_investigacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_semillero_linea", x => new { x.semillero, x.linea_investigacion });
                });

            migrationBuilder.CreateTable(
                name: "termino_clave",
                columns: table => new
                {
                    termino = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    termino_ingles = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_termino_clave", x => x.termino);
                });

            migrationBuilder.CreateTable(
                name: "tipo_producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoria = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    clase = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    nombre = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    tipologia = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_producto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "universidad",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    tipo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    ciudad = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_universidad", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aa_proyecto");

            migrationBuilder.DropTable(
                name: "ac_linea");

            migrationBuilder.DropTable(
                name: "ac_proyecto");

            migrationBuilder.DropTable(
                name: "acreditacion");

            migrationBuilder.DropTable(
                name: "actv_academica");

            migrationBuilder.DropTable(
                name: "aliado");

            migrationBuilder.DropTable(
                name: "aliado_proyecto");

            migrationBuilder.DropTable(
                name: "alianza");

            migrationBuilder.DropTable(
                name: "area_aplicacion");

            migrationBuilder.DropTable(
                name: "area_conocimiento");

            migrationBuilder.DropTable(
                name: "as_linea");

            migrationBuilder.DropTable(
                name: "aspecto_normativo");

            migrationBuilder.DropTable(
                name: "car_innovacion");

            migrationBuilder.DropTable(
                name: "desarrolla");

            migrationBuilder.DropTable(
                name: "docente_departamento");

            migrationBuilder.DropTable(
                name: "docente_producto");

            migrationBuilder.DropTable(
                name: "enfoque");

            migrationBuilder.DropTable(
                name: "facultad");

            migrationBuilder.DropTable(
                name: "grupo_investigacion");

            migrationBuilder.DropTable(
                name: "grupo_linea");

            migrationBuilder.DropTable(
                name: "linea_investigacion");

            migrationBuilder.DropTable(
                name: "objetivos_desarrollo_sostenible");

            migrationBuilder.DropTable(
                name: "ods");

            migrationBuilder.DropTable(
                name: "palabras_clave");

            migrationBuilder.DropTable(
                name: "participa_grupo");

            migrationBuilder.DropTable(
                name: "participa_semillero");

            migrationBuilder.DropTable(
                name: "pasantia");

            migrationBuilder.DropTable(
                name: "practica_estrategia");

            migrationBuilder.DropTable(
                name: "premio");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "programa");

            migrationBuilder.DropTable(
                name: "proyecto");

            migrationBuilder.DropTable(
                name: "proyecto_linea");

            migrationBuilder.DropTable(
                name: "registro_calificado");

            migrationBuilder.DropTable(
                name: "semillero");

            migrationBuilder.DropTable(
                name: "semillero_linea");

            migrationBuilder.DropTable(
                name: "termino_clave");

            migrationBuilder.DropTable(
                name: "tipo_producto");

            migrationBuilder.DropTable(
                name: "universidad");
        }
    }
}
