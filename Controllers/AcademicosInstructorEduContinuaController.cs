using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGCFIEE.Controllers
{
    public class AcademicosInstructorEduContinuaController : Controller
    {
        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            List<TablaInstructorEduCont> ListInstructorEdu = new List<TablaInstructorEduCont>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListInstructorEdu = (from instruc in context.RecursosExternos
                                        join acad in context.Academicos on instruc.IdAcademicos equals acad.IdAcademicos
                                        join perio in context.TipoPeriodo on instruc.IdPeriodo equals perio.IdPeriodo
                                        select new TablaInstructorEduCont
                                        {
                                            IdInstructorEdu = instruc.IdRecursosExternos,
                                            NumPersonal = acad.NumeroPersonal,
                                            Nombre = acad.Nombre,
                                            ApellidoPaterno = acad.ApellidoPaterno,
                                            ApellidoMaterno = acad.ApellidoMaterno,
                                            Ingreso = instruc.Ingreso,
                                            NomIngreso = instruc.Nombre,
                                            Periodo = perio.Nombre,
                                            Status = acad.Status
                                        }
                                    ).ToList();
            }
            return View(ListInstructorEdu);
        }
        public IActionResult Crear()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList();
                var perio = context.TipoPeriodo.ToList();
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult GuardarInstructorEdu(RecursosExternos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListInstructorEdu = context.RecursosExternos.ToList();
                foreach (RecursosExternos item in ListInstructorEdu)
                {
                    if (datos.IdAcademicos == item.IdAcademicos && datos.IdPeriodo == item.IdPeriodo && datos.Nombre==item.Nombre && datos.Ingreso== item.Ingreso)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("Index");
                    }
                }

                context.RecursosExternos.Add(datos);
                context.SaveChanges();
                
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                RecursosExternos DatosInstructorEdu = context.RecursosExternos.Where(s => s.IdRecursosExternos == id).Single();
                var perio = context.TipoPeriodo.ToList();
                var acad = context.Academicos.ToList();
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosInstructorEdu);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult ActualizarInstructorEdu(RecursosExternos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListInstructorEdu = context.RecursosExternos.Where(y => y.IdRecursosExternos != datos.IdRecursosExternos).ToList();

                foreach (RecursosExternos item in ListInstructorEdu)
                {
                    if (datos.IdAcademicos == item.IdAcademicos && datos.IdPeriodo == item.IdPeriodo && datos.Nombre == item.Nombre && datos.Ingreso == item.Ingreso)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("Index");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.RecursosExternos.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                
            }
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                RecursosExternos eliminar = context.RecursosExternos.Where(w => w.IdRecursosExternos == id).Single();
                context.RecursosExternos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
