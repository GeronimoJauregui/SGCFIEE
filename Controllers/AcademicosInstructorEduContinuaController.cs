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
    public class AcademicosInstructorEduContinuaController : Controller
    {
        //Función index, obtiene la información que se mostrara en la vista index del submodulo Intructor de educación continua.
        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            List<TablaInstructorEduCont> ListInstructorEdu = new List<TablaInstructorEduCont>(); //Se crea una clase manualmente, para poder manipular la información con mayor facilidad.
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //De la clase creada, se genera la lista "ListInstructorEdu" la cual guardara la información obtenida de la consulta a continuación.
                ListInstructorEdu = (from instruc in context.RecursosExternos
                                        join acad in context.Academicos on instruc.IdAcademicos equals acad.IdAcademicos
                                        join perio in context.TipoPeriodo on instruc.IdPeriodo equals perio.IdPeriodo
                                        select new TablaInstructorEduCont
                                        {
                                            IdInstructorEdu = instruc.IdRecursosExternos,
                                            NumPersonal = acad.NumeroPersonal,
                                            Nombre = acad.Nombre,
                                            ApellidoPaterno = acad.ApellidoPaterno,
                                            ApellidoMaterno = acad.ApellidoMaterno,
                                            Ingreso = instruc.Ingreso,
                                            NomIngreso = instruc.Nombre,
                                            Periodo = perio.Nombre,
                                            Status = acad.Status
                                        }
                                    ).ToList();
            }
            return View(ListInstructorEdu); //Información retornada  a la vista.
        }
        //Función para obtener la información que llenara los select en la vista de crear.
        public IActionResult Crear()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var acad = context.Academicos.ToList(); //Obtención de los académicos que se encuentran registrados en el sistema.
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos que se encuentran registrados en el sistema.
                ViewData["academicos"] = acad; //Paso de los datos a la vista por el diccionario ViewData.
                ViewData["periodos"] = perio; //Paso de los datos a la vista por el diccionario ViewData.
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función para guardar a los académicos que han hecho ingreso de recursos externos.
        public IActionResult GuardarInstructorEdu(RecursosExternos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se verifica que la información a guardar no este ya registrada en el sistema.
                var ListInstructorEdu = context.RecursosExternos.ToList();
                foreach (RecursosExternos item in ListInstructorEdu)
                {
                    //Comparación de los datos ha guardar y los datos ya registrados. 
                    if (datos.IdAcademicos == item.IdAcademicos && datos.IdPeriodo == item.IdPeriodo && datos.Nombre==item.Nombre && datos.Ingreso== item.Ingreso)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("Index");
                    }
                }
                //Guardado de los datos en la tabla RecursosExternos.
                context.RecursosExternos.Add(datos);
                context.SaveChanges();
                
            }
            //Alerta de guardado exitosamente.
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("Index"); //Regreso al index del submodulo.
        }
        //Función para obtener los datos que llenaran los input ha editar.
        public IActionResult Editar(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta de los datos registrados en la base de datos.
                RecursosExternos DatosInstructorEdu = context.RecursosExternos.Where(s => s.IdRecursosExternos == id).Single();
                var perio = context.TipoPeriodo.ToList(); //Obtención de los periodos.
                var acad = context.Academicos.ToList(); //Obtención de los académicos.
                ViewData["periodos"] = perio; //Paso de los datos a la vista.
                ViewData["academicos"] = acad; //Paso de los datos a la vista.
                return View(DatosInstructorEdu);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //Función que actualiza la información de los Instructores de eduacación continua.
        public IActionResult ActualizarInstructorEdu(RecursosExternos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Verificación que los datos ha actualizar no esten ya registrados.
                var ListInstructorEdu = context.RecursosExternos.Where(y => y.IdRecursosExternos != datos.IdRecursosExternos).ToList();

                foreach (RecursosExternos item in ListInstructorEdu)
                {
                    //Se comparan que los datos ya registrados no sean iguales al actualizado.
                    if (datos.IdAcademicos == item.IdAcademicos && datos.IdPeriodo == item.IdPeriodo && datos.Nombre == item.Nombre && datos.Ingreso == item.Ingreso)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("Index");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Actualizacion de los datos en la tabla.
                context.RecursosExternos.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>"; //Mensaje de alerta.

            }
            return RedirectToAction("Index");
        }
        //Función para eliminara un registro de la tabla de Recursos Externos.
        public IActionResult Eliminar(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Teniendo el id del registro a eliminar, se realiza la consulta de los datos.
                RecursosExternos eliminar = context.RecursosExternos.Where(w => w.IdRecursosExternos == id).Single();
                context.RecursosExternos.Remove(eliminar); //Eliminación del registro.
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
