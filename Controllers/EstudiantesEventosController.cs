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
        //Función para mostrar la vista principal del submodulo eventos y obtener los tipos de eventos.
        public IActionResult Index()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.TipoEventos.ToList(); //Obtención de los tipos de eventos de la base de datos, los cuales se mostran un select.
                ViewData["tipos"] = x; //Envio de datos por medio del diccionario ViewData.
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
        //Función que muestra la lista de los eventos segun el tipo que se haya escogido en la vista index.
        public IActionResult OpcionesEventos(int idEvento)
        {
            int x = idEvento;
            //x contiene el valor que se haya seleccionado en la vista index.
            if(x == 0)
            {
                //Si la opción seleccionada en el index fue "seleccionar..." (que es 0),redireccionara a la función index.
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    var categorias = context.TipoEventos.ToList(); //se obtienen los tipos de eventos registrados en el sistema.
                    var evento = context.TbEventos.Where(s => s.RTioEvento.Equals(x)).ToList<TbEventos>(); //Se obtienen los eventos que pertenecen al tipo de evento selecionado.
                    //Envio de datos atraves del diccionario ViewData.
                    ViewData["tipos"] = categorias;
                    ViewData["Eventos"] = evento;
                    ViewData["idEvento"] = x;
                }
            }
            return View();
        }
        [Authorize]
        //Función que accede a la vista para registrarse en el evento seleccionado.
        public IActionResult FormEvento(int id, int idEvento)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var evento = context.TbEventos.Where(s => s.IdEventos.Equals(id)).Single(); //Se obtiene el evento selecionado.
                //Paso de datos a la vista por medio del diccionario ViewData.
                ViewData["evento"] = evento;
                ViewData["idEvento"] = idEvento;
            }
            return View();
        }
        [Authorize]
        //Función que guarda los datos del evento con el alumno.
        public IActionResult RegistrarEventoAlu(EventosAlumnos eventos, int idEvento)
        {
            int idAlu = (int)HttpContext.Session.GetInt32("IdUsu"); //idAlu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            eventos.RAlumno = idAlu;

            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "EventosAlumnos".
                var even = context.EventosAlumnos.Where(a => a.RAlumno == idAlu).ToList(); //Se obtienen los registros de la tabla.
                foreach (EventosAlumnos item in even)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara a la vista OpcionesEventos y no se guardaran los datos.
                    if (item.REvento == eventos.REvento && item.Fecha == eventos.Fecha)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("OpcionesEventos", new { idEvento = idEvento });
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.EventosAlumnos.Add(eventos); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("OpcionesEventos", new { idEvento = idEvento});
        }
    }
}