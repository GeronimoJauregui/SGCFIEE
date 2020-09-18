using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using SGCFIEE.Models;

namespace SGCFIEE.Controllers
{
    public class EstudiantesExamenController : Controller
    {
        [HttpGet] // vista principal
        public IActionResult Index()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            ViewData["idAlu"] = (int)HttpContext.Session.GetInt32("IdUsu");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var calif = context.TbExamenalumno.ToList();
                var x = context.TbRubrosexamenes.ToList();
                ViewData["rubros"] = x;
                ViewData["calif"] = calif;
                return View();
            }
                
        }
        [HttpPost]
        // al crear las calificaciones se obtiene en un json porque se reciben de diferentes rubros
        public IActionResult Crear(JSON examen)
        {
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            // se transforman del json a un modelo y se guardan en lista
             List<TbExamenalumno> lista =
                json_serializer.Deserialize<List<TbExamenalumno>>(examen.json);
            //  AlumnoExamenTB list = new AlumnoExamenTB();
            using (sgcfieeContext context = new sgcfieeContext())
            { // se guardan unno por uno
                foreach (var item in lista)
                {
                    context.TbExamenalumno.Update(item);
                    context.SaveChanges();
                }                
                TempData["mensaje"] = "Dato guardado";
                return RedirectToAction("Default","Home");
            }
        }
    }
}