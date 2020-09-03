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
    public class AcademicosEvaluacionesController : Controller
    {
        // GET: /<controller>/
        
        [Authorize]
        //Función para mostrar la información de las evaluaciones de los alumnos a los académicos.
        public IActionResult IndexEvalEstudiantes()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso segun tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaCalifEstudiantes fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaCalifEstudiantes> ListCalifEstudiantes = new List<TablaCalifEstudiantes>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1)
                {
                    //Consulta para obtener a todos los academicos con sus respectivas calificaciones.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 1 (director).
                    ListCalifEstudiantes = (from calif in context.EvaluacionEstudiantes
                                            join acad in context.Academicos on calif.IdAcademico equals acad.IdAcademicos
                                            join perio in context.TipoPeriodo on calif.IdPeriodo equals perio.IdPeriodo
                                            select new TablaCalifEstudiantes
                                            {
                                                IdCalifEstudiantes = calif.IdEvaluacionEstudiantes,
                                                NumPersonal = acad.NumeroPersonal,
                                                Nombre = acad.Nombre,
                                                ApellidoPaterno = acad.ApellidoPaterno,
                                                ApellidoMaterno = acad.ApellidoMaterno,
                                                Calificacion = calif.Calificacion,
                                                Periodo = perio.Nombre,
                                                Status = acad.Status
                                            }
                                   ).ToList();
                }
                if (tipo == 2)
                {
                    //Consulta para obtener las respectivas calificaciones del usuario que este ingresando al sistema.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 2 (académico).
                    ListCalifEstudiantes = (from calif in context.EvaluacionEstudiantes
                                            join acad in context.Academicos on calif.IdAcademico equals acad.IdAcademicos
                                            join perio in context.TipoPeriodo on calif.IdPeriodo equals perio.IdPeriodo
                                            where calif.IdAcademico == idUsu
                                            select new TablaCalifEstudiantes
                                            {
                                                IdCalifEstudiantes = calif.IdEvaluacionEstudiantes,
                                                NumPersonal = acad.NumeroPersonal,
                                                Nombre = acad.Nombre,
                                                ApellidoPaterno = acad.ApellidoPaterno,
                                                ApellidoMaterno = acad.ApellidoMaterno,
                                                Calificacion = calif.Calificacion,
                                                Periodo = perio.Nombre,
                                                Status = acad.Status
                                            }
                                   ).ToList();
                }
            }
            return View(ListCalifEstudiantes); //Envio de los datos a la vista.
        }
        [Authorize]
        //Función para mostrar la información de las evaluaciones del consejo tecnico a los académicos.
        public IActionResult IndexEvalCT()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso segun tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            //La clase TablaCalifCT fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaCalifCT> ListCalifCT = new List<TablaCalifCT>(); //Declaración de la lista donde se obtendran los datos.
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1)
                {
                    // Consulta para obtener a todos los academicos con sus respectivas calificaciones.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 1 (director).
                    ListCalifCT = (from calif in context.EvaluacionConsejoTecnico
                                   join acad in context.Academicos on calif.IdAcademico equals acad.IdAcademicos
                                   join perio in context.TipoPeriodo on calif.IdPeriodo equals perio.IdPeriodo
                                   select new TablaCalifCT
                                   {
                                       IdCalifCT = calif.IdConsejoTecnico,
                                       NumPersonal = acad.NumeroPersonal,
                                       Nombre = acad.Nombre,
                                       ApellidoPaterno = acad.ApellidoPaterno,
                                       ApellidoMaterno = acad.ApellidoMaterno,
                                       CalifDesempenio = calif.CalificacionDesempenio,
                                       CalifGestion = calif.CalificacionGestion,
                                       Periodo = perio.Nombre,
                                       Status = acad.Status
                                   }
                               ).ToList();
                }
                if (tipo == 2)
                {
                    //Consulta para obtener las respectivas calificaciones del usuario que este ingresando al sistema.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 2 (académico).
                    ListCalifCT = (from calif in context.EvaluacionConsejoTecnico
                                   join acad in context.Academicos on calif.IdAcademico equals acad.IdAcademicos
                                   join perio in context.TipoPeriodo on calif.IdPeriodo equals perio.IdPeriodo
                                   where calif.IdAcademico == idUsu
                                   select new TablaCalifCT
                                   {
                                       IdCalifCT = calif.IdConsejoTecnico,
                                       NumPersonal = acad.NumeroPersonal,
                                       Nombre = acad.Nombre,
                                       ApellidoPaterno = acad.ApellidoPaterno,
                                       ApellidoMaterno = acad.ApellidoMaterno,
                                       CalifDesempenio = calif.CalificacionDesempenio,
                                       CalifGestion = calif.CalificacionGestion,
                                       Periodo = perio.Nombre,
                                       Status = acad.Status
                                   }
                               ).ToList();
                }
            }
            return View(ListCalifCT); //Envio de los datos a la vista.
        }
        [Authorize]
        //Función para mostrar la información de las evaluaciones de los tutores a los académicos.
        public IActionResult IndexEvalTutor()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            // La clase TablaCalifTutor fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaCalifTutor> ListCalifTutor = new List<TablaCalifTutor>(); //Declaración de la lista donde se obtendran los datos.
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1)
                {
                    //Consulta para obtener a todos los academicos con sus respectivas calificaciones.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 1 (director.)
                    ListCalifTutor = (from calif in context.TbCalificacionTutor
                                      join
                                      acad in context.Academicos on calif.RAcademicos equals acad.IdAcademicos
                                      join
                                      perio in context.TipoPeriodo on calif.RPeriodo equals perio.IdPeriodo
                                      select
                                      new TablaCalifTutor
                                      {
                                          IdCalifTutor = calif.IdTbCalificacionTutor,
                                          NumPersonal = acad.NumeroPersonal,
                                          Nombre = acad.Nombre,
                                          ApellidoPaterno = acad.ApellidoPaterno,
                                          ApellidoMaterno = acad.ApellidoMaterno,
                                          Calificacion = calif.Calificacion,
                                          Periodo = perio.Nombre,
                                          Status = acad.Status
                                      }
                                ).ToList();
                }
                if (tipo == 2)
                { 
                    //Consulta para obtener las respectivas calificaciones del usuario que este ingresando al sistema.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 2 (académico).
                    ListCalifTutor = (from calif in context.TbCalificacionTutor
                                      join
                                      acad in context.Academicos on calif.RAcademicos equals acad.IdAcademicos
                                      join
                                      perio in context.TipoPeriodo on calif.RPeriodo equals perio.IdPeriodo
                                      where calif.RAcademicos == idUsu
                                      select
                                      new TablaCalifTutor
                                      {
                                          IdCalifTutor = calif.IdTbCalificacionTutor,
                                          NumPersonal = acad.NumeroPersonal,
                                          Nombre = acad.Nombre,
                                          ApellidoPaterno = acad.ApellidoPaterno,
                                          ApellidoMaterno = acad.ApellidoMaterno,
                                          Calificacion = calif.Calificacion,
                                          Periodo = perio.Nombre,
                                          Status = acad.Status
                                      }
                                ).ToList();
                }
            }
            return View(ListCalifTutor); //Envio de los datos a la vista.
    }

        [Authorize]
        //Función para acceder a la vista de agregar evaluacion del consejo tecnico y obtener los datos necesarios para los select.
        public IActionResult CrearEvalCT()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var perio = context.TipoPeriodo.ToList(); //Obtencion de los periodos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear evaluación de consejo tecnico.
        public IActionResult GuardarEvalCT(EvaluacionConsejoTecnico datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "EvaluacionConsejoTecnico".
                var ListCalifCT = context.EvaluacionConsejoTecnico.ToList(); //Se obtienen los registros de la tabla.
                foreach (EvaluacionConsejoTecnico item in ListCalifCT)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexEvalCT");
                    }
                }
           
                context.EvaluacionConsejoTecnico.Add(datos); //Guardado de la información.
                context.SaveChanges();
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("IndexEvalCT");
        }
        [Authorize]
        //Función para acceder a la vista de agregar evaluación de los estudiantes y obtener los datos necesarios para los select.
        public IActionResult CrearEvalEstudiantes()
        {
            
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var perio = context.TipoPeriodo.ToList(); //Obtencion de los periodos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear evaluación de los estudiantes.
        public IActionResult GuardarEvalEstudiantes(EvaluacionEstudiantes datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "EvaluacionEstudiantes".
                var ListCalifEstudiantes = context.EvaluacionEstudiantes.ToList(); //Se obtienen los registros de la tabla.
                foreach (EvaluacionEstudiantes item in ListCalifEstudiantes)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexEvalEstudiantes");
                    }
                }
           
                context.EvaluacionEstudiantes.Add(datos); //Guardado de la información.
                 context.SaveChanges();
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("IndexEvalEstudiantes");
        }
        [Authorize]
        //Función para acceder a la vista de agregar evaluación del tutor y obtener los datos necesarios para los select.
        public IActionResult CrearEvalTutor()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var perio = context.TipoPeriodo.ToList(); //Obtencion de los periodos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear evaluación del tutor.
        public IActionResult GuardarEvalTutor(TbCalificacionTutor datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                    datos.RAcademicos = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "TbCalificacionTutor".
                var ListCalifTutor = context.TbCalificacionTutor.ToList(); //Se obtienen los registros de la tabla.
                foreach (TbCalificacionTutor item in ListCalifTutor)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.RAcademicos == item.RAcademicos && datos.RPeriodo == item.RPeriodo)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexEvalTutor");
                    }
                }
                context.TbCalificacionTutor.Add(datos); //Guardado de la información.
                context.SaveChanges();
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("IndexEvalTutor");
        }
        [Authorize]
        //Función para mostrar la información de las evaluaciones de los alumnos a los académicos por materia.
        public IActionResult DatosEvalEstudiantes(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            //La clase CalifAcademicoEE fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<CalifAcademicoEE> ListCalifEE = new List<CalifAcademicoEE>(); //Declaración de la lista donde se obtendran los datos.
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener todas las calificaciones por materia segun el periodo y el académico.
                EvaluacionEstudiantes DatosCalifEstudiantes = context.EvaluacionEstudiantes.Where(s => s.IdEvaluacionEstudiantes == id).Single();
                ListCalifEE = (from calif in context.ExperienciaEducativaPeriodo
                               join acad in context.Academicos on calif.IdAcademico equals acad.IdAcademicos
                               join perio in context.TipoPeriodo on calif.IdPeriodo equals perio.IdPeriodo
                               join mapa in context.MapaCurricular on calif.IdMapaCurricular equals mapa.IdMapaCurricular
                               join EE in context.ExperienciaEducativa on mapa.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                               join Institucion in context.InstitucionesEmpresas on calif.IdInstitucionSuperior equals Institucion.IdIE
                               select new CalifAcademicoEE
                               {
                                   IdAcademico = calif.IdAcademico,
                                   Institucion = Institucion.Nombre,
                                   IdCalifEE = calif.IdExperienciaEducativaPeriodo,
                                   IdPeriodo = calif.IdPeriodo,
                                   NumPersonal = acad.NumeroPersonal,
                                   Nombre = acad.Nombre,
                                   ApellidoPaterno = acad.ApellidoPaterno,
                                   ApellidoMaterno = acad.ApellidoMaterno,
                                   Nrc = calif.Nrc,
                                   Calificacion= calif.CalificacionAcademico,
                                   ExperienciaE = EE.Nombre,
                                   Periodo = perio.Nombre
                               }
                               ).Where(calif => calif.IdAcademico == DatosCalifEstudiantes.IdAcademico && calif.IdPeriodo == DatosCalifEstudiantes.IdPeriodo && calif.Institucion=="Universidad Veracruzana").ToList();
                
            }

                return View(ListCalifEE); //Envio de los datos a la vista.
        }


        [Authorize]
        //Función para acceder a la vista de editar evaluación del consejo tecnico y obtener los datos necesarios para los select.
        public IActionResult EditarEvalCT(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Obtención de los datos a editar.
                EvaluacionConsejoTecnico DatosCalifCT = context.EvaluacionConsejoTecnico.Where(s => s.IdConsejoTecnico == id).Single();
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos de la base de datos.
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosCalifCT);
            }
        }
        [Authorize]
        //Función para acceder a la vista de editar evaluación de los estudiantes y obtener los datos necesarios para los select.
        public IActionResult EditarEvalEstudiantes(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Obtención de los datos a editar.
                EvaluacionEstudiantes DatosCalifEstudiantes = context.EvaluacionEstudiantes.Where(s => s.IdEvaluacionEstudiantes == id).Single();
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos de la base de datos.
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosCalifEstudiantes);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar evaluación de los estudiantes.
        public IActionResult ActualizarEvalEstudiantes(EvaluacionEstudiantes datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                datos.IdAcademico = idUsu;
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información ha actualizar no se encuentre ya registrada en la tabla "EvaluacionEstudiantes".
                var ListCalifEstudiantes = context.EvaluacionEstudiantes.ToList(); // Se obtienen los registros de la tabla.

                foreach (EvaluacionEstudiantes item in ListCalifEstudiantes)
                {
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdEvaluacionEstudiantes != item.IdEvaluacionEstudiantes)
                    {
                        //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexEvalEstudiantes");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.EvaluacionEstudiantes.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexEvalEstudiantes");
        }
        [Authorize]
        //Función para acceder a la vista de editar evaluación del tutor y obtener los datos necesarios para los select.
        public IActionResult EditarEvalTutor(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Obtención de los datos a editar.
                TbCalificacionTutor DatosCalifTutor = context.TbCalificacionTutor.Where(s => s.IdTbCalificacionTutor == id).Single();
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos de la base de datos.
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosCalifTutor);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar evaluación del tutor.
        public IActionResult ActualizarEvalTutor(TbCalificacionTutor datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                datos.RAcademicos = idUsu;
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información ha actualizar no se encuentre ya registrada en la tabla "TbCalificacionTutor".
                var ListCalifTutor = context.TbCalificacionTutor.ToList(); //Se obtienen los registros de la tabla.

                foreach (TbCalificacionTutor item in ListCalifTutor)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.RAcademicos == item.RAcademicos && datos.RPeriodo == item.RPeriodo && datos.IdTbCalificacionTutor != item.IdTbCalificacionTutor)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexEvalTutor");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                
                
                context.TbCalificacionTutor.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexEvalTutor");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar evaluación de consejo tecnico.
        public IActionResult ActualizarEvalCT(EvaluacionConsejoTecnico datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                datos.IdAcademico = idUsu;
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "EvaluacionConsejoTecnico".
                var ListCalifCT = context.EvaluacionConsejoTecnico.ToList(); //Se obtienen los registros de la tabla.

                foreach (EvaluacionConsejoTecnico item in ListCalifCT)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdConsejoTecnico != item.IdConsejoTecnico)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexEvalCT");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {


                context.EvaluacionConsejoTecnico.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexEvalCT");
        }

        //Función para eliminar un registro de la evaluación del tutor.
        public IActionResult EliminarEvalTutor(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Busqueda del registro ha eliminar, condicionado por el id recibido.
                TbCalificacionTutor eliminar = context.TbCalificacionTutor.Where(w => w.IdTbCalificacionTutor == id).Single();
                context.TbCalificacionTutor.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexEvalTutor");
            }
        }
        //Función para eliminar un registro de la evaluación del consejo tecnico.
        public IActionResult EliminarEvalCT(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Busqueda del registro ha eliminar, condicionado por el id recibido.
                EvaluacionConsejoTecnico eliminar = context.EvaluacionConsejoTecnico.Where(w => w.IdConsejoTecnico == id).Single();
                context.EvaluacionConsejoTecnico.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexEvalCT");
            }
        }
        //Función para eliminar un registro de la evaluación de los estudiantes.
        public IActionResult EliminarEvalEstudiantes(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Busqueda del registro ha eliminar, condicionado por el id recibido.
                EvaluacionEstudiantes eliminar = context.EvaluacionEstudiantes.Where(w => w.IdEvaluacionEstudiantes == id).Single();
                context.EvaluacionEstudiantes.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexEvalEstudiantes");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
