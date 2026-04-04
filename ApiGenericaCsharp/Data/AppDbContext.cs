using Microsoft.EntityFrameworkCore;
using ApiProyecto.Models.investigacion;
using ApiProyecto.Models.Caracterizacion;
using ApiProyecto.Models.conocimiento;
using ApiProyecto.Models.Curricular;
namespace ApiProyecto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
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
        //CARACTERIZACION
        public DbSet<AreaConocimiento> AreasConocimiento { get; set; }
        public DbSet<AreaAplicacion> AreasAplicacion { get; set; }
         public DbSet<ObjetivoDesarrolloSostenible> ObjetivosDesarrolloSostenible { get; set; }
         //CONOCIMIENTO
        public DbSet<TipoProducto> TipoProductos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<DocenteProducto> DocenteProductos { get; set; }
        public DbSet<PalabraClave> PalabrasClave { get; set; }
        public DbSet<Ods> Ods { get; set; }
        public DbSet<ProyectoLinea> ProyectoLineas { get; set; }
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














    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<SemilleroLinea>()
        .HasKey(x => new { x.semillero, x.linea_investigacion });

    modelBuilder.Entity<ParticipaGrupo>()
        .HasKey(x => new { x.docente, x.grupo_investigacion });

    modelBuilder.Entity<GrupoLinea>()
        .HasKey(x => new { x.grupo_investigacion, x.linea_investigacion });

    // Si ya tienes ParticipaS emillero:
    modelBuilder.Entity<ParticipaSemillero>()
        .HasKey(x => new { x.docente, x.semillero });

        modelBuilder.Entity<AcLinea>()
        .HasKey(x => new { x.linea_investigacion, x.area_conocimiento });

    modelBuilder.Entity<AsLinea>()
        .HasKey(x => new { x.linea_investigacion, x.area_aplicacion });

    modelBuilder.Entity<AcProyecto>().HasKey(x => new { x.proyecto, x.area_conocimiento });
    modelBuilder.Entity<Desarrolla>().HasKey(x => new { x.docente, x.proyecto });
    modelBuilder.Entity<AliadoProyecto>().HasKey(x => new { x.aliado, x.proyecto });
    modelBuilder.Entity<AaProyecto>().HasKey(x => new { x.proyecto, x.area_aplicacion });
    modelBuilder.Entity<DocenteDepartamento>().HasKey(x => new { x.docente, x.departamento });



}
}
}