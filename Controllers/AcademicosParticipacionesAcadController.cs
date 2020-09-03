using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Fiver.Mvc.FileUpload.Models.Home;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGCFIEE.Controllers
{
    public class AcademicosParticipacionesAcadController : Controller
    {
        // GET: /<controller>/
        [Authorize]
        //Función para mostrar la información de los Arbitraje de productos académicos que presentan los académicos.
        public IActionResult IndexArbitraje()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaEvaluadores fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaEvaluadores> ListEvaluadores = new List<TablaEvaluadores>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivos Arbitraje de productos académicos.
                ListEvaluadores = (from datos in context.EvaluadoresAcademicos
                                   join tipo in context.TipoEvaluador on datos.IdTipoEvaluador equals tipo.IdTipoEvaluador
                                   select new TablaEvaluadores
                                   {
                                       IdEvaluadores = datos.IdEvaluadoresAcademicos,
                                       Archivo = datos.Archivo,
                                       Tipo = tipo.Nombre,
                                       RevisorEvaluador = datos.RevisorEvaluador,
                                       StatusEvaluador = datos.Status
                                   }
                               ).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de algun Arbitraje y darle el permiso de modificar dichos registros.
                    List<Academicosevaluadores> ListAcad = new List<Academicosevaluadores>();
                    ListAcad = context.Academicosevaluadores.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListEvaluadores);
        }
        [Authorize]
        //Función para acceder a la vista de agregar el arbitraje y obtener los datos necesarios para los select.
        public IActionResult CrearArbitraje()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var tipo = context.TipoEvaluador.ToList(); //Obtención de los tipos de evaluadores de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["evaluadores"] = tipo;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear arbitraje de productos académicos.
        public async Task<IActionResult> GuardarArbitraje(IFormFile file, EvaluadoresAcademicos datos, int idAcademico, int Lider)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "EvaluadoresAcademicos".
                var ListEvaluador = context.EvaluadoresAcademicos.ToList(); //Se obtienen los registros de la tabla.
                foreach (EvaluadoresAcademicos item in ListEvaluador)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdTipoEvaluador == item.IdTipoEvaluador && datos.RevisorEvaluador == item.RevisorEvaluador)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexArbitraje");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.EvaluadoresAcademicos.Add(datos); //Guardado de la información.
                context.SaveChanges();
                EvaluadoresAcademicos DatosEval = context.EvaluadoresAcademicos.Last(); //Se obtiene el registro anteriormente guardado, para poder modificar el nombre del archivo y evitar sobre escritura.
                var new_name_table = DatosEval.IdEvaluadoresAcademicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.EvaluadoresAcademicos.Update(datos); //Actualización de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdEvaluadoresAcademicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/Arbitraje", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al académico creador del arbitraje en la tabla Academicosevaluadores.
                EvaluadoresAcademicos DatosCT = context.EvaluadoresAcademicos.Last();
                Academicosevaluadores info = new Academicosevaluadores();
                info.IdAcademico = idAcademico;
                info.IdEvaluadores = DatosCT.IdEvaluadoresAcademicos; //Guardado de la información.
                info.Lider = Lider;
                context.Academicosevaluadores.Add(info); 
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexArbitraje");
        }
        [Authorize]
        //Función para acceder a la vista de editar el arbitraje y obtener los datos necesarios para los select.
        public IActionResult EditarArbitraje(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Obtención de los datos a editar.
                EvaluadoresAcademicos DatosEvaluadores = context.EvaluadoresAcademicos.Where(s => s.IdEvaluadoresAcademicos == id).Single();


                var tipo = context.TipoEvaluador.ToList(); //Obtención de los tipos de evaluador de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["evaluadores"] = tipo;
                return View(DatosEvaluadores);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar arbitraje de productos académicos.
        public async Task<IActionResult> ActualizarArbitraje(IFormFile file, EvaluadoresAcademicos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "EvaluadoresAcademicos".
                var ListEvaluador = context.EvaluadoresAcademicos.Where(e => e.IdEvaluadoresAcademicos != datos.IdEvaluadoresAcademicos).ToList(); //Se obtienen los registros de la tabla.
                foreach (EvaluadoresAcademicos item in ListEvaluador)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizaran los datos.
                    if (datos.IdTipoEvaluador == item.IdTipoEvaluador && datos.RevisorEvaluador == item.RevisorEvaluador)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexArbitraje");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.EvaluadoresAcademicos.Where(w => w.IdEvaluadoresAcademicos == datos.IdEvaluadoresAcademicos).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdEvaluadoresAcademicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.EvaluadoresAcademicos.Update(datos); //Actualizado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo ha guardar, se redirecciona al index correspondiente.
                return RedirectToAction("IndexArbitraje");
            }
            var new_name_file = datos.IdEvaluadoresAcademicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/Arbitraje", new_name_file); //Se acompleta la ruta del archivo.

            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexArbitraje");
        }
        //Función para eliminar un registro del arbitraje.
        public IActionResult EliminarArbitraje(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicosevaluadores> eliminarAcad = context.Academicosevaluadores.Where(f => f.IdEvaluadores == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico con el regitro.
                    context.Academicosevaluadores.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
                EvaluadoresAcademicos eliminar = context.EvaluadoresAcademicos.Where(w => w.IdEvaluadoresAcademicos == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.EvaluadoresAcademicos.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexArbitraje");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre el arbitraje.
        public async Task<IActionResult> DescargarArbitraje(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/ParticipacionAcad/Arbitraje", filename);
            //Busqueda y descarga del archivo.
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        [Authorize]
        //Función para mostrar la información académicos colaboradores de un respectivo arbitraje seleccionado.
        public IActionResult AcademicosArbitraje(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipoUsu es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadArbitraje fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadArbitraje> ListAcadArbitraje = new List<TablaAcadArbitraje>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con el arbitraje de productos académicos.
                ListAcadArbitraje = (from datos in context.Academicosevaluadores
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     where datos.IdEvaluadores == id
                                     select new TablaAcadArbitraje
                                     {
                                         IdAcadEvaluadores = datos.IdAcademicosEvaluadores,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         idEvaluadores = datos.IdEvaluadores
                                     }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idArbitraje"] = id;
                
                Academicosevaluadores Acad = new Academicosevaluadores();
                //Se busca si el academico usuario es lider del arbitraje seleccionado, esto comparando si el campo lider es igual = 1.
                int cant = context.Academicosevaluadores.Where(w => w.IdEvaluadores == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicosevaluadores.Where(w => w.IdEvaluadores == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadArbitraje);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de un arbitraje de productos académicos.
        public IActionResult GuardarAcadArbitraje(int idAcademico, int arbitraje, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicosevaluadores AcadArbitraje = new Academicosevaluadores();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "Academicosevaluadores".
                var ListAcad = context.Academicosevaluadores.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicosevaluadores item in ListAcad)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademico && arbitraje == item.IdEvaluadores)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosArbitraje", new { id = arbitraje });
                    }
                }
                AcadArbitraje.Lider = Lider;
                AcadArbitraje.IdAcademico = idAcademico;
                AcadArbitraje.IdEvaluadores = arbitraje;
                context.Academicosevaluadores.Add(AcadArbitraje); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosArbitraje", new { id = AcadArbitraje.IdEvaluadores });
        }
        [Authorize]
        //Función para eliminar la relación un academico al arbitraje.
        public IActionResult EliminarAcadArbitraje(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicosevaluadores eliminar = context.Academicosevaluadores.Where(w => w.IdAcademicosEvaluadores == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Academicosevaluadores.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("AcademicosArbitraje", new { id = id_acad });
            }
        }





        [Authorize]
        //Función para mostrar la información de los Cursos o Talleres que presentan los académicos.
        public IActionResult IndexCursos_Talleres()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaCursoTaller fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaCursoTaller> ListCursoTaller = new List<TablaCursoTaller>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivos Cursos o talleres.
                ListCursoTaller = (from datos in context.CursosTalleresAplicacion
                                   select new TablaCursoTaller
                                   {
                                       IdCursoTaller = datos.IdCursosTalleres,
                                       Archivo = datos.Archivo,
                                       Tipo = datos.CT,
                                       Titulo = datos.Titulo,
                                       Fecha = datos.Fecha.ToString()
                                   }
                               ).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de algun Curso o taller y darle el permiso de modificar dichos registros.
                    List<Academicoscursostaller> ListAcad = new List<Academicoscursostaller>();
                    ListAcad = context.Academicoscursostaller.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListCursoTaller);
        }
        [Authorize]
        //Función para acceder a la vista de agregar cursos o talleres y obtener los datos necesarios para los select.
        public IActionResult CrearCursos_Talleres()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear cursos o talleres.
        public async Task<IActionResult> GuardarCursos_Talleres(IFormFile file, CursosTalleresAplicacion datos, int idAcademico, int Lider)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "CursosTalleresAplicacion".
                var ListCurTalle = context.CursosTalleresAplicacion.ToList(); //Se obtienen los registros de la tabla.
                foreach (CursosTalleresAplicacion item in ListCurTalle)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.CT == item.CT && datos.Titulo == item.Titulo && datos.Fecha == item.Fecha)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexCursos_Talleres");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.CursosTalleresAplicacion.Add(datos); //Guardado de la información.
                context.SaveChanges();
                CursosTalleresAplicacion DatosCT = context.CursosTalleresAplicacion.Last(); //Se obtiene el registro anteriormente guardado, para poder modificar el nombre del archivo y evitar sobre escritura.
                var new_name_table = DatosCT.IdCursosTalleres + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.CursosTalleresAplicacion.Update(datos); //Actualización de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdCursosTalleres + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/CursosTalleres", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            //Se guarda al académico creador del curso o taller en la tabla Academicoscursostaller.
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CursosTalleresAplicacion DatosCT = context.CursosTalleresAplicacion.Last();
                Academicoscursostaller info = new Academicoscursostaller();
                info.IdAcademico = idAcademico;
                info.IdCursosDiplo = DatosCT.IdCursosTalleres;
                info.Lider = Lider;
                context.Academicoscursostaller.Add(info); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexCursos_Talleres");
        }
        [Authorize]
        //Función para acceder a la vista de editar cursos o talleres y obtener los datos necesarios para los select.
        public IActionResult EditarCursos_Talleres(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Obtención de los datos a editar.
                CursosTalleresAplicacion DatosCursosTalleres = context.CursosTalleresAplicacion.Where(s => s.IdCursosTalleres == id).Single();

                //Obtención de la fecha (como en la base de datos las fechas son datetime, este proceso se realiza para eliminar la hora de la fecha).
                string fecha = DatosCursosTalleres.Fecha.ToString();
                string[] resultado = fecha.Split(' ');
                ViewData["fecha"] = resultado[0];
                return View(DatosCursosTalleres);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar cursos o talleres.
        public async Task<IActionResult> ActualizarCursos_Talleres(IFormFile file, CursosTalleresAplicacion datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "CursosTalleresAplicacion".
                var ListCurTalle = context.CursosTalleresAplicacion.Where(c => c.IdCursosTalleres != datos.IdCursosTalleres).ToList(); //Se obtienen los registros de la tabla.
                foreach (CursosTalleresAplicacion item in ListCurTalle)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizaran los datos.
                    if (datos.CT == item.CT && datos.Titulo == item.Titulo && datos.Fecha == item.Fecha)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexCursos_Talleres");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.CursosTalleresAplicacion.Where(w => w.IdCursosTalleres == datos.IdCursosTalleres).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdCursosTalleres + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CursosTalleresAplicacion.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo a guardar, se redirecciona al index correspondiente.
                return RedirectToAction("IndexCursos_Talleres");
            }
            var new_name_file = datos.IdCursosTalleres + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/CursosTalleres", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexCursos_Talleres");
        }
        //Función para eliminar un registro de cursos o talleres.
        public IActionResult EliminarCursos_Talleres(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicoscursostaller> eliminarAcad = context.Academicoscursostaller.Where(f => f.IdCursosDiplo == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico con el regitro.
                    context.Academicoscursostaller.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
                CursosTalleresAplicacion eliminar = context.CursosTalleresAplicacion.Where(w => w.IdCursosTalleres == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.CursosTalleresAplicacion.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexCursos_Talleres");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre cursos o talleres.
        public async Task<IActionResult> DescargarCursos_Talleres(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/ParticipacionAcad/CursosTalleres", filename);
            
            //Busqueda y descarga del archivo.
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        [Authorize]
        //Función para mostrar la información de académicos colaboradores de un respectivo curso o taller.
        public IActionResult AcademicosCursos_Talleres(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipoUsu es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadCursoTalleres fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadCursoTalleres> ListAcadCursoTaller = new List<TablaAcadCursoTalleres>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con un curso o taller.
                ListAcadCursoTaller = (from datos in context.Academicoscursostaller
                                       join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                       where datos.IdCursosDiplo == id
                                       select new TablaAcadCursoTalleres
                                       {
                                           IdAcadCursoTalleres = datos.IdAcademicosCursosTaller,
                                           NumPersonal = acad.NumeroPersonal,
                                           Nombre = acad.Nombre,
                                           ApellidoPaterno = acad.ApellidoPaterno,
                                           ApellidoMaterno = acad.ApellidoMaterno,
                                           idCursosTalleres = datos.IdCursosDiplo
                                       }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idCursoTaller"] = id;

                //Se busca si el academico usuario es lider de un curso o taller seleccionado, esto comparando si el campo lider es igual = 1.
                Academicoscursostaller Acad = new Academicoscursostaller();
                int cant = context.Academicoscursostaller.Where(w => w.IdCursosDiplo == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicoscursostaller.Where(w => w.IdCursosDiplo == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadCursoTaller);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de un curso o taller.
        public IActionResult GuardarAcadCursos_Talleres(int idAcademico, int cursotaller, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicoscursostaller AcadCursoTaller = new Academicoscursostaller();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Academicoscursostaller".
                var ListAcad = context.Academicoscursostaller.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicoscursostaller item in ListAcad)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademico && cursotaller == item.IdCursosDiplo)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosCursos_Talleres", new { id = cursotaller });
                    }
                }
                AcadCursoTaller.Lider = Lider;
                AcadCursoTaller.IdAcademico = idAcademico;
                AcadCursoTaller.IdCursosDiplo = cursotaller;
                context.Academicoscursostaller.Add(AcadCursoTaller); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosCursos_Talleres", new { id = AcadCursoTaller.IdCursosDiplo });
        }
        [Authorize]
        //Función para eliminar a los academicos relacionados con un curso o taller.
        public IActionResult EliminarAcadCursos_Talleres(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicoscursostaller eliminar = context.Academicoscursostaller.Where(w => w.IdAcademicosCursosTaller == id).Single(); //Busqueda del académico relacionado con el registro, condicionado por el id recibido.
                context.Academicoscursostaller.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("AcademicosCursos_Talleres", new { id = id_acad });
            }
        }



        [Authorize]
        //Función para mostrar la información de la Participación en cuerpos académicos que presentan los académicos.
        public IActionResult IndexPartCuerpos()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaCA fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaCA> ListCA = new List<TablaCA>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivas Participación en cuerpos académicos.
                ListCA = (from datos in context.CaAcademicos
                          join nivel in context.CanivelJerarquico on datos.IdCanivelJerarquico equals nivel.IdCanivelJerarquico
                          join cuerpo in context.CuerposAcademicos on datos.IdCuerpoAcademico equals cuerpo.IdCuerpoAcademico
                          select new TablaCA
                          {
                              IdCA = datos.IdCa,
                              Archivo = datos.Archivo,
                              Fecha = datos.FechaRegistro.ToString(),
                              StatusAcademico = datos.Status,
                              NombreNivel = nivel.Nombre,
                              NombreCuerpo = cuerpo.Nombre
                          }
                               ).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de alguna Participación en cuerpos académicos y darle el permiso de modificar dichos registros.
                    List<Academicoscuerposacad> ListAcad = new List<Academicoscuerposacad>();
                    ListAcad = context.Academicoscuerposacad.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListCA);
        }
        [Authorize]
        //Función para acceder a la vista de agregar Participación en cuerpos académicos y obtener los datos necesarios para los select.
        public IActionResult CrearPartCuerpos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var nivel = context.CanivelJerarquico.ToList(); //Obtención de los niveles jerarquicos de la base de datos.
                var cuerpo = context.CuerposAcademicos.ToList(); //Obtención de los cuerpos académicos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["nivel"] = nivel;
                ViewData["cuerpo"] = cuerpo;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear participación en cuerpos académicos.
        public async Task<IActionResult> GuardarPartCuerpos(IFormFile file, CaAcademicos datos, int idAcademico, int Lider)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "CaAcademicos".
                var ListCA = context.CaAcademicos.ToList(); //Se obtienen los registros de la tabla.
                foreach (CaAcademicos item in ListCA)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdCanivelJerarquico == item.IdCuerpoAcademico && datos.IdCuerpoAcademico == item.IdCuerpoAcademico && datos.FechaRegistro == item.FechaRegistro && datos.Status == item.Status)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexPartCuerpos");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.CaAcademicos.Add(datos); //Guardado de la información.
                context.SaveChanges();
                CaAcademicos DatosCA = context.CaAcademicos.Last(); //Se obtiene el registro anteriormente guardado, para poder modificar el nombre del archivo y evitar sobre escritura.
                var new_name_table = DatosCA.IdCa + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.CaAcademicos.Update(datos); //Actualizado de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdCa + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/CuerposAcademicos", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al académico creador del arbitraje en la tabla Academicoscuerposacad.
                CaAcademicos DatosCA = context.CaAcademicos.Last();
                Academicoscuerposacad info = new Academicoscuerposacad();
                info.IdAcademico = idAcademico;
                info.IdCuerpoAcad = DatosCA.IdCa;
                info.Lider = Lider;
                context.Academicoscuerposacad.Add(info); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexPartCuerpos");
        }
        [Authorize]
        //Función para acceder a la vista de editar Participación en cuerpos académicos y obtener los datos necesarios para los select.
        public IActionResult EditarPartCuerpos(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CaAcademicos DatosCA = context.CaAcademicos.Where(s => s.IdCa == id).Single(); //Obtención de los datos a editar.
                var nivel = context.CanivelJerarquico.ToList(); //Obtención de los niveles jerarquicos de la base de datos.
                var cuerpo = context.CuerposAcademicos.ToList(); //Obtención de los cuerpos académicos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["nivel"] = nivel;
                ViewData["cuerpo"] = cuerpo;
                //Obtención de la fecha (como en la base de datos las fechas son datetime, este proceso se realiza para eliminar la hora de la fecha).
                string fecha = DatosCA.FechaRegistro.ToString();
                string[] resultado = fecha.Split(' ');
                ViewData["fecha"] = resultado[0];
                return View(DatosCA);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar participación de cuerpos académicos.
        public async Task<IActionResult> ActualizarPartCuerpos(IFormFile file, CaAcademicos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "CaAcademicos".
                var ListCA = context.CaAcademicos.Where(a => a.IdCa != datos.IdCa).ToList(); //Se obtienen los registros de la tabla.
                foreach (CaAcademicos item in ListCA)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizaran los datos.
                    if (datos.IdCanivelJerarquico == item.IdCuerpoAcademico && datos.IdCuerpoAcademico == item.IdCuerpoAcademico && datos.FechaRegistro == item.FechaRegistro && datos.Status == item.Status)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexPartCuerpos");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.CaAcademicos.Where(w => w.IdCa == datos.IdCa).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdCa + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CaAcademicos.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo a guardar, se redirecciona al index correspondiente.
                return RedirectToAction("IndexPartCuerpos");
            }
            var new_name_file = datos.IdCa + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/CuerposAcademicos", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPartCuerpos");
        }
        //Función para eliminar un registro de participacion en cuerpos academicos.
        public IActionResult EliminarPartCuerpos(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicoscuerposacad> eliminarAcad = context.Academicoscuerposacad.Where(f => f.IdCuerpoAcad == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico con el regitro.
                    context.Academicoscuerposacad.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }

                CaAcademicos eliminar = context.CaAcademicos.Where(w => w.IdCa == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.CaAcademicos.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexPartCuerpos");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre participación de cuerpos académicos.
        public async Task<IActionResult> DescargarPartCuerpos(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/ParticipacionAcad/CuerposAcademicos", filename);
            //Busqueda y descarga del archivo.
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        [Authorize]
        //Función para mostrar la información de académicos colaboradores de un respectivo a participación de cuerpos académicos seleccionado.
        public IActionResult AcademicosPartCuerpos(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipoUsu es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadPartCuerpos fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadPartCuerpos> ListAcadPartCuerpos = new List<TablaAcadPartCuerpos>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con la participación de cuerpos académicos académicos.
                ListAcadPartCuerpos = (from datos in context.Academicoscuerposacad
                                       join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                       where datos.IdCuerpoAcad == id
                                       select new TablaAcadPartCuerpos
                                       {
                                           IdAcadCuerpoAcad = datos.IdAcademicosCuerposAcad,
                                           NumPersonal = acad.NumeroPersonal,
                                           Nombre = acad.Nombre,
                                           ApellidoPaterno = acad.ApellidoPaterno,
                                           ApellidoMaterno = acad.ApellidoMaterno,
                                           idCuerpo = datos.IdCuerpoAcad
                                       }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idCuerpoAcad"] = id;

                //Se busca si el academico usuario es lider de participación de un cuerpo academico seleccionado, esto comparando si el campo lider es igual = 1.
                Academicoscuerposacad Acad = new Academicoscuerposacad();
                int cant = context.Academicoscuerposacad.Where(w => w.IdCuerpoAcad == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicoscuerposacad.Where(w => w.IdCuerpoAcad == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadPartCuerpos);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de una participación de cuerpos académicos.
        public IActionResult GuardarAcadPartCuerpos(int idAcademico, int cuerpoacademico, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicoscuerposacad AcadCuerpoAcad = new Academicoscuerposacad();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Academicoscuerposacad".
                var ListAcad = context.Academicoscuerposacad.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicoscuerposacad item in ListAcad)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademico && cuerpoacademico == item.IdCuerpoAcad)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosPartCuerpos", new { id = cuerpoacademico });
                    }
                }
                AcadCuerpoAcad.Lider = Lider;
                AcadCuerpoAcad.IdAcademico = idAcademico;
                AcadCuerpoAcad.IdCuerpoAcad = cuerpoacademico;
                context.Academicoscuerposacad.Add(AcadCuerpoAcad); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosPartCuerpos", new { id = AcadCuerpoAcad.IdCuerpoAcad });
        }
        [Authorize]
        //Función para eliminar a los academicos relacionados con una participacion en cuerpos académicos.
        public IActionResult EliminarAcadPartCuerpos(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicoscuerposacad eliminar = context.Academicoscuerposacad.Where(w => w.IdAcademicosCuerposAcad == id).Single(); //Busqueda del académico relacionado con el registro, condicionado por el id recibido.
                context.Academicoscuerposacad.Remove(eliminar); //Se elimina la relación del academico con el regitro.
                context.SaveChanges();
                return RedirectToAction("AcademicosPartCuerpos", new { id = id_acad });
            }
        }



        [Authorize]
        //Función para mostrar la información de las Ponencias o Conferencias que presentan los académicos.
        public IActionResult IndexPonencias_Conferencias()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaPonenciasConferencias fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaPonenciasConferencias> ListPonenciasConferencias = new List<TablaPonenciasConferencias>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivas ponencias o conferencias.
                ListPonenciasConferencias = (from datos in context.PonenciasConferencias
                                             join tipo in context.TipoLocNacInter on datos.IdTipo equals tipo.IdTipo
                                             select new TablaPonenciasConferencias
                                             {
                                                 IdPonenConfer = datos.IdPonencias,
                                                 Archivo = datos.Archivo,
                                                 Fecha = datos.Fecha.ToString(),
                                                 NombrePonConf = datos.Nombre,
                                                 TipoPonenConfe = datos.PonenciaConferencia,
                                                 tipo = tipo.Nombre
                                             }
                            ).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de alguna ponencia o conferencia y darle el permiso de modificar dichos registros.
                    List<Academicoponenciasconf> ListAcad = new List<Academicoponenciasconf>();
                    ListAcad = context.Academicoponenciasconf.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListPonenciasConferencias);
        }
        [Authorize]
        //Función para acceder a la vista de agregar ponencias o conferencias y obtener los datos necesarios para los select.
        public IActionResult CrearPonencias_Conferencias()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var nac = context.TipoLocNacInter.ToList(); //Obtención de los tipos de localización (nacional, local e internacional) de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["nac"] = nac;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear ponencias o conferencias.
        public async Task<IActionResult> GuardarPonencias_Conferencias(IFormFile file, PonenciasConferencias datos, int idAcademico, int Lider)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "PonenciasConferencias".
                var ListPonConf = context.PonenciasConferencias.ToList(); //Se obtienen los registros de la tabla.
                foreach (PonenciasConferencias item in ListPonConf)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.PonenciaConferencia == item.PonenciaConferencia && datos.IdTipo == item.IdTipo && datos.Fecha == item.Fecha && datos.Nombre == item.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexPonencias_Conferencias");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.PonenciasConferencias.Add(datos); //Guardado de la información.
                context.SaveChanges();
                PonenciasConferencias DatosPC = context.PonenciasConferencias.Last(); // Se obtiene el registro anteriormente guardado, para poder modificar el nombre del archivo y evitar sobre escritura.
                 var new_name_table = DatosPC.IdPonencias + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.PonenciasConferencias.Update(datos); //Actualizacion de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdPonencias + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/PonenciasConferencias", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al académico creador del ponencias o conferencias en la tabla Academicoponenciasconf.
                PonenciasConferencias DatosPC = context.PonenciasConferencias.Last();
                Academicoponenciasconf info = new Academicoponenciasconf();
                info.IdAcademico = idAcademico;
                info.IdPonenciasConf = DatosPC.IdPonencias;
                info.Lider = Lider;
                context.Academicoponenciasconf.Add(info); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexPonencias_Conferencias");
        }
        [Authorize]
        //Función para acceder a la vista de editar ponencias o conferencias y obtener los datos necesarios para los select.
        public IActionResult EditarPonencias_Conferencias(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                PonenciasConferencias DatosPC = context.PonenciasConferencias.Where(s => s.IdPonencias == id).Single(); //Obtención de los datos a editar.

                var nac = context.TipoLocNacInter.ToList(); //Obtención de los tipos de localización (Local, Nacional e Internacional) de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["nac"] = nac;
                //Obtención de la fecha (como en la base de datos las fechas son datetime, este proceso se realiza para eliminar la hora de la fecha).
                string fecha = DatosPC.Fecha.ToString();
                string[] resultado = fecha.Split(' ');
                ViewData["fecha"] = resultado[0];
                return View(DatosPC);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar ponencias o conferencias.
        public async Task<IActionResult> ActualizarPonencias_Conferencias(IFormFile file, PonenciasConferencias datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "PonenciasConferencias".
                var ListPonConf = context.PonenciasConferencias.Where(p => p.IdPonencias != datos.IdPonencias).ToList(); //Se obtienen los registros de la tabla.
                foreach (PonenciasConferencias item in ListPonConf)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizaran los datos.
                    if (datos.PonenciaConferencia == item.PonenciaConferencia && datos.IdTipo == item.IdTipo && datos.Fecha == item.Fecha && datos.Nombre == item.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexPonencias_Conferencias");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.PonenciasConferencias.Where(w => w.IdPonencias == datos.IdPonencias).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdPonencias + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.PonenciasConferencias.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo ha actualizar, se redirecciona al index.
                return RedirectToAction("IndexPonencias_Conferencias");
            }
            var new_name_file = datos.IdPonencias + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/ParticipacionAcad/PonenciasConferencias", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPonencias_Conferencias");
        }
        //Función para eliminar un registro de ponencias o conferencias.
        public IActionResult EliminarPonencias_Conferencias(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicoponenciasconf> eliminarAcad = context.Academicoponenciasconf.Where(f => f.IdPonenciasConf == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico con el regitro.
                    context.Academicoponenciasconf.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
                PonenciasConferencias eliminar = context.PonenciasConferencias.Where(w => w.IdPonencias == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.PonenciasConferencias.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexPonencias_Conferencias");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre las ponencias o conferencias.
        public async Task<IActionResult> DescargarPonencias_Conferencias(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/ParticipacionAcad/PonenciasConferencias", filename);
            //Busqueda y descarga del archivo.
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        [Authorize]
        //Función para mostrar la información de académicos colaboradores de un respectiva ponencia o conferencia seleccionado.
        public IActionResult AcademicosPonencias_Conferencias(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipoUsu es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadPonenciaConf fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadPonenciaConf> ListAcadPonenciasConfe = new List<TablaAcadPonenciaConf>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con la ponencia o conferencia.
                ListAcadPonenciasConfe = (from datos in context.Academicoponenciasconf
                                          join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                          where datos.IdPonenciasConf == id
                                          select new TablaAcadPonenciaConf
                                          {
                                              IdAcadPonenciaConfe = datos.IdAcademicoPonenciasConf,
                                              NumPersonal = acad.NumeroPersonal,
                                              Nombre = acad.Nombre,
                                              ApellidoPaterno = acad.ApellidoPaterno,
                                              ApellidoMaterno = acad.ApellidoMaterno,
                                              idPonencia = datos.IdPonenciasConf
                                          }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idPonencia"] = id;
                //Se busca si el academico usuario es lider de una ponencia o conferencia seleccionado, esto comparando si el campo lider es igual = 1.
                Academicoponenciasconf Acad = new Academicoponenciasconf();
                int cant = context.Academicoponenciasconf.Where(w => w.IdPonenciasConf == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicoponenciasconf.Where(w => w.IdPonenciasConf == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadPonenciasConfe);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de ponencias o conferencias.
        public IActionResult GuardarAcadPonencias_Conferencias(int idAcademico, int ponencia, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicoponenciasconf AcadPonenciaConfe = new Academicoponenciasconf();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Academicoponenciasconf".
                var ListAcad = context.Academicoponenciasconf.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicoponenciasconf item in ListAcad)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademico && ponencia == item.IdPonenciasConf)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosPonencias_Conferencias", new { id = ponencia });
                    }
                }
                AcadPonenciaConfe.Lider = Lider;
                AcadPonenciaConfe.IdAcademico = idAcademico;
                AcadPonenciaConfe.IdPonenciasConf = ponencia;
                context.Academicoponenciasconf.Add(AcadPonenciaConfe); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosPonencias_Conferencias", new { id = AcadPonenciaConfe.IdPonenciasConf });
        }
        [Authorize]
        //Función para eliminar a un academico relacionado con una ponencia o conferencia.
        public IActionResult EliminarAcadPonencias_Conferencias(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicoponenciasconf eliminar = context.Academicoponenciasconf.Where(w => w.IdAcademicoPonenciasConf == id).Single(); //Busqueda del académico relacionado con el registro, condicionado por el id recibido.
                context.Academicoponenciasconf.Remove(eliminar); //Se elimina la relación del academico con el regitro.
                context.SaveChanges();
                return RedirectToAction("AcademicosPonencias_Conferencias", new { id = id_acad });
            }
        }




        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        //Función donde se encuentran las extenciones de tipos de descarga en el sistema.
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
                    {
                        {".txt", "text/plain"},
                        {".pdf", "application/pdf"},
                        {".doc", "application/vnd.ms-word"},
                        {".docx", "application/vnd.ms-word"},
                        {".xls", "application/vnd.ms-excel"},
                        {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                        {".png", "image/png"},
                        {".jpg", "image/jpeg"},
                        {".jpeg", "image/jpeg"},
                        {".gif", "image/gif"},
                        {".csv", "text/csv"},
                        {".pptx","application/vnd.openxmlformats-officedocument.presentationml.presentation"},
                        {".rar","application/x-rar-compressed"},
                        {".zip","application/zip"}
                    };
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
