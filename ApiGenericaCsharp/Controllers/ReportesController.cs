using ApiProyecto.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Controllers
{
    [ApiController]
    [Route("api/reportes")]
    [Authorize]
    public class ReportesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReportesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult> Dashboard()
        {
            var resumen = new[]
            {
                new
                {
                    docentes = await _context.Docentes.AsNoTracking().CountAsync(),
                    proyectos = await _context.Proyectos.AsNoTracking().CountAsync(),
                    productos = await _context.Productos.AsNoTracking().CountAsync(),
                    grupos = await _context.GruposInvestigacion.AsNoTracking().CountAsync(),
                    programas = await _context.Programas.AsNoTracking().CountAsync(),
                    registros_calificados = await _context.RegistrosCalificados.AsNoTracking().CountAsync(),
                    redes = await _context.redes.AsNoTracking().CountAsync(),
                    alianzas = await _context.Alianzas.AsNoTracking().CountAsync()
                }
            };

            return Ok(new { datos = resumen });
        }

        [HttpGet("proyectos-docentes-lineas-ods-palabras")]
        public async Task<ActionResult> ProyectosDocentesLineasOdsPalabras()
        {
            var datos = await (
                from p in _context.Proyectos.AsNoTracking()
                join d in _context.Desarrollas.AsNoTracking() on p.id equals d.proyecto
                join doc in _context.Docentes.AsNoTracking() on d.docente equals doc.cedula
                join pl in _context.ProyectosLinea.AsNoTracking() on p.id equals pl.proyecto
                join li in _context.LineasInvestigacion.AsNoTracking() on pl.linea_investigacion equals li.id
                join op in _context.OdsProyectos.AsNoTracking() on p.id equals op.proyecto
                join ods in _context.ObjetivosDesarrolloSostenible.AsNoTracking() on op.ods equals ods.id
                join pk in _context.PalabrasClave.AsNoTracking() on p.id equals pk.proyecto
                join tk in _context.TerminosClave.AsNoTracking() on pk.termino_clave equals tk.termino
                select new
                {
                    proyecto_id = p.id,
                    proyecto = p.nombre,
                    docente = (doc.nombres ?? "") + " " + (doc.apellidos ?? ""),
                    rol_docente = d.rol,
                    linea = li.nombre,
                    ods = ods.nombre,
                    termino = tk.termino,
                    termino_ingles = tk.termino_ingles
                })
                .Take(200)
                .ToListAsync();

            return Ok(new { datos });
        }

        [HttpGet("proyectos-areas-aliados")]
        public async Task<ActionResult> ProyectosAreasAliados()
        {
            var datos = await (
                from p in _context.Proyectos.AsNoTracking()
                join ap in _context.AcProyectos.AsNoTracking() on p.id equals ap.proyecto
                join ac in _context.AreasConocimiento.AsNoTracking() on ap.area_conocimiento equals ac.id
                join aa in _context.AaProyectos.AsNoTracking() on p.id equals aa.proyecto
                join areaAp in _context.AreasAplicacion.AsNoTracking() on aa.area_aplicacion equals areaAp.id
                join aliP in _context.AliadoProyectos.AsNoTracking() on p.id equals aliP.proyecto
                join aliado in _context.Aliados.AsNoTracking() on aliP.aliado equals aliado.id
                select new
                {
                    proyecto_id = p.id,
                    proyecto = p.nombre,
                    gran_area = ac.gran_area,
                    area_conocimiento = ac.area,
                    area_aplicacion = areaAp.nombre,
                    aliado = (aliado.nombre ?? "") + " " + (aliado.apellidos ?? ""),
                    empresa = aliado.empresa
                })
                .Take(200)
                .ToListAsync();

            return Ok(new { datos });
        }

        [HttpGet("productos-docentes-proyectos-tipos")]
        public async Task<ActionResult> ProductosDocentesProyectosTipos()
        {
            var datos = await (
                from prod in _context.Productos.AsNoTracking()
                join dp in _context.DocenteProductos.AsNoTracking() on prod.id equals dp.producto
                join doc in _context.Docentes.AsNoTracking() on dp.docente equals doc.cedula
                join proy in _context.Proyectos.AsNoTracking() on prod.proyecto equals proy.id
                join tipo in _context.TipoProductos.AsNoTracking() on prod.tipo_producto equals tipo.id
                select new
                {
                    producto_id = prod.id,
                    producto = prod.nombre,
                    proyecto = proy.nombre,
                    docente = (doc.nombres ?? "") + " " + (doc.apellidos ?? ""),
                    tipo_producto = tipo.nombre,
                    categoria = tipo.categoria,
                    clase = tipo.clase
                })
                .Take(200)
                .ToListAsync();

            return Ok(new { datos });
        }

        [HttpGet("grupos-docentes-lineas-universidades")]
        public async Task<ActionResult> GruposDocentesLineasUniversidades()
        {
            var datos = await (
                from g in _context.GruposInvestigacion.AsNoTracking()
                join pg in _context.ParticipaGrupos.AsNoTracking() on g.id equals pg.grupo_investigacion
                join doc in _context.Docentes.AsNoTracking() on pg.docente equals doc.cedula
                join gl in _context.GrupoLineas.AsNoTracking() on g.id equals gl.grupo_investigacion
                join li in _context.LineasInvestigacion.AsNoTracking() on gl.linea_investigacion equals li.id
                join uni in _context.Universidades.AsNoTracking() on g.universidad equals uni.id
                select new
                {
                    grupo_id = g.id,
                    grupo = g.nombre,
                    universidad = uni.nombre,
                    linea = li.nombre,
                    docente = (doc.nombres ?? "") + " " + (doc.apellidos ?? ""),
                    categoria_docente = pg.categoria,
                    ambito = g.ambito
                })
                .Take(200)
                .ToListAsync();

            return Ok(new { datos });
        }

        [HttpGet("semilleros-lineas-docentes-universidades")]
        public async Task<ActionResult> SemillerosLineasDocentesUniversidades()
        {
            var datos = await (
                from s in _context.Semilleros.AsNoTracking()
                join sl in _context.SemilleroLineas.AsNoTracking() on s.id equals sl.semillero
                join li in _context.LineasInvestigacion.AsNoTracking() on sl.linea_investigacion equals li.id
                join ps in _context.ParticipaSemilleros.AsNoTracking() on s.id equals ps.semillero
                join doc in _context.Docentes.AsNoTracking() on ps.docente equals doc.cedula
                join uni in _context.Universidades.AsNoTracking() on s.universidad equals uni.id
                select new
                {
                    semillero_id = s.id,
                    semillero = s.nombre,
                    universidad = uni.nombre,
                    linea = li.nombre,
                    docente = (doc.nombres ?? "") + " " + (doc.apellidos ?? ""),
                    rol = ps.rol
                })
                .Take(200)
                .ToListAsync();

            return Ok(new { datos });
        }

        [HttpGet("programas-facultades-universidades-acreditaciones-premios")]
        public async Task<ActionResult> ProgramasFacultadesUniversidadesAcreditacionesPremios()
        {
            var datos = await (
                from p in _context.Programas.AsNoTracking()
                join f in _context.Facultades.AsNoTracking() on p.facultad equals f.id
                join u in _context.Universidades.AsNoTracking() on f.universidad equals u.id
                join a in _context.Acreditaciones.AsNoTracking() on p.id equals a.programa
                join pr in _context.Premios.AsNoTracking() on p.id equals pr.programa
                select new
                {
                    programa_id = p.id,
                    programa = p.nombre,
                    facultad = f.nombre,
                    universidad = u.nombre,
                    acreditacion = a.codigo,
                    premio = pr.nombre,
                    entidad_premio = pr.entidad_otorgante
                })
                .Take(200)
                .ToListAsync();

            return Ok(new { datos });
        }

        [HttpGet("programas-innovacion-aspectos-areas-practicas")]
        public async Task<ActionResult> ProgramasInnovacionAspectosAreasPracticas()
        {
            var datos = await (
                from p in _context.Programas.AsNoTracking()
                join pci in _context.ProgramasCi.AsNoTracking() on p.id equals pci.programa
                join ci in _context.CarInnovaciones.AsNoTracking() on pci.car_innovacion equals ci.id
                join an in _context.AnProgramas.AsNoTracking() on p.id equals an.programa
                join asp in _context.AspectosNormativos.AsNoTracking() on an.aspecto_normativo equals asp.id
                join pac in _context.ProgramasAc.AsNoTracking() on p.id equals pac.programa
                join ac in _context.AreasConocimiento.AsNoTracking() on pac.area_conocimiento equals ac.id
                join ppe in _context.ProgramasPe.AsNoTracking() on p.id equals ppe.programa
                join pe in _context.PracticasEstrategias.AsNoTracking() on ppe.practica_estrategia equals pe.id
                select new
                {
                    programa_id = p.id,
                    programa = p.nombre,
                    car_innovacion = ci.nombre,
                    aspecto_normativo = asp.aspecto_norm_ac,
                    gran_area = ac.gran_area,
                    practica_estrategia = pe.nombre
                })
                .Take(200)
                .ToListAsync();

            return Ok(new { datos });
        }

        [HttpGet("registros-enfoques-actividades-programas")]
        public async Task<ActionResult> RegistrosEnfoquesActividadesProgramas()
        {
            var datos = await (
                from rc in _context.RegistrosCalificados.AsNoTracking()
                join er in _context.EnfoquesRc.AsNoTracking() on rc.id equals er.registro_calificado
                join enf in _context.Enfoques.AsNoTracking() on er.enfoque equals enf.id
                join aar in _context.AaRcs.AsNoTracking() on rc.id equals aar.registro_calificado_codigo
                join aa in _context.ActvsAcademicas.AsNoTracking() on aar.actv_academicas_idcurso equals aa.id
                join p in _context.Programas.AsNoTracking() on rc.programa equals p.id
                select new
                {
                    registro_id = rc.id,
                    programa = p.nombre,
                    enfoque = enf.nombre,
                    actividad_tipo = aa.tipo,
                    area_formacion = aa.area_formacion,
                    componente = aar.componente,
                    semestre = aar.semestre
                })
                .Take(200)
                .ToListAsync();

            return Ok(new { datos });
        }

        [HttpGet("docentes-redes-estudios-areas")]
        public async Task<ActionResult> DocentesRedesEstudiosAreas()
        {
            var datos = await (
                from d in _context.Docentes.AsNoTracking()
                join rd in _context.RedDocentes.AsNoTracking() on d.cedula equals rd.docente
                join r in _context.redes.AsNoTracking() on rd.red equals r.idr
                join e in _context.EstudiosRealizados.AsNoTracking() on d.cedula equals e.docente
                join ea in _context.EstudiosAc.AsNoTracking() on e.id equals ea.estudio
                join ac in _context.AreasConocimiento.AsNoTracking() on ea.area_conocimiento equals ac.id
                select new
                {
                    docente = (d.nombres ?? "") + " " + (d.apellidos ?? ""),
                    cargo = d.cargo,
                    red = r.nombre,
                    estudio = e.titulo,
                    universidad_estudio = e.universidad,
                    gran_area = ac.gran_area,
                    area = ac.area
                })
                .Take(200)
                .ToListAsync();

            return Ok(new { datos });
        }

        [HttpGet("docentes-becas-apoyos-reconocimientos")]
        public async Task<ActionResult> DocentesBecasApoyosReconocimientos()
        {
            var datos = await (
                from d in _context.Docentes.AsNoTracking()
                join e in _context.EstudiosRealizados.AsNoTracking() on d.cedula equals e.docente
                join b in _context.Becas.AsNoTracking() on e.id equals b.estudios
                join ap in _context.ApoyosProfesoral.AsNoTracking() on e.id equals ap.estudios
                join r in _context.Reconocimientos.AsNoTracking() on d.cedula equals r.docente
                select new
                {
                    docente = (d.nombres ?? "") + " " + (d.apellidos ?? ""),
                    estudio = e.titulo,
                    beca = b.tipo,
                    institucion_beca = b.institucion,
                    apoyo = ap.tipo,
                    institucion_apoyo = ap.institucion,
                    reconocimiento = r.nombre,
                    ambito_reconocimiento = r.ambito
                })
                .Take(200)
                .ToListAsync();

            return Ok(new { datos });
        }
    }
}
