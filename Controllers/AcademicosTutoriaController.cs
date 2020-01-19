using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SGCFIEE.Models;

namespace SGCFIEE.Controllers
{
    public class AcademicosTutoriaController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pAcademicosAlumnos> tutoI = new List<pAcademicosAlumnos>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var tutoE = context.TutoradosExternos.Where( w => w.IdAcademico == acad[0].IdAcademicos).ToList();

                tutoI = (from tuto in context.Tutores
                           join alum in context.Alumnos on tuto.IdAlumno equals alum.IdAlumnos
                           join DG in context.DatosPersonales on alum.RDatosPerson equals DG.IdDatosPersonales
                           where tuto.IdAcademicos == acad[0].IdAcademicos
                           select new pAcademicosAlumnos
                           {
                               IdAlumnos = tuto.IdTutores,
                               matricula = alum.Matricula,
                               Nombre = DG.Nombre,
                               A_paterno = DG.ApellidoPaterno,
                               A_materno = DG.ApellidoMaterno,
                           }
                               ).ToList();
                ViewData["academicos"] = acad;
                ViewData["tutoI"] = tutoI;
                ViewData["tutoE"] = tutoE;
            }
            return View();
        }

        [Authorize]
        public IActionResult IdIndex(Academicos datos)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pAcademicosAlumnos> tutoI = new List<pAcademicosAlumnos>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var esp_aca = context.Academicos.Where(w => w.IdAcademicos == datos.IdAcademicos).Single();
                var tutoE = context.TutoradosExternos.Where(w => w.IdAcademico == esp_aca.IdAcademicos).ToList();

                tutoI = (from tuto in context.Tutores
                         join alum in context.Alumnos on tuto.IdAlumno equals alum.IdAlumnos
                         join DG in context.DatosPersonales on alum.RDatosPerson equals DG.IdDatosPersonales
                         where tuto.IdAcademicos == esp_aca.IdAcademicos
                         select new pAcademicosAlumnos
                         {
                             IdAlumnos = tuto.IdTutores,
                             matricula = alum.Matricula,
                             Nombre = DG.Nombre,
                             A_paterno = DG.ApellidoPaterno,
                             A_materno = DG.ApellidoMaterno,
                         }
                               ).ToList();
                ViewData["academicos"] = acad;
                ViewData["esp_aca"] = esp_aca;
                ViewData["tutoI"] = tutoI;
                ViewData["tutoE"] = tutoE;
            }
            return View();
        }

        [Authorize]
        public IActionResult Agregar()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pAcademicosAlumnos> Alumnos = new List<pAcademicosAlumnos>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();

                Alumnos = (from alum in context.Alumnos
                            join DG in context.DatosPersonales on alum.RDatosPerson equals DG.IdDatosPersonales
                            select new pAcademicosAlumnos
                            {
                                IdAlumnos = alum.IdAlumnos,
                                Nombre = DG.Nombre,
                                A_paterno = DG.ApellidoPaterno,
                                A_materno = DG.ApellidoMaterno,
                            }
                               ).ToList();
                ViewData["academicos"] = acad;
                ViewData["alumnos"] = Alumnos;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Guardar(ptutorados datos)
        {
            Console.WriteLine(datos.Tipotutorado);
            using (sgcfieeContext context = new sgcfieeContext())
            {   
                if (datos.Tipotutorado == 0)
                {
                    Tutores tuto = new Tutores();
                    tuto.IdAcademicos = datos.IdAcademicos;
                    tuto.IdAlumno = datos.IdAlumno;
                    tuto.Status = 1;
                    context.Tutores.Add(tuto);
                }
                else
                {
                    TutoradosExternos tuto = new TutoradosExternos();
                    tuto.IdAcademico = datos.IdAcademicos;
                    tuto.Nombre = datos.Nombre;
                    tuto.Matricula = datos.Matricula;
                    context.TutoradosExternos.Add(tuto);
                }
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult EditarI(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");

            List<pAcademicosAlumnos> Alumnos = new List<pAcademicosAlumnos>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Tutores tutoi = context.Tutores.Where(s => s.IdTutores == id).Single();

                var acad = context.Academicos.ToList();

                Alumnos = (from alum in context.Alumnos
                           join DG in context.DatosPersonales on alum.RDatosPerson equals DG.IdDatosPersonales
                           select new pAcademicosAlumnos
                           {
                               IdAlumnos = alum.IdAlumnos,
                               Nombre = DG.Nombre,
                               A_paterno = DG.ApellidoPaterno,
                               A_materno = DG.ApellidoMaterno,
                           }
                               ).ToList();
                ViewData["academicos"] = acad;
                ViewData["alumnos"] = Alumnos;
                return View(tutoi);
            }
            
        }

        [Authorize]
        public IActionResult EditarE(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");

            using (sgcfieeContext context = new sgcfieeContext())
            {
                TutoradosExternos tutoe = context.TutoradosExternos.Where(s => s.IdTutoradosExternos == id).Single();

                var acad = context.Academicos.ToList();

                ViewData["academicos"] = acad;
                return View(tutoe);
            }

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarI(Tutores datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                datos.Status = 1;
                context.Tutores.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarE(TutoradosExternos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TutoradosExternos.Update(datos);
                context.SaveChanges();
                TempData["Mensaje"] = "La informacion se ha guardado correctamente";
            }
            return RedirectToAction("Index");
        }

        public IActionResult EliminarI(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Tutores eliminar = context.Tutores.Where(w => w.IdTutores == id).Single();
                context.Tutores.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult EliminarE(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TutoradosExternos eliminar = context.TutoradosExternos.Where(w => w.IdTutoradosExternos == id).Single();
                context.TutoradosExternos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}