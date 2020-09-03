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
    public class AcademicosComisionesController : Controller
    {
        //Esta función muestra la información en el index de la pestaña Jurado de Experiencia Recepcional, guardandose
        //en la lista llamada "ListJurExperiencia" que pertenece a una clase nueva llamada "TablaJurExperiencia"
        //al final de la consulta para sacar los datos se compara con "1" para que se guarden solo los que pertenecen
        //ha Jurado 
        // GET: /<controller>/
        [Authorize]
        public IActionResult IndexJurExperiencia()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            List<TablaJurExperiencia> ListJurExperiencia = new List<TablaJurExperiencia>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListJurExperiencia = (from datos in context.JuradoExperienciaRecepcional
                                      join trabajo in context.TrabajosRecepcionales on datos.IdTr equals trabajo.IdTrabajosRecepcionales
                                      join alum in context.Alumnos on trabajo.IdAlumno equals alum.IdAlumnos
                                      join datosG in context.DatosPersonales on alum.RDatosPerson equals datosG.IdDatosPersonales
                                      join modalidad in context.TipoModalidad on trabajo.IdModalidad equals modalidad.IdModalidad
                                      select new TablaJurExperiencia
                                      {
                                          IdJurado = datos.IdJer,
                                          NombreAlum = datosG.Nombre,
                                          ApellidoPaternoAlum = datosG.ApellidoPaterno,
                                          ApellidoMaternoAlum = datosG.ApellidoMaterno,
                                          Modalidad = modalidad.Nombre,
                                          NombreTrabajo = trabajo.NombreTrabajo,
                                          Fecha = trabajo.FechaPresentacion.ToString(),
                                          Archivo = datos.Archivo,
                                          JuradoPrejurado = datos.JuradoPrejurado
                                      }
                               ).Where(s => s.JuradoPrejurado == 1).ToList();
                //Esta condición es para verificar que el tipo de usuario sea = 2 (que es academico) = 1 (es direcctor).
                //Dentro de la consulta se va a verificar si el académico que esta ingresando tiene los permisos para modificar el Jurado
                //esto es si Lider es = 1, si no se cumple, no tiene permiso para modificarlo.
                if (tipoUsu == 2)
                {
                    List<Academicosjuradorecep> ListAcad = new List<Academicosjuradorecep>();
                    ListAcad = context.Academicosjuradorecep.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListJurExperiencia);
        }
        //Función CrearJurExperiencia, se utiliza para llenar los select que se encuentran en la vista.
        [Authorize]
        public IActionResult CrearJurExperiencia()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<TrabajosRecepcionales> datTR = new List<TrabajosRecepcionales>();
                List<Alumnos> datAlum = new List<Alumnos>();
                List<Alumnos> datosfin = new List<Alumnos>();
                List<DatosPersonales> datGene = new List<DatosPersonales>();
                List<DatosPersonales> datosGene = new List<DatosPersonales>();
                var acad = context.Academicos.ToList();

                datTR = context.TrabajosRecepcionales.ToList();
                datAlum = context.Alumnos.ToList();
                datGene = context.DatosPersonales.ToList();
                //En este foreach se extraen los ID de los alumnos que se encuentran en proceso de su Experiencia Recepcional.
                //Por lo que que se compara Proceso == 1.
                foreach (TrabajosRecepcionales item in datTR)
                {
                    foreach (Alumnos item2 in datAlum)
                    {
                        if (item.IdAlumno == item2.IdAlumnos && item.Proceso == 1)
                        {
                            datosfin.Add(item2);
                        }
                    }

                }
                //Teniendo ya los id de los alumnos se hace un la extracción de los datos del alumno, es decir, su nombre, matricula, etc.
                foreach (Alumnos item in datosfin)
                {
                    foreach (DatosPersonales item2 in datGene)
                    {
                        if (item.RDatosPerson == item2.IdDatosPersonales)
                        {
                            datosGene.Add(item2);
                        }
                    }
                }
                //Para el pase de los datos a la vista, se utiliza el ViewData.
                ViewData["datosGene"] = datosGene;
                ViewData["academicos"] = acad;

            }
            return View();
        }
        //En la función GuardarJurExperiencia, se lleva acabo el proceso de guardar la información en la base de datos. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Se recibe el archivo de evidencia, los datos generales, el ID academico que esta haciendo el guardado, y una variable llamada
        //Lider que tendra como dato un "1" para poder identificar que el fue el creador de ese jurado de experiencia.
        public async Task<IActionResult> GuardarJurExperiencia(IFormFile file, JuradoExperienciaRecepcional datos, int idAcademico, int Lider)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            //Si el usuario es de tipo = 2 (académico), se hace la extraccion del ID del académico que esta guardando la información,
            //ya que en la vista no se podra seleccionar al académico, por lo tanto al llegar ha este punto se realiza.
            if (tipo == 2)
            {
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se verifica que la información no este guardada en la Base de datos, comparando ID del trabajo recepcional y la bandera de JuradoPrejurado.
                //si se da el caso, le redireccionara la pestaña index y mostrar un mensaje, que la información ya se encuentra registrada.
                var ListJurado = context.JuradoExperienciaRecepcional.ToList();
                foreach (JuradoExperienciaRecepcional item in ListJurado)
                {
                    if (datos.IdTr == item.IdTr && datos.JuradoPrejurado == item.JuradoPrejurado)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexJurExperiencia");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda la información en la tabla JuradoExperienciaRecepcional
                var datosAlum = context.Alumnos.Where(s => s.RDatosPerson == datos.IdTr).Single();
                var datosTR = context.TrabajosRecepcionales.Where(a => a.IdAlumno == datosAlum.IdAlumnos).Single();
                datos.IdTr = datosTR.IdTrabajosRecepcionales;
                var name = file.GetFilename(); //se extrae el nombre del archivo, para guardarlo en name.
                datos.Archivo = name;
                context.JuradoExperienciaRecepcional.Add(datos);
                context.SaveChanges();
                //Para que no haya duplisidad de nombres de archivos, se lleva acabo un agregado al nombre original, que es ID de la
                //tabla JuradoExperienciaRecepcional + "_" + el nombre ya antes guardado, para proseguir con una sola actualización de la información.
                JuradoExperienciaRecepcional DatosJur = context.JuradoExperienciaRecepcional.Last();
                var new_name_table = DatosJur.IdJer + "_" + file.GetFilename();
                datos.Archivo = new_name_table;
                context.JuradoExperienciaRecepcional.Update(datos);
                context.SaveChanges();
            }
            //se verifica que si exista archivo.
            if (file == null || file.Length == 0)
                return Content("file not selected");
            //Se guarda el archivo en una ruta fija.
            var new_name_file = datos.IdJer + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/JuradoExperienciaRecepcional", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Aquí se guarda ID del académico, ID que pertenece a la información antes guardada en la tabla JuradoExperienciaRecepcional y el
                // "1" que viene en la variable Lider en la tabla Academicosjuradorecep, la cual es donde se estaran guardado todos los académicos
                // que pertenecen al jurado.
                JuradoExperienciaRecepcional DatosJur = context.JuradoExperienciaRecepcional.Last();
                Academicosjuradorecep info = new Academicosjuradorecep();
                info.IdAcademico = idAcademico;
                info.IdJurado = DatosJur.IdJer;
                info.Lider = Lider;
                context.Academicosjuradorecep.Add(info);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexJurExperiencia");
        }
        //Función que se encarga de llenar los campos de la vista de editar.
        [Authorize]
        public IActionResult EditarJurExperiencia(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Teniendo ya el ID de la información que se requiere, se realiza una consulta para tener toda la información de la tabla que ir en los campos
                JuradoExperienciaRecepcional DatosJur = context.JuradoExperienciaRecepcional.Where(s => s.IdJer == id).Single();

                List<TrabajosRecepcionales> datTR = new List<TrabajosRecepcionales>();
                List<Alumnos> datAlum = new List<Alumnos>();
                List<Alumnos> datosfin = new List<Alumnos>();
                List<DatosPersonales> datGene = new List<DatosPersonales>();
                List<DatosPersonales> datosGene = new List<DatosPersonales>();

                datTR = context.TrabajosRecepcionales.ToList();
                datAlum = context.Alumnos.ToList();
                datGene = context.DatosPersonales.ToList();
                //Igual que la parte del agregar, se buscan todos los ID de alumnos que pertenecen a trabajos recepcionales.
                foreach (TrabajosRecepcionales item in datTR)
                {
                    foreach (Alumnos item2 in datAlum)
                    {
                        if (item.IdAlumno == item2.IdAlumnos)
                        {
                            datosfin.Add(item2);
                        }
                    }

                }
                //Se extraen la información de los ID antes buscados.
                foreach (Alumnos item in datosfin)
                {
                    foreach (DatosPersonales item2 in datGene)
                    {
                        if (item.RDatosPerson == item2.IdDatosPersonales)
                        {
                            datosGene.Add(item2);
                        }
                    }
                }
                ViewData["datosGene"] = datosGene;

                return View(DatosJur);
            }
        }
        //Función que actualiza la información de la tabla JuradoExperienciaRecepcional.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ActualizarJurExperiencia(IFormFile file, JuradoExperienciaRecepcional datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Primero se verifica que la información actualizada no este ya guardada en la Base de datos.
                //Para ellos se checa que el campo JuradoPrejurado no este ya con ese valor, si esto es así, se mostrara un mensaje que la información ya esta registrada.
                var ListJurado = context.JuradoExperienciaRecepcional.Where(j => j.IdJer != datos.IdJer).ToList();
                foreach (JuradoExperienciaRecepcional item in ListJurado)
                {
                    if (datos.IdTr == item.IdTr && datos.JuradoPrejurado == item.JuradoPrejurado)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexJurExperiencia");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Si la variable del archivo viene vacia, solo se busca el nombre del archivo ya guardado.
                if (file == null || file.Length == 0)
                {
                   
                    var nomArchivo = context.JuradoExperienciaRecepcional.Where(w => w.IdJer == datos.IdJer).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si la variable del archivo trae información, se prosigue a modificar el nombre original, para descargar nombres repetidos.
                    var new_name_table = datos.IdJer + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Toda la información a actualizar se guarda.
                var datosAlum2 = context.Alumnos.Where(s => s.RDatosPerson == datos.IdTr).Single();
                var datosTR2 = context.TrabajosRecepcionales.Where(a => a.IdAlumno == datosAlum2.IdAlumnos).Single();
                datos.IdTr = datosTR2.IdTrabajosRecepcionales;
                context.JuradoExperienciaRecepcional.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo que guardar, aquí se corta, y se redireccioona a la pestaña index que le respecta.
                return RedirectToAction("IndexJurExperiencia");
            }
            //De lo contrario, se prosigue a guardar el archivo en la carpeta fijada.
            var new_name_file = datos.IdJer + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/JuradoExperienciaRecepcional", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexJurExperiencia");
        }
        //Función para eliminar un registro de la tabla JuradoExperienciaRecepcional.
        public IActionResult EliminarJurExperiencia(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Primero se extraen todos los ID de academicos de la tabla Academicosjuradorecep que son responsable del jurado de ese trabajo
                List<Academicosjuradorecep> eliminarAcad = context.Academicosjuradorecep.Where(f => f.IdJurado == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina cada uno de los académicos, de dicha tabla anteriormente mencionada.
                    context.Academicosjuradorecep.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
                //Por ultimo se elimina el registro de la tabla JuradoExperienciaRecepcional.
                JuradoExperienciaRecepcional eliminar = context.JuradoExperienciaRecepcional.Where(w => w.IdJer == id).Single();
                context.JuradoExperienciaRecepcional.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexJurExperiencia");
            }
        }
        //Función que se encarga de descargar el archivo que respecta al Jurado de Experiencia Recepcional
        public async Task<IActionResult> DescargarJurExperiencia(string filename)
        {
            //Se verifica que la variable venga con información.
            if (filename == null)
                return Content("filename not present");
            //Se guarda la dirección de donde se encuentra guardado el archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Comisiones/JuradoExperienciaRecepcional", filename);

            var memory = new MemoryStream();
            //Para proseguir con la descarga de dicho archivo.
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        //Aquí se buscan los academicos jurado responsables del Trabajo recepcional seleccionado.
        [Authorize]
        public IActionResult AcademicosJurExperiencia(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            List<TablaAcadJurExperiencia> ListAcadJurExp = new List<TablaAcadJurExperiencia>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            //Se guardan la información de todos los académicos jurados del trabajo en la lista creada "ListAcadJurExp"
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAcadJurExp = (from datos in context.Academicosjuradorecep
                                  join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                  where datos.IdJurado == id
                                  select new TablaAcadJurExperiencia
                                  {
                                      IdAcadJurExp = datos.IdAcademicosJuradoRecep,
                                      NumPersonal = acad.NumeroPersonal,
                                      Nombre = acad.Nombre,
                                      ApellidoPaterno = acad.ApellidoPaterno,
                                      ApellidoMaterno = acad.ApellidoMaterno,
                                      idJurado = datos.IdJurado
                                  }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idJur"] = id;
                //Ahora se busca al academico lider del jurado, para ellos se busca al académico que tenga un 1 en el campo Lider,
                //guardandolo en la variable Acad, si no se encuentra al academico lider, la variable se va con null.
                Academicosjuradorecep Acad = new Academicosjuradorecep();
                int cant = context.Academicosjuradorecep.Where(w => w.IdJurado == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    Acad = context.Academicosjuradorecep.Where(w => w.IdJurado == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadJurExp);
        }
        //Esta función se ocupa para guardar a los académicos jurados, agregados por el lider.
        [Authorize]
        public IActionResult GuardarAcadJurExperiencia(int idAcademico, int jurado, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicosjuradorecep AcadJurado = new Academicosjuradorecep();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Primero se busca que el académico a guardar no este ya la tabla, comparando el id del académico y id del trabajo.
                var ListAcad = context.Academicosjuradorecep.ToList();
                foreach (Academicosjuradorecep item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && jurado == item.IdJurado)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosJurExperiencia", new { id = jurado });
                    }
                }
                //Se guarda el ID del académico jurado, junto con el trabajo al que se le relaciona y la variable lider que traera como valor "0"
                //Donde Lider = 0 es porque este academico no es el creador del jurado y por lo  tanto no podra realizar ningun cambio en ello.
                AcadJurado.Lider = Lider;
                AcadJurado.IdAcademico = idAcademico;
                AcadJurado.IdJurado = jurado;
                context.Academicosjuradorecep.Add(AcadJurado);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosJurExperiencia", new { id = AcadJurado.IdJurado });
        }
        //Esta función, sirve para que el lider del jurado del trabajo pueda eliminar a otros académicos, agregados por el mismo.
        [Authorize]
        public IActionResult EliminarAcadJurExperiencia(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se busca la información que pertenece al academico a eliminar en la tabla Academicosjuradorecep.
                Academicosjuradorecep eliminar = context.Academicosjuradorecep.Where(w => w.IdAcademicosJuradoRecep == id).Single();
                context.Academicosjuradorecep.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosJurExperiencia", new { id = id_acad });
            }
        }



        //Esta función muestra la información en el index de la pestaña Jurado de Examen de  Oposición, guardandose
        //en la lista llamada "ListJurOposicion" que pertenece a una clase nueva llamada "TablaJurOposicion"
        
        [Authorize]
        public IActionResult IndexJurOposicion()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            List<TablaJurOposicion> ListJurOposicion = new List<TablaJurOposicion>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListJurOposicion = (from datos in context.JuradoExamenOposicion
                                    join mc in context.MapaCurricular on datos.IdEe equals mc.IdMapaCurricular
                                    join pe in context.ProgramaEducativo on mc.IdProgramaEducativo equals pe.IdProgramaEducativo
                                    join ee in context.ExperienciaEducativa on mc.IdExperienciaEducativa equals ee.IdExperienciaEducativa
                                    select new TablaJurOposicion
                                    {
                                        IdJurado = datos.IdJexposicion,
                                        Pe = pe.Nombre,
                                        Ee = ee.Nombre,
                                        TipoExamen = datos.TipoExamen,
                                        Fecha = datos.Fecha.ToString(),
                                        Archivo = datos.Archivo,
                                    }
                               ).ToList();
                //Esta condición es para verificar que el tipo de usuario sea = 2 (que es academico) = 1 (es direcctor).
                //Dentro de la consulta se va a verificar si el académico que esta ingresando tiene los permisos para modificar el Jurado
                //esto es si Lider es = 1, si no se cumple, no tiene permiso para modificarlo.
                if (tipoUsu == 2)
                {
                    List<Academicosjuroposicion> ListAcad = new List<Academicosjuroposicion>();
                    ListAcad = context.Academicosjuroposicion.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListJurOposicion);
        }
        //Función CrearJurOposicion, se utiliza para ingresar a la vista y llenar los select.
        [Authorize]
        public IActionResult CrearJurOposicion()
        {
            List<MCEE> ListMCEE = new List<MCEE>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //La lista creada de la clase MCEE es para acumular a las Expericias Educativas con su respectivo programa educativo.
                ListMCEE = (from MC in context.MapaCurricular
                            join EE in context.ExperienciaEducativa on MC.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                            join PE in context.ProgramaEducativo on MC.IdProgramaEducativo equals PE.IdProgramaEducativo
                            where PE.Nombre != "Externo"
                            select new MCEE
                            {
                                IdMapaCurricular = MC.IdMapaCurricular,
                                IdExperienciaEducativa = MC.IdExperienciaEducativa,
                                NombreEE = EE.Nombre,
                                IdProgramaEducativo = MC.IdProgramaEducativo,
                                NombrePE = PE.Nombre,
                                Estado = MC.Estado

                            }
                               ).ToList();

                
                var acad = context.Academicos.ToList(); //Aquí se consulta a todos los academicos existentes
                ViewData["academicos"] = acad; //Se ocupan el diccionario ViewData para mostrar en la vista a los académicos.
                ViewData["ExperienciasE"] = ListMCEE; //Se ocupan el diccionario ViewData para mostrar en la vista a las EE.
            }
            return View();
        }
        //En la función GuardarJurOposicion, se lleva acabo el proceso de guardar la información en la base de datos. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Se recibe el archivo de evidencia, los datos generales, el ID del académico que esta haciendo el guardado, y una variable llamada
        //Lider que tendra como dato un "1" para poder identificar que el fue el creador de ese jurado de experiencia.
        public async Task<IActionResult> GuardarJurOposicion(IFormFile file, JuradoExamenOposicion datos, int idAcademico, int Lider)
        {
            //Si el usuario es de tipo = 2 (académico), se hace la extraccion del ID del académico que esta guardando la información,
            //ya que en la vista no se podra seleccionar al académico, por lo tanto al llegar ha este punto se realiza.
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            if (tipo == 2)
            {
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se verifica que la información ha guardar no este ya registrada.
                var ListJurado = context.JuradoExamenOposicion.ToList(); //Se extraen todos los jurados de examen de oposicion ya registrados.
                foreach (JuradoExamenOposicion item in ListJurado)
                {
                    if (datos.TipoExamen == item.TipoExamen && datos.IdEe == item.IdEe && datos.Fecha == item.Fecha)//Se comparan los tres datos (Tipo de examen, Id de la experiencia educativa y la fecha), que juntos no se pueden repetir en otro Examen de oposición.
                    {
                        //Si se encuentra igualdad en los tres datos, se mostrara el siguiente mensaje.
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexJurOposicion");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var name = file.GetFilename(); //Se guarda el nombre del archivo en la variable name.
                datos.Archivo = name;
                context.JuradoExamenOposicion.Add(datos); //Se guardan los datos en la tabla JuradoExamenOposicion de la Base de datos.
                context.SaveChanges();
                JuradoExamenOposicion DatosJur = context.JuradoExamenOposicion.Last(); //Se obtienen la información del ultimo registro guardado.
                var new_name_table = DatosJur.IdJexposicion + "_" + file.GetFilename(); //Se modifica el nombre del archivo, agregandole el id llave que se le genero, para evitar posible sobreescritura ha otros archivos.
                datos.Archivo = new_name_table;
                context.JuradoExamenOposicion.Update(datos); //Se actualiza la información en la base de datos.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            var new_name_file = datos.IdJexposicion + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/JuradoOposicion", new_name_file); //Se guarda el archivo en su respectiva ruta fija.

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Aquí se guarda al académico creador del jurado de examen de oposición.
                JuradoExamenOposicion DatosJur = context.JuradoExamenOposicion.Last(); //Se obtienen los datos de la ultima información guardada en la tabla, para obtener el id respectivo.
                Academicosjuroposicion info = new Academicosjuroposicion();
                //Se llenan los campos con sus respectivos datos ha guardar, para tener un registro del academico que estan en el jurado.
                info.IdAcademico = idAcademico;
                info.IdJurado = DatosJur.IdJexposicion;
                info.Lider = Lider;
                context.Academicosjuroposicion.Add(info); //Se guarda la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexJurOposicion");
        }
        //Función que se encargar de llegar a la vista de edición y mostrar los campos llenos ha editar.
        [Authorize]
        public IActionResult EditarJurOposicion(int id)
        {
            List<MCEE> ListMCEE = new List<MCEE>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se obtienen los datos de la base de datos, con ayuda del id que se tiene.
                JuradoExamenOposicion DatosJur = context.JuradoExamenOposicion.Where(s => s.IdJexposicion == id).Single();

                //Se genera una consulta para obtener la EE y los programas educativos que se mostraran en el select respectivo.
                ListMCEE = (from MC in context.MapaCurricular
                            join EE in context.ExperienciaEducativa on MC.IdExperienciaEducativa equals EE.IdExperienciaEducativa
                            join PE in context.ProgramaEducativo on MC.IdProgramaEducativo equals PE.IdProgramaEducativo
                            where PE.Nombre != "Externo"
                            select new MCEE
                            {
                                IdMapaCurricular = MC.IdMapaCurricular,
                                IdExperienciaEducativa = MC.IdExperienciaEducativa,
                                NombreEE = EE.Nombre,
                                IdProgramaEducativo = MC.IdProgramaEducativo,
                                NombrePE = PE.Nombre,
                                Estado = MC.Estado

                            }
                               ).ToList();

                ViewData["ExperienciasE"] = ListMCEE;
                string fecha = DatosJur.Fecha.ToString(); //Como la fecha es de tipo dateTime, se le agrega el .ToString(), para convertirlo a cadena.
                string[] resultado = fecha.Split(' '); //Ahora se separa por espacios
                ViewData["fecha"] = resultado[0]; //Para al final solo quedarnos con la fecha y enviarla a traves de un diccionario (ViewData).
                return View(DatosJur);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función que actualiza la información del jurado de examen de oposición.
        public async Task<IActionResult> ActualizarJurOposicion(IFormFile file, JuradoExamenOposicion datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se verifica que la información actualizada, no este ya guardada en la base de datos.
                var ListJurado = context.JuradoExamenOposicion.Where(j => j.IdJexposicion != datos.IdJexposicion).ToList(); //Se obtiene la informción ya guardada.
                foreach (JuradoExamenOposicion item in ListJurado)
                {
                    //Se comparan los campos necesarios con la información actualizada, si esta repetida, se mostrar el mensaje, si no, se continuara.
                    if (datos.TipoExamen == item.TipoExamen && datos.IdEe == item.IdEe && datos.Fecha == item.Fecha)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexJurOposicion");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se verifica si el archivo tambien se actualiza o no.
                if (file == null || file.Length == 0)
                {
                    //Si no hay archivo ha actualizar, solo se busca el nombre del archivo actual, y se guarda en una variable.
                    var nomArchivo = context.JuradoExamenOposicion.Where(w => w.IdJexposicion == datos.IdJexposicion).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si el archivo si se actualizara, el genera el nuevo nombre al archivo y se guarda en una variable.
                    var new_name_table = datos.IdJexposicion + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.JuradoExamenOposicion.Update(datos); //Se actualizan los datos en la base de datos.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo ha actualizar, aqui termina el proceso.
                return RedirectToAction("IndexJurOposicion");
            }
            //Se actualiza el archivo nuevo, en la carpeta.
            var new_name_file = datos.IdJexposicion + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/JuradoOposicion", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexJurOposicion");
        }
        //Función para eliminar la informción del jurado de examen de oposición.
        public IActionResult EliminarJurOposicion(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Primero, se buscan en la tabla de "Academicosjuroposicion" los académicos que pertenecen al jurado a eliminar, para ello
                //se realiza la consulta de todos los registros que tengan el mismo id de jurado.
                List<Academicosjuroposicion> eliminarAcad = context.Academicosjuroposicion.Where(f => f.IdJurado == id).ToList();
                int i = 0;
                //Se elimina registro por registro a los campos que tienen relacion con el jurado.
                foreach (var item in eliminarAcad)
                {
                    context.Academicosjuroposicion.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
                //Por ultimo, se elimina el registro de la tabla "JuradoExamenOposicion".
                JuradoExamenOposicion eliminar = context.JuradoExamenOposicion.Where(w => w.IdJexposicion == id).Single();
                context.JuradoExamenOposicion.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexJurOposicion");
            }
        }
        //Función para descargar el archivo correspondiente de la pestaña Jurado de examen de oposición.
        public async Task<IActionResult> DescargarJurOposicion(string filename)
        {
            //Verificacion que la variable filename, contenga información, en este caso el nombre del archivo.
            if (filename == null)
                return Content("filename not present");
            //Se genera acompleta la ruta exacta de donde se encuentra el archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Comisiones/JuradoOposicion", filename);
            //Se prosigue a la descarga del archivo.
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        //Función que muestra la vista de los académicos que perteneces como jurado a un examen.
        [Authorize]
        public IActionResult AcademicosJurOposicion(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            List<TablaAcadJurOposicion> ListAcadJurOpo = new List<TablaAcadJurOposicion>(); //Se genera una lista, de una nueva clase generada manualmente.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se genera una consulta para guardar el nombre y numero de personal, de los académicos jurados del examen de oposicion respectivo.
                ListAcadJurOpo = (from datos in context.Academicosjuroposicion
                                  join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                  where datos.IdJurado == id
                                  select new TablaAcadJurOposicion
                                  {
                                      IdAcadJurOpo = datos.IdAcademicosJurOposicion,
                                      NumPersonal = acad.NumeroPersonal,
                                      Nombre = acad.Nombre,
                                      ApellidoPaterno = acad.ApellidoPaterno,
                                      ApellidoMaterno = acad.ApellidoMaterno,
                                      IdJurado = datos.IdJurado
                                  }
                                     ).ToList();
                //En la vista, hay un select para poder agregar mas academicos como jurado, por lo tanto, se guardan todos los académicos existentes en la variable.
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idJur"] = id;
                //Se busca si el usuario que ingreso es lider del jurado de examen de oposición.
                Academicosjuroposicion Acad = new Academicosjuroposicion();
                int cant = context.Academicosjuroposicion.Where(w => w.IdJurado == id && w.Lider == 1 && w.IdAcademico == idUsu).Count(); //Se busca si el académico en el campo Lider tenga = 1, si es asi, la variable sera 1.
                if (cant > 0)
                {
                    //Si es 1 cant, entonces se obtiene la información del regirtro.
                    Acad = context.Academicosjuroposicion.Where(w => w.IdJurado == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    //Si no Lider, entonces la variable se va vacia.
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadJurOpo);
        }
        //Función para guardar a un nuevo académico como jurado de un examen de oposición.
        [Authorize]
        public IActionResult GuardarAcadJurOposicion(int idAcademico, int jurado, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicosjuroposicion AcadJurado = new Academicosjuroposicion();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se busca que el nuevo académico a agregar no este ya agregado en el jurado.
                var ListAcad = context.Academicosjuroposicion.ToList();
                foreach (Academicosjuroposicion item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && jurado == item.IdJurado)//Se compara que el jurado y los academicos no sean iguales al nuevo.
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosJurOposicion", new { id = jurado });
                    }
                }
                //Se agrega al nuevo académico al jurado respectivo.
                AcadJurado.Lider = Lider;
                AcadJurado.IdAcademico = idAcademico;
                AcadJurado.IdJurado = jurado;
                context.Academicosjuroposicion.Add(AcadJurado);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosJurOposicion", new { id = AcadJurado.IdJurado });
        }
        //Función para eliminar a un académico jurado.
        [Authorize]
        public IActionResult EliminarAcadJurOposicion(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se busca al academico en la tabla "Academicosjuroposicion" y se prosigue con su eliminación.
                Academicosjuroposicion eliminar = context.Academicosjuroposicion.Where(w => w.IdAcademicosJurOposicion == id).Single();
                context.Academicosjuroposicion.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("AcademicosJurOposicion", new { id = id_acad }); //Se redirecciona a la vista, con el id del jurado en el que se encuentra.
            }
        }



        //Función que muestra la información en el index del modulo Comisiones, en la pestaña "Participación activa en el rediseño o actualización".
        [Authorize]
        public IActionResult IndexPartRedisenio()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //La variable tipo, guarda el nivel de permiso que tendra, 1 = (director), 2 = (académicos), 3 = (estudiantes).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //La variable idUsu, guarda el id del usuario respecto a la tabla Usuario de la Base de datos.
            List<TablaRedisenio> ListRedisenio = new List<TablaRedisenio>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario"); //Se realiza para pasar el tipo de usuario a la vista.
            using (sgcfieeContext context = new sgcfieeContext())
            {
               
                if (tipo == 1)
                {
                    //La consulta realizada es para mostrar los académicos y la informacion del plan de estudio que presentaron. Esta consulta
                    //se llevara acabo si el usuario que entra es de tipo 1 (direcctor).
                    ListRedisenio = (from datos in context.RediseñoPlanEstudios
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     join programa in context.ProgramaEducativo on datos.IdPrograma equals programa.IdProgramaEducativo
                                     select new TablaRedisenio
                                     {
                                         IdPlan = datos.IdRediseñoActualizacionEstudios,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         Area = datos.Area,
                                         NombrePrograma = programa.Nombre,
                                         Tipo = datos.CoordinadorColaborador,
                                         Archivo = datos.Archivo,
                                         Status = acad.Status
                                     }
                               ).ToList();
                }
                if (tipo == 2)
                {
                    //La consulta realizada es para mostrar solo al academicos usuario y la información de los planes de estudio que ha presentado,
                    //esta consulta solo se realizara cuando el usuario que ingreso sea de tipo 2 (academico)
                    ListRedisenio = (from datos in context.RediseñoPlanEstudios
                                     join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                     join programa in context.ProgramaEducativo on datos.IdPrograma equals programa.IdProgramaEducativo
                                     where datos.IdAcademico == idUsu 
                                     select new TablaRedisenio
                                     {
                                         IdPlan = datos.IdRediseñoActualizacionEstudios,
                                         NumPersonal = acad.NumeroPersonal,
                                         Nombre = acad.Nombre,
                                         ApellidoPaterno = acad.ApellidoPaterno,
                                         ApellidoMaterno = acad.ApellidoMaterno,
                                         Area = datos.Area,
                                         NombrePrograma = programa.Nombre,
                                         Tipo = datos.CoordinadorColaborador,
                                         Archivo = datos.Archivo,
                                         Status = acad.Status
                                     }
                               ).ToList();
                }
            }
            return View(ListRedisenio);
        }
        //Función para llegar a la vista de edición y obtener los datos que iran en los select.
        [Authorize]
        public IActionResult CrearPartRedisenio()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obteneción de todos los académicos dados de alta en el sistema.
                var programa = context.ProgramaEducativo.ToList(); //Obtención de los programas educativos 
                ViewData["academicos"] = acad; //Paso de información a la vista
                ViewData["programa"] = programa; //Paso de información a la vista
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar la informcion de los planes de estudio en su respectiva tabla.
        public async Task<IActionResult> GuardarPartRedisenio(IFormFile file, RediseñoPlanEstudios datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Verificación que los datos ha guardar no este ya registrados en la base de datos.
                var ListRedisenio = context.RediseñoPlanEstudios.ToList();
                foreach (RediseñoPlanEstudios item in ListRedisenio)
                {
                    //Se compara la informacion ha guardar, donde todos ellos no pueden estar repetidos en otro plan de estudio, son (Area, Programa y el tipo (coordinador/colaborador)).
                    if (datos.Area == item.Area && datos.IdPrograma == item.IdPrograma && datos.CoordinadorColaborador == item.CoordinadorColaborador)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexPartRedisenio");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                
                if (tipo == 2)
                {
                    //Si el usuario que ingresa es de tipo 2 (académico), en esta parte se obtiene el ID de dicho académico, para
                    //mas adelante guardarlo en la respectiva relación.
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename();//Se le agregar el id del académico al nombre del archivo de evidencia.
                datos.Archivo = new_name_table;
                context.RediseñoPlanEstudios.Add(datos);//Se guardan los datos en la tabla "RediseñoPlanEstudios"
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");

            //Se guarda el archivo en la ruta especificada.
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/RedesenioPlanEstudio", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPartRedisenio");
        }
        [Authorize]
        //Función para acceder la vista de editar y obtener los datos ha editar.
        public IActionResult EditarPartRedisenio(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se realiza la consulta sobre el plan de estudio seleccionado, el cual lo consultamos por medio de su id.
                RediseñoPlanEstudios DatosPlan = context.RediseñoPlanEstudios.Where(s => s.IdRediseñoActualizacionEstudios == id).Single();

                var acad = context.Academicos.ToList(); //Obtención de todos los académicos registrados en el sistema.
                var programa = context.ProgramaEducativo.ToList(); //Obtención de todos los programas educativos registrados en el sistema.
                ViewData["academicos"] = acad; //Paso de los datos a la vista.
                ViewData["programa"] = programa;
                return View(DatosPlan);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar la actualizacion de los datos del plan de estudio.
        public async Task<IActionResult> ActualizarPartRedisenio(IFormFile file, RediseñoPlanEstudios datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            if (tipo == 2)
            {
                //Si el usuario que ingresa es de tipo 2 (académico), en esta parte se obtiene el ID de dicho académico, para
                //mas adelante guardarlo en la respectiva relación.
                datos.IdAcademico = idUsu;
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Verificación de la información a actualizar no este ya registrada en la base de datos.
                var ListRedisenio = context.RediseñoPlanEstudios.Where(r => r.IdRediseñoActualizacionEstudios != datos.IdRediseñoActualizacionEstudios).ToList(); //Se hace la consulta de todos los planes de estudio, descartando al que se esta editando.
                foreach (RediseñoPlanEstudios item in ListRedisenio)
                {
                    //Se compara la informacion ha guardar, donde todos ellos no pueden estar repetidos en otro plan de estudio, son (Area, Programa y el tipo (coordinador/colaborador)).
                    if (datos.Area == item.Area && datos.IdPrograma == item.IdPrograma && datos.CoordinadorColaborador == item.CoordinadorColaborador)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexPartRedisenio");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //En la condición de arriba se verifica si la variable file viene vacia, si es asi, se prosigue con obtener el nombre del archivo que ya estaba guardado, para poder hacer la actualización.
                    var nomArchivo = context.RediseñoPlanEstudios.Where(w => w.IdRediseñoActualizacionEstudios == datos.IdRediseñoActualizacionEstudios).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si la variable file viene con información, se prosigue a obtenerla y ha actualizar el nombre.
                    var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.RediseñoPlanEstudios.Update(datos); //Actualización de la información obtenida.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("IndexPartRedisenio"); //Si el archivo no se actualizo, termina el proceso y se regresa a la vista index respectiva.
            }
            //El archivo de evidencia se guarda en la ruta especifica.
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/RedesenioPlanEstudio", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPartRedisenio");
        }
        //Función para eliminar  un plan de rediseño.
        public IActionResult EliminarPartRedesenio(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Teniendo el id del registro a eliminar, con la consulta se obtiene la información.
                RediseñoPlanEstudios eliminar = context.RediseñoPlanEstudios.Where(w => w.IdRediseñoActualizacionEstudios == id).Single();
                context.RediseñoPlanEstudios.Remove(eliminar); //Se elimina el registro.
                context.SaveChanges();
                return RedirectToAction("IndexPartRedisenio");
            }
        }
        //Función para descargar el archivo de evidencia del plan de rediseño.
        public async Task<IActionResult> DescargarPartRedesenio(string filename)
        {
            //Se verifica la variable filename no este vacia.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Comisiones/RedesenioPlanEstudio", filename);

            //Se busca la ruta del archivo, para su descarga.
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }



        //Función para mostrar la información en la pestaña participación en el PLADEA.
        [Authorize]
        public IActionResult IndexPLADEA()
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario"); //La variable tipo, guarda el nivel de permiso que tendra, 1 = (director), 2 = (académicos), 3 = (estudiantes).
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu"); //La variable idUsu, guarda el id del usuario respecto a la tabla Usuario de la Base de datos.
            List<TablaPladea> ListPladea = new List<TablaPladea>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario"); //Se realiza para pasar el tipo de usuario a la vista.
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 1)
                {
                    //La consulta realizada es para mostrar los académicos y la informacion del PLADEA. Esta consulta
                    //se llevara acabo si el usuario que entra es de tipo 1 (direcctor).
                    ListPladea = (from datos in context.ParticipacionPladea
                                  join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                  select new TablaPladea
                                  {
                                      IdJurado = datos.IdPladea,
                                      NumPersonal = acad.NumeroPersonal,
                                      Nombre = acad.Nombre,
                                      ApellidoPaterno = acad.ApellidoPaterno,
                                      ApellidoMaterno = acad.ApellidoMaterno,
                                      Comision = datos.Comision,
                                      Meta = datos.Meta,
                                      Accion = datos.Accion,
                                      Fecha = datos.Fecha.ToString(),
                                      Archivo = datos.Archivo,
                                      Status = acad.Status
                                  }
                               ).ToList();
                }
                if (tipo == 2)
                {
                    //La consulta realizada es para mostrar solo al academicos usuario y la información del PLADEA,
                    //esta consulta solo se realizara cuando el usuario que ingreso sea de tipo 2 (academico).
                    ListPladea = (from datos in context.ParticipacionPladea
                                  join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                  where datos.IdAcademico == idUsu
                                  select new TablaPladea
                                  {
                                      IdJurado = datos.IdPladea,
                                      NumPersonal = acad.NumeroPersonal,
                                      Nombre = acad.Nombre,
                                      ApellidoPaterno = acad.ApellidoPaterno,
                                      ApellidoMaterno = acad.ApellidoMaterno,
                                      Comision = datos.Comision,
                                      Meta = datos.Meta,
                                      Accion = datos.Accion,
                                      Fecha = datos.Fecha.ToString(),
                                      Archivo = datos.Archivo,
                                      Status = acad.Status
                                  }
                               ).ToList();
                }
            }
            return View(ListPladea);
        }
        [Authorize]
        //Función para llegar al vista de crear y obtener la información que tendran la vista.
        public IActionResult CrearPLADEA()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los academicos registrados en el sistema.
                ViewData["academicos"] = acad;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar la información de participación en el PLADEA.
        public async Task<IActionResult> GuardarPLADEA(IFormFile file, ParticipacionPladea datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var ListPladea = context.ParticipacionPladea.ToList();
                foreach (ParticipacionPladea item in ListPladea)
                {
                    //Se verifica que la información ha guardar no este ya registrada. Comparando la comision, la meta, acción, y fecha.
                    if (datos.Comision == item.Comision && datos.Meta == item.Meta && datos.Accion == item.Accion && datos.Fecha == item.Fecha)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexPLADEA");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (tipo == 2)
                {
                    //Si el usuario que ingresa es de tipo 2 (académico), en esta parte se obtiene el ID de dicho académico, para
                    //mas adelante guardarlo en la respectiva relación.
                    datos.IdAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
                }
                var new_name_table = datos.IdAcademico + "_" + file.GetFilename(); //Se obtienen el nombre del archivo y se actualiza.
                datos.Archivo = new_name_table;
                context.ParticipacionPladea.Add(datos); //Se realiza el guardado de la información.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");
            //Se guarda el archivo en la ruta especificada, con el nombre modificado.
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/PLADEA", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPLADEA");
        }
        //Función para llegar a la vista de edición y obtener los datos ha mostrar en los input.
        [Authorize]
        public IActionResult EditarPLADEA(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se consulta el registro segun el id que se mando a esta función desde la vista.
                ParticipacionPladea DatosPladea = context.ParticipacionPladea.Where(s => s.IdPladea == id).Single();

                var acad = context.Academicos.ToList(); //Obtención de los académicos
                ViewData["academicos"] = acad;
                //Como la fecha esta conpuesta por el tiempo se tuvo que separar.
                string fecha = DatosPladea.Fecha.ToString(); //La fecha se convierte a string
                string[] resultado = fecha.Split(' '); //Se separa por los espacios.
                ViewData["fecha"] = resultado[0]; //Se guarda solo la fecha, dejando a un lado la hora.
                return View(DatosPladea);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar la información actualizada
        public async Task<IActionResult> ActualizarPLADEA(IFormFile file, ParticipacionPladea datos)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            if (tipo == 2)
            {
                //Si el usuario que ingresa es de tipo 2 (académico), en esta parte se obtiene el ID de dicho académico, para
                //mas adelante guardarlo en la respectiva relación.
                datos.IdAcademico = idUsu;
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se verifica que la información a actualizar, no este ya guardada en la base de datos.
                var ListPladea = context.ParticipacionPladea.Where(p => p.IdPladea != datos.IdPladea).ToList(); //Se extrae todos los registros del PLADEA, descartando el registro que se esta editando.
                foreach (ParticipacionPladea item in ListPladea)
                {
                    //Se compara la información actualizada y la información de los registros.
                    if (datos.Comision == item.Comision && datos.Meta == item.Meta && datos.Accion == item.Accion && datos.Fecha == item.Fecha)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexPLADEA");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //En la condición de arriba se verifica si la variable file viene vacia, si es asi, se prosigue con obtener el nombre del archivo que ya estaba guardado, para poder hacer la actualización.
                    var nomArchivo = context.ParticipacionPladea.Where(w => w.IdPladea == datos.IdPladea).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si la variable file viene con información, se prosigue a obtenerla y ha actualizar el nombre.
                    var new_name_table = datos.IdAcademico + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ParticipacionPladea.Update(datos); //Se hace el guardado de los datos actualizados.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo para actualizar, se redirecciona a la vista index.
                return RedirectToAction("IndexPLADEA");
            }
            //Si el archivo se necesita actualizar, aqui se guardara en la ruta establecida.
            var new_name_file = datos.IdAcademico + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/PLADEA", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPLADEA");
        }
        //Función para eliminar un registro de la tabla "ParticipacionPladea", que es donde se guardan la participaciones en el PLADEA.
        public IActionResult EliminarPLADEA(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se busca al registro que indica el id, para su eliminación.
                ParticipacionPladea eliminar = context.ParticipacionPladea.Where(w => w.IdPladea == id).Single();
                context.ParticipacionPladea.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexPLADEA");
            }
        }
        //Función para descargar el archivo de evidencia que del PLADEA.
        public async Task<IActionResult> DescargarPLADEA(string filename)
        {
            //Se verifica que variable no venga vacia.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta la ruta para descargar el archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Comisiones/PLADEA", filename);
            //Se busca el archivo y se descarga.
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }



        //Función que muestra los PreJurados de Experiencia Recepcional
        [Authorize]
        public IActionResult IndexPreJurExperiencia()
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            List<TablaPreJurExperiencia> ListPreJurExperiencia = new List<TablaPreJurExperiencia>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se obtienen a los academicos y sus respectivos trabajos recepcionales, con la condicion al de que JuradoPrejurado = 0,
                //es decir que sean Prejurados.
                ListPreJurExperiencia = (from datos in context.JuradoExperienciaRecepcional
                                         join trabajo in context.TrabajosRecepcionales on datos.IdTr equals trabajo.IdTrabajosRecepcionales
                                         join alum in context.Alumnos on trabajo.IdAlumno equals alum.IdAlumnos
                                         join datosG in context.DatosPersonales on alum.RDatosPerson equals datosG.IdDatosPersonales
                                         join modalidad in context.TipoModalidad on trabajo.IdModalidad equals modalidad.IdModalidad
                                         select new TablaPreJurExperiencia
                                         {
                                             IdJurado = datos.IdJer,
                                             NombreAlum = datosG.Nombre,
                                             ApellidoPaternoAlum = datosG.ApellidoPaterno,
                                             ApellidoMaternoAlum = datosG.ApellidoMaterno,
                                             Modalidad = modalidad.Nombre,
                                             NombreTrabajo = trabajo.NombreTrabajo,
                                             Archivo = datos.Archivo,
                                             JuradoPrejurado = datos.JuradoPrejurado
                                         }
                               ).Where(s => s.JuradoPrejurado == 0).ToList();
                if (tipoUsu == 2)
                {
                    //Si el usuario es de tipo 2 (académico), se buscara si el usuario es lider de algun Prejurado.
                    List<Academicosjuradorecep> ListAcad = new List<Academicosjuradorecep>();
                    ListAcad = context.Academicosjuradorecep.Where(w => w.IdAcademico == idUsu && w.Lider == 1).ToList();
                    ViewData["ListAcad"] = ListAcad;
                }
            }
            return View(ListPreJurExperiencia);
        }
        [Authorize]
        //Función para crear un nuevo registro de Prejurado de Experiencia recepcional.
        public IActionResult CrearPreJurExperiencia()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<TrabajosRecepcionales> datTR = new List<TrabajosRecepcionales>();
                List<Alumnos> datAlum = new List<Alumnos>();
                List<Alumnos> datosfin = new List<Alumnos>();
                List<DatosPersonales> datGene = new List<DatosPersonales>();
                List<DatosPersonales> datosGene = new List<DatosPersonales>();
                var acad = context.Academicos.ToList();

                datTR = context.TrabajosRecepcionales.ToList();
                datAlum = context.Alumnos.ToList();
                datGene = context.DatosPersonales.ToList();

                //En este foreach se extraen los ID de los alumnos que se encuentran con fecha establecida para presentar trabajo de Experiencia Recepcional.
                //Por lo que que se compara Proceso == 0.
                foreach (TrabajosRecepcionales item in datTR)
                {
                    foreach (Alumnos item2 in datAlum)
                    {
                        if (item.IdAlumno == item2.IdAlumnos && item.Proceso == 0)
                        {
                            datosfin.Add(item2);
                        }
                    }

                }
                //Teniendo ya los id de los alumnos se hace un la extracción de los datos del alumno, es decir, su nombre, matricula, etc.
                foreach (Alumnos item in datosfin)
                {
                    foreach (DatosPersonales item2 in datGene)
                    {
                        if (item.RDatosPerson == item2.IdDatosPersonales)
                        {
                            datosGene.Add(item2);
                        }
                    }
                }
                ViewData["datosGene"] = datosGene;
                ViewData["academicos"] = acad;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GuardarPreJurExperiencia(IFormFile file, JuradoExperienciaRecepcional datos, int idAcademico, int Lider)
        {
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            if (tipo == 2)
            {
                //Si el usuario que ingresa es de tipo 2 (académico), en esta parte se obtiene el ID de dicho académico, para
                //mas adelante guardarlo en la respectiva relación.
                idAcademico = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se verifica que la información a guardar, no este ya registrada en el sistema.
                var ListJurado = context.JuradoExperienciaRecepcional.ToList();
                foreach (JuradoExperienciaRecepcional item in ListJurado)
                {
                    //Comparando la información a guardar, con la información ya guardada.
                    if (datos.IdTr == item.IdTr && datos.JuradoPrejurado == item.JuradoPrejurado)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexPreJurExperiencia");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var datosAlum = context.Alumnos.Where(s => s.RDatosPerson == datos.IdTr).Single();
                var datosTR = context.TrabajosRecepcionales.Where(a => a.IdAlumno == datosAlum.IdAlumnos).Single();
                datos.IdTr = datosTR.IdTrabajosRecepcionales;
                var name = file.GetFilename();
                datos.Archivo = name;
                context.JuradoExperienciaRecepcional.Add(datos); //Se guarda la información en la base de datos
                context.SaveChanges();
                JuradoExperienciaRecepcional DatosJur = context.JuradoExperienciaRecepcional.Last(); //Se obtiene el ultimo registro agregado.
                var new_name_table = DatosJur.IdJer + "_" + file.GetFilename(); //Se le cambia el nombre al archivo de evidencia.
                datos.Archivo = new_name_table;
                context.JuradoExperienciaRecepcional.Update(datos); //Se vuelve a guardar la información.
                context.SaveChanges();
            }

            if (file == null || file.Length == 0)
                return Content("file not selected");
            //Se guarda el archivo en la ruta establecida.
            var new_name_file = datos.IdJer + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/PreJuradoExperienciaRecepcional", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se guarda al academico creador del Prejurado en la tabla "Academicosjuradorecep".
                JuradoExperienciaRecepcional DatosJur = context.JuradoExperienciaRecepcional.Last();
                Academicosjuradorecep info = new Academicosjuradorecep();
                info.IdAcademico = idAcademico;
                info.IdJurado = DatosJur.IdJer;
                info.Lider = Lider;
                context.Academicosjuradorecep.Add(info);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("IndexPreJurExperiencia");
        }
        [Authorize]
        //Función para llegar a la vista de editar y obtener los datos a editar.
        public IActionResult EditarPreJurExperiencia(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                JuradoExperienciaRecepcional DatosJur = context.JuradoExperienciaRecepcional.Where(s => s.IdJer == id).Single();


                List<TrabajosRecepcionales> datTR = new List<TrabajosRecepcionales>();
                List<Alumnos> datAlum = new List<Alumnos>();
                List<Alumnos> datosfin = new List<Alumnos>();
                List<DatosPersonales> datGene = new List<DatosPersonales>();
                List<DatosPersonales> datosGene = new List<DatosPersonales>();

                datTR = context.TrabajosRecepcionales.ToList();
                datAlum = context.Alumnos.ToList();
                datGene = context.DatosPersonales.ToList();
                //En este foreach se extraen los ID de los alumnos que se encuentran con fecha establecida para presentar trabajo de Experiencia Recepcional.
                //Por lo que que se compara Proceso == 0.
                foreach (TrabajosRecepcionales item in datTR)
                {
                    foreach (Alumnos item2 in datAlum)
                    {
                        if (item.IdAlumno == item2.IdAlumnos)
                        {
                            datosfin.Add(item2);
                        }
                    }

                }
                //Teniendo ya los id de los alumnos se hace un la extracción de los datos del alumno, es decir, su nombre, matricula, etc.
                foreach (Alumnos item in datosfin)
                {
                    foreach (DatosPersonales item2 in datGene)
                    {
                        if (item.RDatosPerson == item2.IdDatosPersonales)
                        {
                            datosGene.Add(item2);
                        }
                    }
                }
                ViewData["datosGene"] = datosGene;

                return View(DatosJur);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función que guarda la información actualizada del Prejurado
        public async Task<IActionResult> ActualizarPreJurExperiencia(IFormFile file, JuradoExperienciaRecepcional datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Verificación de la información ha actualizar no este ya registrada en la base de datos.
                var ListJurado = context.JuradoExperienciaRecepcional.Where(j => j.IdJer != datos.IdJer).ToList(); //Se consulta a todos los trabajos con prejurado y evitando el que esta en actual edición.
                foreach (JuradoExperienciaRecepcional item in ListJurado)
                {
                    //Se compara a los datos consultados con la información actualizada.
                    if (datos.IdTr == item.IdTr && datos.JuradoPrejurado == item.JuradoPrejurado)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("IndexPreJurExperiencia");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (file == null || file.Length == 0)
                {
                    //Se verifica que el archivo no se vaya a actualizar, y se consulta el nombre del archivo ya guardado.
                    var nomArchivo = context.JuradoExperienciaRecepcional.Where(w => w.IdJer == datos.IdJer).Single();
                    datos.Archivo = nomArchivo.Archivo;
                }
                else
                {
                    //Si el archivo si sera modificado, se edita el nombre del archivo original.
                    var new_name_table = datos.IdJer + "_" + file.GetFilename();
                    datos.Archivo = new_name_table;
                }

            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var datosAlum2 = context.Alumnos.Where(s => s.RDatosPerson == datos.IdTr).Single(); //  Se realiza la consulta para poder obtener el id del alumno responsable.
                var datosTR2 = context.TrabajosRecepcionales.Where(a => a.IdAlumno == datosAlum2.IdAlumnos).Single(); //Teniendo el id del alumno se hace la consulta para obtener el id del trabajo recepcional.
                datos.IdTr = datosTR2.IdTrabajosRecepcionales;
                context.JuradoExperienciaRecepcional.Update(datos); //Se guada la información actualizada.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            if (file == null || file.Length == 0)
            {
                //Si no hay archivo a actualizar, se redirecciona a al index.
                return RedirectToAction("IndexPreJurExperiencia");
            }
            //Se guarda el archivo en la direccion especificada.
            var new_name_file = datos.IdJer + "_" + file.GetFilename();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos/Comisiones/PreJuradoExperienciaRecepcional", new_name_file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("IndexPreJurExperiencia");
        }
        //Función para eliminar un registro del Prejurado.
        public IActionResult EliminarPreJurExperiencia(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se obtienen a todos los academicos que pertenecen al prejurado a eliminar.
                List<Academicosjuradorecep> eliminarAcad = context.Academicosjuradorecep.Where(f => f.IdJurado == id).ToList();
                int i = 0;
                foreach (var item in eliminarAcad)
                {
                    //Se elimina la relación del academico al prejurado, uno por uno.
                    context.Academicosjuradorecep.Remove(eliminarAcad[i]);
                    context.SaveChanges();
                    i++;
                }
                //Se elimina el registro del prejurado indicado por el id.
                JuradoExperienciaRecepcional eliminar = context.JuradoExperienciaRecepcional.Where(w => w.IdJer == id).Single();
                context.JuradoExperienciaRecepcional.Remove(eliminar);
                context.SaveChanges();
                return RedirectToAction("IndexPreJurExperiencia");
            }
        }
        //Función para descargar el archivo de evidencia del Prejurado.
        public async Task<IActionResult> DescargarPreJurExperiencia(string filename)
        {
            //Se verifica que la variable filename no este vacia.
            if (filename == null)
                return Content("filename not present");
            //Se acompleta el direccion del archivo.
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/Archivos/Comisiones/PreJuradoExperienciaRecepcional", filename);
            //Se busca el archivo y se descarga.
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        [Authorize]
        //Función para mostrar a los academicos que perteneces aun mismo prejurado.
        public IActionResult AcademicosPreJurExperiencia(int id)
        {
            int tipoUsu = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int idUsu = (int)HttpContext.Session.GetInt32("IdUsu");
            List<TablaAcadJurExperiencia> ListAcadJurExp = new List<TablaAcadJurExperiencia>();
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se obtiene la información y se guarda en la lista "ListAcadJurExp" de la clase creada manualmente "TablaAcadJurExperiencia", esto para su consulta mas eficaz.
                ListAcadJurExp = (from datos in context.Academicosjuradorecep
                                  join acad in context.Academicos on datos.IdAcademico equals acad.IdAcademicos
                                  where datos.IdJurado == id
                                  select new TablaAcadJurExperiencia
                                  {
                                      IdAcadJurExp = datos.IdAcademicosJuradoRecep,
                                      NumPersonal = acad.NumeroPersonal,
                                      Nombre = acad.Nombre,
                                      ApellidoPaterno = acad.ApellidoPaterno,
                                      ApellidoMaterno = acad.ApellidoMaterno,
                                      idJurado = datos.IdJurado
                                  }
                                     ).ToList();
                var acade = context.Academicos.ToList();
                ViewData["academicos"] = acade;
                ViewData["idJur"] = id;
                //Se busca si el usuario que ingreso, es lider del prejurado que se esta consultando.
                Academicosjuradorecep Acad = new Academicosjuradorecep();
                int cant = context.Academicosjuradorecep.Where(w => w.IdJurado == id && w.Lider == 1 && w.IdAcademico == idUsu).Count();
                if (cant > 0)
                {
                    //Si el registro de la tabla "Academicosjuradorecep" el campo Lider == 1, el valor Acad, cambiara a 1.
                    Acad = context.Academicosjuradorecep.Where(w => w.IdJurado == id && w.Lider == 1 && w.IdAcademico == idUsu).Single();
                }
                else
                {
                    Acad = null;
                }
                ViewData["Acad"] = Acad;
                
            }
            return View(ListAcadJurExp);
        }
        [Authorize]
        //Función para guardar a los academicos que pertenecen al mismo prejurado.
        public IActionResult GuardarAcadPreJurExperiencia(int idAcademico, int jurado, int Lider)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academicosjuradorecep AcadJurado = new Academicosjuradorecep();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se verifica que el academico a guardar en la tabla Academicosjuradorecep no este ya registrado. Esto comparando el Id del jurado con los académicos ya registrados.
                var ListAcad = context.Academicosjuradorecep.ToList();
                foreach (Academicosjuradorecep item in ListAcad)
                {
                    if (idAcademico == item.IdAcademico && jurado == item.IdJurado)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El académico ya se encuentra registrado!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("AcademicosPreJurExperiencia", new { id = jurado });
                    }
                }
                //Se realiza el guardado de la relación del académico con el Prejurado.
                AcadJurado.Lider = Lider;
                AcadJurado.IdAcademico = idAcademico;
                AcadJurado.IdJurado = jurado;
                context.Academicosjuradorecep.Add(AcadJurado);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("AcademicosPreJurExperiencia", new { id = AcadJurado.IdJurado });
        }
        [Authorize]
        //Función para eliminar a un academico que pertenezca aun prejurado.
        public IActionResult EliminarAcadPreJurExperiencia(int id, int id_acad)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se consulta al académico a eliminar
                Academicosjuradorecep eliminar = context.Academicosjuradorecep.Where(w => w.IdAcademicosJuradoRecep == id).Single();
                context.Academicosjuradorecep.Remove(eliminar); //Eliminación del académico.
                context.SaveChanges();
                return RedirectToAction("AcademicosPreJurExperiencia", new { id = id_acad });
            }
        }





        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        //Diccionario donde estan declarados todos los tipos de archivos que se podras descargar.
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
