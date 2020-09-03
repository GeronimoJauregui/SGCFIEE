using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;
using Fiver.Mvc.FileUpload.Models.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.IO;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGCFIEE.Controllers
{
    public class AcademicosCoordinadores : Controller
    {
        // GET: /<controller>/
        [Authorize]
        //Funcion para mostrar los datos de los coordinadores de academia.
        public IActionResult IndexAcademia()
        {
            List<TablaAcademia> TablaAcademia = new List<TablaAcademia>(); 
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta de los datos a mostrar en la vista IndexAcademia, obteniendolos en la lista TablaAcademia.
                TablaAcademia = (from datos in context.CoordinadorAcademia
                               join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                               join perioIni in context.TipoPeriodo on datos.IdFechaInicial equals perioIni.IdPeriodo
                               join perioTer in context.TipoPeriodo on datos.IdFechaCierre equals perioTer.IdPeriodo
                               join academia in context.Academias on datos.IdAcadademia equals academia.IdAcademias
                                 select new TablaAcademia
                               {
                                   IdCoordinadorAcademia = datos.IdCoordinadorAcademia,
                                   NumPersonal = acad.NumeroPersonal,
                                   Nombre = acad.Nombre,
                                   ApellidoPaterno = acad.ApellidoPaterno,
                                   ApellidoMaterno = acad.ApellidoMaterno,
                                   NombreAcademia = academia.Nombre,
                                   Archivo = datos.ArchivoActaA,
                                   PeriodoInicio = perioIni.Nombre,
                                   PeriodoTermino = perioTer.Nombre,
                                   Status = acad.Status
                               }
                               ).ToList();
            }
            return View(TablaAcademia); //Paso de información a la vista.
        }
        //Función para acceder a la vista de agregar a un nuevo coordinador de academia y llenar los campos que se requieran.
        [Authorize]
        public IActionResult CrearAcademia()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los académicos registrados en el sistema.
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos registrados en el sistema.
                var academia = context.Academias.Where(s => s.Status == 1).ToList(); //Obtención de los nombres de las academias que este con estatus = 1 (activos).
                //Paso de información a la vista por el diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
                ViewData["academias"] = academia;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar la información ingresada en la vista de agregar academicos de academia.
        public async Task<IActionResult> GuardarAcademia(IFormFile file, CoordinadorAcademia datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Verificación de que la información a guardar no este ya registrada en el sistema.
                var ListAcademia = context.CoordinadorAcademia.ToList(); //Obtención de los datos registrados la tabla CoordinadorAcademia.
                foreach (CoordinadorAcademia item in ListAcademia) //Ciclo para checar registro por registro.
                {
                    //Comparación del registro con la información a guardar.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdFechaInicial == item.IdFechaInicial && datos.IdFechaCierre == item.IdFechaCierre && datos.IdAcadademia == item.IdAcadademia)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexAcademia");
                    }
                }
                var new_name_table = datos.IdFechaInicial+ "_"+ datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename(); //Modificación del nombre del archivo a guardar.
                datos.ArchivoActaA = new_name_table;
                context.CoordinadorAcademia.Add(datos); //Guardado de datos en la tabla CoordinadorAcademia.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");
            //Modificación del nombre del archivo a guardar en la carpeta.
            var new_name_file = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Coordinador/Academia", new_name_file); //Ruta del archivo donde se guardara.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("IndexAcademia");
        }
        [Authorize]
        //Función para acceder a la vista de edición y obtención de los datos que tendran los input a editar.
        public IActionResult EditarAcademia(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CoordinadorAcademia DatosCoorAcademia = context.CoordinadorAcademia.Where(s => s.IdCoordinadorAcademia == id).Single(); //Consulta del registro ha editar.
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos registrados en el sistema.
                var acad = context.Academicos.ToList(); //Obtención de los académicos registrados en el sistema.
                var academia = context.Academias.Where(s => s.Status == 1).ToList(); //Obtención de las academias registradas en el sistema, con el status = 1 (activos).
                //Paso de información a la vista por me dio del diccionario ViewData.
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                ViewData["academias"] = academia;
                return View(DatosCoorAcademia);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar la información obtenida en la vista de edición.
        public async Task<IActionResult> ActualizarAcademia(IFormFile file, CoordinadorAcademia datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Verificación de que la información a actualizar no este ya registrada en el sistema.
                var ListAcademia = context.CoordinadorAcademia.ToList(); //Obtención de los datos registrados la tabla CoordinadorAcademia.

                foreach (CoordinadorAcademia item in ListAcademia)
                {
                    //Comparación del registro con la información a actualizar.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdFechaInicial == item.IdFechaInicial && datos.IdFechaCierre == item.IdFechaCierre && datos.IdAcadademia == item.IdAcadademia && datos.IdCoordinadorAcademia != item.IdCoordinadorAcademia)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexAcademia");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si la variable file esta vacia, no hay archivo ha guardar, entonces se busca el nombre del archivo ya guardado, para que el campo de archivo no se quede vacio.
                    var nomArchivo = context.CoordinadorAcademia.Where(w => w.IdCoordinadorAcademia == datos.IdCoordinadorAcademia).Single();
                    datos.ArchivoActaA = nomArchivo.ArchivoActaA;
                }
                else
                {
                    //Si se encuentra que la variable file tiene información, es que si hay archivo a guardar, por lo tanto se renombra el archivo con las llaves que lo haran unico y se paso a su campo correspondiente.
                    var new_name_table = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
                    datos.ArchivoActaA = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CoordinadorAcademia.Update(datos); //Actualizado de datos en la tabla CoordinadorAcademia.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";

            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo que guardar, entonces se procede por redireccionar a la vista index correspondiente.
                return RedirectToAction("IndexAcademia");
            }
            //Modificación del nombre del archivo a guardar en la carpeta.
            var new_name_file = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Coordinador/Academia", new_name_file); //Ruta del archivo donde se guardara.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            return RedirectToAction("IndexAcademia");
        }
        //Función para la eliminación de un registro de la tabla CoordinadoraAcademia.
        public IActionResult EliminarAcademia(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se busca el registro ha eliminar, con la ayuda del id que nos proporciona la vista.
                CoordinadorAcademia eliminar = context.CoordinadorAcademia.Where(w => w.IdCoordinadorAcademia == id).Single();
                context.CoordinadorAcademia.Remove(eliminar); //Al obtenerlo, se elimina el registro.
                context.SaveChanges(); 
                return RedirectToAction("IndexAcademia");
            }
        }
        //Función para descargar el archivo de evidencia que corresponda.
        public async Task<IActionResult> DescargarAcademia(string filename)
        {
            //Se verifica que la variable filename, tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Coordinador/Academia", filename);
            //Se busca el archivo en la ruta antes acompletada, y se procede con la eliminación.
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }






        [Authorize]
        //Función para mostrar la información de los academicos que pertenecen a un programa trasnversal.
        public IActionResult IndexProgramaTransversal()
        {
            //La clase TablaProgramaTransversal fue creada manualmente para poder tener un solo lugar todos los datos necesarios.
            List<TablaProgramaTransversal> ListProgramaTransversal = new List<TablaProgramaTransversal>(); //Declaracón de una lista ListProgramaTransversal que es donde se obtendran los datos a mostrar.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta de la información a mostrar.
                ListProgramaTransversal = (from datos in context.CoordinadorProgramaTransversal
                                 join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                 join perioIni in context.TipoPeriodo on datos.IdFechaInicial equals perioIni.IdPeriodo
                                 join perioTer in context.TipoPeriodo on datos.IdFechaCierre equals perioTer.IdPeriodo
                                 join programa in context.ProgramasTrasversales on datos.IdPt equals programa.IdProgramasTrasversales
                                 select new TablaProgramaTransversal
                                 {
                                     IdCoordinadorPrograma = datos.IdCoordinadorProgramaTransversal,
                                     NumPersonal = acad.NumeroPersonal,
                                     Nombre = acad.Nombre,
                                     ApellidoPaterno = acad.ApellidoPaterno,
                                     ApellidoMaterno = acad.ApellidoMaterno,
                                     NombrePrograma = programa.Nombre,
                                     Archivo = datos.Evidencia,
                                     PeriodoInicio = perioIni.Nombre,
                                     PeriodoTermino = perioTer.Nombre,
                                     Status = acad.Status
                                 }
                               ).ToList();
            }
            return View(ListProgramaTransversal); //Paso de la información a la vista.
        }
        //Función para acceder a la vista de agregación de un nuevo academico a un programa transversal y obtención de los datos necesarios a mostrar.
        [Authorize]
        public IActionResult CrearProgramaTransversal()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los académicos registrados en el sistema.
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos registrados en el sistema.
                var programa = context.ProgramasTrasversales.Where(s => s.Status == 1).ToList(); //Obtención de los programas transversales que tienen como estado = 1 (activos).
                //Paso de información a la vista por el diccionario ViewData. 
                ViewData["academicos"] = acad;
                ViewData["periodos"] = perio;
                ViewData["programas"] = programa;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos en la vista para agregar.
        public async Task<IActionResult> GuardarProgramaTransversal(IFormFile file, CoordinadorProgramaTransversal datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Verificación que los datos a guardar no este ya registrados en el sistema.
                var ListPrograma = context.CoordinadorProgramaTransversal.ToList(); //Obtención de los registros ya guardados (tabla CoordinadorProgramaTransversal).
                foreach (CoordinadorProgramaTransversal item in ListPrograma)
                {
                    //Comparación de los datos a guardar, con los registros del la base de datos.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdFechaInicial == item.IdFechaInicial && datos.IdFechaCierre == item.IdFechaCierre && datos.IdPt == item.IdPt)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexProgramaTransversal");
                    }
                }
                //Modificación del nombre del archivo a guardar en la base de datos.
                var new_name_table = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
                datos.Evidencia = new_name_table;
                context.CoordinadorProgramaTransversal.Add(datos); //Guardado de los datos en la base de datos.
                context.SaveChanges(); //Confirmación de guardado.
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>"; //Alerta de guardado exitoso al usuario.
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");
            //Modificación del nombre del archivo a guardar en la carpeta.
            var new_name_file = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Coordinador/ProgramaTransversal", new_name_file); //Acompletación de la ruta donde se guardara el archivo.

            //Guardado del archivo en la ruta establecida.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexProgramaTransversal");
        }
        [Authorize]
        //Función para acceder a la vista de edición y obtención de los datos que iran en los input a editar.
        public IActionResult EditarProgramaTransversal(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta a la base de datos de los datos del registro a editar.
                CoordinadorProgramaTransversal DatosCoorPrograma = context.CoordinadorProgramaTransversal.Where(s => s.IdCoordinadorProgramaTransversal == id).Single();
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos registrados en el sistema.
                var acad = context.Academicos.ToList(); //Obtencion de los académicos registrados en el sistema.
                var programa = context.ProgramasTrasversales.Where(s => s.Status == 1).ToList(); //Obtención de los Programas transversales con estado = 1 (activos).
                //Paso de información a la vista por medio del diccionario ViewData.
                ViewData["periodos"] = perio;
                ViewData["academicos"] = acad;
                ViewData["programas"] = programa;
                return View(DatosCoorPrograma);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos en la vista de edicion de los académicos que pertenecen a un programa transversal.
        public async Task<IActionResult> ActualizarProgramaTransversal(IFormFile file, CoordinadorProgramaTransversal datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Verificación que la información ha actualizar no este registrada ya en la base de datos.
                var ListPrograma = context.CoordinadorProgramaTransversal.ToList(); //Obtención de los registros de la base de datos.

                foreach (CoordinadorProgramaTransversal item in ListPrograma)
                {
                    //Comparación de los datos actualizados con los de losregistros ya registrados.
                    if (datos.IdAcademico == item.IdAcademico && datos.IdFechaInicial == item.IdFechaInicial && datos.IdFechaCierre == item.IdFechaCierre && datos.IdPt == item.IdPt && datos.IdCoordinadorProgramaTransversal != item.IdCoordinadorProgramaTransversal)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexProgramaTransversal");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si la varibale file esta vicia, se procede con buscar el nombre del archivo ya guardado para llenar el campo vacio y sea exitosa la actualización.
                    var nomArchivo = context.CoordinadorProgramaTransversal.Where(w => w.IdCoordinadorProgramaTransversal == datos.IdCoordinadorProgramaTransversal).Single();
                    datos.Evidencia = nomArchivo.Evidencia;
                }
                else
                {
                    //Si la variable tiene el nombre del archivo, se procede con modificarlo, para evitar la sobreescritura de algun otro archivo.
                    var new_name_table = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
                    datos.Evidencia = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CoordinadorProgramaTransversal.Update(datos); //Actualización del registro correspondiente.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";

            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo por guardar en la carpeta, termina el proceso y se redirecciona a la vista index correspondiente.
                return RedirectToAction("IndexProgramaTransversal");
            }
            //Modificación del nombre del archivo a guardar en la carpeta.
            var new_name_file = datos.IdFechaInicial + "_" + datos.IdFechaCierre + "_" + datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Coordinador/ProgramaTransversal", new_name_file); //Acompletación de la ruta donde se guardara el archivo.
            //Busqueda de la ruta y guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexProgramaTransversal");
        }
        //Eliminación de un registro de la tabla CoordinadorProgramaTransversal.
        public IActionResult EliminarProgramaTransversal(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Busqueda del registro ha eliminar, con ayuda del id obtenido desde la vista IndexProgramaTransversals
                CoordinadorProgramaTransversal eliminar = context.CoordinadorProgramaTransversal.Where(w => w.IdCoordinadorProgramaTransversal == id).Single();
                context.CoordinadorProgramaTransversal.Remove(eliminar); //Eliminación del registro consultado.
                context.SaveChanges();
                return RedirectToAction("IndexProgramaTransversal");
            }
        }
        //Descarga del archivo de evidencia del academico correspondiente.
        public async Task<IActionResult> DescargarProgramaTransversal(string filename)
        {
            //Verificación que el nombre del archivo venga en la variable filename.
            if (filename == null)
                return Content("filename not present");
            //Acompletación de la ruta donde se encuentra el archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Coordinador/ProgramaTransversal", filename);
            //Busqueda y descarga del archivo.
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }




        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        //Extención de tipos de archivos que se pueden descargar en el sistema.
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
