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
    //en este submodulo tenemos 2 vistas principales, una es solo vista generica,
    //la segunda ya recibe un id para buscar
    {
        [Authorize]
        // primera vista (generica)
        public IActionResult Index()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            ViewData["tipo"] = tipo;
            //si se trata de un académico redireccionamos al otro metodo index, pasando su id
            if (tipo == 2) {
                Academicos aca = new Academicos();
                aca.IdAcademicos = (int)HttpContext.Session.GetInt32("IdUsu");
                return RedirectToAction("IdIndex", aca );            
            } // usamos un modelo personalizado para los tutorados internos
            List<pAcademicosAlumnos> tutoI = new List<pAcademicosAlumnos>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // para esta vista generica siempre vamos a mostrar los tutorados del primer academico en la DB
                var acad = context.Academicos.ToList();
                // buscamos los tutorados externos
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
        // vista que recibe id del academico,este metodo se manda a llamar cada vez que el select de la vista cambie 
        // se recibe en un modelo de académicos aunque lo unico que contiene es el id
        public IActionResult IdIndex(Academicos datos)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pAcademicosAlumnos> tutoI = new List<pAcademicosAlumnos>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // necesitamos tener la lista de todos los académicos otra vez para el select 
                var acad = context.Academicos.ToList();
                // buscamos al académico 
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
        // usamos el mismo modelo para recibir los datos de internos y externos
        public IActionResult Guardar(ptutorados datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            // si es tipo 2 no se le preguntan sus datos en la vista, aqui obtenemos su id
            if (tipo == 2) {
                datos.IdAcademicos = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {   // si es un tutorado interno
                if (datos.Tipotutorado == 0)
                {
                    Tutores tuto = new Tutores();
                    tuto.IdAcademicos = datos.IdAcademicos;
                    tuto.IdAlumno = datos.IdAlumno;
                    tuto.Status = 1;
                    context.Tutores.Add(tuto);
                }
                // si es un tutorado externo
                else
                {
                    TutoradosExternos tuto = new TutoradosExternos();
                    tuto.IdAcademico = datos.IdAcademicos;
                    tuto.Nombre = datos.Nombre;
                    tuto.Matricula = datos.Matricula;
                    context.TutoradosExternos.Add(tuto);
                }
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        // editar tutorado interno
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
        // editar externo
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
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {   // si es un academico en la vista no se piden sus datos, se buscan aqui
                if (tipo == 2)
                {
                    datos.IdAcademicos = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                datos.Status = 1;
                context.Tutores.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarE(TutoradosExternos datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {   // si es un academico en la vista no se piden sus datos, se buscan aqui
                if (tipo == 2)
                {
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                context.TutoradosExternos.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("Index");
        }
        // eliminar tutorado interno
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
        // eliminar tutorado externo
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