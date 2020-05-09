using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;

namespace SGCFIEE.Controllers
{
    public class EstudiantesMovilidadController : Controller
    {
        // GET: EstudiantesMovilidad
        [Authorize]
        public ActionResult Index(CtMovilidades movi)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var movilidades = context.CtMovilidades.Where(s => s.TipoMovilidades.Equals(movi.TipoMovilidades)).ToList();
                ViewData["Movilidades"] = movilidades;
            }
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }


        [Authorize]
        public IActionResult EleccionMovilidades()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }


        // GET: EstudiantesMovilidad/Edit/5
        [Authorize]
        public IActionResult Editar(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            CtMovilidades datosMovi;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                datosMovi = context.CtMovilidades.Where(d => d.IdCtMovilidades == id).Single();
            }
            return View(datosMovi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarEdicion(CtMovilidades movilidades)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtMovilidades.Update(movilidades);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        // GET: EstudiantesMovilidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        public IActionResult FormInscribir(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var y = context.ProgramaEducativo.ToList();
                ViewData["clv"] = id;
                ViewData["Programas"] = y;
            }
            return View();
        }

        [Authorize]
        public IActionResult MostrarListaAlumnos(FormInscribirMovilidad movi)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int x = movi.idMovilidad;
            int progra = movi.idAlumno;
            List<TablaAlumno> tb = new List<TablaAlumno>();
            List<ProgramaEducativo> y = new List<ProgramaEducativo>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                tb = (from d in context.DatosPersonales
                      join a in context.Alumnos on d.IdDatosPersonales equals a.RDatosPerson
                      join p in context.ProgramaEducativo on a.RProgramaEducativo equals p.IdProgramaEducativo
                      select
                      new TablaAlumno
                      {
                          id = a.IdAlumnos,
                          Nombre = d.Nombre,
                          ApellidoPaterno = d.ApellidoPaterno,
                          ApellidoMaterno = d.ApellidoMaterno,
                          Matricula = a.Matricula,
                          NombrePro = p.Nombre
                      }).ToList();
                y = context.ProgramaEducativo.ToList();
                ViewData["clv"] = x;
                ViewData["Programas"] = y;
            }
            String nombrePe = "";
            foreach (ProgramaEducativo pe in y)
            {
                if (progra == pe.IdProgramaEducativo)
                {
                    nombrePe = pe.Nombre;
                }
            }
            List<TablaAlumno> correcto = new List<TablaAlumno>();
            foreach (TablaAlumno t in tb)
            {
                if (t.NombrePro.Equals(nombrePe))
                {
                    correcto.Add(t);
                }
            }
            ViewData["Alumnos"] = correcto;
            return View();
        }

        [Authorize]
        public IActionResult MostrarInformacionInscripcion(FormInscribirMovilidad movi)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int movilidad = movi.idMovilidad;
            int alumno = movi.idAlumno;
            DatosPersonales dp;
            CtMovilidades mov;
            Alumnos alu;
            FormInscribirMovilidad formulario = new FormInscribirMovilidad();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                dp = context.DatosPersonales.Where(s => s.IdDatosPersonales == alumno).SingleOrDefault();
                mov = context.CtMovilidades.Where(m => m.IdCtMovilidades == movilidad).SingleOrDefault();
                alu = context.Alumnos.Where(a => a.IdAlumnos == alumno).SingleOrDefault();
                var periodo = context.TipoPeriodo.ToList();
                ViewData["periodo"] = periodo;
            }
            formulario.NombreAlumno = dp.Nombre + " " + dp.ApellidoPaterno + " " + dp.ApellidoMaterno;
            formulario.idAlumno = alumno;
            formulario.idMovilidad = movilidad;
            ViewData["dtMovi"] = mov;
            ViewData["dtPAlu"] = dp;
            ViewData["dtEAlu"] = alu;
            ViewData["dt"] = formulario;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarInscripcion(FormInscribirMovilidad formovi)
        {
            TbMovilidad tb = new TbMovilidad();
            tb.RAlumno = formovi.idAlumno;
            tb.RMovilidad = formovi.idMovilidad;
            tb.RPeriodo = formovi.idPeriodo;
            List<TbMovilidad> datosmovilidad = new List<TbMovilidad>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                datosmovilidad = context.TbMovilidad.ToList();
                foreach (TbMovilidad item in datosmovilidad)
                {
                    if (item.RAlumno == formovi.idAlumno && item.RMovilidad == formovi.idMovilidad && item.RPeriodo==formovi.idPeriodo)
                    {
                        return RedirectToAction("Index");
                    }
                }
                context.TbMovilidad.Add(tb);
                context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult ConsultarEstatus()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<Calificaciones_Alumno_Movilidad> cam;
            int idAlumno = (int)HttpContext.Session.GetInt32("IdUsu");
            //int idAlumno = 1;
            ProgramaEducativo pe;
            Alumnos alu;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                cam = (from ex in context.ExperienciaEducativaPeriodo
                       join mc in context.MapaCurricular
                       on ex.IdMapaCurricular equals mc.IdMapaCurricular
                       join ee in context.ExperienciaEducativa
                       on mc.IdExperienciaEducativa equals ee.IdExperienciaEducativa
                       join t in context.TbHorario
                       on ex.IdExperienciaEducativaPeriodo equals t.RExperienciaPeriodo
                       join ca in context.TbCalificacion
                       on t.RTipoCalif equals ca.IdTbCalificacion
                       select
                       new Calificaciones_Alumno_Movilidad
                       {
                           calificacion = ca.Calificacion.Value,
                           creditos = ee.Creditos.Value,
                           idAlu = t.RAlumno.Value,
                           NombreMateria = ee.Nombre
                       }).Where(s => s.calificacion > 5 && s.idAlu == idAlumno).ToList();
                alu = context.Alumnos.Where(a => a.IdAlumnos == idAlumno).Single();
                pe = context.ProgramaEducativo.Where(b => b.IdProgramaEducativo == alu.RProgramaEducativo.Value).Single();
            }
            int suma = 0;
            foreach (Calificaciones_Alumno_Movilidad calif in cam)
            {
                suma = suma + calif.creditos;
            }
            int total = pe.Creditos.Value / 2;
            if (suma >= total)
            {
                ViewData["consejo"] = "El total de tus creditos: " + suma + " supera a la mitad de los creditos de tu carrera, ve con tu tutor a checar tus opciones\nTotal de creditos necesarios: " + total;
            }
            else
            {
                ViewData["consejo"] = "El total de tus creditos: " + suma + " no supera a la mitad de los creditos de tu carrera, te recomendamos checar en futuros periodos\nTotal de creditos necesarios: " + total;
            }
            return View(cam);
        }
    }
}