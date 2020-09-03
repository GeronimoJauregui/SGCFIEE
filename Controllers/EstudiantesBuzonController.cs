using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace SGCFIEE.Controllers
{
    public class EstudiantesBuzonController : Controller
    {
        private string from = "pruebasgcfiee@gmail.com"; //Datos globales para el envio de quejas a un correo.
        private string to = "jonathan9623@hotmail.es"; //Datos globales para el envio de quejas a un correo.
        private string pass = "Qwerty.12"; //Datos globales para el envio de quejas a un correo.
        MailMessage m = new MailMessage();
        SmtpClient smtp = new SmtpClient();

        [HttpGet]
        [Authorize]
        //Función para acceder a la vista de agregar una sugerencia sobre la infraestructura y obtener los datos necesarios para los select.
        public IActionResult Index()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 1)
            {
                //Si el usuario que ingreso es de tipo 1 (director), se redireccionara a la vista de SeleccionarQueja.
                return RedirectToAction("SeleccionarQueja");
            }
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {

                var x = context.CtProblemas.ToList(); //Obtención de los problemas registrados en el sistema.
                ViewData["problema"] = x; //Paso de los datos a la vista por medio del diccionario ViewData.
                var y = context.TipoPeriodo.ToList(); //Obtención de los periodos registrados en el sistema.
                ViewData["periodo"] = y; //Paso de los datos a la vista por medio del diccionario ViewData.
                return View();
            }

        }
        [HttpGet]
        [Authorize]
        //Función para acceder a la vista de agregar una sugerencia sobre el desempeño académico y obtener los datos necesarios para los select.
        public IActionResult IndexDesempenio()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 1)
            {
                //Si el usuario que ingreso es de tipo 1 (director), se redireccionara a la vista de SeleccionarQueja.
                return RedirectToAction("SeleccionarQueja");
            }
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {

                var y = context.TipoPeriodo.ToList(); //Obtención de los periodos registrados en el sistema.
                ViewData["periodo"] = y; //Paso de los datos a la vista por medio del diccionario ViewData.
                var z = context.Academicos.ToList(); //Obtención de los académicos registrados en el sistema.
                ViewData["academico"] = z; //Paso de los datos a la vista por medio del diccionario ViewData.
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Función para guardar los datos obtenidos de la vista de agregar sugerencia sobre la infraestructura.
        public IActionResult CrearSugerencia(BuzonSugerencias suge)
        {
            TbBuzonDeQuejas buzon = new TbBuzonDeQuejas();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Paso de los datos a sus campos correspondientes.
                buzon.RPeriodo = suge.RPeriodo;
                buzon.RProblema = suge.RProblema;
                buzon.RAlumno = (int)HttpContext.Session.GetInt32("IdUsu"); //guarda al ID del usuario segun la tabla de usuario de la base de datos.
                buzon.Sugerencia = suge.Sugerencia;
                buzon.Propuesta = suge.Propuesta;
                context.TbBuzonDeQuejas.Add(buzon); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Enviado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                var problem = context.CtProblemas.Where(s => s.IdCtProblemas == buzon.RProblema).Single();
                string problema = problem.NombreProblemas;
                //Envio de correo.
                try
                {
                    m.From = new MailAddress(from, "Jonathan Trujillo");
                    m.To.Add(new MailAddress(to));
                    m.Subject = "PROBLEMA CON: " + problema;
                    m.BodyEncoding = System.Text.Encoding.UTF8;
                    m.Body = "SITUACION: " + suge.Propuesta + "\r\nPROPUESTA: " + suge.Sugerencia;
                    m.IsBodyHtml = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.UseDefaultCredentials = true;
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Función para guardar los datos obtenidos de la vista de agregar sugerencia sobre el desempeño académico.
        public IActionResult CrearSugerenciaAca(BuzonSugerencias sugere)
        {

            TbBuzonAcademicos buzon = new TbBuzonAcademicos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Paso de los datos a sus campos correspondientes.
                buzon.RAcademicos = sugere.RAcademicos;
                buzon.RPeriodo = sugere.RPeriodo.Value;
                buzon.Propuesta = sugere.Propuesta;
                buzon.RAlumno = (int)HttpContext.Session.GetInt32("IdUsu"); //guarda al ID del usuario segun la tabla de usuario de la base de datos.
                buzon.Sugerencia = sugere.Sugerencia;
                context.TbBuzonAcademicos.Add(buzon); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Enviado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                var aca = context.Academicos.Where(s => s.IdAcademicos == sugere.RAcademicos).Single();
                string academico = aca.Nombre;
                //Envio de correo.
                try
                {
                    m.From = new MailAddress(from);
                    m.To.Add(new MailAddress(to));
                    m.Subject = "PROBLEMA CON:" + academico;
                    m.Body = "SITUACION: " + sugere.Propuesta + "\r\nPROPUESTA: " + sugere.Sugerencia;
                    smtp.Host = "smtp.gmail.com";
                    smtp.UseDefaultCredentials = true;
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                return RedirectToAction("IndexDesempenio");
            }
        }
        [HttpGet]
        [Authorize]
        //Función para acceder a la vista de crear un nuevo problema.
        public IActionResult CrearProblema()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Función para guardar el problema que se ingrese en la vista de crear problema.
        public IActionResult CrearProblema(CtProblemas problema)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtProblemas.Add(problema); //Guardado de la información.
                context.SaveChanges();
                TempData["mensaje"] = "Dato guardado";
                return RedirectToAction("Index"); //Retorno a la vista index.
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        //Función que muestra un select con los dos tipos de sugerencias.
        public IActionResult SeleccionarQueja()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [Authorize]
        //Una vez seleccionada una opción en la vista SeleccionarQueja, dicho dato llegara ha esta función.
        public IActionResult CargarTabla(CtMovilidades queja)
        {
            //Dependiendo de cual haya sido la opción seleccionada, sera la condición que se cumpla.
            int x = queja.TipoMovilidades.Value;
            if(x == 0)
            {
                return RedirectToAction("SeleccionarQueja"); //Redirección a la vista de SeleccionarQueja (Aparece el menu para seleccionar quejas).
            }
            if(x == 1)
            {
                return RedirectToAction("TablaInfrestructura"); //Redirección a la vista de TablaInfrestructura (Aparecen las quejas sobre la infraestructura).
            }
            else
            {
                return RedirectToAction("TablaAcademicos"); //Redirección a la vista de TablaAcademicos (Aparecen las quejas sobre el desempeño académico).
            }
        }

        [Authorize]
        //Función para mostrar la tabla de quejas sobre la infraestructura.
        public IActionResult TablaInfrestructura()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            //La clase TablaSugerenciasBuzon fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaSugerenciasBuzon> suge = new List<TablaSugerenciasBuzon>(); //Declaración de la lista donde se obtendran los datos.
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener todas las quejas de los alumnos.
                suge = (from t in context.TbBuzonDeQuejas
                           join
                            p in context.CtProblemas on t.RProblema equals p.IdCtProblemas
                           join
                           a in context.Alumnos on t.RAlumno equals a.IdAlumnos
                           join
                           d in context.DatosPersonales on a.RDatosPerson equals d.IdDatosPersonales
                           join
                           o in context.TipoPeriodo on t.RPeriodo equals o.IdPeriodo
                           select
                           new TablaSugerenciasBuzon
                           {
                               idtb = t.IdTbBuzonDeQuejas,
                               nombrePro = p.NombreProblemas,
                               nombreAlu = d.Nombre,
                               apeAluP = d.ApellidoPaterno,
                               apeAluM = d.ApellidoMaterno,
                               nomPeri = o.Nombre,
                               sugerencia = t.Sugerencia,
                               propuesta = t.Propuesta
                           }
                          ).ToList();
                ViewData["lista"] = suge;
            }
            return View();
        }

        [Authorize]
        //Función para mostrar la tabla de quejas sobre el desempeño académico.
        public IActionResult TablaAcademicos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            //La clase TablaSugerenciasBuzon fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaSugerenciasBuzon> suge = new List<TablaSugerenciasBuzon>(); //Declaración de la lista donde se obtendran los datos.
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener todas las quejas de los alumnos.
                suge = (from t in context.TbBuzonAcademicos
                        join
                         p in context.Academicos on t.RAcademicos equals p.IdAcademicos
                        join
                        a in context.Alumnos on t.RAlumno equals a.IdAlumnos
                        join
                        d in context.DatosPersonales on a.RDatosPerson equals d.IdDatosPersonales
                        join
                        o in context.TipoPeriodo on t.RPeriodo equals o.IdPeriodo
                        select
                        new TablaSugerenciasBuzon
                        {
                            idtb = t.IdBuzonAcademicos,
                            nombreAlu = d.Nombre,
                            apeAluP = d.ApellidoPaterno,
                            apeAluM = d.ApellidoMaterno,
                            nomPeri = o.Nombre,
                            sugerencia = t.Sugerencia,
                            propuesta = t.Propuesta,
                            nombreMaestro = p.Nombre,
                            apePat = p.ApellidoPaterno,
                            apeMaP = p.ApellidoMaterno
                        }
                          ).ToList();
                ViewData["lista"] = suge;
            }
            return View();
        }
    }
}
