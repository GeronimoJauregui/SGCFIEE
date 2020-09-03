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
using System.Globalization;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGCFIEE.Controllers
{
    public class AcademicosPublicacionesController : Controller
    {
        // GET: /<controller>/
        [Authorize]
        //Función para mostrar la información de los articulos que presentan los académicos.
        public IActionResult IndexArticulos()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaArticulos fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaArticulos> ListArticulos = new List<TablaArticulos>(); //Declaración de la lista donde se obtendran los datos
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivos articulos.
                ListArticulos = (from datos in context.Articulos
                                 join tipo in context.TipoLocNacInter on datos.IdTipoNI equals tipo.IdTipo
                                 select new TablaArticulos
                                 {
                                     IdArticulos = datos.IdArticulos,
                                     Archivo = datos.Archivo,
                                     Tipo = tipo.Nombre,
                                     Registro = datos.Registro,
                                     Arbitrada = datos.Arbitrada,
                                     NombreArticulo = datos.Nombre,
                                 }
                               ).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de algun articulo y darle el permiso de modificar dichos registros.
                    List<Academicoarticulos> ListAcad = new List<Academicoarticulos>();
                    ListAcad = context.Academicoarticulos.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }

            return View(ListArticulos);
        }
        [Authorize]
        //Función para acceder a la vista de agregar el  articulo de un académico y obtener los datos necesarios para los select.
        public IActionResult CrearArticulos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList(); //Obtención de los datos a editar.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["lugar"] = lugar;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear articulos.
        public async Task<IActionResult> GuardarArticulos(IFormFile file, Articulos datos, int idAcademico, int Lider)
        { 
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Articulos".
                var ListArticulos = context.Articulos.ToList(); //Se obtienen los registros de la tabla.
                foreach (Articulos item in ListArticulos)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdTipoNI == item.IdTipoNI && datos.Nombre == item.Nombre && datos.Registro == item.Registro && datos.Arbitrada == item.Arbitrada)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexArticulos");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.Articulos.Add(datos); //Guardado de la información.
                context.SaveChanges();
                Articulos DatosArticulo = context.Articulos.Last(); //Se obtiene el registro anteriormente guardado, para poder modificar el nombre del archivo y evitar sobre escritura.
                var new_name_table = DatosArticulo.IdArticulos + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Articulos.Update(datos); //Actualización de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdArticulos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Articulos", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al académico creador del articulo en la tabla Academicoarticulos.
                Articulos DatosArticulo = context.Articulos.Last();
                Academicoarticulos info = new Academicoarticulos();
                info.IdAcademico = idAcademico;
                info.IdArticulo = DatosArticulo.IdArticulos;
                info.Lider = Lider;
                context.Academicoarticulos.Add(info); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexArticulos");
        }
        [Authorize]
        //Función para mostrar la información de académicos colaboradores de un respectivo articulo seleccionado.
        public IActionResult AcademicosArticulos(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipoUsu es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadArticulos fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadArticulos> ListAcadArticulos = new List<TablaAcadArticulos>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con el articulo.
                ListAcadArticulos = (from datos in context.Academicoarticulos
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     where datos.IdArticulo == id
                                     select new TablaAcadArticulos
                                     {
                                         IdAcadArticulos = datos.IdAcademicoArticulos,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         idArticulo = datos.IdArticulo
                                     }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idArticulo"] = id;
                //Se busca si el academico usuario es lider del articulo seleccionado, esto comparando si el campo lider es igual = 1.
                Academicoarticulos Acad = new Academicoarticulos();
                int cant = context.Academicoarticulos.Where(w => w.IdArticulo == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicoarticulos.Where(w => w.IdArticulo == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;

            }
            return View(ListAcadArticulos);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de un articulo.
        public IActionResult GuardarAcadArticulos(int idAcademico, int articulo, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            Academicoarticulos AcadArticulos = new Academicoarticulos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Academicoarticulos".
                var ListAcad = context.Academicoarticulos.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicoarticulos item in ListAcad)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademico && articulo == item.IdArticulo)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosArticulos", new { id = articulo });
                    }
                }
                AcadArticulos.IdAcademico = idAcademico;
                AcadArticulos.IdArticulo = articulo;
                AcadArticulos.Lider = Lider;
                context.Academicoarticulos.Add(AcadArticulos); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosArticulos", new { id = AcadArticulos.IdArticulo });
        }
        [Authorize]
        //Función para eliminar a los academicos relacionados con un articulo.
        public IActionResult EliminarAcadArticulos(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicoarticulos eliminar = context.Academicoarticulos.Where(w => w.IdAcademicoArticulos == id).Single(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                context.Academicoarticulos.Remove(eliminar); //Se elimina la relación del academico con el registro.
                context.SaveChanges();
                return RedirectToAction("AcademicosArticulos", new { id = id_acad });
            }
        }
        [Authorize]
        //Función para acceder a la vista de editar el material didactico de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarArticulos(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Articulos DatosArticulo = context.Articulos.Where(s => s.IdArticulos == id).Single(); //Obtención de los datos a editar.
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList(); //Obtención de los datos a editar.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["lugar"] = lugar;
                return View(DatosArticulo);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar articulos.
        public async Task<IActionResult> ActualizarArticulos(IFormFile file, Articulos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "Articulos".
                var ListArticulos = context.Articulos.Where(a => a.IdArticulos != datos.IdArticulos).ToList(); //Se obtienen los registros de la tabla.
                foreach (Articulos item in ListArticulos)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizaran los datos.
                    if (datos.IdTipoNI == item.IdTipoNI && datos.Nombre == item.Nombre && datos.Registro == item.Registro && datos.Arbitrada == item.Arbitrada)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexArticulos");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    // Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                     var nomArchivo = context.Articulos.Where(w => w.IdArticulos == datos.IdArticulos).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdArticulos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.Articulos.Update(datos); //Actualizado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo a guardar, se redireccionara al index correspondientes.
                return RedirectToAction("IndexArticulos");
            }
            var new_name_file = datos.IdArticulos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Articulos", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexArticulos");
        }
        //Función para eliminar un registro de articulos.
        public IActionResult EliminarArticulos(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicoarticulos> eliminarAcad = context.Academicoarticulos.Where(f => f.IdArticulo == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    context.Academicoarticulos.Remove(eliminarAcad[i]); //Se elimina la relación del academico con el registro.
                    context.SaveChanges();
                    i++;
                }

                Articulos eliminar = context.Articulos.Where(w => w.IdArticulos == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Articulos.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexArticulos");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre el articulo.
        public async Task<IActionResult> DescargarArticulos(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/Articulos", filename);
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
        //Función para mostrar la información de los congreso que presentan los académicos.
        public IActionResult IndexCongresos()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaCongresos fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaCongresos> ListCongreso = new List<TablaCongresos>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivos congresos.
                ListCongreso = (from datos in context.Congresos
                                join tipo in context.TipoLocNacInter on datos.IdNacInt equals tipo.IdTipo
                                select new TablaCongresos
                                {
                                    IdCongresos = datos.IdCongresos,
                                    Archivo = datos.Archivo,
                                    Tipo = tipo.Nombre,
                                    NombreCongreso = datos.Nombre
                                }
                               ).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de algun congreso y darle el permiso de modificar dichos registros.
                    List<Academicocongresos> ListAcad = new List<Academicocongresos>();
                    ListAcad = context.Academicocongresos.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListCongreso);
        }
        [Authorize]
        //Función para acceder a la vista de crear el congreso de un académico y obtener los datos necesarios para los select.
        public IActionResult CrearCongresos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList(); //Obtención de las localizaciones de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["lugar"] = lugar;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear congreso.
        public async Task<IActionResult> GuardarCongresos(IFormFile file, Congresos datos, int idAcademico, int Lider)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Congresos".
                var ListArticulos = context.Congresos.ToList(); //Se obtienen los registros de la tabla.
                foreach (Congresos item in ListArticulos)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdNacInt == item.IdNacInt && datos.Nombre == item.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexCongresos");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.Congresos.Add(datos); //Guardado de la información.
                context.SaveChanges();
                Congresos DatosCongreso = context.Congresos.Last(); //Se obtiene el registro anteriormente guardado, para poder modificar el nombre del archivo y evitar sobre escritura.
                var new_name_table = DatosCongreso.IdCongresos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.Congresos.Update(datos); //Actualizado de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdCongresos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Congresos", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al académico creador del congreso en la tabla Academicocongresos.
                Congresos DatosCongresos = context.Congresos.Last();
                Academicocongresos info = new Academicocongresos();
                info.IdAcademico = idAcademico;
                info.IdCongreso = DatosCongresos.IdCongresos;
                info.Lider = Lider;
                context.Academicocongresos.Add(info); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexCongresos");
        }
        [Authorize]
        //Función para acceder a la vista de editar el congreso de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarCongresos(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Congresos DatosCongresos = context.Congresos.Where(s => s.IdCongresos == id).Single(); //Obtención de los datos a editar.
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList(); //Obtención de las localizaciones de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["lugar"] = lugar;
                return View(DatosCongresos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar congreso.
        public async Task<IActionResult> ActualizarCongresos(IFormFile file, Congresos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "Congresos".
                var ListCongresos = context.Congresos.Where(a => a.IdCongresos != datos.IdCongresos).ToList(); //Se obtienen los registros de la tabla.
                foreach (Congresos item in ListCongresos)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizaran los datos.
                    if (datos.IdNacInt == item.IdNacInt && datos.Nombre == item.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexCongresos");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.Congresos.Where(w => w.IdCongresos == datos.IdCongresos).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdCongresos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.Congresos.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo para guardar, se redireccionara al index correspondiente.
                return RedirectToAction("IndexCongresos");
            }
            var new_name_file = datos.IdCongresos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Congresos", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexCongresos");
        }
        //Función para eliminar un registro del congreso.
        public IActionResult EliminarCongresos(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicocongresos> eliminarAcad = context.Academicocongresos.Where(f => f.IdCongreso == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico con el registro.
                    context.Academicocongresos.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }

                Congresos eliminar = context.Congresos.Where(w => w.IdCongresos == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Congresos.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexCongresos");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre el congreso.
        public async Task<IActionResult> DescargarCongresos(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/Congresos", filename);
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
        //Función para mostrar la información de académicos colaboradores de un respectivo congreso seleccionado.
        public IActionResult AcademicosCongresos(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipoUsu es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadCongresos fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadCongresos> ListAcadCongresos = new List<TablaAcadCongresos>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con el congreso.
                ListAcadCongresos = (from datos in context.Academicocongresos
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     where datos.IdCongreso == id
                                     select new TablaAcadCongresos
                                     {
                                         IdAcadCongreso = datos.IdAcademicoCongresos,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         idCongreso = datos.IdCongreso
                                     }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idCongreso"] = id;
                //Se busca si el academico usuario es lider del congreso seleccionado, esto comparando si el campo lider es igual = 1.
                Academicocongresos Acad = new Academicocongresos();
                int cant = context.Academicocongresos.Where(w => w.IdCongreso == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicocongresos.Where(w => w.IdCongreso == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
            }
            return View(ListAcadCongresos);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de un congreso.
        public IActionResult GuardarAcadCongresos(int idAcademico, int congreso, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicocongresos AcadCongresos = new Academicocongresos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Academicocongresos".
                var ListAcad = context.Academicocongresos.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicocongresos item in ListAcad)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademico && congreso == item.IdCongreso)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosCongresos", new { id = congreso });
                    }
                }
                AcadCongresos.IdAcademico = idAcademico;
                AcadCongresos.IdCongreso = congreso;
                AcadCongresos.Lider = Lider;
                context.Academicocongresos.Add(AcadCongresos); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosCongresos", new { id = AcadCongresos.IdCongreso });
        }
        [Authorize]
        //Función para eliminar a los academicos relacionados con un congreso.
        public IActionResult EliminarAcadCongresos(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicocongresos eliminar = context.Academicocongresos.Where(w => w.IdAcademicoCongresos == id).Single(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                context.Academicocongresos.Remove(eliminar); //Se elimina la relación del academico con el registro.
                context.SaveChanges();
                return RedirectToAction("AcademicosCongresos", new { id = id_acad });
            }
        }




        [Authorize]
        //Función para mostrar la información de las revistas que presentan los académicos.
        public IActionResult IndexRevistas()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaRevistas fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaRevistas> ListRevistas = new List<TablaRevistas>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivas revistas.
                ListRevistas = (from datos in context.Revistas
                                join tipo in context.TipoLocNacInter on datos.IdNI equals tipo.IdTipo
                                select new TablaRevistas
                                {
                                    IdRevistas = datos.IdRevistas,
                                    Archivo = datos.Archivo,
                                    Tipo = tipo.Nombre,
                                    NombreRevista = datos.Nombre,
                                    Registro = datos.Registro,
                                    Arbitrada = datos.Arbitrada
                                }
                               ).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de alguna revista y darle el permiso de modificar dichos registros.
                    List<Academicorevistas> ListAcad = new List<Academicorevistas>();
                    ListAcad = context.Academicorevistas.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListRevistas);
        }
        [Authorize]
        //Función para acceder a la vista de agregar una revista de un académico y obtener los datos necesarios para los select.
        public IActionResult CrearRevistas()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList(); //Obtención de las localizaciones de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["lugar"] = lugar;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear revistas.
        public async Task<IActionResult> GuardarRevistas(IFormFile file, Revistas datos, int idAcademico, int Lider)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Revistas".
                var ListRevistas = context.Revistas.ToList(); //Se obtienen los registros de la tabla.
                foreach (Revistas item in ListRevistas)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdNI == item.IdNI && datos.Nombre == item.Nombre && datos.Registro == item.Registro && datos.Arbitrada == item.Arbitrada)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexRevistas");
                    }
                }
            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.Revistas.Add(datos); //Guardado de la información.
                context.SaveChanges();
                Revistas DatosRevistas = context.Revistas.Last(); //Se obtiene el registro anteriormente guardado, para poder modificar el nombre del archivo y evitar sobre escritura.
                var new_name_table = DatosRevistas.IdRevistas + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.Revistas.Update(datos); //Actualización de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdRevistas + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Revistas", new_name_file);//Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al académico creador de la revista en la tabla Academicorevistas.
                Revistas DatosRevistas = context.Revistas.Last();
                Academicorevistas info = new Academicorevistas();
                info.IdAcademico = idAcademico;
                info.IdRevista = DatosRevistas.IdRevistas;
                info.Lider = Lider;
                context.Academicorevistas.Add(info); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexRevistas");
        }
        [Authorize]
        //Función para acceder a la vista de editar la revista de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarRevistas(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Revistas DatosRevistas = context.Revistas.Where(s => s.IdRevistas == id).Single(); //Obtención de los datos a editar.
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList(); //Obtención de las localizaciones de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["lugar"] = lugar;
                return View(DatosRevistas);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar revistas.
        public async Task<IActionResult> ActualizarRevistas(IFormFile file, Revistas datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "Revistas".
                var ListRevistas = context.Revistas.Where(a => a.IdRevistas != datos.IdRevistas).ToList(); //Se obtienen los registros de la tabla.
                foreach (Revistas item in ListRevistas)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizaran los datos.
                    if (datos.IdNI == item.IdNI && datos.Nombre == item.Nombre && datos.Registro == item.Registro && datos.Arbitrada == item.Arbitrada)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexRevistas");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.Revistas.Where(w => w.IdRevistas == datos.IdRevistas).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdRevistas + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Actualizado de la información.
                context.Revistas.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo a actualizar, se redirecciona al index correspondiente.
                return RedirectToAction("IndexRevistas");
            }
            var new_name_file = datos.IdRevistas + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Revistas", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexRevistas");
        }
        //Función para eliminar un registro de las revistas.
        public IActionResult EliminarRevistas(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicorevistas> eliminarAcad = context.Academicorevistas.Where(f => f.IdRevista == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico con el registro.
                    context.Academicorevistas.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }

                Revistas eliminar = context.Revistas.Where(w => w.IdRevistas == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Revistas.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexRevistas");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre la revista.
        public async Task<IActionResult> DescargarRevistas(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/Revistas", filename);
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
        //Función para mostrar la información de académicos colaboradores de una respectiva revista seleccionado.
        public IActionResult AcademicosRevistas(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipoUsu es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadRevistas fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadRevistas> ListAcadRevistas = new List<TablaAcadRevistas>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con la revista.
                ListAcadRevistas = (from datos in context.Academicorevistas
                                    join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                    where datos.IdRevista == id
                                    select new TablaAcadRevistas
                                    {
                                        IdAcadRevistas = datos.IdAcademicorevistas,
                                        NumPersonal = acad.NumeroPersonal,
                                        Nombre = acad.Nombre,
                                        ApellidoPaterno = acad.ApellidoPaterno,
                                        ApellidoMaterno = acad.ApellidoMaterno,
                                        IdRevistas = datos.IdRevista
                                    }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idRevistas"] = id;

                //Se busca si el academico usuario es lider de la revista seleccionado, esto comparando si el campo lider es igual = 1.
                Academicorevistas Acad = new Academicorevistas();
                int cant = context.Academicorevistas.Where(w => w.IdRevista == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicorevistas.Where(w => w.IdRevista == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadRevistas);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de una revista.
        public IActionResult GuardarAcadRevistas(int idAcademico, int revistas, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicorevistas AcadRevistas = new Academicorevistas();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Academicorevistas".
                var ListAcad = context.Academicorevistas.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicorevistas item in ListAcad)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademico && revistas == item.IdRevista)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosRevistas", new { id = revistas });
                    }
                }
                AcadRevistas.IdAcademico = idAcademico;
                AcadRevistas.IdRevista = revistas;
                AcadRevistas.Lider = Lider;
                context.Academicorevistas.Add(AcadRevistas); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosRevistas", new { id = AcadRevistas.IdRevista });
        }
        [Authorize]
        //Función para eliminar a los academicos relacionados con una revista.
        public IActionResult EliminarAcadRevistas(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicorevistas eliminar = context.Academicorevistas.Where(w => w.IdAcademicorevistas == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Academicorevistas.Remove(eliminar); //Se elimina la relación del academico con el registro.
                context.SaveChanges();
                return RedirectToAction("AcademicosRevistas", new { id = id_acad });
            }
        }



        [Authorize]
        //Función para mostrar la información de los reportes tecnicos que presentan los académicos.
        public IActionResult IndexReportesTecnicos()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaReportesTecnicos fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaReportesTecnicos> ListReportes = new List<TablaReportesTecnicos>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivos reportes tecnicos.
                ListReportes = (from datos in context.ReportesTecnicos
                                select new TablaReportesTecnicos
                                {
                                    IdReporteTecnico = datos.IdReportesTecnicos,
                                    Archivo = datos.Archivo,
                                    NombreReporte = datos.Nombre,
                                    Empresa_Sector = datos.LugarEmpresaSector
                                }
                               ).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de algun reporte tecnico y darle el permiso de modificar dichos registros.
                    List<Academicoreportest> ListAcad = new List<Academicoreportest>();
                    ListAcad = context.Academicoreportest.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListReportes);
        }
        [Authorize]
        //Función para acceder a la vista de agregar el reporte tecnico de un académico y obtener los datos necesarios para los select.
        public IActionResult CrearReportes()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                // Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear reporte tecnico.
        public async Task<IActionResult> GuardarReportes(IFormFile file, ReportesTecnicos datos, int idAcademico, int Lider)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu"); 
            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "ReportesTecnicos".
                var ListReporte = context.ReportesTecnicos.ToList(); //Se obtienen los registros de la tabla.
                foreach (ReportesTecnicos item in ListReporte)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.Nombre == item.Nombre && datos.LugarEmpresaSector == item.LugarEmpresaSector )
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexReportesTecnicos");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.ReportesTecnicos.Add(datos); //Guardado de la información.
                context.SaveChanges();
                var new_name_table = datos.IdReportesTecnicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.ReportesTecnicos.Update(datos); //Actualizado de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdReportesTecnicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/ReportesTecnicos", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al académico creador del reporte tecnico en la tabla Academicoreportest.
                ReportesTecnicos DatosReportesTecnicos = context.ReportesTecnicos.Last();
                Academicoreportest info = new Academicoreportest();
                info.IdAcademico = idAcademico;
                info.IdReportesTec = DatosReportesTecnicos.IdReportesTecnicos;
                info.Lider = Lider;
                context.Academicoreportest.Add(info); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexReportesTecnicos");
        }
        [Authorize]
        //Función para acceder a la vista de editar el reporte tecnico de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarReportes(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Obtención de los datos a editar.
                ReportesTecnicos DatosReporte = context.ReportesTecnicos.Where(s => s.IdReportesTecnicos == id).Single();

                return View(DatosReporte);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar reportes tecnicos.
        public async Task<IActionResult> ActualizarReportes(IFormFile file, ReportesTecnicos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "ReportesTecnicos".
                var ListReportes = context.ReportesTecnicos.Where(a => a.IdReportesTecnicos != datos.IdReportesTecnicos).ToList(); //Se obtienen los registros de la tabla.
                foreach (ReportesTecnicos item in ListReportes)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizaran los datos.
                    if (datos.Nombre == item.Nombre && datos.LugarEmpresaSector == item.LugarEmpresaSector)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexReportesTecnicos");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.ReportesTecnicos.Where(w => w.IdReportesTecnicos == datos.IdReportesTecnicos).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdReportesTecnicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ReportesTecnicos.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo a guardar, se redirecciona a al index correspondiente.
                return RedirectToAction("IndexReportesTecnicos");
            }
            var new_name_file = datos.IdReportesTecnicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/ReportesTecnicos", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexReportesTecnicos");
        }
        //Función para eliminar un registro de reportes tecnicos.
        public IActionResult EliminarReportes(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicoreportest> eliminarAcad = context.Academicoreportest.Where(f => f.IdReportesTec == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico con el registro.
                    context.Academicoreportest.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }

                ReportesTecnicos eliminar = context.ReportesTecnicos.Where(w => w.IdReportesTecnicos == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.ReportesTecnicos.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexReportesTecnicos");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre los reportes tecnicos.
        public async Task<IActionResult> DescargarReportes(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/ReportesTecnicos", filename);
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
        //Función para mostrar la información de académicos colaboradores de un respectivo reporte tecnico seleccionado.
        public IActionResult AcademicosReportes(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipoUsu es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadReportes fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadReportes> ListAcadReportes = new List<TablaAcadReportes>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con el reporte tecnico.
                ListAcadReportes = (from datos in context.Academicoreportest
                                    join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                    where datos.IdReportesTec == id
                                    select new TablaAcadReportes
                                    {
                                        IdAcadReportes = datos.IdAcademicoReportesT,
                                        NumPersonal = acad.NumeroPersonal,
                                        Nombre = acad.Nombre,
                                        ApellidoPaterno = acad.ApellidoPaterno,
                                        ApellidoMaterno = acad.ApellidoMaterno,
                                        IdReporte = datos.IdReportesTec
                                    }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idReportes"] = id;

                //Se busca si el academico usuario es lider del reporte tecnico seleccionado, esto comparando si el campo lider es igual = 1.
                Academicoreportest Acad = new Academicoreportest();
                int cant = context.Academicoreportest.Where(w => w.IdReportesTec == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicoreportest.Where(w => w.IdReportesTec == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadReportes);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de un reporte tecnico.
        public IActionResult GuardarAcadReportes(int idAcademico, int reportes, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicoreportest AcadReportes = new Academicoreportest();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Academicoreportest".
                var ListAcad = context.Academicoreportest.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicoreportest item in ListAcad)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademico && reportes == item.IdReportesTec)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosReportes", new { id = reportes });
                    }
                }

                AcadReportes.IdAcademico = idAcademico;
                AcadReportes.IdReportesTec = reportes;
                AcadReportes.Lider = Lider;
                context.Academicoreportest.Add(AcadReportes); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosReportes", new { id = AcadReportes.IdReportesTec });
        }
        [Authorize]
        //Función para eliminar un registro de reportes tecnicos.
        public IActionResult EliminarAcadReportes(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicoreportest eliminar = context.Academicoreportest.Where(w => w.IdAcademicoReportesT == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Academicoreportest.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("AcademicosReportes", new { id = id_acad });
            }
        }



        [Authorize]
        //Función para mostrar la información de los libros que presentan los académicos.
        public IActionResult IndexLibros()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaLibros fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaLibros> ListLibros = new List<TablaLibros>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivos libros.
                ListLibros = (from datos in context.LibrosAcademicos
                              join edi in context.Editorial on datos.IdEditorial equals edi.IdEditorial
                              select new TablaLibros
                              {
                                  IdLibro = datos.IdLibrosAcademicos,
                                  Archivo = datos.Archivo,
                                  Titulo = datos.Titulo,
                                  ISBN = datos.Isbn,
                                  Anio = datos.Anio,
                                  Tiraje = datos.Tiraje,
                                  Editorial = edi.Nombre
                              }
                               ).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de algun libro y darle el permiso de modificar dichos registros.
                    List<Academicolibro> ListAcad = new List<Academicolibro>();
                    ListAcad = context.Academicolibro.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListLibros);
        }
        [Authorize]
        //Función para acceder a la vista de agregar un libro de un académico y obtener los datos necesarios para los select.
        public IActionResult CrearLibros()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var edit = context.Editorial.ToList(); //Obtención de los editoriales de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["editorial"] = edit;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear un libro de un académico.
        public async Task<IActionResult> GuardarLibros(IFormFile file, LibrosAcademicos datos, int idAcademico, int Lider, string nuevaE)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            //Si la variable nuevaE, esta vacia quiere decir que en la variable datos viene una editorial seleccionada, pero si la
            //variable nuevaE es diferente de null, quiere decir que la editorial que se requiere no se encuentra en las opciones que hay
            //por lo tanto se crea la nueva editorial y se agrega a la lista predeterminada.
            if (nuevaE != null)
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    Editorial nuevo = new Editorial();
                    nuevo.Nombre = nuevaE;
                    context.Editorial.Add(nuevo);
                    context.SaveChanges();
                    Editorial ultimaE = context.Editorial.Last();
                    datos.IdEditorial = ultimaE.IdEditorial;
                }

            }
            else
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "LibrosAcademicos".
                    var ListLibro = context.LibrosAcademicos.ToList(); //Se obtienen los registros de la tabla.
                    foreach (LibrosAcademicos item in ListLibro)
                    {
                        //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                        if (datos.Titulo == item.Titulo && datos.IdEditorial == item.IdEditorial && datos.Isbn == item.Isbn && datos.Anio == item.Anio && datos.Tiraje == item.Tiraje)
                        {
                            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                            return RedirectToAction("IndexLibros");
                        }
                    }
                }
            }


            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.LibrosAcademicos.Add(datos); //Guardado de la información.
                context.SaveChanges();
                var new_name_table = datos.IdLibrosAcademicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.LibrosAcademicos.Update(datos); //Actualizado de la información.
                context.SaveChanges();

            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdLibrosAcademicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Libros", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al académico creador del libro en la tabla Academicolibro.
                LibrosAcademicos DatosLibro = context.LibrosAcademicos.Last();
                Academicolibro info = new Academicolibro();
                info.IdAcademico = idAcademico;
                info.IdLibroAcad = DatosLibro.IdLibrosAcademicos;
                info.Lider = Lider;
                context.Academicolibro.Add(info); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexLibros");
        }
        [Authorize]
        //Función para acceder a la vista de editar el libro de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarLibros(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                LibrosAcademicos DatosLibros = context.LibrosAcademicos.Where(s => s.IdLibrosAcademicos == id).Single(); //Obtención de los datos a editar.
                var edit = context.Editorial.ToList(); //Obtención de las editoriales de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["editorial"] = edit;
                return View(DatosLibros);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar un libro.
        public async Task<IActionResult> ActualizarLibros(IFormFile file, LibrosAcademicos datos, string nuevaE)
        {
            //Si la variable nuevaE, esta vacia quiere decir que en la variable datos viene una editorial seleccionada, pero si la
            //variable nuevaE es diferente de null, quiere decir que la editorial que se requiere no se encuentra en las opciones que hay
            //por lo tanto se crea la nueva editorial y se agrega a la lista predeterminada.
            if (nuevaE != null)
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    Editorial nuevo = new Editorial();
                    nuevo.Nombre = nuevaE;
                    context.Editorial.Add(nuevo);
                    context.SaveChanges();
                    Editorial ultimaE = context.Editorial.Last();
                    datos.IdEditorial = ultimaE.IdEditorial;
                }

            }
            else
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "LibrosAcademicos".
                    var ListLibro = context.LibrosAcademicos.Where(l => l.IdLibrosAcademicos != datos.IdLibrosAcademicos).ToList(); //Se obtienen los registros de la tabla.
                    foreach (LibrosAcademicos item in ListLibro)
                    {
                        //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                        if (datos.Titulo == item.Titulo && datos.IdEditorial == item.IdEditorial && datos.Isbn == item.Isbn && datos.Anio == item.Anio && datos.Tiraje == item.Tiraje)
                        {
                            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                            return RedirectToAction("IndexLibros");
                        }
                    }
                }
            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.LibrosAcademicos.Where(w => w.IdLibrosAcademicos == datos.IdLibrosAcademicos).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdLibrosAcademicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.LibrosAcademicos.Update(datos); //Actualizado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo para guardar, se redirecciona al index correspondiente.
                return RedirectToAction("IndexLibros");
            }
            var new_name_file = datos.IdLibrosAcademicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Libros", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexLibros");
        }
        //Función para eliminar un registro de un libro.
        public IActionResult EliminarLibros(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicolibro> eliminarAcad = context.Academicolibro.Where(f => f.IdLibroAcad == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico con el registro.
                    context.Academicolibro.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }

                LibrosAcademicos eliminar = context.LibrosAcademicos.Where(w => w.IdLibrosAcademicos == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.LibrosAcademicos.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexLibros");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre un libro.
        public async Task<IActionResult> DescargarLibros(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/Libros", filename);
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
        //Función para mostrar la información de académicos colaboradores de un respectivo libro seleccionado.
        public IActionResult AcademicosLibros(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipoUsu es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadLibros fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadLibros> ListAcadLibros = new List<TablaAcadLibros>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con el libro.
                ListAcadLibros = (from datos in context.Academicolibro
                                  join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                  where datos.IdLibroAcad == id
                                  select new TablaAcadLibros
                                  {
                                      IdAcadLibros = datos.IdAcademicoLibro,
                                      NumPersonal = acad.NumeroPersonal,
                                      Nombre = acad.Nombre,
                                      ApellidoPaterno = acad.ApellidoPaterno,
                                      ApellidoMaterno = acad.ApellidoMaterno,
                                      IdLibros = datos.IdLibroAcad
                                  }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idLibros"] = id;
                //Se busca si el academico usuario es lider del libro seleccionado, esto comparando si el campo lider es igual = 1.
                Academicolibro Acad = new Academicolibro();
                int cant = context.Academicolibro.Where(w => w.IdLibroAcad == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicolibro.Where(w => w.IdLibroAcad == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadLibros);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de un libro.
        public IActionResult GuardarAcadLibros(int idAcademico, int libros, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicolibro AcadLibros = new Academicolibro();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Academicolibro".
                var ListAcad = context.Academicolibro.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicolibro item in ListAcad)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademico && libros == item.IdLibroAcad)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosLibros", new { id = libros });
                    }
                }
                AcadLibros.IdAcademico = idAcademico;
                AcadLibros.IdLibroAcad = libros;
                AcadLibros.Lider = Lider;
                context.Academicolibro.Add(AcadLibros); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosLibros", new { id = AcadLibros.IdLibroAcad });
        }
        [Authorize]
        //Función para eliminar a los academicos relacionados con un libro.
        public IActionResult EliminarAcadLibros(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicolibro eliminar = context.Academicolibro.Where(w => w.IdAcademicoLibro == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Academicolibro.Remove(eliminar); //Se elimina la relación del academico con el registro.
                context.SaveChanges();
                return RedirectToAction("AcademicosLibros", new { id = id_acad });
            }
        }




        [Authorize]
        //Función para mostrar la información de los capitulos de un libro que presentan los académicos.
        public IActionResult IndexCapitulos()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaCapitulos fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaCapitulos> ListCapitulos = new List<TablaCapitulos>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivos capitulos de un libro.
                ListCapitulos = (from datos in context.CapLibro
                                 join edi in context.Editorial on datos.IdEditorial equals edi.IdEditorial
                                 select new TablaCapitulos
                                 {
                                     IdCapitulo = datos.IdCapLibro,
                                     Archivo = datos.Archivo,
                                     Titulo = datos.Titulo,
                                     ISBN = datos.Isbn,
                                     Anio = datos.Anio,
                                     Editorial = edi.Nombre
                                 }
                               ).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de algun capitulo y darle el permiso de modificar dichos registros.
                    List<Academicocaplibro> ListAcad = new List<Academicocaplibro>();
                    ListAcad = context.Academicocaplibro.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListCapitulos);
        }
        [Authorize]
        //Función para acceder a la vista de agregar el capitulo de un libro de un académico y obtener los datos necesarios para los select.
        public IActionResult CrearCapitulosLibros()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var edit = context.Editorial.ToList(); //Obtención de los editoriales de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["editorial"] = edit;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear capitulos de un libro.
        public async Task<IActionResult> GuardarCapitulos(IFormFile file, CapLibro datos, int idAcademico, int Lider, string nuevaE)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            //Si la variable nuevaE, esta vacia quiere decir que en la variable datos viene una editorial seleccionada, pero si la
            //variable nuevaE es diferente de null, quiere decir que la editorial que se requiere no se encuentra en las opciones que hay
            //por lo tanto se crea la nueva editorial y se agrega a la lista predeterminada.
            if (nuevaE != null)
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    Editorial nuevo = new Editorial();
                    nuevo.Nombre = nuevaE;
                    context.Editorial.Add(nuevo);
                    context.SaveChanges();
                    Editorial ultimaE = context.Editorial.Last();
                    datos.IdEditorial = ultimaE.IdEditorial;
                }

            }
            else
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "CapLibro".
                    var ListCapLibro = context.CapLibro.ToList(); //Se obtienen los registros de la tabla.
                    foreach (CapLibro item in ListCapLibro)
                    {
                        //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                        if (datos.Titulo == item.Titulo && datos.IdEditorial == item.IdEditorial && datos.Isbn == item.Isbn && datos.Anio == item.Anio)
                        {
                            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                            return RedirectToAction("IndexCapitulos");
                        }
                    }
                }
            }


            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.CapLibro.Add(datos); //Guardado de la información.
                context.SaveChanges();
                var new_name_table = datos.IdCapLibro + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.CapLibro.Update(datos); //Actualizado de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdCapLibro + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/CapitulosLibros", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al académico creador del capitulo de un libro en la tabla Academicocaplibro.
                CapLibro DatosLibro = context.CapLibro.Last();
                Academicocaplibro info = new Academicocaplibro();
                info.IdAcademico = idAcademico;
                info.IdCapLibro = DatosLibro.IdCapLibro;
                info.Lider = Lider;
                context.Academicocaplibro.Add(info); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexCapitulos");
        }
        [Authorize]
        //Función para acceder a la vista de editar el capitulo de un libro de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarCapitulosLibros(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CapLibro DatosCap = context.CapLibro.Where(s => s.IdCapLibro == id).Single(); //Obtención de los datos a editar.
                var edit = context.Editorial.ToList(); //Obtención de las editoriales de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["editorial"] = edit;
                return View(DatosCap);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar capitulos de un libro.
        public async Task<IActionResult> ActualizarCapitulos(IFormFile file, CapLibro datos, string nuevaE)
        {
            //Si la variable nuevaE, esta vacia quiere decir que en la variable datos viene una editorial seleccionada, pero si la
            //variable nuevaE es diferente de null, quiere decir que la editorial que se requiere no se encuentra en las opciones que hay
            //por lo tanto se crea la nueva editorial y se agrega a la lista predeterminada.
            if (nuevaE != null)
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    Editorial nuevo = new Editorial();
                    nuevo.Nombre = nuevaE;
                    context.Editorial.Add(nuevo); //Guardado de la información.
                    context.SaveChanges();
                    Editorial ultimaE = context.Editorial.Last();
                    datos.IdEditorial = ultimaE.IdEditorial;
                }

            }
            else
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "CapLibro".
                    var ListCapLibro = context.CapLibro.Where(l => l.IdCapLibro != datos.IdCapLibro).ToList(); //Se obtienen los registros de la tabla.
                    foreach (CapLibro item in ListCapLibro)
                    {
                        //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                        if (datos.Titulo == item.Titulo && datos.IdEditorial == item.IdEditorial && datos.Isbn == item.Isbn && datos.Anio == item.Anio)
                        {
                            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                            return RedirectToAction("IndexCapitulos");
                        }
                    }
                }
            }


            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.CapLibro.Where(w => w.IdCapLibro == datos.IdCapLibro).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdCapLibro + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CapLibro.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo para guardar, se redirecciona al index correspondiente.
                return RedirectToAction("IndexCapitulos");
            }
            var new_name_file = datos.IdCapLibro + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/CapitulosLibros", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexCapitulos");
        }
        //Función para eliminar un registro del capitulo de un libro.
        public IActionResult EliminarCapitulos(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicocaplibro> eliminarAcad = context.Academicocaplibro.Where(f => f.IdCapLibro == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico con el registro.
                    context.Academicocaplibro.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
                CapLibro eliminar = context.CapLibro.Where(w => w.IdCapLibro == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.CapLibro.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexCapitulos");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre los capitulos de archivos.
        public async Task<IActionResult> DescargarCapitulos(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/CapitulosLibros", filename);
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
        //Función para mostrar la información de académicos colaboradores de un respectivo capitulo de un libro seleccionado.
        public IActionResult AcademicosCapituloLibros(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadCapLibros fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadCapLibros> ListAcadCapLibros = new List<TablaAcadCapLibros>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con el capitulo de un libro.
                ListAcadCapLibros = (from datos in context.Academicocaplibro
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     where datos.IdCapLibro == id
                                     select new TablaAcadCapLibros
                                     {
                                         IdAcadCapLibros = datos.IdAcademicoCapLibro,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         IdCapLibros = datos.IdCapLibro
                                     }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idCapLibros"] = id;
                //Se busca si el academico usuario es lider del capitulo del libro seleccionado, esto comparando si el campo lider es igual = 1.
                Academicocaplibro Acad = new Academicocaplibro();
                int cant = context.Academicocaplibro.Where(w => w.IdCapLibro == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicocaplibro.Where(w => w.IdCapLibro == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadCapLibros);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de un capitulo de un libro.
        public IActionResult GuardarAcadCapLibros(int idAcademico, int Caplibros, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicocaplibro AcadCapLibros = new Academicocaplibro();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Academicocaplibro".
                var ListAcad = context.Academicocaplibro.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicocaplibro item in ListAcad)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademico && Caplibros == item.IdCapLibro)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosCapituloLibros", new { id = Caplibros });
                    }
                }
                AcadCapLibros.Lider = Lider;
                AcadCapLibros.IdAcademico = idAcademico;
                AcadCapLibros.IdCapLibro = Caplibros;
                context.Academicocaplibro.Add(AcadCapLibros); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosCapituloLibros", new { id = AcadCapLibros.IdCapLibro });
        }
        [Authorize]
        //Función para eliminar a los academicos relacionados con un capitulo de libros.
        public IActionResult EliminarAcadCapLibros(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicocaplibro eliminar = context.Academicocaplibro.Where(w => w.IdAcademicoCapLibro == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Academicocaplibro.Remove(eliminar); //Se elimina la relación del academico con el registro.
                context.SaveChanges();
                return RedirectToAction("AcademicosCapituloLibros", new { id = id_acad });
            }
        }





        [Authorize]
        //Función para mostrar la información de los patentes que presentan los académicos.
        public IActionResult IndexPatentes()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaPatentes fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaPatentes> ListPatentes = new List<TablaPatentes>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivas patentes.
                ListPatentes = (from datos in context.PatentesAcademicos
                                join tipo in context.TipoLocNacInter on datos.IdNacI equals tipo.IdTipo
                                select new TablaPatentes
                                {
                                    IdPatentes = datos.IdPatentesAcademicos,
                                    Archivo = datos.Archivo,
                                    NombrePatente = datos.Nombre,
                                    Tipo = tipo.Nombre
                                }
                               ).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de alguna patente y darle el permiso de modificar dichos registros.
                    List<Academicospatentes> ListAcad = new List<Academicospatentes>();
                    ListAcad = context.Academicospatentes.Where(w => w.IdAcademicos == idUsu && w.Lider == 1).ToList();
                    //Envio de los datos a la vista.
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListPatentes);
        }
        [Authorize]
        //Función para acceder a la vista de agregar la patente de un académico y obtener los datos necesarios para los select.
        public IActionResult CrearPatentes()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList(); //Obtención de las localizaciones de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["lugar"] = lugar;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear patentes.
        public async Task<IActionResult> GuardarPatentes(IFormFile file, PatentesAcademicos datos, int idAcademico, int Lider)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "PatentesAcademicos".
                var ListPatentes = context.PatentesAcademicos.ToList(); //Se obtienen los registros de la tabla.
                foreach (PatentesAcademicos item in ListPatentes)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdNacI == item.IdNacI && datos.Nombre == item.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexPatentes");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.PatentesAcademicos.Add(datos); //Guardado de la información.
                context.SaveChanges();
                var new_name_table = datos.IdPatentesAcademicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.PatentesAcademicos.Update(datos); //Guardado de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdPatentesAcademicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Patentes", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al académico creador de una patente en la tabla Academicospatentes.
                PatentesAcademicos DatosPatentes = context.PatentesAcademicos.Last();
                Academicospatentes info = new Academicospatentes();
                info.IdAcademicos = idAcademico;
                info.IdPatentes = DatosPatentes.IdPatentesAcademicos;
                info.Lider = Lider;
                context.Academicospatentes.Add(info); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexPatentes");
        }
        [Authorize]
        //Función para acceder a la vista de editar la patente de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarPatentes(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                PatentesAcademicos DatosPatentes = context.PatentesAcademicos.Where(s => s.IdPatentesAcademicos == id).Single(); //Obtención de los datos a editar.
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList(); //Obtención de las localizaciones de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["lugar"] = lugar;
                return View(DatosPatentes);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar patentes.
        public async Task<IActionResult> ActualizarPatentes(IFormFile file, PatentesAcademicos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a actualizar no se encuentre ya registrada en la tabla "PatentesAcademicos".
                var ListPatentes = context.PatentesAcademicos.Where(l => l.IdPatentesAcademicos != datos.IdPatentesAcademicos).ToList(); //Se obtienen los registros de la tabla.
                foreach (PatentesAcademicos item in ListPatentes)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizaran los datos.
                    if (datos.IdNacI == item.IdNacI && datos.Nombre == item.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexPatentes");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.PatentesAcademicos.Where(w => w.IdPatentesAcademicos == datos.IdPatentesAcademicos).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdPatentesAcademicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.PatentesAcademicos.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo para guardar, se redirecciona al index correspondientes.
                return RedirectToAction("IndexPatentes");
            }
            var new_name_file = datos.IdPatentesAcademicos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Patentes", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPatentes");
        }
        //Función para eliminar un registro de las patentes.
        public IActionResult EliminarPatentes(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicospatentes> eliminarAcad = context.Academicospatentes.Where(f => f.IdPatentes == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico con el registro.
                    context.Academicospatentes.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
                PatentesAcademicos eliminar = context.PatentesAcademicos.Where(w => w.IdPatentesAcademicos == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.PatentesAcademicos.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexPatentes");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre las patentes.
        public async Task<IActionResult> DescargarPatentes(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/Patentes", filename);
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
        //Función para mostrar la información de académicos colaboradores de una respectiva patente seleccionada.
        public IActionResult AcademicosPatentes(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipoUsu es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadPatentes fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadPatentes> ListAcadPatentes = new List<TablaAcadPatentes>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con el una patente.
                ListAcadPatentes = (from datos in context.Academicospatentes
                                    join acad in context.Academicos on datos.IdAcademicos equals acad.IdAcademicos
                                    where datos.IdPatentes == id
                                    select new TablaAcadPatentes
                                    {
                                        IdAcadPatentes = datos.IdAcademicosPatentes,
                                        NumPersonal = acad.NumeroPersonal,
                                        Nombre = acad.Nombre,
                                        ApellidoPaterno = acad.ApellidoPaterno,
                                        ApellidoMaterno = acad.ApellidoMaterno,
                                        IdPatentes = datos.IdPatentes
                                    }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idPatentes"] = id;
                //Se busca si el academico usuario es lider de una patente seleccionado, esto comparando si el campo lider es igual = 1.
                Academicospatentes Acad = new Academicospatentes();
                int cant = context.Academicospatentes.Where(w => w.IdPatentes == id && w.Lider == 1 && w.IdAcademicos == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicospatentes.Where(w => w.IdPatentes == id && w.Lider == 1 && w.IdAcademicos == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadPatentes);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de una patente.
        public IActionResult GuardarAcadPatentes(int idAcademico, int patentes, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicospatentes AcadPatentes = new Academicospatentes();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Academicospatentes".
                var ListAcad = context.Academicospatentes.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicospatentes item in ListAcad)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademicos && patentes == item.IdPatentes)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosPatentes", new { id = patentes });
                    }
                }
                AcadPatentes.Lider = Lider;
                AcadPatentes.IdAcademicos = idAcademico;
                AcadPatentes.IdPatentes = patentes;
                context.Academicospatentes.Add(AcadPatentes); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosPatentes", new { id = AcadPatentes.IdPatentes });
        }
        [Authorize]
        //Función para eliminar a los academicos relacionados con un patente.
        public IActionResult EliminarAcadPatentes(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicospatentes eliminar = context.Academicospatentes.Where(w => w.IdAcademicosPatentes == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Academicospatentes.Remove(eliminar); //Se elimina la relación del academico con el registro.
                context.SaveChanges();
                return RedirectToAction("AcademicosPatentes", new { id = id_acad });
            }
        }



        [Authorize]
        //Función para mostrar la información de los trabajos recepcionales que presentan los académicos.
        public IActionResult IndexTrabajoRecep()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaTrabajosRecep fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaTrabajosRecep> ListTrabajosRecep = new List<TablaTrabajosRecep>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivos trabajos recepcionales.
                ListTrabajosRecep = (from datos in context.TrabajosRecepcionales
                                     join academia in context.Academias on datos.IdAcademia equals academia.IdAcademias
                                     join alum in context.Alumnos on datos.IdAlumno equals alum.IdAlumnos
                                     join datosalum in context.DatosPersonales on alum.RDatosPerson equals datosalum.IdDatosPersonales
                                     join grado in context.GradoTitulo on datos.IdGrado equals grado.IdGradoTitulo
                                     join mod in context.TipoModalidad on datos.IdModalidad equals mod.IdModalidad
                                     select new TablaTrabajosRecep
                                     {
                                         IdTrabajos = datos.IdTrabajosRecepcionales,
                                         NombreAlum = datosalum.Nombre,
                                         ApellidoPaternoAlum = datosalum.ApellidoPaterno,
                                         ApellidoMaternoAlum = datosalum.ApellidoMaterno,
                                         Proceso = datos.Proceso,
                                         Modalidad = mod.Nombre,
                                         Grado = grado.Nombre,
                                         Academia = academia.Nombre,
                                         Fecha = datos.FechaPresentacion.ToString(),
                                         NumCT = datos.NumeroConsejoT,
                                         Archivo = datos.Archivo,
                                         NombreTrabajo = datos.NombreTrabajo,
                                     }
                               ).ToList();
                if (tipoUsu == 2)
                { 
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de algun trabajo recepcional y darle el permiso de modificar dichos registros.
                    List<Academicotrabajosrecep> ListAcad = new List<Academicotrabajosrecep>();
                    ListAcad = context.Academicotrabajosrecep.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    //Envio de los datos a la vista.
                    ViewData["ListAcad"] = ListAcad;
                }


            }
            return View(ListTrabajosRecep);
        }

        [Authorize]
        //Función para acceder a la vista de agregar un trabajo recepcional de un académico y obtener los datos necesarios para los select.
        public IActionResult CrearTrabajosRecep()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos de la base de datos.
                var academia = context.Academias.Where(s => s.Status == 1).ToList(); //Obtención de las academias activas de la base de datos.
                var alum = context.DatosPersonales.ToList(); //Obtención de los datos personales de los alumnos de la base de datos.
                var grados = context.GradoTitulo.ToList(); //Obtención de los grados de un titulo de la base de datos.
                var modalidad = context.TipoModalidad.ToList(); //Obtención de lo modalidad de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["academia"] = academia;
                ViewData["alumnos"] = alum;
                ViewData["grados"] = grados;
                ViewData["modalidad"] = modalidad;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear trabajos recepcionales.
        public async Task<IActionResult> GuardarTrabajosRecep(IFormFile file, TrabajosRecepcionales datos, int idAcademico, int Lider)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "TrabajosRecepcionales".
                var ListTrabRecep = context.TrabajosRecepcionales.ToList(); //Se obtienen los registros de la tabla.

                foreach (TrabajosRecepcionales item in ListTrabRecep){
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (item.IdAlumno == datos.IdAlumno)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El alumno ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexTrabajoRecep");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.TrabajosRecepcionales.Add(datos); //Guardado de la información.
                context.SaveChanges();
                var new_name_table = datos.IdTrabajosRecepcionales + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.TrabajosRecepcionales.Update(datos); //Actualización de la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdTrabajosRecepcionales + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/TrabajosRecepcionales", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al académico creador del trabajo recepcional en la tabla Academicotrabajosrecep.
                TrabajosRecepcionales DatosTrabajosR = context.TrabajosRecepcionales.Last();
                Academicotrabajosrecep info = new Academicotrabajosrecep();
                info.IdAcademico = idAcademico;
                info.IdTrabajosRecep = DatosTrabajosR.IdTrabajosRecepcionales;
                info.Lider = Lider;
                context.Academicotrabajosrecep.Add(info); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexTrabajoRecep");
        }
        [Authorize]
        //Función para acceder a la vista de editar el trabajo recepcional de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarTrabajosRecep(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TrabajosRecepcionales DatosTrabajos = context.TrabajosRecepcionales.Where(s => s.IdTrabajosRecepcionales == id).Single(); //Obtención de los datos a editar.

                var academia = context.Academias.Where(s => s.Status == 1).ToList(); //Obtención de las academias de la base de datos.
                var alum = context.DatosPersonales.ToList(); //Obtención de los datos personales de la base de datos.
                var grados = context.GradoTitulo.ToList(); //Obtención de los grados del titulo de la base de datos.
                var modalidad = context.TipoModalidad.ToList(); //Obtención de los tipo de modalidad de la base de datos.

                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academia"] = academia;
                ViewData["alumnos"] = alum;
                ViewData["grados"] = grados;
                ViewData["modalidad"] = modalidad;
                string fecha = DatosTrabajos.FechaPresentacion.ToString();
                string[] resultado = fecha.Split(' ');
                ViewData["fecha"] = resultado[0];

                return View(DatosTrabajos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar trabajos recepcionales.
        public async Task<IActionResult> ActualizarTrabajosRecep(IFormFile file, TrabajosRecepcionales datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "TrabajosRecepcionales".
                var ListTrabRecep = context.TrabajosRecepcionales.Where(t => t.IdTrabajosRecepcionales != datos.IdTrabajosRecepcionales).ToList(); //Se obtienen los registros de la tabla.

                foreach (TrabajosRecepcionales item in ListTrabRecep)
                {
                    //Se comparan los datos ha actualizar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se actualizaran los datos.
                    if (item.IdAlumno == datos.IdAlumno)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El alumno ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexTrabajoRecep");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.TrabajosRecepcionales.Where(w => w.IdTrabajosRecepcionales == datos.IdTrabajosRecepcionales).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdTrabajosRecepcionales + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            if (datos.Proceso == 0) datos.FechaPresentacion = null;
            using (sgcfieeContext context = new sgcfieeContext())
            {

                context.TrabajosRecepcionales.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexTrabajoRecep");
            }
            var new_name_file = datos.IdTrabajosRecepcionales + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/TrabajosRecepcionales", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexTrabajoRecep");
        }
        //Función para eliminar un registro de un trabajo recepcional.
        public IActionResult EliminarTrabajosRecep(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicotrabajosrecep> eliminarAcad = context.Academicotrabajosrecep.Where(f => f.IdTrabajosRecep == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico con el registro.
                    context.Academicotrabajosrecep.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
                TrabajosRecepcionales eliminar = context.TrabajosRecepcionales.Where(w => w.IdTrabajosRecepcionales == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.TrabajosRecepcionales.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexTrabajoRecep");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre los trabajos recepcionales.
        public async Task<IActionResult> DescargarTrabajosRecep(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/TrabajosRecepcionales", filename);
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
        //Función para mostrar la información de académicos colaboradores de un respectivo trabajo recepcional seleccionado.
        public IActionResult AcademicosTrabajosRecep(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipoUsu es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadTrabajosRecep fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadTrabajosRecep> ListAcadTrabajosRecep = new List<TablaAcadTrabajosRecep>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con el trabajo recepcional.
                ListAcadTrabajosRecep = (from datos in context.Academicotrabajosrecep
                                         join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                         where datos.IdTrabajosRecep == id
                                         select new TablaAcadTrabajosRecep
                                         {
                                             IdAcadTrabajos = datos.IdAcademicoTrabajosRecep,
                                             NumPersonal = acad.NumeroPersonal,
                                             Nombre = acad.Nombre,
                                             ApellidoPaterno = acad.ApellidoPaterno,
                                             ApellidoMaterno = acad.ApellidoMaterno,
                                             IdTrabajos = datos.IdTrabajosRecep
                                         }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idTrabajos"] = id;
                //Se busca si el academico usuario es lider de un trabajo recepcional seleccionado, esto comparando si el campo lider es igual = 1.
                Academicotrabajosrecep Acad = new Academicotrabajosrecep();
                int cant = context.Academicotrabajosrecep.Where(w => w.IdTrabajosRecep == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicotrabajosrecep.Where(w => w.IdTrabajosRecep == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadTrabajosRecep);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de un trabajo recepcional.
        public IActionResult GuardarAcadTrabajosRecep(int idAcademico, int trabajos, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicotrabajosrecep AcadTrabajos = new Academicotrabajosrecep();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Academicotrabajosrecep".
                var ListAcad = context.Academicotrabajosrecep.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicotrabajosrecep item in ListAcad)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademico && trabajos == item.IdTrabajosRecep)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosTrabajosRecep", new { id = trabajos });
                    }
                }
                AcadTrabajos.Lider = Lider;
                AcadTrabajos.IdAcademico = idAcademico;
                AcadTrabajos.IdTrabajosRecep = trabajos;
                context.Academicotrabajosrecep.Add(AcadTrabajos); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosTrabajosRecep", new { id = AcadTrabajos.IdTrabajosRecep });
        }
        [Authorize]
        //Función para eliminar a los academicos relacionados con un trabajo recepcional.
        public IActionResult EliminarAcadTrabajosRecep(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicotrabajosrecep eliminar = context.Academicotrabajosrecep.Where(w => w.IdAcademicoTrabajosRecep == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Academicotrabajosrecep.Remove(eliminar); //Se elimina la relación del academico con el registro.
                context.SaveChanges();
                return RedirectToAction("AcademicosTrabajosRecep", new { id = id_acad });
            }
        }






        [Authorize]
        //Función para mostrar la información de los concursos que presentan los académicos.
        public IActionResult IndexConcursos()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaConcursos fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaConcursos> ListConcursos = new List<TablaConcursos>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos con sus respectivos concursos.
                ListConcursos = (from datos in context.Concursos
                                 join tipo in context.TipoLocNacInter on datos.IdNacInter equals tipo.IdTipo
                                 select new TablaConcursos
                                 {
                                     IdConcursos = datos.IdConcursos,
                                     Archivo = datos.Archivo,
                                     Tipo = tipo.Nombre,
                                     NombreConcurso = datos.Nombre,
                                 }
                               ).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se consulta si es lider de algun concurso y darle el permiso de modificar dichos registros.
                    List<Academicoconcursos> ListAcad = new List<Academicoconcursos>();
                    ListAcad = context.Academicoconcursos.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListConcursos);
        }
        [Authorize]
        //Función para acceder a la vista de agregar un concurso de un académico y obtener los datos necesarios para los select.
        public IActionResult CrearConcursos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de las academias de la base de datos.
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList(); //Obtención de las localizaciones de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["academicos"] = acad;
                ViewData["lugar"] = lugar;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar los datos obtenidos de la vista de crear concurso.
        public async Task<IActionResult> GuardarConcursos(IFormFile file, Concursos datos, int idAcademico, int Lider)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipo es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            if (tipo == 2)
            {
                //Si el tipo de usuario es = 2 (académico), aquí se obtinen el id del académico, ya que en los datos obtenidos de la vista no viene.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Concursos".
                var ListConcursos = context.Concursos.ToList(); //Se obtienen los registros de la tabla.
                foreach (Concursos item in ListConcursos)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdNacInter == item.IdNacInter && datos.Nombre == item.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexConcursos");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename();
                datos.Archivo = name;
                context.Concursos.Add(datos); //Guardado de la información.
                context.SaveChanges();
                var new_name_table = datos.IdConcursos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                datos.Archivo = new_name_table;
                context.Concursos.Update(datos); //Actualización de la información.s
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdConcursos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Concursos", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al académico creador del concurso en la tabla Academicoconcursos.
                Concursos DatosTrabajosR = context.Concursos.Last();
                Academicoconcursos info = new Academicoconcursos();
                info.IdAcademico = idAcademico;
                info.IdConcursos = DatosTrabajosR.IdConcursos;
                info.Lider = Lider;
                context.Academicoconcursos.Add(info); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexConcursos");
        }
        [Authorize]
        //Función para acceder a la vista de editar un concurso de un académico y obtener los datos necesarios para los select.
        public IActionResult EditarConcursos(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Concursos DatosConcursos = context.Concursos.Where(s => s.IdConcursos == id).Single(); //Obtención de los datos a editar.
                var lugar = context.TipoLocNacInter.Where(s => s.Nombre != "Local").ToList(); //Obtención de las localizaciones de la base de datos.
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["lugar"] = lugar;

                return View(DatosConcursos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para actualizar los datos obtenidos de la vista de editar concurso.
        public async Task<IActionResult> ActualizarConcursos(IFormFile file, Concursos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Concursos".
                var ListConcursos = context.Concursos.Where(l => l.IdConcursos != datos.IdConcursos).ToList(); //Se obtienen los registros de la tabla.
                foreach (Concursos item in ListConcursos)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (datos.IdNacInter == item.IdNacInter && datos.Nombre == item.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexConcursos");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo a guardar, solo se consulta el nombre del archivo ya guardado para colocarlo en su campo correspondiente.
                    var nomArchivo = context.Concursos.Where(w => w.IdConcursos == datos.IdConcursos).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si se encuentra archivo ha guardar, se prosigue a lo siguiente.
                    var new_name_table = datos.IdConcursos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.Concursos.Update(datos); //Actualización de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo para guardar, se redirecciona al index correspondiente.
                return RedirectToAction("IndexConcursos");
            }
            var new_name_file = datos.IdConcursos + "_" + file.GetFilename(); //Modificación del nombre del archivo, para evitar la sobreescritura con otros.
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Publicaciones/Concursos", new_name_file); //Se acompleta la ruta del archivo.
            //Guardado del archivo.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexConcursos");
        }
        //Función para eliminar a los academicos relacionados con un concurso.
        public IActionResult EliminarConcursos(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<Academicoconcursos> eliminarAcad = context.Academicoconcursos.Where(f => f.IdConcursos == id).ToList(); //Busqueda de los académicos relacionados con el registro, condicionado por el id recibido.
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico con el registro.
                    context.Academicoconcursos.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
                Concursos eliminar = context.Concursos.Where(w => w.IdConcursos == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Concursos.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("IndexConcursos");
            }
        }
        //Función para descargar el archivo de evidencia del academico seleccionado sobre los concursos.
        public async Task<IActionResult> DescargarConcursos(string filename)
        {
            //Se verifica que la variable filename tenga el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Publicaciones/Concursos", filename);
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
        //Función para mostrar la información de académicos colaboradores de un respectivo concurso seleccionado.
        public IActionResult AcademicosConcursos(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario"); //tipoUsu es la variable donde se guarda el permiso según tipo de usuario (1=director, 2=académico, 3=alumno).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //idUsu guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //La clase TablaAcadConcursos fue creada manualmente, esto para poder tener acceso a los datos de un solo lugar.
            List<TablaAcadConcursos> ListAcadConcursos = new List<TablaAcadConcursos>(); //Declaración de la lista donde se obtendran los datos.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener a todos los academicos relacionados con los concursos.
                ListAcadConcursos = (from datos in context.Academicoconcursos
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     where datos.IdConcursos == id
                                     select new TablaAcadConcursos
                                     {
                                         IdAcadConcursos = datos.IdAcademicoConcursos,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         IdConcursos = datos.IdConcursos
                                     }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                //Envio de los datos a la vista.
                ViewData["academicos"] = acade;
                ViewData["idConcursos"] = id;
                //Se busca si el academico usuario es lider del concurso seleccionado, esto comparando si el campo lider es igual = 1.
                Academicoconcursos Acad = new Academicoconcursos();
                int cant = context.Academicoconcursos.Where(w => w.IdConcursos == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicoconcursos.Where(w => w.IdConcursos == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadConcursos);
        }
        [Authorize]
        //Función para guardar los datos de los académicos colaboradores de un concurso.
        public IActionResult GuardarAcadConcursos(int idAcademico, int concursos, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicoconcursos AcadConcursos = new Academicoconcursos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "Academicoconcursos".
                var ListAcad = context.Academicoconcursos.ToList(); //Se obtienen los registros de la tabla.
                foreach (Academicoconcursos item in ListAcad)
                {
                    //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                    if (idAcademico == item.IdAcademico && concursos == item.IdConcursos)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosConcursos", new { id = concursos });
                    }
                }
                AcadConcursos.Lider = Lider;
                AcadConcursos.IdAcademico = idAcademico;
                AcadConcursos.IdConcursos = concursos;
                context.Academicoconcursos.Add(AcadConcursos); //Guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosConcursos", new { id = AcadConcursos.IdConcursos });
        }
        [Authorize]
        //Función para eliminar un registro de un concurso.
        public IActionResult EliminarAcadConcursos(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicoconcursos eliminar = context.Academicoconcursos.Where(w => w.IdAcademicoConcursos == id).Single(); //Busqueda del registro ha eliminar, condicionado por el id recibido.
                context.Academicoconcursos.Remove(eliminar); //Se elimina la relación del academico con el registro.
                context.SaveChanges();
                return RedirectToAction("AcademicosConcursos", new { id = id_acad });
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
