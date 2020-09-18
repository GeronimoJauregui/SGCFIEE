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
using System.Security.Cryptography;
using System.Text;

namespace SGCFIEE.Controllers
{
    public class AcademicosDatosGeneralesController : Controller
    {
        [Authorize]
        // Este es el metodo que reune la información de la vista principal de Academicos/Datos generales
        public IActionResult Index()
        {
            // el ID y tipo de usuario lo obtenemos en todos los metodos esto porque existe un nivel jerarquico dentro del sistema
            // Tipo 1: corresponde al maximo usuario que es el director, el cual tiene acceso a todo
            // Tipo 2: se refiere a un academico, este ve el contenido limitado solo a lo que el respecta
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            ViewData["tipo"] = tipo;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos si el usuario es tipo director para recopilar la informacion de todos los academicos que esten en la DB
                // la informacion la retornamos en una lista hacia la vista
                if (tipo == 1)
                {
                    var dg = (from aca in context.Academicos
                              join pe in context.ProgramaEducativo on aca.IdProgramaEducativo equals pe.IdProgramaEducativo
                              join tp in context.TipoPersonal on aca.RTipoPersonal equals tp.IdTipoPersonal
                              // creamos modelos dentro del framework (no existen en la DB) ya que las tablas de la db
                              // solo guardan valores numericos de las relaciones a otras tablas
                              // con esto podemos obtener el nombre y no el numero
                              // siendo mas fácil a la hora de mostrar la información en la vista
                              select new pAcademicos
                              {
                                  IdAcademicos = aca.IdAcademicos,
                                  Nombre = aca.Nombre,
                                  ApellidoPaterno = aca.ApellidoPaterno,
                                  ApellidoMaterno = aca.ApellidoMaterno,
                                  // las fechas que nos retorna la busqueda estan en formato fecha - hora
                                  // nosotros solo necesitamos la fecha, "Tostring()" nos regresa justo eso.
                                  FechaNacimiento = aca.FechaNacimiento.ToString(),
                                  Curp = aca.Curp,
                                  CorreoInstitucional = aca.CorreoInstitucional,
                                  CorreoAlternativo = aca.CorreoAlternativo,
                                  Celular = aca.Celular,
                                  Sexo = aca.Sexo,
                                  ProgramaEducativo = pe.Nombre,
                                  NumeroPersonal = aca.NumeroPersonal,
                                  FechaIngresoUv = aca.FechaIngresoUv.ToString(),
                                  Status = aca.Status,
                                  RTipoPersonal = aca.RTipoPersonal,
                                  tipoPersonal = tp.Nombre,
                                  Rfc = aca.Rfc

                              }
                               ).ToList();

                    // el modelo creado en el framework solo acepta el sexo en string
                    // entonces lo convertimos manuelmente como se ve abajo
                    foreach (var item in dg)
                    {
                        if (item.Sexo == 0)
                            item.Nombre_Sexo = "Femenino";
                        if (item.Sexo == 1)
                            item.Nombre_Sexo = "Masculino";
                        if (item.Status == 1)
                            item.NombreStatus = "Activo";
                        if (item.Status == 2)
                            item.NombreStatus = "Inactivo";
                        if (item.Status == 3)
                            item.NombreStatus = "Incapacitado";
                    }
                    ViewData["academicos"] = dg;
                }
                // tipo 2 nos dice que se trata de un académico
                if (tipo == 2) {
                    var dg = (from aca in context.Academicos
                              join pe in context.ProgramaEducativo on aca.IdProgramaEducativo equals pe.IdProgramaEducativo
                              join tp in context.TipoPersonal on aca.RTipoPersonal equals tp.IdTipoPersonal
                              // buscamos solo la información correspondiente a este académico
                              where aca.IdAcademicos == idUsu
                              select new pAcademicos
                              {
                                  IdAcademicos = aca.IdAcademicos,
                                  Nombre = aca.Nombre,
                                  ApellidoPaterno = aca.ApellidoPaterno,
                                  ApellidoMaterno = aca.ApellidoMaterno,
                                  FechaNacimiento = aca.FechaNacimiento.ToString(),
                                  Curp = aca.Curp,
                                  CorreoInstitucional = aca.CorreoInstitucional,
                                  CorreoAlternativo = aca.CorreoAlternativo,
                                  Celular = aca.Celular,
                                  Sexo = aca.Sexo,
                                  ProgramaEducativo = pe.Nombre,
                                  NumeroPersonal = aca.NumeroPersonal,
                                  FechaIngresoUv = aca.FechaIngresoUv.ToString(),
                                  Status = aca.Status,
                                  RTipoPersonal = aca.RTipoPersonal,
                                  tipoPersonal = tp.Nombre,
                                  Rfc = aca.Rfc

                              }
                                   ).ToList();

                    foreach (var item in dg)
                    {
                        if (item.Sexo == 0)
                            item.Nombre_Sexo = "Femenino";
                        if (item.Sexo == 1)
                            item.Nombre_Sexo = "Masculino";
                        if (item.Status == 1)
                            item.NombreStatus = "Activo";
                        if (item.Status == 2)
                            item.NombreStatus = "Inactivo";
                        if (item.Status == 3)
                            item.NombreStatus = "Incapacitado";
                    }
                    ViewData["academicos"] = dg;
                }

            }
            return View();
        }

        //crear Datos Generales
        [Authorize]
        public IActionResult CrearDG()
        {
            // el formulario para crear a un nuevo academico solo necesita el catalogo de programas educativos
            // los demás son inputs
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var pe = context.ProgramaEducativo.ToList();
                ViewData["pe"] = pe;
            }
            return View();
        }

        public IActionResult EditarDG(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicos aca = new Academicos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // este método recibe el id del académico a editar
                // y lo retorna a la vista
                aca = context.Academicos.Where(w => w.IdAcademicos == id).Single();
                var pe = context.ProgramaEducativo.ToList();
                ViewData["pe"] = pe;
                ViewData["aca"] = aca;
                ViewData["academico"] = id;
                //string fecha = aca.FechaNacimiento.ToString();
                //string[] resultado = fecha.Split(' ');
                //ViewData["fecha"] = resultado[0];
            }
            return View(aca);
        }
        public IActionResult Restablecercontra(int idd)
        {
            Usuarios usu = new Usuarios();
            Academicos aca = new Academicos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                
               // buscamos al académico tanto en la tabla de académicos como en usuarios 
                usu = context.Usuarios.Where(w => w.IdAcademico == idd).Single();
                aca = context.Academicos.Where(w => w.IdAcademicos == idd).Single();
                // la contraseña por defecto utiliza los primeros 10 carácteres de la CURP
                string subcurp = aca.Curp.Substring(0, 10);
                // despues se concatena con el número de personal
                String p = string.Concat(aca.NumeroPersonal, subcurp);
                //String p = string.Concat("15344", "POBL660419");
                // finalmente se encripta
                SHA1 sha = new SHA1CryptoServiceProvider();
                byte[] input2 = (new UnicodeEncoding()).GetBytes(p);
                byte[] h = sha.ComputeHash(input2);
                string pa = Convert.ToBase64String(h);
                usu.Contrasenia = pa;
                context.Usuarios.Update(usu);
                context.SaveChanges();
            }// enviamos el mensaje de confirmación
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Restablecido exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("DetallesDG", new { id = idd });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult GuardarDG(Academicos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // El formulario de datos generales no pide el tipo de personal
                // pero es necesario asignarlo al momento de crear un nuevo académico
                // por el momento asignamos el numero 2 que corresponde a "asignatura"
                // ya que este tipo no necesita crear datos en otra tabla
                datos.RTipoPersonal = 2;
                // todas las CURP's deben ser mayúsculas
                datos.Curp.ToUpper();
                context.Academicos.Add(datos);
                context.SaveChanges();
                // una vez guardado obtenemos ese ultimo para usar el id llave
                // y hacer la relación a la tabla de usuarios
                Academicos last = context.Academicos.Last();

                Usuarios usunuevo = new Usuarios();
                usunuevo.IdAcademico = last.IdAcademicos;
                usunuevo.Nombre = last.NumeroPersonal.ToString();
                // tipo 2 significa académico normal
                usunuevo.Tipo = 2;

                string curp = last.Curp.ToString();
                string subcurp = curp.Substring(0,10);


                String p = string.Concat(last.NumeroPersonal.ToString(), subcurp.ToString());
                SHA1 sha = new SHA1CryptoServiceProvider();
                byte[] input2 = (new UnicodeEncoding()).GetBytes(p);
                byte[] h = sha.ComputeHash(input2);
                string pa = Convert.ToBase64String(h);
                usunuevo.Contrasenia = pa;
                context.Usuarios.Add(usunuevo);
                context.SaveChanges();
            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicos aca = context.Academicos.Last();
                return RedirectToAction("TablaGA", new { id = aca.IdAcademicos });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult ActualizarDG(Academicos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                datos.Curp.ToUpper();
                context.Academicos.Update(datos);
                context.SaveChanges();
            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("EditarDG", new { id = datos.IdAcademicos });
            }

        }

        // Tabla grados académicos
        [Authorize]
        public IActionResult TablaGA(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pEstudios> estudios = new List<pEstudios>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // en esta tabla 1 es para Empresas y 2 para instituciones
                // obtenemos todas las instituciones
                var ies = context.InstitucionesEmpresas.Where(w => w.IesEmpresa == 2).ToList();
                var GradoTitulo = context.GradoTitulo.ToList();

                estudios = (from es in context.Estudios
                            join ie in context.InstitucionesEmpresas on es.IdInstitucion equals ie.IdIE
                            join gt in context.GradoTitulo on es.IdGradoTitulo equals gt.IdGradoTitulo
                            where es.IdAcademico == id
                            select new pEstudios
                            {
                                IdEstudios = es.IdEstudios,
                                IdAcademico = es.IdAcademico,
                                Institucion = ie.Nombre,
                                GradoTitulo = gt.Nombre,
                                AcrePnpc = es.AcrePnpc,
                                FechaDeEgreso = es.FechaDeEgreso.ToString(),
                                FechaDeTitulacion = es.FechaDeTitulacion.ToString(),
                                ArchivoCedula = es.ArchivoCedula,
                                ArchivoTitulo = es.ArchivoTitulo
                            }
                               ).ToList();

                foreach (pEstudios item in estudios) {
                    if (item.AcrePnpc == 0)
                        item.Reconocimiento = "Ninguno";
                    if (item.AcrePnpc == 1)
                        item.Reconocimiento = "Acreditado";
                    if (item.AcrePnpc == 2)
                        item.Reconocimiento = "PNPC";
                }
                ViewData["gt"] = GradoTitulo;
                ViewData["ies"] = ies;
                ViewData["academico"] = id;
                ViewData["estudios"] = estudios;
            }
            return View();
        }

        // Este metódo guarda el formulario de grados académicos perteneciente a Crear alumno
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarTablaGA(List<IFormFile> file, Estudios datos, string nuevoTitulo, string nuevaInstitucion)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                // Si el usuario no encuentra su institución puede agregarla
                // Aquí guardamos esa nueva institución
                if (nuevaInstitucion != null)
                {
                    InstitucionesEmpresas nuevo = new InstitucionesEmpresas();
                    nuevo.Nombre = nuevaInstitucion;
                    nuevo.IesEmpresa = 2;
                    context.InstitucionesEmpresas.Add(nuevo);
                    context.SaveChanges();
                    InstitucionesEmpresas ultima = context.InstitucionesEmpresas.Last();
                    // otenemos el id llave de esa nueva institución y la agregamos a los datos del estudio
                    datos.IdInstitucion = ultima.IdIE;
                }
                // hacemos el mismo porceso anterior pero con el nombre del titulo
                if (nuevoTitulo != null)
                {
                    GradoTitulo nuevo = new GradoTitulo();
                    nuevo.Nombre = nuevoTitulo;
                    context.GradoTitulo.Add(nuevo);
                    context.SaveChanges();
                    GradoTitulo ultima = context.GradoTitulo.Last();
                    datos.IdGradoTitulo = ultima.IdGradoTitulo;
                }

                var new_name_table = "Titulo" + "_" + datos.IdAcademico + "_" + datos.IdGradoTitulo + "_" + file[0].GetFilename();
                var new_name_table2 = "Cedula" + "_" + datos.IdAcademico + "_" + datos.IdGradoTitulo + "_" + file[1].GetFilename();
                datos.ArchivoTitulo = new_name_table;
                datos.ArchivoCedula = new_name_table2;
                context.Estudios.Add(datos);
                context.SaveChanges();
            }
            // si el formulario no contiene archivos retornamos la siguiente vista
            if (file[0] == null || file[0].Length == 0)
                return Content("file not selected");
			// se crea el nuevo norbre del archivo           
            var new_name_file = "Titulo" + "_" + datos.IdAcademico + "_" + datos.IdGradoTitulo + "_" + file[0].GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Estudios", new_name_file);

            // se guarda el archivo 	
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file[0].CopyToAsync(stream);
            }
            // mismo proceso que el archivo anterior
            if (file[1] == null || file[1].Length == 0)
                return Content("file not selected");

            var new_name_file2 = "Cedula" + "_" + datos.IdAcademico + "_" + datos.IdGradoTitulo + "_" + file[1].GetFilename();
            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Estudios", new_name_file2);

            using (var stream = new FileStream(path2, FileMode.Create))
            {
                await file[1].CopyToAsync(stream);
            }          
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            // se redirige y se envia el id del academico con el que estamos tratando
            return RedirectToAction("TablaGA", new { id = datos.IdAcademico });
        }
        // Editar grados académicos
        [Authorize]
        public IActionResult EditarGA(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            // se obtienen los estudios personalizados
            List<pEstudios> estudios = new List<pEstudios>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                estudios = (from es in context.Estudios
                            join ie in context.InstitucionesEmpresas on es.IdInstitucion equals ie.IdIE
                            join gt in context.GradoTitulo on es.IdGradoTitulo equals gt.IdGradoTitulo
                            where es.IdAcademico == id
                            select new pEstudios
                            {
                                IdEstudios = es.IdEstudios,
                                IdAcademico = es.IdAcademico,
                                Institucion = ie.Nombre,
                                GradoTitulo = gt.Nombre,
                                AcrePnpc = es.AcrePnpc,
                                FechaDeEgreso = es.FechaDeEgreso.ToString(),
                                FechaDeTitulacion = es.FechaDeTitulacion.ToString(),
                                ArchivoCedula = es.ArchivoCedula,
                                ArchivoTitulo = es.ArchivoTitulo
                            }
                               ).ToList();

                foreach (pEstudios item in estudios)
                {
                    if (item.AcrePnpc == 0)
                        item.Reconocimiento = "Ninguno";
                    if (item.AcrePnpc == 1)
                        item.Reconocimiento = "Acreditado";
                    if (item.AcrePnpc == 2)
                        item.Reconocimiento = "PNPC";
                }
                ViewData["academico"] = id;
                ViewData["estudios"] = estudios;
            }
            return View();
        }

		// este formulario se ve en Editar -> crear        
        [Authorize]
        public IActionResult FormCrearGA(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // mostramos puras instituciones
                var ies = context.InstitucionesEmpresas.Where(w => w.IesEmpresa == 2).ToList();
                var GradoTitulo = context.GradoTitulo.ToList();

            
                ViewData["gt"] = GradoTitulo;
                ViewData["ies"] = ies;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarFormTablaGA(List<IFormFile> file, Estudios datos, string nuevoTitulo, string nuevaInstitucion)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                // Si el usuario no encuentra su institución puede agregarla
				// Aquí guardamos esa nueva institución
                if (nuevaInstitucion != null)
                {
                    InstitucionesEmpresas nuevo = new InstitucionesEmpresas();
                    nuevo.Nombre = nuevaInstitucion;
                    nuevo.IesEmpresa = 2;
                    context.InstitucionesEmpresas.Add(nuevo);
                    context.SaveChanges();
                    InstitucionesEmpresas ultima = context.InstitucionesEmpresas.Last();
                    // otenemos el id llave de esa nueva institución y la agregamos a los datos del estudio
                    datos.IdInstitucion = ultima.IdIE;
                }
                // hacemos el mismo porceso anterior pero con el nombre del titulo
                if (nuevoTitulo != null)
                {
                    GradoTitulo nuevo = new GradoTitulo();
                    nuevo.Nombre = nuevoTitulo;
                    context.GradoTitulo.Add(nuevo);
                    context.SaveChanges();
                    GradoTitulo ultima = context.GradoTitulo.Last();
                    datos.IdGradoTitulo = ultima.IdGradoTitulo;
                }

                // creamos los nombres de los archivos
                var new_name_table = "Titulo" + "_" + datos.IdAcademico + "_" + datos.IdGradoTitulo + "_" + file[0].GetFilename();
                var new_name_table2 = "Cedula" + "_" + datos.IdAcademico + "_" + datos.IdGradoTitulo + "_" + file[1].GetFilename();
                datos.ArchivoTitulo = new_name_table;
                datos.ArchivoCedula = new_name_table2;
                context.Estudios.Add(datos);
                context.SaveChanges();
            }

            if (file[0] == null || file[0].Length == 0)
                return Content("file not selected");

            // guardamos archivo
            var new_name_file = "Titulo" + "_" + datos.IdAcademico + "_" + datos.IdGradoTitulo + "_" + file[0].GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Estudios", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file[0].CopyToAsync(stream);
            }

            if (file[1] == null || file[1].Length == 0)
                return Content("file not selected");

            // guardamos archivo
            var new_name_file2 = "Cedula" + "_" + datos.IdAcademico + "_" + datos.IdGradoTitulo + "_" + file[1].GetFilename();
            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Estudios", new_name_file2);

            using (var stream = new FileStream(path2, FileMode.Create))
            {
                await file[1].CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("EditarGA", new { id = datos.IdAcademico });
        }
        // Editar grados academicos
        [Authorize]
        // obtenemos el id del estudio y el id del academico
        public IActionResult FormEditarGA(int id, int idAcad)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ies = context.InstitucionesEmpresas.Where(w => w.IesEmpresa == 2).ToList();
                var GradoTitulo = context.GradoTitulo.ToList();
                var ga = context.Estudios.Where(w => w.IdEstudios == id).Single();

                ViewData["gt"] = GradoTitulo;
                ViewData["ies"] = ies;
                ViewData["academico"] = idAcad;
                return View(ga);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> FormActualizarTablaGA(IFormFile file, IFormFile file2, Estudios datos, string nuevoTitulo, string nuevaInstitucion)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
            	// se crea la institucion si es que no existe
                if (nuevaInstitucion != null)
                {
                    InstitucionesEmpresas nuevo = new InstitucionesEmpresas();
                    nuevo.Nombre = nuevaInstitucion;
                    nuevo.IesEmpresa = 2;
                    context.InstitucionesEmpresas.Add(nuevo);
                    context.SaveChanges();
                    InstitucionesEmpresas ultima = context.InstitucionesEmpresas.Last();
                    datos.IdInstitucion = ultima.IdIE;
                }
                // se crea el titulo si es que no existe
                if (nuevoTitulo != null)
                {
                    GradoTitulo nuevo = new GradoTitulo();
                    nuevo.Nombre = nuevoTitulo;
                    context.GradoTitulo.Add(nuevo);
                    context.SaveChanges();
                    GradoTitulo ultima = context.GradoTitulo.Last();
                    datos.IdGradoTitulo = ultima.IdGradoTitulo;
                }
                // si no ingreso un nuevo archivo, se pone el mismo que tenia antes
                if (file == null || file.Length == 0)
                {
                    var nomArchivo = context.Estudios.Where(w => w.IdEstudios == datos.IdEstudios).Single();
                    datos.ArchivoTitulo = nomArchivo.ArchivoTitulo;
                }
                else
                {
                	// se sustituye el archivo
                    var new_name_table = "Titulo" + "_" + datos.IdAcademico + "_" + datos.IdGradoTitulo + "_" + file.GetFilename();
                    datos.ArchivoTitulo = new_name_table;
                }
                // si no ingreso un nuevo archivo, se pone el mismo que tenia antes
                if (file2 == null || file2.Length == 0)
                {
                    var nomArchivo = context.Estudios.Where(w => w.IdEstudios == datos.IdEstudios).Single();
                    datos.ArchivoCedula = nomArchivo.ArchivoCedula;
                }
                else
                {
                	// se sustituye el archivo
                    var new_name_table2 = "Cedula" + "_" + datos.IdAcademico + "_" + datos.IdGradoTitulo + "_" + file2.GetFilename();
                    datos.ArchivoCedula = new_name_table2;
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.Estudios.Update(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length != 0)
            {
                
            }
            else
            {	
            	//se guarda el archivo en el servidor
                var new_name_file = "Titulo" + "_" + datos.IdAcademico + "_" + datos.IdGradoTitulo + "_" + file.GetFilename();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Estudios", new_name_file);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            if (file2 == null || file2.Length != 0)
            {
               
            }
            else
            {
            	//se guarda el archivo en el servidor
                var new_name_file2 = "Cedula" + "_" + datos.IdAcademico + "_" + datos.IdGradoTitulo + "_" + file2.GetFilename();
                var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Estudios", new_name_file2);

                using (var stream = new FileStream(path2, FileMode.Create))
                {
                    await file2.CopyToAsync(stream);
                }
            }

            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("EditarGA", new { id = datos.IdAcademico });
        }

        
        // todos los metodos que empiezan con tabla...
        // pertenecen a la lista de formularios de cuando se crea un nuevo academico por primera vez

        // recibe el id del académico
        public IActionResult TablaCertificaciones(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pCertificaciones> certificaciones = new List<pCertificaciones>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var tc = context.TipoCertificacion.ToList();

                certificaciones = (from cer in context.Certificaciones
                                   join tcer in context.TipoCertificacion on cer.IdTipoCertificacion equals tcer.IdCertificacion
                                   where cer.IdAcademico == id
                                   select new pCertificaciones
                                   {
                                       IdCertificaciones = cer.IdCertificaciones,
                                       Nombre = cer.Nombre,
                                       IdTipoCertificacion = cer.IdTipoCertificacion,
                                       TipoCertificacion = tcer.Nombre,
                                       IdAcademico = cer.IdAcademico,
                                   }
                                   ).ToList();

                ViewData["tc"] = tc;
                ViewData["cer"] = certificaciones;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarTablaCertificaciones(IFormFile file, Certificaciones datos, string nuevoTC)
        {
        	// si el usuario ingreeso un tipo de certificacion nuevo, se agrega a la DB
            if (nuevoTC != null)
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    TipoCertificacion nuevo = new TipoCertificacion();
                    nuevo.Nombre = nuevoTC;
                    context.TipoCertificacion.Add(nuevo);
                    context.SaveChanges();
                    TipoCertificacion ultimaE = context.TipoCertificacion.Last();
                    datos.IdTipoCertificacion = ultimaE.IdCertificacion;
                }

            }

            // se guarda la certificación
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = "Certificacion" + "" + datos.IdAcademico + "" + datos.Nombre + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Certificaciones.Add(datos);
                context.SaveChanges();
            }

            // si no hay archivo regresa lo siguiente
            if (file == null || file.Length == 0)
                return Content("file not selected");

            // se guarda el archivo en el servidor
            var new_name_file = "Certificacion" + "" + datos.IdAcademico + "" + datos.Nombre + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Certificaciones", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
			// se redirige a la tabla        
            return RedirectToAction("TablaCertificaciones", new { id = datos.IdAcademico });
        }

        // recibe el id de la certificación a editar
        public IActionResult EditarCertificaciones(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pCertificaciones> certificaciones = new List<pCertificaciones>();
            using (sgcfieeContext context = new sgcfieeContext())
            {

                certificaciones = (from cer in context.Certificaciones
                                   join tcer in context.TipoCertificacion on cer.IdTipoCertificacion equals tcer.IdCertificacion
                                   where cer.IdAcademico == id
                                   select new pCertificaciones
                                   {
                                       IdCertificaciones = cer.IdCertificaciones,
                                       Nombre = cer.Nombre,
                                       IdTipoCertificacion = cer.IdTipoCertificacion,
                                       TipoCertificacion = tcer.Nombre,
                                       IdAcademico = cer.IdAcademico,
                                       Archivo = cer.Archivo
                                   }
                                   ).ToList();

                ViewData["cer"] = certificaciones;
                ViewData["academico"] = id;
            }
            return View();
        }
        // todos los metodos que empiezen con formCrrear....
        // se muestradan cuando desde modificar se agrega un elemento nuevo
        
        // recibe id del academico
        public IActionResult FormCrearCertificacion(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var tc = context.TipoCertificacion.ToList();
                ViewData["tc"] = tc;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarFormCertificaciones(IFormFile file, Certificaciones datos, string nuevoTC)
        {

            // si el usuario ingresa un nuevo tipo de certificación primero se guarda en el DB
            if (nuevoTC != null)
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    TipoCertificacion nuevo = new TipoCertificacion();
                    nuevo.Nombre = nuevoTC;
                    context.TipoCertificacion.Add(nuevo);
                    context.SaveChanges();
                    TipoCertificacion ultimaE = context.TipoCertificacion.Last();
                    datos.IdTipoCertificacion = ultimaE.IdCertificacion;
                }

            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = "Certificacion" + "" + datos.IdAcademico + "" + datos.Nombre + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.Certificaciones.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            // se guarda el archivo en el servidor
            var new_name_file = "Certificacion" + "" + datos.IdAcademico + "" + datos.Nombre + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Certificaciones", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("EditarCertificaciones", new { id = datos.IdAcademico });
        }

        // recibe id de la certificacion y id del académico
        public IActionResult FormEditarCertificaciones(int id, int idAcad)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Certificaciones certificaciones = new Certificaciones();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var tc = context.TipoCertificacion.ToList();

                certificaciones = context.Certificaciones.Where(w => w.IdCertificaciones == id).Single();

                ViewData["tc"] = tc;
                ViewData["academico"] = idAcad;
                return View(certificaciones);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarFormCertificaciones(IFormFile file, Certificaciones datos, string nuevoTC)
        {
            // si el usuario ingresa un nuevo tipo de certificación primero se guarda en el DB
            if (nuevoTC != null)
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    TipoCertificacion nuevo = new TipoCertificacion();
                    nuevo.Nombre = nuevoTC;
                    context.TipoCertificacion.Add(nuevo);
                    context.SaveChanges();
                    TipoCertificacion ultimaE = context.TipoCertificacion.Last();
                    datos.IdTipoCertificacion = ultimaE.IdCertificacion;
                }

            }

            using (sgcfieeContext context = new sgcfieeContext())
            {
            	// se sustituye el archivo
                if (file != null)
                {
                    var new_name_table = "Certificacion" + "" + datos.IdAcademico + "" + datos.Nombre + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }
                else
                {
                	// si no actualizo el archivo se pone el que ya tenia anteriormente
                    var nomArchivo = context.Certificaciones.Where(w => w.IdCertificaciones == datos.IdCertificaciones).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }

            }
            // se actualiza el registro
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.Certificaciones.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }

            // se guarda el archivo en el servidor
            if (file != null)
            {
                var new_name_file = "Certificacion" + "" + datos.IdAcademico + "" + datos.Nombre + "_" + file.GetFilename();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Certificaciones", new_name_file);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return RedirectToAction("EditarCertificaciones", new { id = datos.IdAcademico });
        }

        // se muestra cuado se agrega un académico por primera vez
        // recibe id dela académico
        // Tabla cursos diplomados
        public IActionResult TablaCD(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pCursosDiplomadoFormacion> CD = new List<pCursosDiplomadoFormacion>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ies = context.InstitucionesEmpresas.ToList();

                CD = (from cd in context.CursosDiplomadoFormacion
                      join ins in context.InstitucionesEmpresas on cd.IdIesEmpresa equals ins.IdIE
                      where cd.IdAcademico == id
                      select new pCursosDiplomadoFormacion
                      {
                          IdCD = cd.IdCD,
                          IdAcademico = cd.IdAcademico,
                          Nombre = cd.Nombre,
                          CursoDiplomado = cd.CursoDiplomado,
                          PD = cd.PD,
                          Horas = cd.Horas,
                          IdIesEmpresa = cd.IdIesEmpresa,
                          institucion = ins.Nombre,
                          Lugar = cd.Lugar,
                          Fecha = cd.Fecha.ToString(),
                          Archivo = cd.Archivo

                      }
                                   ).ToList();

                ViewData["ies"] = ies;
                ViewData["cd"] = CD;
                ViewData["academico"] = id;
            }
            return View();
        }
        // recibe el id del curso/diplomado
        [Authorize]
        public IActionResult EditarCD(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pCursosDiplomadoFormacion> CD = new List<pCursosDiplomadoFormacion>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CD = (from cd in context.CursosDiplomadoFormacion
                      join ins in context.InstitucionesEmpresas on cd.IdIesEmpresa equals ins.IdIE
                      where cd.IdAcademico == id
                      select new pCursosDiplomadoFormacion
                      {
                          IdCD = cd.IdCD,
                          IdAcademico = cd.IdAcademico,
                          Nombre = cd.Nombre,
                          CursoDiplomado = cd.CursoDiplomado,
                          PD = cd.PD,
                          Horas = cd.Horas,
                          IdIesEmpresa = cd.IdIesEmpresa,
                          institucion = ins.Nombre,
                          Lugar = cd.Lugar,
                          Fecha = cd.Fecha.ToString(),
                          Archivo = cd.Archivo

                      }
                                   ).ToList();
                ViewData["cd"] = CD;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarTablaCD(IFormFile file, CursosDiplomadoFormacion datos, int tipo, string nuevaInstEmpre)
        {
        	// tipo recibe si se trata de un una institución o una empresa
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // si el usuario ingresa un nueva institución\empresa primero se guarda en el DB
                if (nuevaInstEmpre != null)
                {
                    InstitucionesEmpresas nuevo = new InstitucionesEmpresas();
                    nuevo.Nombre = nuevaInstEmpre;
                    nuevo.IesEmpresa = tipo;
                    context.InstitucionesEmpresas.Add(nuevo);
                    context.SaveChanges();
                    InstitucionesEmpresas ultima = context.InstitucionesEmpresas.Last();
                    datos.IdIesEmpresa = ultima.IdIE;
                }

                // se guarda el nuevo registro en la DB
                var new_name_table = "CD" + "_" + datos.IdAcademico + "_" + datos.Nombre + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.CursosDiplomadoFormacion.Add(datos);
                context.SaveChanges();
            }

            // si no hay archivo envia este mensaje
            if (file == null || file.Length == 0)
                return Content("file not selected");

            // se guarda el archivo en el servidor
            var new_name_file = "CD" + "_" + datos.IdAcademico + "_" + datos.Nombre + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Cursos_Diplomados", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("TablaCD", new { id = datos.IdAcademico });
        }

        // recibe el id del académico
        public IActionResult FormCrearCD(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ies = context.InstitucionesEmpresas.ToList();
                ViewData["ies"] = ies;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        // Curso/diplomado
        public async Task<IActionResult> GuardarFormCD(IFormFile file, CursosDiplomadoFormacion datos, int tipo, string nuevaInstEmpre)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                // si el usuario ingresa un nueva institución/empresa primero se guarda en el DB
                if (nuevaInstEmpre != null)
                {
                    InstitucionesEmpresas nuevo = new InstitucionesEmpresas();
                    nuevo.Nombre = nuevaInstEmpre;
                    nuevo.IesEmpresa = tipo;
                    context.InstitucionesEmpresas.Add(nuevo);
                    context.SaveChanges();
                    InstitucionesEmpresas ultima = context.InstitucionesEmpresas.Last();
                    datos.IdIesEmpresa = ultima.IdIE;
                }

                // se guarda el el registro
                var new_name_table = "CD" + "_" + datos.IdAcademico + "_" + datos.Nombre + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.CursosDiplomadoFormacion.Add(datos);
                context.SaveChanges();
            }
            // si no contiene archivo regresa lo siguiente
            if (file == null || file.Length == 0)
                return Content("file not selected");

            // se guarda el archivo en el servidor
            var new_name_file = "CD" + "_" + datos.IdAcademico + "_" + datos.Nombre + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Cursos_Diplomados", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("EditarCD", new { id = datos.IdAcademico });
        }

        public IActionResult FormEditarCD(int id, int idAcad)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            CursosDiplomadoFormacion CD = new CursosDiplomadoFormacion();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ies = context.InstitucionesEmpresas.ToList();

                CD = context.CursosDiplomadoFormacion.Where(w => w.IdCD == id).Single();

                ViewData["ies"] = ies;
                ViewData["academico"] = idAcad;
            }
            return View(CD);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarFormCD(IFormFile file, CursosDiplomadoFormacion datos, int tipo, string nuevaInstEmpre)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                // si el usuario ingresa una nueva institución/empresa primero se guarda en el DB
                if (nuevaInstEmpre != null)
                {
                    InstitucionesEmpresas nuevo = new InstitucionesEmpresas();
                    nuevo.Nombre = nuevaInstEmpre;
                    nuevo.IesEmpresa = tipo;
                    context.InstitucionesEmpresas.Add(nuevo);
                    context.SaveChanges();
                    InstitucionesEmpresas ultima = context.InstitucionesEmpresas.Last();
                    datos.IdIesEmpresa = ultima.IdIE;
                }

                // se sustituye el archivo
                if (file != null)
                {
                    var new_name_table = "CD" + "_" + datos.IdAcademico + "_" + datos.Nombre + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }
                else
                {
                    // si no actualizo el archivo se pone el que ya tenia anteriormente
                    var nomArchivo = context.CursosDiplomadoFormacion.Where(w => w.IdCD == datos.IdCD).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CursosDiplomadoFormacion.Update(datos);
                context.SaveChanges();
            }

        	// se guarda el archivo en el servidor
            if (file != null) {
                var new_name_file = "CD" + "_" + datos.IdAcademico + "_" + datos.Nombre + "_" + file.GetFilename();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Cursos_Diplomados", new_name_file);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("EditarCD", new { id = datos.IdAcademico });
        }

        [Authorize]
        // experiencia profesional
        public IActionResult TablaEP(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pExperienciaProfesional> EP = new List<pExperienciaProfesional>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // obtiene las empresas
                var ies = context.InstitucionesEmpresas.Where(w => w.IesEmpresa == 1).ToList();
                var tp = context.TipoPuesto.ToList();

                EP = (from ep in context.ExperienciaProfesional
                      join ins in context.InstitucionesEmpresas on ep.IdEmpresa equals ins.IdIE
                      join tip in context.TipoPuesto on ep.IdTipoPuesto equals tip.IdPuesto
                      where ep.IdAcademico == id
                      select new pExperienciaProfesional
                      {
                          IdEp = ep.IdEp,
                          IdAcademico = ep.IdAcademico,
                          IdEmpresa = ep.IdEmpresa,
                          empresa = ins.Nombre,
                          IdTipoPuesto = tip.IdPuesto,
                          TipoPuesto = tip.Nombre,
                          FechaInicio = ep.FechaInicio.ToString(),
                          FechaFin = ep.FechaFin.ToString(),
                          AreaDesarrollo = ep.AreaDesarrollo

                      }
                                   ).ToList();
                // tomamos los años de inicio y final para calcular los años de expericia
                foreach (pExperienciaProfesional item in EP)
                {
                    int inicio = int.Parse(item.FechaInicio.Substring(0, 4));
                    int fin = int.Parse(item.FechaFin.Substring(0, 4));
                    int exp = fin - inicio;
                    if (exp == 0)
                        exp = 1;
                    item.FechaInicio = exp.ToString();

                }


                ViewData["ies"] = ies;
                ViewData["tp"] = tp;
                ViewData["ep"] = EP;
                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        public IActionResult EditarEP(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pExperienciaProfesional> EP = new List<pExperienciaProfesional>();
            using (sgcfieeContext context = new sgcfieeContext())
            {

                EP = (from ep in context.ExperienciaProfesional
                      join ins in context.InstitucionesEmpresas on ep.IdEmpresa equals ins.IdIE
                      join tip in context.TipoPuesto on ep.IdTipoPuesto equals tip.IdPuesto
                      where ep.IdAcademico == id
                      select new pExperienciaProfesional
                      {
                          IdEp = ep.IdEp,
                          IdAcademico = ep.IdAcademico,
                          IdEmpresa = ep.IdEmpresa,
                          empresa = ins.Nombre,
                          IdTipoPuesto = tip.IdPuesto,
                          TipoPuesto = tip.Nombre,
                          FechaInicio = ep.FechaInicio.ToString(),
                          FechaFin = ep.FechaFin.ToString(),
                          AreaDesarrollo = ep.AreaDesarrollo,
                          Archivo = ep.Archivo

                      }
                                   ).ToList();

                // tomamos los años de inicio y final para calcular los años de expericia
                foreach (pExperienciaProfesional item in EP)
                {
                    int inicio = int.Parse(item.FechaInicio.Substring(0, 4));
                    int fin = int.Parse(item.FechaFin.Substring(0, 4));
                    int exp = fin - inicio;
                    if (exp == 0)
                        exp = 1;
                    item.FechaInicio = exp.ToString();

                }

                ViewData["ep"] = EP;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarTablaEP(IFormFile file, ExperienciaProfesional datos, string nuevaEmpresa)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
            	// si el usuario ingresa un nueva empresa primero se guarda en el DB
                if (nuevaEmpresa != null)
                {
                    InstitucionesEmpresas nuevo = new InstitucionesEmpresas();
                    nuevo.Nombre = nuevaEmpresa;
                    nuevo.IesEmpresa = 1;
                    context.InstitucionesEmpresas.Add(nuevo);
                    context.SaveChanges();
                    InstitucionesEmpresas ultima = context.InstitucionesEmpresas.Last();
                    datos.IdEmpresa = ultima.IdIE;
                }

                // guardamos los datos
                var new_name_table = "EP" + "_" + datos.IdAcademico + "_" + datos.IdEmpresa + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.ExperienciaProfesional.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            // guardamos le archivo
            var new_name_file = "EP" + "_" + datos.IdAcademico + "_" + datos.IdEmpresa + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Exp_Profesional", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("TablaEP", new { id = datos.IdAcademico });
        }

        [Authorize]
        public IActionResult FormCrearEP(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ies = context.InstitucionesEmpresas.Where(w => w.IesEmpresa == 1).ToList();
                var tp = context.TipoPuesto.ToList();
                ViewData["ies"] = ies;
                ViewData["tp"] = tp;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarFormEP(IFormFile file, ExperienciaProfesional datos, string nuevaEmpresa)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
            	// si el usuario ingresa un nueva empresa primero se guarda en el DB
                if (nuevaEmpresa != null)
                {
                    InstitucionesEmpresas nuevo = new InstitucionesEmpresas();
                    nuevo.Nombre = nuevaEmpresa;
                    nuevo.IesEmpresa = 1;
                    context.InstitucionesEmpresas.Add(nuevo);
                    context.SaveChanges();
                    InstitucionesEmpresas ultima = context.InstitucionesEmpresas.Last();
                    datos.IdEmpresa = ultima.IdIE;
                }
                // guardamos los datos
                var new_name_table = "EP" + "_" + datos.IdAcademico + "_" + datos.IdEmpresa + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.ExperienciaProfesional.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            // guardamos el archivo
            var new_name_file = "EP" + "_" + datos.IdAcademico + "_" + datos.IdEmpresa + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Exp_Profesional", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("EditarEP", new { id = datos.IdAcademico });
        }

        [Authorize]
        // recibe el id del registro a editar y el id del academico
        public IActionResult FormEditarEP(int id, int idAcad)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            ExperienciaProfesional EP = new ExperienciaProfesional();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ies = context.InstitucionesEmpresas.Where(w => w.IesEmpresa == 1).ToList();
                var tp = context.TipoPuesto.ToList();

                EP = context.ExperienciaProfesional.Where(w => w.IdEp == id).Single();


                ViewData["ies"] = ies;
                ViewData["tp"] = tp;
                ViewData["academico"] = idAcad;
            }
            return View(EP);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarFormEP(IFormFile file, ExperienciaProfesional datos, string nuevaEmpresa)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {

                // si el usuario ingresa un nueva empresa primero se guarda en el DB
                if (nuevaEmpresa != null)
                {
                    InstitucionesEmpresas nuevo = new InstitucionesEmpresas();
                    nuevo.Nombre = nuevaEmpresa;
                    nuevo.IesEmpresa = 1;
                    context.InstitucionesEmpresas.Add(nuevo);
                    context.SaveChanges();
                    InstitucionesEmpresas ultima = context.InstitucionesEmpresas.Last();
                    datos.IdEmpresa = ultima.IdIE;
                }

                // se sustituye el archivo
                if (file != null)
                {
                    var new_name_table = "EP" + "_" + datos.IdAcademico + "_" + datos.IdEmpresa + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }
                else
                {
                	// si no actualizo el archivo se pone el que ya tenia anteriormente
                    var nomArchivo = context.ExperienciaProfesional.Where(w => w.IdEp == datos.IdEp).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ExperienciaProfesional.Update(datos);
                context.SaveChanges();
            }

            // se guarda el archivo en el servidor
            if (file != null) {
                var new_name_file = "EP" + "_" + datos.IdAcademico + "_" + datos.IdEmpresa + "_" + file.GetFilename();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Exp_Profesional", new_name_file);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("EditarEP", new { id = datos.IdAcademico });
        }

        [Authorize]
        // Tipo de contratación
        public IActionResult TablaTC(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var tl = context.TipoLaboratorio.ToList();
                var tp = context.TipoPersonal.ToList();
                ViewData["tl"] = tl;
                ViewData["tp"] = tp;
                ViewData["academico"] = id;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarTablaTC(IFormFile file, pTipoContratacion datos)
        {
            // al momento de crear un académico se le asigna el tipo 2, pero aqui se asigna el que verdaderamente es

            // guardamos los datos en la tabla "controtacionPTC" y actualizamos el tipo de contratacion en la tabla académicos
            if (datos.tipopersonal == 1) {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    var new_name_table = "PTC" + "_" + datos.IdAcademico + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                    ContratacionPtc ptc = new ContratacionPtc();
                    ptc.IdAcademico = datos.IdAcademico;
                    ptc.FechaNombramiento = datos.FechaNombramiento;
                    ptc.Archivo = datos.Archivo;
                    ptc.Status = 1;
                    context.ContratacionPtc.Add(ptc);
                    var academico = context.Academicos.Where(w => w.IdAcademicos == datos.IdAcademico).Single();
                    academico.RTipoPersonal = 1;
                    context.Academicos.Update(academico);
                    context.SaveChanges();
                }

                // guardamos el archivo en el servidor
                if (file == null || file.Length == 0)
                    return Content("file not selected");

                var new_name_file = "PTC" + "_" + datos.IdAcademico + "_" + file.GetFilename();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/ptc", new_name_file);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            // guardamos los datos en la tabla "laboratorio" y actualizamos el tipo de contratacion en la tabla académicos
            if (datos.tipopersonal == 3) {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    Laboratorio lab = new Laboratorio();
                    lab.IdTipoLaboratorio = datos.IdTipoLaboratorio;
                    lab.IdAcademico = datos.IdAcademico;
                    lab.Status = 1;
                    context.Laboratorio.Add(lab);
                    var academico = context.Academicos.Where(w => w.IdAcademicos == datos.IdAcademico).Single();
                    academico.RTipoPersonal = 3;
                    context.Academicos.Update(academico);
                    context.SaveChanges();
                }

            }
            // asignatura e investigador no requieren guardar datos adicionales
            // solo actualizamos el tipo de contratación en la tabla académicos
            if (datos.tipopersonal == 2 || datos.tipopersonal == 4)
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    var academico = context.Academicos.Where(w => w.IdAcademicos == datos.IdAcademico).Single();
                    academico.RTipoPersonal = datos.tipopersonal;
                    context.Academicos.Update(academico);
                    context.SaveChanges();
                }

            }
            return RedirectToAction("TablaDistinciones", new { id = datos.IdAcademico });
        }

        [Authorize]
        // recibe el id del académico
        public IActionResult EditarTC(int id)
        {
            // teniemos un modelo personalizado para tener los 3 tipos de contratación
            pTipoContratacion tipoc = new pTipoContratacion();

            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // debemos buscar
                var ptc = context.ContratacionPtc.Where(w => w.IdAcademico == id).ToList();
                var lab = context.Laboratorio.Where(w => w.IdAcademico == id).ToList();
                var aca = context.Academicos.Where(w => w.IdAcademicos == id).Single();
                // si es ptc
                if (ptc.Count > 0)
                {
                    tipoc.IdAcademico = ptc[0].IdAcademico;
                    tipoc.IdContrato = ptc[0].IdContrato;
                    tipoc.FechaNombramiento = ptc[0].FechaNombramiento;
                    tipoc.Archivo = ptc[0].Archivo;
                    tipoc.Status = ptc[0].Status;
                    tipoc.tipopersonal = 1;
                }
                // si es de laboratorio
                else if (lab.Count > 0)
                {
                    tipoc.IdLaboratorio = lab[0].IdLaboratorio;
                    tipoc.IdAcademico = lab[0].IdLaboratorio;
                    tipoc.IdTipoLaboratorio = lab[0].IdTipoLaboratorio;
                    tipoc.Status = lab[0].Status;
                    tipoc.Archivo = "NULL";
                    tipoc.tipopersonal = 3;
                }
                else {
                	// si es asignatura o investigador
                    if (aca.RTipoPersonal == 2)
                    {
                        tipoc.tipopersonal = 2;
                    }
                    else {
                        tipoc.tipopersonal = 4;
                    }
                    tipoc.Archivo = "NULL";
                }
                var tl = context.TipoLaboratorio.ToList();
                var tp = context.TipoPersonal.ToList();
                ViewData["tl"] = tl;
                ViewData["tp"] = tp;
                ViewData["academico"] = id;
            }
            return View(tipoc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarTC(IFormFile file, pTipoContratacion datos)
        {
            Academicos academico = new Academicos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // obtenemos al académico para comarar con su nuevo tipo de contratación
                academico = context.Academicos.Where(w => w.IdAcademicos == datos.IdAcademico).Single();
            }
            // vamos a actualizar a tipo 1
            if (datos.tipopersonal == 1)
            {
                // su tipo anterior no debe ser 1
                if (academico.RTipoPersonal != 1)
                {
                    // actualizamos y creamos el registro en la tabla ptc
                    using (sgcfieeContext context = new sgcfieeContext())
                    {
                        var new_name_table = "PTC" + "_" + datos.IdAcademico + "_" + file.GetFilename();
                        datos.Archivo = new_name_table;
                        ContratacionPtc ptc = new ContratacionPtc();
                        ptc.IdAcademico = datos.IdAcademico;
                        ptc.FechaNombramiento = datos.FechaNombramiento;
                        ptc.Archivo = datos.Archivo;
                        ptc.Status = 1;
                        context.ContratacionPtc.Add(ptc);
                        context.SaveChanges();

                        if (file == null || file.Length == 0)
                            return Content("file not selected");

                        // guardamos archivo
                        var new_name_file = "PTC" + "_" + datos.IdAcademico + "_" + file.GetFilename();
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/ptc", new_name_file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        if (academico.RTipoPersonal == 3)
                        {
                            Laboratorio eliminar = context.Laboratorio.Where(w => w.IdAcademico == datos.IdAcademico).Single();
                            context.Laboratorio.Remove(eliminar);
                            context.SaveChanges();
                        }
                        academico.RTipoPersonal = 1;
                        context.Academicos.Update(academico);
                        context.SaveChanges();
                    }

                }
                // su tipo anterior es el mismo, entonces solo actualizamos datos
                else {
                    using (sgcfieeContext context = new sgcfieeContext())
                    {
                        var ptc = context.ContratacionPtc.Where(w => w.IdAcademico == datos.IdAcademico).Single();
                        if (file != null)
                        {
                            var new_name_table = "PTC" + "_" + datos.IdAcademico + "_" + file.GetFilename();
                            ptc.Archivo = new_name_table;

                            var new_name_file = "PTC" + "_" + datos.IdAcademico + "_" + file.GetFilename();
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/ptc", new_name_file);

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        }
                        ptc.FechaNombramiento = datos.FechaNombramiento;

                        context.ContratacionPtc.Update(ptc);
                        context.SaveChanges();
                    }
                }

            }
            // Actualizamos a tipo 3
            if (datos.tipopersonal == 3)
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                	// su tipo anterior no es 3, entonces creamos el nuevo registro
                    if (academico.RTipoPersonal != 3)
                    {
                        Laboratorio lab = new Laboratorio();
                        lab.IdTipoLaboratorio = datos.IdTipoLaboratorio;
                        lab.IdAcademico = datos.IdAcademico;
                        lab.Status = 1;
                        context.Laboratorio.Add(lab);
                        context.SaveChanges();

                       // eliminamos su registro en otras tablas
                        if (academico.RTipoPersonal == 1)
                        {
                            ContratacionPtc eliminar = context.ContratacionPtc.Where(w => w.IdAcademico == datos.IdAcademico).Single();
                            context.ContratacionPtc.Remove(eliminar);
                            context.SaveChanges();

                            
                        }
                        // actualizamos el tipo
                        academico.RTipoPersonal = 3;
                        context.Academicos.Update(academico);
                        context.SaveChanges();
                    }
                    else {
                    	// actualizamos solo datos
                        Laboratorio lab = context.Laboratorio.Where(w => w.IdAcademico == datos.IdAcademico).Single();
                        lab.IdTipoLaboratorio = datos.IdTipoLaboratorio;
                        context.Laboratorio.Update(lab);
                        context.SaveChanges();
                    }
                }


            }
            // se cambiara a un tipo de contratacion que no necesita registros en otras tablas
            if ((datos.tipopersonal == 2 && academico.RTipoPersonal != 2) || (datos.tipopersonal == 4 && academico.RTipoPersonal != 4))
            {
                using (sgcfieeContext context = new sgcfieeContext())
                {
                    // eliminamos cualquier registro en otras tablas
                    if (academico.RTipoPersonal == 1)
                    {
                        ContratacionPtc eliminar = context.ContratacionPtc.Where(w => w.IdAcademico == datos.IdAcademico).Single();
                        context.ContratacionPtc.Remove(eliminar);
                        context.SaveChanges();

                    }
                    if (academico.RTipoPersonal == 3)
                    {
                        Laboratorio eliminar = context.Laboratorio.Where(w => w.IdAcademico == datos.IdAcademico).Single();
                        context.Laboratorio.Remove(eliminar);
                        context.SaveChanges();
                    }
            		// actualizamos el nuevo tipo
                    academico.RTipoPersonal = datos.tipopersonal;
                    context.Academicos.Update(academico);
                    context.SaveChanges();
                }
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("EditarTC", new { id = datos.IdAcademico });
        }

        [Authorize]
        //Distinciones académicas
        public IActionResult TablaDistinciones(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var td = context.TipoDistincionTa.ToList();
                ViewData["td"] = td;
                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        public IActionResult EditarDistinciones(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var td = context.TipoDistincionTa.ToList();
                var dista = context.DistincionesTa.ToList();
                var dis = new DistincionesTa();
                foreach (DistincionesTa val in dista)
                {
                    if (val.IdAcademico == id)
                    {
                        dis = val;
                    }
                }
                ViewData["td"] = td;
                ViewData["academico"] = id;
                return View(dis);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarDistinciones(IFormFile file, DistincionesTa datos)
        {
    		// guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var new_name_table = "Dist" + "_" + datos.IdAcademico + "_" + datos.IdDistincion + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                datos.Status = 1;
                context.DistincionesTa.Add(datos);
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");
            // guardamos archivos
            var new_name_file = "Dist" + "_" + datos.IdAcademico + "_" + datos.IdDistincion + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Distinciones", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarDistinciones(IFormFile file, DistincionesTa datos)
        {

            using (sgcfieeContext context = new sgcfieeContext())
            {
                // se sustituye el archivo
                if (file != null) {
                    var new_name_table = "Dist" + "_" + datos.IdAcademico + "_" + datos.IdDistincion + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }
                else {
                	// si no actualizo el archivo se pone el que ya tenia anteriormente
                    var dis = context.DistincionesTa.Where(w => w.IdAcademico == datos.IdAcademico).Single();
                    datos.Archivo = dis.Archivo;
                }

                datos.Status = 1;
                context.DistincionesTa.Update(datos);
                context.SaveChanges();
            }
            // // se guarda el archivo en el servidor
            if (file != null) {
                var new_name_file = "Dist" + "_" + datos.IdAcademico + "_" + datos.IdDistincion + "_" + file.GetFilename();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/DatosGenerales/Distinciones", new_name_file);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("EditarDistinciones", new { id = datos.IdAcademico });
        }

        [Authorize]
        // detalles datos generales
        public IActionResult DetallesDG(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");

            using (sgcfieeContext context = new sgcfieeContext()) {
                var dg = (from aca in context.Academicos
                          join pe in context.ProgramaEducativo on aca.IdProgramaEducativo equals pe.IdProgramaEducativo
                          join tp in context.TipoPersonal on aca.RTipoPersonal equals tp.IdTipoPersonal
                          where aca.IdAcademicos == id
                          select new pAcademicos
                          {
                              IdAcademicos = aca.IdAcademicos,
                              Nombre = aca.Nombre,
                              ApellidoPaterno = aca.ApellidoPaterno,
                              ApellidoMaterno = aca.ApellidoMaterno,
                              FechaNacimiento = aca.FechaNacimiento.ToString(),
                              Curp = aca.Curp,
                              CorreoInstitucional = aca.CorreoInstitucional,
                              CorreoAlternativo = aca.CorreoAlternativo,
                              Celular = aca.Celular,
                              Sexo = aca.Sexo,
                              ProgramaEducativo = pe.Nombre,
                              NumeroPersonal = aca.NumeroPersonal,
                              FechaIngresoUv = aca.FechaIngresoUv.ToString(),
                              Status = aca.Status,
                              RTipoPersonal = aca.RTipoPersonal,
                              tipoPersonal = tp.Nombre,
                              Rfc = aca.Rfc

                          }
                               ).Single();
                if (dg.Sexo == 0)
                    dg.Nombre_Sexo = "Femenino";
                if (dg.Sexo == 1)
                    dg.Nombre_Sexo = "Masculino";
                if (dg.Status == 1)
                    dg.NombreStatus = "Activo";
                if (dg.Status == 2)
                    dg.NombreStatus = "Inactivo";
                if (dg.Status == 3)
                    dg.NombreStatus = "Incapacitado";

                ViewData["academicos"] = dg;
                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        // detalles grados academicos
        public IActionResult DetallesGA(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pEstudios> estudios = new List<pEstudios>();
            using (sgcfieeContext context = new sgcfieeContext())
            {

                estudios = (from es in context.Estudios
                            join ie in context.InstitucionesEmpresas on es.IdInstitucion equals ie.IdIE
                            join gt in context.GradoTitulo on es.IdGradoTitulo equals gt.IdGradoTitulo
                            where es.IdAcademico == id
                            select new pEstudios
                            {
                                IdEstudios = es.IdEstudios,
                                IdAcademico = es.IdAcademico,
                                Institucion = ie.Nombre,
                                GradoTitulo = gt.Nombre,
                                AcrePnpc = es.AcrePnpc,
                                FechaDeEgreso = es.FechaDeEgreso.ToString(),
                                FechaDeTitulacion = es.FechaDeTitulacion.ToString(),
                                ArchivoCedula = es.ArchivoCedula,
                                ArchivoTitulo = es.ArchivoTitulo

                            }
                               ).ToList();

                foreach (pEstudios item in estudios)
                {
                    if (item.AcrePnpc == 0)
                        item.Reconocimiento = "Ninguno";
                    if (item.AcrePnpc == 1)
                        item.Reconocimiento = "Acreditado";
                    if (item.AcrePnpc == 2)
                        item.Reconocimiento = "PNPC";
                }
                ViewData["academico"] = id;
                ViewData["estudios"] = estudios;
            }
            return View();
        }

        public IActionResult DetallesCertificaciones(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pCertificaciones> certificaciones = new List<pCertificaciones>();
            using (sgcfieeContext context = new sgcfieeContext())
            {

                certificaciones = (from cer in context.Certificaciones
                                   join tcer in context.TipoCertificacion on cer.IdTipoCertificacion equals tcer.IdCertificacion
                                   where cer.IdAcademico == id
                                   select new pCertificaciones
                                   {
                                       IdCertificaciones = cer.IdCertificaciones,
                                       Nombre = cer.Nombre,
                                       IdTipoCertificacion = cer.IdTipoCertificacion,
                                       TipoCertificacion = tcer.Nombre,
                                       IdAcademico = cer.IdAcademico,
                                       Archivo = cer.Archivo
                                   }
                                   ).ToList();

                ViewData["cer"] = certificaciones;
                ViewData["academico"] = id;
            }
            return View();
        }

        // detalles cursos/diplomados
        public IActionResult DetallesCD(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pCursosDiplomadoFormacion> CD = new List<pCursosDiplomadoFormacion>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CD = (from cd in context.CursosDiplomadoFormacion
                      join ins in context.InstitucionesEmpresas on cd.IdIesEmpresa equals ins.IdIE
                      where cd.IdAcademico == id
                      select new pCursosDiplomadoFormacion
                      {
                          IdCD = cd.IdCD,
                          IdAcademico = cd.IdAcademico,
                          Nombre = cd.Nombre,
                          CursoDiplomado = cd.CursoDiplomado,
                          PD = cd.PD,
                          Horas = cd.Horas,
                          IdIesEmpresa = cd.IdIesEmpresa,
                          institucion = ins.Nombre,
                          Lugar = cd.Lugar,
                          Fecha = cd.Fecha.ToString(),
                          Archivo = cd.Archivo

                      }
                                   ).ToList();
                ViewData["cd"] = CD;
                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        // detalles experiencia profesional
        public IActionResult DetallesEP(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<pExperienciaProfesional> EP = new List<pExperienciaProfesional>();
            using (sgcfieeContext context = new sgcfieeContext())
            {

                EP = (from ep in context.ExperienciaProfesional
                      join ins in context.InstitucionesEmpresas on ep.IdEmpresa equals ins.IdIE
                      join tip in context.TipoPuesto on ep.IdTipoPuesto equals tip.IdPuesto
                      where ep.IdAcademico == id
                      select new pExperienciaProfesional
                      {
                          IdEp = ep.IdEp,
                          IdAcademico = ep.IdAcademico,
                          IdEmpresa = ep.IdEmpresa,
                          empresa = ins.Nombre,
                          IdTipoPuesto = tip.IdPuesto,
                          TipoPuesto = tip.Nombre,
                          FechaInicio = ep.FechaInicio.ToString(),
                          FechaFin = ep.FechaFin.ToString(),
                          AreaDesarrollo = ep.AreaDesarrollo,
                          Archivo = ep.Archivo

                      }
                                   ).ToList();


                // calculamos los años de experiencia
                foreach (pExperienciaProfesional item in EP) {
                    int inicio = int.Parse(item.FechaInicio.Substring(0, 4));
                    int fin = int.Parse(item.FechaFin.Substring(0, 4));
                    int exp = fin - inicio;
                    if (exp == 0)
                        exp = 1;
                    item.FechaInicio = exp.ToString();

                }

                ViewData["ep"] = EP;
                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        // detalles tipo de contratación
        public IActionResult DetallesTC(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var aca = context.Academicos.Where(w => w.IdAcademicos == id).Single();
                var tl = context.TipoLaboratorio.ToList();
                var tp = context.TipoPersonal.ToList();
                ViewData["idtp"] = aca.RTipoPersonal;

                foreach (TipoPersonal item in tp)
                {
                    if (item.IdTipoPersonal == aca.RTipoPersonal)
                        ViewData["tp"] = item.Nombre;
                }

                if (aca.RTipoPersonal == 1) {
                    ViewData["tc"] = context.ContratacionPtc.Where(w => w.IdAcademico == id).Single();
                }
                if (aca.RTipoPersonal == 3)
                {
                    var lab = context.Laboratorio.Where(w => w.IdAcademico == id).Single();
                    foreach (TipoLaboratorio item in tl)
                    {
                        if (item.IdTipoLaboratorio == lab.IdTipoLaboratorio)
                            ViewData["tc"] = item.Nombre;
                    }
                }

                ViewData["academico"] = id;
            }
            return View();
        }

        [Authorize]
        public IActionResult DetallesDistinciones(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var td = context.TipoDistincionTa.ToList();
                var dista = context.DistincionesTa.ToList();
                ViewData["dis"] = new DistincionesTa();
                foreach (DistincionesTa val in dista)
                {
                    // obtenemos el registro del usuario a buscar
                    // y despues obtenmos el nombre de esa dintinción
                    if (val.IdAcademico == id)
                    {
                        ViewData["dis"] = val;
                        foreach (TipoDistincionTa item in td)
                        {
                            if (item.IdDistincion == val.IdDistincion)
                                ViewData["distincion"] = item.Nombre;
                        }
                    }
                }
            }
            ViewData["academico"] = id;
            return View();

        }

        // todas las acciones de eliminar pasan por un js
        // llamado "eliminar,js"
        public IActionResult EliminarAcademico(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Academicos eliminar = context.Academicos.Where(w => w.IdAcademicos == id).Single();
                context.Academicos.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult EliminarGA(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Estudios eliminar = context.Estudios.Where(w => w.IdEstudios == id).Single();
                context.Estudios.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("EditarGA", new { id = id_acad });
            }
        }

        public IActionResult EliminarCertificaciones(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Certificaciones eliminar = context.Certificaciones.Where(w => w.IdCertificaciones == id).Single();
                context.Certificaciones.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("EditarCertificaciones", new { id = id_acad });
            }
        }

        public IActionResult EliminarCD(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CursosDiplomadoFormacion eliminar = context.CursosDiplomadoFormacion.Where(w => w.IdCD == id).Single();
                context.CursosDiplomadoFormacion.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("EditarCD", new { id = id_acad });
            }
        }

        public IActionResult EliminarEP(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ExperienciaProfesional eliminar = context.ExperienciaProfesional.Where(w => w.IdEp == id).Single();
                context.ExperienciaProfesional.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("EditarEP", new { id = id_acad });
            }
        }





        // descarga de los archivos
        // si no se encuentra nada en la ruta, aparece un mensaje de error

        public async Task<IActionResult> DescargarGA(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/DatosGenerales/Estudios", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        public async Task<IActionResult> DescargarCer(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/DatosGenerales/Certificaciones", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        public async Task<IActionResult> DescargarEP(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/DatosGenerales/Exp_Profesional", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        public async Task<IActionResult> DescargarCD(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/DatosGenerales/Cursos_Diplomados", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        public async Task<IActionResult> DescargarTC(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/DatosGenerales/ptc", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        public async Task<IActionResult> DescargarDistincion(string filename)
        {

            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/DatosGenerales/Distinciones", filename);

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
        // los diferentes tipos de formatos que se pueden guardar/descargar
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