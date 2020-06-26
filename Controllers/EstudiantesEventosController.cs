using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace SGCFIEE.Controllers
{
    public class EstudiantesEventosController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.TipoEventos.ToList();
                ViewData["tipos"] = x;
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public IActionResult ListaEventos(int idTipoEvento)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var eventosEspecificos = context.TbEventos.Where(s => s.RTioEvento.Equals(idTipoEvento)).ToList<TbEventos>();
                ViewData["NomEventos"] = eventosEspecificos;
            }
            return View();
        }
        [Authorize]
        public IActionResult OpcionesEventos(int idEvento)
        {
            int x = idEvento;
            if(x == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    var categorias = context.TipoEventos.ToList();
                    var evento = context.TbEventos.Where(s => s.RTioEvento.Equals(x)).ToList<TbEventos>();
                    ViewData["tipos"] = categorias;
                    ViewData["Eventos"] = evento;
                    ViewData["idEvento"] = x;
                }
            }
            return View();
        }
        [Authorize]
        public IActionResult FormEvento(int id, int idEvento)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var evento = context.TbEventos.Where(s => s.IdEventos.Equals(id)).Single();
                ViewData["evento"] = evento;
                ViewData["idEvento"] = idEvento;
            }
            return View();
        }
        [Authorize]
        public IActionResult RegistrarEventoAlu(EventosAlumnos eventos, int idEvento)
        {
            int idAlu = (int)HttpContext.Session.GetInt32("IdUsu");
            eventos.RAlumno = idAlu;

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var even = context.EventosAlumnos.Where(a => a.RAlumno == idAlu).ToList();
                foreach(EventosAlumnos item in even)
                {
                    if(item.REvento == eventos.REvento && item.Fecha == eventos.Fecha)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("OpcionesEventos", new { idEvento = idEvento });
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.EventosAlumnos.Add(eventos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("OpcionesEventos", new { idEvento = idEvento});
        }
    }
}