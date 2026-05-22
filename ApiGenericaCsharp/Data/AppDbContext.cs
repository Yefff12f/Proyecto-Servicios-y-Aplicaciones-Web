using Microsoft.EntityFrameworkCore;
using ApiProyecto.Models;
using ApiProyecto.Models.investigacion;
using ApiProyecto.Models.Caracterizacion;
using ApiProyecto.Models.conocimiento;
using ApiProyecto.Models.Curricular;
using ApiProyecto.Models.Profesional;
using ApiProyecto.Models.Investigacion;
using ApiProyecto.Models.Proyecto;


namespace ApiProyecto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        //AUTENTICACION
        public DbSet<Usuarios> Usuarios { get; set; }
        
        //INVESTIGACION
        public DbSet<LineaInvestigacion> LineasInvestigacion { get; set; }
        public DbSet<GrupoInvestigacion> GruposInvestigacion { get; set; }
        public DbSet<Semillero> Semilleros { get; set; }
        public DbSet<SemilleroLinea> SemilleroLineas { get; set; }
        public DbSet<ParticipaSemillero> ParticipaSemilleros { get; set; }
        public DbSet<ParticipaGrupo> ParticipaGrupos { get; set; }
        public DbSet<GrupoLinea> GrupoLineas { get; set; }
        public DbSet<AcLinea> AcLineas { get; set; }
        public DbSet<AsLinea> AsLineas { get; set; }
        public DbSet<OdsLinea> OdsLineas { get; set; }
        //CARACTERIZACION
        public DbSet<AreaConocimiento> AreasConocimiento { get; set; }
        public DbSet<AreaAplicacion> AreasAplicacion { get; set; }
         public DbSet<ObjetivoDesarrolloSostenible> ObjetivosDesarrolloSostenible { get; set; }
         //CONOCIMIENTO
        public DbSet<TipoProducto> TipoProductos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<DocenteProducto> DocenteProductos { get; set; }
        public DbSet<PalabrasClave> PalabrasClave { get; set; }
        public DbSet<OdsProyecto> OdsProyectos { get; set; }
        public DbSet<ProyectoLinea> ProyectosLinea { get; set; }
        public DbSet<AcProyecto> AcProyectos { get; set; }
        public DbSet<Desarrolla> Desarrollas { get; set; }
        public DbSet<AliadoProyecto> AliadoProyectos { get; set; }
        public DbSet<AaProyecto> AaProyectos { get; set; }
        public DbSet<TerminoClave> TerminosClave { get; set; }
        //CURRICULAR
        public DbSet<Universidad> Universidades { get; set; }
        public DbSet<Facultad> Facultades { get; set; }
        public DbSet<Programa> Programas { get; set; } 
        public DbSet<Acreditacion> Acreditaciones { get; set; }
        public DbSet<Premio> Premios { get; set; }
         public DbSet<AspectoNormativo> AspectosNormativos { get; set; }
         public DbSet<CarInnovacion> CarInnovaciones { get; set; }
       public DbSet<PracticaEstrategia> PracticasEstrategias { get; set; }
        public DbSet<Enfoque> Enfoques { get; set; }
        public DbSet<Aliado> Aliados { get; set; }
         public DbSet<Pasantia> Pasantias { get; set; }
          public DbSet<RegistroCalificado> RegistrosCalificados { get; set; }

       public DbSet<ActvAcademica> ActvsAcademicas { get; set; }
       public DbSet<Alianza> Alianzas { get; set; }
     public DbSet<DocenteDepartamento> DocentesDepartamentos { get; set; }
     public DbSet<AaRc> AaRcs { get; set; }
     public DbSet<ProgramaCi> ProgramasCi { get; set; }
         public DbSet<AnPrograma> AnProgramas { get; set; }
         public DbSet<ProgramaAc> ProgramasAc { get; set; }
          public DbSet<ProgramaPe> ProgramasPe { get; set; }
          public DbSet<EnfoqueRc> EnfoquesRc { get; set; }
     //PROFESORAL
        public DbSet<Docente> Docentes { get; set; }
                public DbSet<Red> redes { get; set; }
      public DbSet<Reconocimiento> Reconocimientos { get; set; }
       public DbSet<Experiecia> Experecia { get; set; }
       public DbSet<EvaluacionDocente> EvaluacionesDocente { get; set; }
       public DbSet<EstudiosRealizados> EstudiosRealizados { get; set; }
     public DbSet<RedDocente> RedDocentes { get; set; }
      public DbSet<Beca> Becas { get; set; }
      public DbSet<ApoyoProfesoral> ApoyosProfesoral { get; set; }
       public DbSet<EstudioAc> EstudiosAc { get; set; }
      public DbSet<InteresesFuturos> InteresesFuturos { get; set; }




 protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // ── INVESTIGACIÓN (gris) ──
    modelBuilder.Entity<SemilleroLinea>()
        .HasKey(x => new { x.semillero, x.linea_investigacion });

    modelBuilder.Entity<ParticipaGrupo>()
        .HasKey(x => new { x.docente, x.grupo_investigacion });

    modelBuilder.Entity<ParticipaSemillero>()
        .HasKey(x => new { x.docente, x.semillero });

    modelBuilder.Entity<GrupoLinea>()
        .HasKey(x => new { x.grupo_investigacion, x.linea_investigacion });

    modelBuilder.Entity<AcLinea>()
        .HasKey(x => new { x.linea_investigacion, x.area_conocimiento });

    modelBuilder.Entity<AsLinea>()
        .HasKey(x => new { x.linea_investigacion, x.area_aplicacion });

    modelBuilder.Entity<OdsLinea>()
        .HasKey(x => new { x.linea_investigacion, x.ods });

    // ── CONOCIMIENTO / CARACTERIZACIÓN (azul) ──
    // No hay claves compuestas en este módulo

    // ── PROYECTO (verde) ──
    modelBuilder.Entity<AcProyecto>()
        .HasKey(x => new { x.proyecto, x.area_conocimiento });

    modelBuilder.Entity<Desarrolla>()
        .HasKey(x => new { x.docente, x.proyecto });

    modelBuilder.Entity<AliadoProyecto>()
        .HasKey(x => new { x.aliado, x.proyecto });

    modelBuilder.Entity<AaProyecto>()
        .HasKey(x => new { x.proyecto, x.area_aplicacion });

    modelBuilder.Entity<PalabrasClave>()
        .HasKey(x => new { x.proyecto, x.termino_clave });

    modelBuilder.Entity<ProyectoLinea>()
        .HasKey(x => new { x.proyecto, x.linea_investigacion });

    modelBuilder.Entity<OdsProyecto>()
        .HasKey(x => new { x.proyecto, x.ods });

    // ── CURRICULAR (naranja) ──
    modelBuilder.Entity<DocenteDepartamento>()
        .HasKey(x => new { x.docente, x.departamento });

    modelBuilder.Entity<Alianza>()
        .HasKey(x => new { x.aliado, x.departamento });

    modelBuilder.Entity<ProgramaCi>()
        .HasKey(x => new { x.programa, x.car_innovacion });

    modelBuilder.Entity<AnPrograma>()
        .HasKey(x => new { x.aspecto_normativo, x.programa });

    modelBuilder.Entity<ProgramaAc>()
        .HasKey(x => new { x.programa, x.area_conocimiento });

    modelBuilder.Entity<ProgramaPe>()
        .HasKey(x => new { x.programa, x.practica_estrategia });

    modelBuilder.Entity<EnfoqueRc>()
        .HasKey(x => new { x.enfoque, x.registro_calificado });

    modelBuilder.Entity<AaRc>()
        .HasKey(x => new { x.actv_academicas_idcurso, x.registro_calificado_codigo });

    // ── PROFESIONAL (amarillo) ──
    modelBuilder.Entity<RedDocente>()
        .HasKey(x => new { x.red, x.docente });

    modelBuilder.Entity<EstudioAc>()
        .HasKey(x => new { x.estudio, x.area_conocimiento });

    modelBuilder.Entity<InteresesFuturos>()
        .HasKey(x => new { x.docente, x.termino_clave });
}
}
}
