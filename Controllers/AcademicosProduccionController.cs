using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Fiver.Mvc.FileUpload.Models.Home;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGCFIEE.Controllers
{
    public class AcademicosProduccionController : Controller
    {
        // GET: /<controller>/
        [Authorize]
        //Función para mostrar la información de los libros para una EE que presentan los académicos.
        public IActionResult IndexLibroEE()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaLibroEE fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaLibroEE> ListLibroEE = new List<TablaLibroEE>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1)
                {
                    //Consulta para obtener a todos los academicos con sus respectivos libros para una EE.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 1 (director).
                    ListLibroEE = (from datos in context.Libroee
                                   join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                   join perio in context.TipoPeriodo on datos.IdPeriodo equals perio.IdPeriodo
                                   select new TablaLibroEE
                                   {
                                       IdLibroEE = datos.IdLibroEe,
                                       NumPersonal = acad.NumeroPersonal,
                                       Nombre = acad.Nombre,
                                       ApellidoPaterno = acad.ApellidoPaterno,
                                       ApellidoMaterno = acad.ApellidoMaterno,
                                       NombreLibro = datos.Nombre,
                                       Archivo = datos.Archivo,
                                       Periodo = perio.Nombre,
                                       Status = acad.Status
                                   }
                               ).ToList();
                }
                if (tipo == 2)
                {
                    //Consulta para obtener los respectivos libros para una EE del usuario que este ingresando al sistema.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 2 (académico).
                    ListLibroEE = (from datos in context.Libroee
                                   join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                   join perio in context.TipoPeriodo on datos.IdPeriodo equals perio.IdPeriodo
                                   where datos.IdAcademico == idUsu
                                   select new TablaLibroEE
                                   {
                                       IdLibroEE = datos.IdLibroEe,
                                       NumPersonal = acad.NumeroPersonal,
                                       Nombre = acad.Nombre,
                                       ApellidoPaterno = acad.ApellidoPaterno,
                                       ApellidoMaterno = acad.ApellidoMaterno,
                                       NombreLibro = datos.Nombre,
                                       Archivo = datos.Archivo,
                                       Periodo = perio.Nombre,
                                       Status = acad.Status
                                   }
                               ).ToList();
                }
            }
            return View(ListLibroEE); //Envio de los datos a la vista.
        }
        [Authorize]
        //Función para mostrar la información del material didactico que presentan los académicos.
        public IActionResult IndexMaterialDidactico()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaMaterialD fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaMaterialD> ListMaterialD = new List<TablaMaterialD>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1)
                {
                    //Consulta para obtener a todos los academicos con sus respectivos Materiales didacticos.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 1 (director).
                    ListMaterialD = (from datos in context.MateriaDidactico
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     join perio in context.TipoPeriodo on datos.IdPeriodo equals perio.IdPeriodo
                                     select new TablaMaterialD
                                     {
                                         IdMDidactico = datos.IdMateriaDidactico,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         NotasClase = datos.NotasClase,
                                         Acetatos = datos.Acetatos,
                                         Videos = datos.Videos,
                                         Programas = datos.Programas,
                                         Prototipos = datos.Prototipos,
                                         Archivo = datos.Acta,
                                         Periodo = perio.Nombre,
                                         Status = acad.Status
                                     }
                               ).ToList();
                }
                if (tipo == 2)
                {
                    //Consulta para obtener los respectivos materiales didacticos del usuario que este ingresando al sistema.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 2 (académico).
                    ListMaterialD = (from datos in context.MateriaDidactico
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     join perio in context.TipoPeriodo on datos.IdPeriodo equals perio.IdPeriodo
                                     where datos.IdAcademico == idUsu
                                     select new TablaMaterialD
                                     {
                                         IdMDidactico = datos.IdMateriaDidactico,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         NotasClase = datos.NotasClase,
                                         Acetatos = datos.Acetatos,
                                         Videos = datos.Videos,
                                         Programas = datos.Programas,
                                         Prototipos = datos.Prototipos,
                                         Archivo = datos.Acta,
                                         Periodo = perio.Nombre,
                                         Status = acad.Status
                                     }
                               ).ToList();
                }
            }
            return View(ListMaterialD); //Envio de los datos a la vista.
        }
        [Authorize]
        //Función para mostrar la información de los libros para una EE que presentan los académicos.
        public IActionResult IndexMPractica()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaMPractica fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaMPractica> ListMPractica = new List<TablaMPractica>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1)
                {
                    //Consulta para obtener a todos los academicos con sus respectivos manuales de practica.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 1 (director).
                    ListMPractica = (from datos in context.ManualesPractica
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     join perio in context.TipoPeriodo on datos.IdPeriodo equals perio.IdPeriodo
                                     select new TablaMPractica
                                     {
                                         IdMPractica = datos.IdMaterialesPractica,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         NombreManual = datos.Nombre,
                                         Archivo = datos.Archivo,
                                         Periodo = perio.Nombre,
                                         Status = acad.Status
                                     }
                               ).ToList();
                }
                if (tipo == 2)
                {
                    //Consulta para obtener los respectivos manuales de practica del usuario que este ingresando al sistema.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 2 (académico).
                    ListMPractica = (from datos in context.ManualesPractica
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     join perio in context.TipoPeriodo on datos.IdPeriodo equals perio.IdPeriodo
                                     where datos.IdAcademico == idUsu
                                     select new TablaMPractica
                                     {
                                         IdMPractica = datos.IdMaterialesPractica,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         NombreManual = datos.Nombre,
                                         Archivo = datos.Archivo,
                                         Periodo = perio.Nombre,
                                         Status = acad.Status
                                     }
                               ).ToList();
                }
            }
            return View(ListMPractica); //Envio de los datos a la vista.
        }
        [Authorize]
        //Función para mostrar la información de los proyectos educativos innovadores que presentan los académicos.
        public IActionResult IndexProyectosE()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaProyectosEdu fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaProyectosEdu> ListProyectosEdu = new List<TablaProyectosEdu>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1)
                {
                    //Consulta para obtener a todos los academicos con sus respectivos proyectos educativos innovadores.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 1 (director).
                    ListProyectosEdu = (from datos in context.ProyectoEducativos
                                        join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                        join perio in context.TipoPeriodo on datos.IdPeriodo equals perio.IdPeriodo
                                        select new TablaProyectosEdu
                                        {
                                            IdProyectoEdu = datos.IdProyectoEducativos,
                                            NumPersonal = acad.NumeroPersonal,
                                            Nombre = acad.Nombre,
                                            ApellidoPaterno = acad.ApellidoPaterno,
                                            ApellidoMaterno = acad.ApellidoMaterno,
                                            Descripcion = datos.Descripcion,
                                            Archivo = datos.Archivo,
                                            Periodo = perio.Nombre,
                                            Status = acad.Status
                                        }
                               ).ToList();
                }
                if (tipo == 2)
                {
                    //Consulta para obtener los respectivos proyectos educativos innovadores del usuario que este ingresando al sistema.
                    //Esta consulta se realizara cuando el usuario que ingrese al sistema sea de tipo 2 (académico).
                    ListProyectosEdu = (from datos in context.ProyectoEducativos
                                        join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                        join perio in context.TipoPeriodo on datos.IdPeriodo equals perio.IdPeriodo
                                        where datos.IdAcademico == idUsu
                                        select new TablaProyectosEdu
                                        {
                                            IdProyectoEdu = datos.IdProyectoEducativos,
                                            NumPersonal = acad.NumeroPersonal,
                                            Nombre = acad.Nombre,
                                            ApellidoPaterno = acad.ApellidoPaterno,
                                            ApellidoMaterno = acad.ApellidoMaterno,
                                            Descripcion = datos.Descripcion,
                                            Archivo = datos.Archivo,
                                            Periodo = perio.Nombre,
                                            Status = acad.Status
                                        }
                               ).ToList();
                }
            }
            return View(ListProyectosEdu); //Envio de los datos a la vista.
        }


        [Authorize]
        //Función para acceder a la vista de agregar material didactico y obtener los datos necesarios para los select.
        public IActionResult CrearMaterialDidactico()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear material didactico.
        public async Task<IActionResult> GuardarMaterialDidactico(IFormFile file, MateriaDidactico datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "MateriaDidactico".
                var ListMDidactico = context.MateriaDidactico.ToList(); //Se obtienen los registros de la tabla.
                foreach (MateriaDidactico item in ListMDidactico)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexMaterialDidactico");
                    }
                }
                var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Acta = new_name_table;
                context.MateriaDidactico.Add(datos); //Guardado de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/MaterialDidactico", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("IndexMaterialDidactico");
        }
        [Authorize]
        //Función para acceder a la vista de editar el material didactico de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarMaterialDidactico(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                MateriaDidactico DatosMDidactico = context.MateriaDidactico.Where(s => s.IdMateriaDidactico == id).Single(); //Obtención de los datos a editar.
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos de la base de datos.
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosMDidactico);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar material didactico.
        public async Task<IActionResult> ActualizarMaterialDidactico(IFormFile file, MateriaDidactico datos)
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
                //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "MateriaDidactico".
                var ListMaterialDidactico = context.MateriaDidactico.ToList(); //Se obtienen los registros de la tabla.

                foreach (MateriaDidactico item in ListMaterialDidactico)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdMateriaDidactico != item.IdMateriaDidactico)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexMaterialDidactico");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.MateriaDidactico.Where(w => w.IdMateriaDidactico == datos.IdMateriaDidactico).Single();
                    datos.Acta = nomArchivo.Acta;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Acta = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.MateriaDidactico.Update(datos); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo a guardar, se redirecciona al index.
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("IndexMaterialDidactico");
            }
            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/MaterialDidactico", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexMaterialDidactico");
        }
        //Función para eliminar un registro del material didactico.
        public IActionResult EliminarMaterialDidactico(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                MateriaDidactico eliminar = context.MateriaDidactico.Where(w => w.IdMateriaDidactico == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.MateriaDidactico.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexMaterialDidactico");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre el material didactico.
        public async Task<IActionResult> DescargarMaterialDidactico(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Produccion/MaterialDidactico", filename);
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
        //Función para acceder a la vista de agregar manuales de practica y obtener los datos necesarios para los select.
        public IActionResult CrearMPractica()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear Manual de practicas.
        public async Task<IActionResult> GuardarMPractica(IFormFile file, ManualesPractica datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.s
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "ManualesPractica".
                var ListMPractica = context.ManualesPractica.ToList(); //Se obtienen los registros de la tabla.
                foreach (ManualesPractica item in ListMPractica)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexMPractica");
                    }
                }
                var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.ManualesPractica.Add(datos); //Guardado de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/ManualesPractica", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("IndexMPractica");
        }
        [Authorize]
        //Función para acceder a la vista de editar el manual de practica de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarMPractica(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ManualesPractica DatosMPractica = context.ManualesPractica.Where(s => s.IdMaterialesPractica == id).Single(); //Obtención de los datos a editar.
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos de la base de datos.
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosMPractica);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar manuales de practica.
        public async Task<IActionResult> ActualizarMPractica(IFormFile file, ManualesPractica datos)
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
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "ManualesPractica".
                var ListMPractica = context.ManualesPractica.ToList(); //Se obtienen los registros de la tabla.

                foreach (ManualesPractica item in ListMPractica)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizaran los datos.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdMaterialesPractica != item.IdMaterialesPractica)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexMPractica");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.ManualesPractica.Where(w => w.IdMaterialesPractica == datos.IdMaterialesPractica).Single(); 
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ManualesPractica.Update(datos); //Actualización de la información.
                context.SaveChanges();
                
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo ha guardar, se redirecciona al index.
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("IndexMPractica");
            }
            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/ManualesPractica", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("IndexMPractica");
        }
        //Función para eliminar un registro del material de practica.
        public IActionResult EliminarMPractica(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ManualesPractica eliminar = context.ManualesPractica.Where(w => w.IdMaterialesPractica == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.ManualesPractica.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexMPractica");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre el manual de practica.
        public async Task<IActionResult> DescargarMPractica(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Produccion/ManualesPractica", filename);
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
        //Función para acceder a la vista de agregar un libro para una EE y obtener los datos necesarios para los select.
        public IActionResult CrearLibroEE()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
            }
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear libro para una EE.
        public async Task<IActionResult> GuardarLibroEE(IFormFile file, Libroee datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Libroee".
                var ListLibroEE = context.Libroee.ToList(); //Se obtienen los registros de la tabla.
                foreach (Libroee item in ListLibroEE)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexLibroEE");
                    }
                }
                var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.Libroee.Add(datos); //Guardado de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            
            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); // Modificación del nombre del archivo, para evitar la sobreescritura con otros.
             var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/LibroEE", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("IndexLibroEE");
        }
        [Authorize]
        //Función para acceder a la vista de editar un registro de libros para una EE de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarLibroEE(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Libroee DatosLibroEE = context.Libroee.Where(s => s.IdLibroEe == id).Single(); //Obtención de los datos a editar.
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos de la base de datos.
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosLibroEE);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar libro para una EE.
        public async Task<IActionResult> ActualizarLibroEE(IFormFile file, Libroee datos)
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
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Libroee".
                var ListLibroEE = context.Libroee.ToList(); //Se obtienen los registros de la tabla.

                foreach (Libroee item in ListLibroEE)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizaran los datos.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdLibroEe != item.IdLibroEe)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexLibroEE");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.Libroee.Where(w => w.IdLibroEe == datos.IdLibroEe).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.Libroee.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo a guardar, se redirecciona al index.
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("IndexLibroEE");
            }
            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/LibroEE", new_name_file); //Se acompleta la ruta del archivo.

            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexLibroEE");
        }
        //Función para eliminar un registro dd libros para una EE.
        public IActionResult EliminarLibroEE(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Libroee eliminar = context.Libroee.Where(w => w.IdLibroEe == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Libroee.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexLibroEE");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre los libros para una EE.
        public async Task<IActionResult> DescargarLibroEE(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Produccion/LibroEE", filename);
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
        //Función para acceder a la vista de agregar proyecto educativo innovador y obtener los datos necesarios para los select.
        public IActionResult CrearProyectosE()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear proyecto educativo innovador.
        public async Task<IActionResult> GuardarProyectosE(IFormFile file, ProyectoEducativos datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "ProyectoEducativos".
                var ListProyectoEducativo = context.ProyectoEducativos.ToList(); //Se obtienen los registros de la tabla.
                foreach (ProyectoEducativos item in ListProyectoEducativo)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexProyectosE");
                    }
                }
                var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.ProyectoEducativos.Add(datos); //Guardado de la información.
                context.SaveChanges();
            }
            
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/ProyectoEducativoInnovador", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("IndexProyectosE");
        }
        [Authorize]
        //Función para acceder a la vista de editar el proyecto educativo de innovador de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarProyectosE(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ProyectoEducativos DatosProyectosEdu = context.ProyectoEducativos.Where(s => s.IdProyectoEducativos == id).Single(); //Obtención de los datos a editar.
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos de la base de datos.
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                return View(DatosProyectosEdu);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar proyecto educativo innovador.
        public async Task<IActionResult> ActualizarProyectosE(IFormFile file,ProyectoEducativos datos)
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
                //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "ProyectoEducativos".
                var ListProyectosE = context.ProyectoEducativos.ToList(); //Se obtienen los registros de la tabla.

                foreach (ProyectoEducativos item in ListProyectosE)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizarn los datos.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdPeriodo == item.IdPeriodo && datos.IdProyectoEducativos != item.IdProyectoEducativos)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexProyectosE");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.ProyectoEducativos.Where(w => w.IdProyectoEducativos == datos.IdProyectoEducativos).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }
                
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ProyectoEducativos.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo ha guardar, se redirecciona al index.
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("IndexProyectosE");
            }
            var new_name_file = datos.IdPeriodo + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Produccion/ProyectoEducativoInnovador", new_name_file); //Se acompleta la ruta del archivo.

            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexProyectosE");
        }
        //Función para eliminar un registro sobre proyecto de eduación innovador.
        public IActionResult EliminarProyectosE(int id)
        {
             using(sgcfieeContext context = new sgcfieeContext())
            {
                ProyectoEducativos eliminar = context.ProyectoEducativos.Where(w => w.IdProyectoEducativos == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.ProyectoEducativos.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexProyectosE");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre el proyecto de eduacación innovador.
        public async Task<IActionResult> DescargarProyectosE(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Produccion/ProyectoEducativoInnovador", filename);
            //Busqueda y descarga del archivo.
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path),Path.GetFileName(path));
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
