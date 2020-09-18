using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;

namespace SGCFIEE.Controllers
{
    // aqui se encuentran todos los catalogos del sistema
    // de esta forma los usuarios pueden hacer cambios en el futuro
    // siempre es necesario obtener el id del tipo de usuario que esta haciendo las solicutudes
    // ya que solo el administrador debe tener acceso a esa parte

    // vista principal con los catálogos
    public class AcademicosComplementariaController : Controller
    {
        [Authorize]
        public IActionResult VistaOpcionesCatalogos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }




        [Authorize]
        // muestra los tipos de localización: local, nacional, internacional 
        public IActionResult MostrarLocalizacion()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TipoLocNacInter> loc = new List<TipoLocNacInter>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                loc = context.TipoLocNacInter.ToList();
            }
            return View(loc);
        }
        [Authorize]
        public IActionResult InsertarLocalizacion()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarLocalizacion(TipoLocNacInter datos)
        {
            // verificamos que los datos no sean repetidos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var info = context.TipoLocNacInter.ToList();
                foreach(TipoLocNacInter item in info)
                {
                    if(item.Nombre == datos.Nombre)
                    {   // retornamos un mensaje cuando los datos ya existan
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarLocalizacion");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoLocNacInter.Add(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarLocalizacion");
        }
        [Authorize]
        // obtenemos el id del registro a Editar
        public IActionResult EditarLocalizacion(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TipoLocNacInter datos = context.TipoLocNacInter.Where(s => s.IdTipo == id).Single();
                return View(datos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarLocalizacion(TipoLocNacInter datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoLocNacInter.Where(i => i.IdTipo != datos.IdTipo).ToList();
                foreach (TipoLocNacInter item in info)
                {
                    if (item.Nombre == datos.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarLocalizacion");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoLocNacInter.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarLocalizacion");
        }
        public IActionResult EliminarLocalizacion(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TipoLocNacInter eliminar = context.TipoLocNacInter.Where(s => s.IdTipo == id).Single();
                context.TipoLocNacInter.Remove(eliminar);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarLocalizacion");
        }



        [Authorize]
        public IActionResult MostrarEditorial()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<Editorial> edit = new List<Editorial>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                edit = context.Editorial.ToList();
            }
            return View(edit);
        }
        [Authorize]
        public IActionResult InsertarEditorial()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarEditorial(Editorial datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.Editorial.ToList();
                foreach (Editorial item in info)
                {
                    if (item.Nombre == datos.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarEditorial");
                    }
                }
            }
            // se guardan los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.Editorial.Add(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarEditorial");
        }
        [Authorize]
        public IActionResult EditarEditorial(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Editorial datos = context.Editorial.Where(s => s.IdEditorial == id).Single();
                return View(datos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarEditorial(Editorial datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.Editorial.Where(e => e.IdEditorial != datos.IdEditorial).ToList();
                foreach (Editorial item in info)
                {
                    if (item.Nombre == datos.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarEditorial");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.Editorial.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarEditorial");
        }
        public IActionResult EliminarEditorial(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Editorial eliminar = context.Editorial.Where(s => s.IdEditorial == id).Single();
                context.Editorial.Remove(eliminar);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarEditorial");
        }

        [Authorize]
        // nivel jerarquico de los cuerpos académicos
        public IActionResult MostrarNivel()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<CanivelJerarquico> nivel = new List<CanivelJerarquico>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                nivel = context.CanivelJerarquico.ToList();
            }
            return View(nivel);
        }
        [Authorize]
        public IActionResult InsertarNivel()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarNivel(CanivelJerarquico datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.CanivelJerarquico.ToList();
                foreach (CanivelJerarquico item in info)
                {
                    if (item.Nombre == datos.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarNivel");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CanivelJerarquico.Add(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarNivel");
        }
        [Authorize]
        public IActionResult EditarNivel(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CanivelJerarquico datos = context.CanivelJerarquico.Where(s => s.IdCanivelJerarquico == id).Single();
                return View(datos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarNivel(CanivelJerarquico datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.CanivelJerarquico.Where(c => c.IdCanivelJerarquico != datos.IdCanivelJerarquico).ToList();
                foreach (CanivelJerarquico item in info)
                {
                    if (item.Nombre == datos.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarNivel");
                    }
                }
            }
            // actualizamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CanivelJerarquico.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarNivel");
        }
        public IActionResult EliminarNivel(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CanivelJerarquico eliminar = context.CanivelJerarquico.Where(s => s.IdCanivelJerarquico == id).Single();
                context.CanivelJerarquico.Remove(eliminar);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarNivel");
        }




        [Authorize]
        public IActionResult MostrarProducto()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TipoEvaluador> produc = new List<TipoEvaluador>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                produc = context.TipoEvaluador.ToList();
            }
            return View(produc);
        }
        [Authorize]
        public IActionResult InsertarProducto()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarProducto(TipoEvaluador datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoEvaluador.ToList();
                foreach (TipoEvaluador item in info)
                {
                    if (item.Nombre == datos.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarProducto");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoEvaluador.Add(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarProducto");
        }
        [Authorize]
        // recibe el id del registro
        public IActionResult EditarProducto(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TipoEvaluador datos = context.TipoEvaluador.Where(s => s.IdTipoEvaluador == id).Single();
                return View(datos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarProducto(TipoEvaluador datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoEvaluador.Where(t => t.IdTipoEvaluador != datos.IdTipoEvaluador).ToList();
                foreach (TipoEvaluador item in info)
                {
                    if (item.Nombre == datos.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarProducto");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoEvaluador.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarProducto");
        }
        public IActionResult EliminarProducto(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TipoEvaluador eliminar = context.TipoEvaluador.Where(s => s.IdTipoEvaluador == id).Single();
                context.TipoEvaluador.Remove(eliminar);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarProducto");
        }




        [Authorize]
        public IActionResult MostrarModalidad()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TipoModalidad> modal = new List<TipoModalidad>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                modal = context.TipoModalidad.ToList();
            }
            return View(modal);
        }
        [Authorize]
        public IActionResult InsertarModalidad()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarModalidad(TipoModalidad datos)
        {
            // verificamos que los datos no sean repetidos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var info = context.TipoModalidad.ToList();
                foreach (TipoModalidad item in info)
                {
                    if (item.Nombre == datos.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarModalidad");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoModalidad.Add(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarModalidad");
        }
        [Authorize]
        public IActionResult EditarModalidad(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TipoModalidad datos = context.TipoModalidad.Where(s => s.IdModalidad == id).Single();
                return View(datos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarModalidad(TipoModalidad datos)
        {
            // verificamos que los datos no sean repetidos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var info = context.TipoModalidad.Where(t => t.IdModalidad != datos.IdModalidad).ToList();
                foreach (TipoModalidad item in info)
                {
                    if (item.Nombre == datos.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarModalidad");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoModalidad.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarModalidad");
        }
        public IActionResult EliminarModalidad(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TipoModalidad eliminar = context.TipoModalidad.Where(s => s.IdModalidad == id).Single();
                context.TipoModalidad.Remove(eliminar);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarModalidad");
        }



        [Authorize]
        public IActionResult MostrarCuerpos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            // obtenemos los datos en un modelo personalizado
            List<TablaCuerpo> cuerpoAca = new List<TablaCuerpo>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                        cuerpoAca = (from datos in context.CuerposAcademicos
                                      join estado in context.CuerpoEstados on datos.IdEstado equals estado.IdEstado
                                      select new TablaCuerpo
                                      {
                                          IdCuerpo= datos.IdCuerpoAcademico,
                                          NombreCuerpo = datos.Nombre,
                                          Estado = estado.Nombre
                                      }
                                    ).ToList();
            }
            return View(cuerpoAca);
        }
        [Authorize]
        public IActionResult InsertarCuerpo()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var estado = context.CuerpoEstados.ToList();
                ViewData["estados"] = estado;
            }
                return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarCuerpo(CuerposAcademicos datos)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos si se ingreso un estado: en consolidacion, consolidado
                if(datos.IdEstado == null)
                {
                    TempData["msg"] = "<script language='javascript'> swal({ title:'" + "No se ha encontrado el estado del cuerpo académico!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                    return RedirectToAction("InsertarCuerpo");
                }
            }
            // verificamos que los datos no sean repetidos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var info = context.CuerposAcademicos.ToList();
                foreach (CuerposAcademicos item in info)
                {
                    if (item.Nombre == datos.Nombre && item.IdEstado == datos.IdEstado)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarCuerpos");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CuerposAcademicos.Add(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarCuerpos");
        }
        [Authorize]
        public IActionResult EditarCuerpo(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CuerposAcademicos datos = context.CuerposAcademicos.Where(s => s.IdCuerpoAcademico == id).Single();
                var estado = context.CuerpoEstados.ToList();
                ViewData["estados"] = estado;
                return View(datos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarCuerpo(CuerposAcademicos datos)
        {
            // verificamos que los datos no sean repetidos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var info = context.CuerposAcademicos.Where(c => c.IdCuerpoAcademico != datos.IdCuerpoAcademico).ToList();
                foreach (CuerposAcademicos item in info)
                {
                    if (item.Nombre == datos.Nombre && item.IdEstado == datos.IdEstado)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarCuerpos");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CuerposAcademicos.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarCuerpos");
        }
        public IActionResult EliminarCuerpo(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CuerposAcademicos eliminar = context.CuerposAcademicos.Where(s => s.IdCuerpoAcademico == id).Single();
                context.CuerposAcademicos.Remove(eliminar);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarCuerpos");
        }


        [Authorize]
        // estados de los cuerpos académicos
        public IActionResult MostrarEstado()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<CuerpoEstados> estado = new List<CuerpoEstados>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                estado = context.CuerpoEstados.ToList();
            }
            return View(estado);
        }
        [Authorize]
        public IActionResult InsertarEstado()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarEstado(CuerpoEstados datos)
        {
            // verificamos que los datos no sean repetidos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var info = context.CuerpoEstados.ToList();
                foreach (CuerpoEstados item in info)
                {
                    if (item.Nombre == datos.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarEstado");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CuerpoEstados.Add(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarEstado");
        }
        [Authorize]
        public IActionResult EditarEstado(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CuerpoEstados datos = context.CuerpoEstados.Where(s => s.IdEstado == id).Single();
                return View(datos);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // estado de cuerpos académicos
        public IActionResult ActualizarEstado(CuerpoEstados datos)
        {
            // verificamos que los datos no sean repetidos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var info = context.CuerpoEstados.Where(e => e.IdEstado != datos.IdEstado).ToList();
                foreach (CuerpoEstados item in info)
                {
                    if (item.Nombre == datos.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarEstado");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CuerpoEstados.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarEstado");
        }
        public IActionResult EliminarEstado(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CuerpoEstados eliminar = context.CuerpoEstados.Where(s => s.IdEstado == id).Single();
                context.CuerpoEstados.Remove(eliminar);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarEstado");
        }





        [Authorize]
        // tipo de personal
        public IActionResult MostrarPersonal()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TipoPersonal> personal = new List<TipoPersonal>();
            using(sgcfieeContext context = new sgcfieeContext())
            {
                personal = context.TipoPersonal.ToList();
            }
            return View(personal);
        }

        [Authorize]
        // tipos de puestos de experiencia profesional
        public IActionResult MostrarPuestos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TipoPuesto> puestos = new List<TipoPuesto>();
            using(sgcfieeContext context = new sgcfieeContext())
            {
                puestos = context.TipoPuesto.ToList();
            }
            return View(puestos);
        }

        [Authorize]
        // los laboratorios que se ligan con los académicos
        public IActionResult MostrarLaboratorios()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TipoLaboratorio> laboratorios = new List<TipoLaboratorio>();
            using(sgcfieeContext context = new sgcfieeContext())
            {
                laboratorios = context.TipoLaboratorio.ToList();
            }
            return View(laboratorios);
        }

        [Authorize]
        // periodos escolares
        public IActionResult MostrarPeriodos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TipoPeriodo> periodos = new List<TipoPeriodo>();
            using(sgcfieeContext context = new sgcfieeContext())
            {
                periodos = context.TipoPeriodo.ToList();
            }
            return View(periodos);
        }

        [Authorize]
        // grado de titulo de un academico
        public IActionResult MostrarGTitulo()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<GradoTitulo> gradosT = new List<GradoTitulo>();
            using(sgcfieeContext context = new sgcfieeContext())
            {
                gradosT = context.GradoTitulo.ToList();
            }
            return View(gradosT);
        }

        [Authorize]
        // distinciones del trabajo académico
        public IActionResult MostrarDistincionesTA()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TipoDistincionTa> distinciones = new List<TipoDistincionTa>();
            using(sgcfieeContext context = new sgcfieeContext())
            {
                distinciones = context.TipoDistincionTa.ToList();
            }
            return View(distinciones);
        }

        [Authorize]
        // tipos de certificaciones que pueden tener los académicos
        public IActionResult MostrarCertificacion()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TipoCertificacion> certificacion = new List<TipoCertificacion>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                certificacion = context.TipoCertificacion.ToList();
            }
            return View(certificacion);
        }

        [Authorize]
        // instituciones / empresas
        public IActionResult MostrarInstiEmpre()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<InstitucionesEmpresas> emp = new List<InstitucionesEmpresas>();
            using(sgcfieeContext context = new sgcfieeContext())
            {
                emp = context.InstitucionesEmpresas.ToList();
            }
            return View(emp);
        }

        [Authorize]
        // academias de la universidad
        public IActionResult MostrarAcademias()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<Academias> academias = new List<Academias>();
            using(sgcfieeContext context = new sgcfieeContext())
            {
                academias = context.Academias.ToList();
            }
            return View(academias);
        }

        [Authorize]
        // programas transversales
        public IActionResult MostrarProTransversales()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<ProgramasTrasversales> programas = new List<ProgramasTrasversales>();
            using(sgcfieeContext context = new sgcfieeContext())
            {
                programas = context.ProgramasTrasversales.ToList();
            }
            return View(programas);
        }

        [Authorize]
        // tipos de contratación
        public IActionResult MostrarTContratacion()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TipoContratacionee> contratacionees = new List<TipoContratacionee>();
            using(sgcfieeContext context = new sgcfieeContext())
            {
                contratacionees = context.TipoContratacionee.ToList();
            }
            return View(contratacionees);
        }

        [Authorize]
        // programas educativos
        public IActionResult VCarreras()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var carreras = context.ProgramaEducativo.ToList();
                ViewData["carreras"] = carreras;
            }
            return View();
        }
        // pendiente
        [Authorize]
        public IActionResult TablaMatPE(ProgramaEducativo map)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int x = map.IdProgramaEducativo;
            List<TablaMatPE> mapa = new List<TablaMatPE>();
            if(x == 0)
            {
                x = (int)HttpContext.Session.GetInt32("programaE");
                //return RedirectToAction("VCarreras");
            }
            else
            {
                HttpContext.Session.SetInt32("programaE", x);
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                mapa = (from m in context.MapaCurricular
                            join ee in context.ExperienciaEducativa on m.IdExperienciaEducativa equals ee.IdExperienciaEducativa
                            join ar in context.AreaExperienciaEducativa on ee.IdArea equals ar.IdAreaExperienciaEducativa
                            join pe in context.ProgramaEducativo on m.IdProgramaEducativo equals pe.IdProgramaEducativo
                            select
                            new TablaMatPE
                            {
                                idMapa = m.IdMapaCurricular,
                                nomMat = ee.Nombre,
                                creditos = ee.Creditos.Value,
                                idPE = pe.IdProgramaEducativo,
                                area = ar.Nombre,
                                estado = m.Estado.Value
                            }
                            ).Where(s => s.idPE == x && s.estado== 1).ToList();
                    var carreras = context.ProgramaEducativo.ToList();
                    ViewData["carreras"] = carreras;
                }
                ViewData["mapa"] = mapa;
            
            return View();
        }

        // eliminar mapa curricular
        public IActionResult EliminarMC(int id)
        {
            MapaCurricular mc;
            //mc.Estado = 0;
            //mc.IdExperienciaEducativa = id;
            //int x = (int)HttpContext.Session.GetInt32("programaE");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                mc = context.MapaCurricular.Where(s => s.IdMapaCurricular == id).Single();
                mc.Estado = 0;
                context.MapaCurricular.Update(mc);
                context.SaveChanges();
            }
            return RedirectToAction("TablaMatPE");
        }

        //Empiezan los insertar
        [Authorize]
        public IActionResult InsertarPersonal()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // tipo de personal
        public IActionResult CrearPersonal(TipoPersonal personal)
        {
            // verificamos que los datos no sean repetidos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var info = context.TipoPersonal.ToList();
                foreach (TipoPersonal item in info)
                {
                    if (item.Nombre == personal.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarPersonal");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoPersonal.Add(personal);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarPersonal");
        }

        [Authorize]
        // puestos de experiencia recepcional
        public IActionResult InsertarPuestos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // puestos de experiencia recepcional
        public IActionResult CrearPuesto(TipoPuesto puesto)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoPuesto.ToList();
                foreach (TipoPuesto item in info)
                {
                    if (item.Nombre == puesto.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarPuestos");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoPuesto.Add(puesto);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarPuestos");
        }

        [Authorize]
        // tipo de laboratorio
        public IActionResult InsertarLaboratorios()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearLaboratorio(TipoLaboratorio lab)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoLaboratorio.ToList();
                foreach (TipoLaboratorio item in info)
                {
                    if (item.Nombre == lab.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarLaboratorios");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoLaboratorio.Add(lab);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarLaboratorios");
        }

        [Authorize]
        public IActionResult InsertarPeriodos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearPeriodo(TipoPeriodo periodo)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoPeriodo.ToList();
                foreach (TipoPeriodo item in info)
                {
                    if (item.Nombre == periodo.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarPeriodos");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoPeriodo.Add(periodo);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarPeriodos");
        }
        

        [Authorize]
        // grado de titulo
        public IActionResult InsertarGTitulo()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // grado de titulo
        public IActionResult CrearGTitulo(GradoTitulo titulo)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.GradoTitulo.ToList();
                foreach (GradoTitulo item in info)
                {
                    if (item.Nombre == titulo.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarGTitulo");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.GradoTitulo.Add(titulo);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarGTitulo");
        }

        [Authorize]
        // distinciones del trabajo academico
        public IActionResult InsertarDistincionesTA()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // distinciones del trabajo academico
        public IActionResult CrearDistincionTA(TipoDistincionTa distincion)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoDistincionTa.ToList();
                foreach (TipoDistincionTa item in info)
                {
                    if (item.Nombre == distincion.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarDistincionesTA");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoDistincionTa.Add(distincion);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarDistincionesTA");
        }

        [Authorize]
        public IActionResult InsertarCertificacion()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearCertificado(TipoCertificacion certificado)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoCertificacion.ToList();
                foreach (TipoCertificacion item in info)
                {
                    if (item.Nombre == certificado.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarCertificacion");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoCertificacion.Add(certificado);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarCertificacion");
        }

        [Authorize]
        // instituciones / empresas
        public IActionResult InsertarIE()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // instituciones / empresas
        public IActionResult CrearIE(InstitucionesEmpresas IE)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.InstitucionesEmpresas.ToList();
                foreach (InstitucionesEmpresas item in info)
                {
                    if (item.Nombre == IE.Nombre && item.IesEmpresa == IE.IesEmpresa)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarInstiEmpre");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.InstitucionesEmpresas.Add(IE);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarInstiEmpre");
        }

        [Authorize]
        public IActionResult InsertarAcademias()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearAcademias(Academias aca)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.Academias.ToList();
                foreach (Academias item in info)
                {
                    if (item.Nombre == aca.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarAcademias");
                    }
                }
            }
            // guardamos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.Academias.Add(aca);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarAcademias");
        }

        [Authorize]
        // programa transversal
        public IActionResult InsertarPTransversal()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // programa transversal
        public IActionResult CrearPTransversal(ProgramasTrasversales PT)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.ProgramasTrasversales.ToList();
                foreach (ProgramasTrasversales item in info)
                {
                    if (item.Nombre == PT.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarProTransversales");
                    }
                }
            }
            // guardar datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ProgramasTrasversales.Add(PT);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarProTransversales");
        }

        [Authorize]
        // tipo de contratacion
        public IActionResult InsertarTContratacion()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // tipo de contratacion
        public IActionResult CrearTContratacion(TipoContratacionee ee)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoContratacionee.ToList();
                foreach (TipoContratacionee item in info)
                {
                    if (item.Nombre == ee.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarTContratacion");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoContratacionee.Add(ee);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarTContratacion");
        }

        [Authorize]
        // elegir programa educativo
        public IActionResult SeleccionarCarrera()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.ProgramaEducativo.ToList();
                ViewData["carreras"] = x;
            }
            return View();
        }
        // pendiente
        [Authorize]
        public IActionResult MostrarMaterias(ProgramaEducativo pe)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int proe = pe.IdProgramaEducativo;
            if(proe == 0)
            {
                proe = (int)HttpContext.Session.GetInt32("programaE");
            }
            else
            {
                HttpContext.Session.SetInt32("programaE", proe);
            }
            List<ExperienciaEducativa> ee = new List<ExperienciaEducativa>();
            List<TablaMatPE> ee2 = new List<TablaMatPE>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ee = context.ExperienciaEducativa.ToList();
                ee2 = (from m in context.MapaCurricular
                       join e in context.ExperienciaEducativa on m.IdExperienciaEducativa equals e.IdExperienciaEducativa
                       select
                       new TablaMatPE
                       {
                           idEE = e.IdExperienciaEducativa,
                           idPE = m.IdProgramaEducativo.Value,
                           nomMat = e.Nombre,
                           creditos = e.Creditos.Value,
                           estado = m.Estado.Value
                       }).Where(s => s.idPE == proe && s.estado == 1).ToList();

                var x = context.ProgramaEducativo.ToList();
                ViewData["carreras"] = x;

            }
            int band = 0;
            List<ExperienciaEducativa> correcto = new List<ExperienciaEducativa>();
            foreach (ExperienciaEducativa exp in ee)
            {
                band = 0;
                foreach (TablaMatPE tpe in ee2)
                {
                    if(exp.IdExperienciaEducativa == tpe.idEE)
                    {
                        band = 1;
                    }
                }
                if(band == 0)
                {
                    correcto.Add(exp);
                }
            }
            ViewData["materias"] = correcto;

            return View();
        }
        // mapa curricular
        public IActionResult CrearMapaC(int id)
        {
            // mapa curricular contiene el id de la materia y el id del programa educativo al que pertenece
            MapaCurricular mc = new MapaCurricular();
            mc.IdExperienciaEducativa = id;
            int pe = (int)HttpContext.Session.GetInt32("programaE");
            mc.IdProgramaEducativo = pe;
            // en vigencia
            mc.Estado = 1;
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.MapaCurricular.Add(mc);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarMaterias");
        }
        //Eliminar

        public IActionResult EliminarAcademia(int id)
        {
            Academias aca;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                aca = context.Academias.Where(s => s.IdAcademias == id).Single();
                context.Academias.Remove(aca);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarAcademias");
        }

        public IActionResult EliminarCertificacion(int id)
        {
            TipoCertificacion tc;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                tc = context.TipoCertificacion.Where(s => s.IdCertificacion == id).Single();
                context.TipoCertificacion.Remove(tc);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarCertificacion");
        }
        // distincion academica
        public IActionResult EliminarDistincion(int id)
        {
            TipoDistincionTa dis;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                dis = context.TipoDistincionTa.Where(s => s.IdDistincion == id).Single();
                context.TipoDistincionTa.Remove(dis);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarDistincionesTA");
        }
        // grado de titulo
        public IActionResult EliminarGTitulo(int id)
        {
            GradoTitulo gt;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                gt = context.GradoTitulo.Where(s => s.IdGradoTitulo == id).Single();
                context.GradoTitulo.Remove(gt);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarGTitulo");
        }
        // instituciones / empresas
        public IActionResult EliminarInstiEmp(int id)
        {
            InstitucionesEmpresas b;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                b = context.InstitucionesEmpresas.Where(s => s.IdIE == id).Single();
                context.InstitucionesEmpresas.Remove(b);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarInstiEmpre");
        }

        public IActionResult EliminarLaboratorio(int id)
        {
            TipoLaboratorio tipoLab;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                tipoLab = context.TipoLaboratorio.Where(s => s.IdTipoLaboratorio == id).Single();
                context.TipoLaboratorio.Remove(tipoLab);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarLaboratorios");
        }
        // periodo escolar
        public IActionResult EliminarPeriodo(int id)
        {
            TipoPeriodo periodo;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                periodo = context.TipoPeriodo.Where(s => s.IdPeriodo == id).Single();
                context.TipoPeriodo.Remove(periodo);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarPeriodos");
        }
        // tipo de personal
        public IActionResult EliminarTPersonal(int id)
        {
            TipoPersonal personal;
            using(sgcfieeContext context  = new sgcfieeContext())
            {
                personal = context.TipoPersonal.Where(s => s.IdTipoPersonal == id).Single();
                context.TipoPersonal.Remove(personal);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarPersonal");
        }
        // eliminar programa transversal
        public IActionResult EliminarPTransversal(int id)
        {
            ProgramasTrasversales pt;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                pt = context.ProgramasTrasversales.Where(s => s.IdProgramasTrasversales == id).Single();
                context.ProgramasTrasversales.Remove(pt);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarProTransversales");
        }
        // eliminar tipo de puesto
        public IActionResult EliminarTPuesto(int id)
        {
            TipoPuesto puesto;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                puesto = context.TipoPuesto.Where(s => s.IdPuesto == id).Single();
                context.TipoPuesto.Remove(puesto);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarPuestos");
        }
        // tipo de contratacion
        public IActionResult EliminarTContratacion(int id)
        {
            TipoContratacionee contratacionee;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                contratacionee = context.TipoContratacionee.Where(s => s.IdTipoContratacion == id).Single();
                context.TipoContratacionee.Remove(contratacionee);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarTContratacion");
        }


        [Authorize]
        public IActionResult FormEditarAcademia(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            Academias aca;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                aca = context.Academias.Where(s => s.IdAcademias == id).Single();
            }
            return View(aca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarAcademia(Academias aca)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.Academias.Where(a => a.IdAcademias != aca.IdAcademias).ToList();
                foreach (Academias item in info)
                {
                    if (item.Nombre == aca.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarAcademias");
                    }
                }
            }
            // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.Academias.Update(aca);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarAcademias");
        }

        [Authorize]
        // certificaciones académicas
        public IActionResult FormEditarCertificacion(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            TipoCertificacion cert;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                cert = context.TipoCertificacion.Where(s => s.IdCertificacion == id).Single();
            }
            return View(cert);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult EditarCertificacion(TipoCertificacion cert)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoCertificacion.Where(c => c.IdCertificacion != cert.IdCertificacion).ToList();
                foreach (TipoCertificacion item in info)
                {
                    if (item.Nombre == cert.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarCertificacion");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoCertificacion.Update(cert);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarCertificacion");
        }

        [Authorize]
        // distincion academica
        public IActionResult FormEditarDistincion(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            TipoDistincionTa ta;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                ta = context.TipoDistincionTa.Where(s => s.IdDistincion == id).Single();
            }
            return View(ta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // distincion academica
        public IActionResult EditarDistincion(TipoDistincionTa ta)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoDistincionTa.Where(t => t.IdDistincion != ta.IdDistincion).ToList();
                foreach (TipoDistincionTa item in info)
                {
                    if (item.Nombre == ta.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarDistincionesTA");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoDistincionTa.Update(ta);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarDistincionesTA");
        }

        [Authorize]
        // grado de titulo
        public IActionResult FormEditarGTitulo(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            GradoTitulo gt;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                gt = context.GradoTitulo.Where(s => s.IdGradoTitulo == id).Single();
            }
            return View(gt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // grado de titulo
        public IActionResult EditarGTitulo(GradoTitulo gt)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.GradoTitulo.Where(g => g.IdGradoTitulo != gt.IdGradoTitulo).ToList();
                foreach (GradoTitulo item in info)
                {
                    if (item.Nombre == gt.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarGTitulo");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.GradoTitulo.Update(gt);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarGTitulo");
        }

        [Authorize]
        // Instituciones / empresas
        public IActionResult FormEditarIE(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            InstitucionesEmpresas ie;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                ie = context.InstitucionesEmpresas.Where(s => s.IdIE == id).Single();
            }
            return View(ie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // instituciones / empresas
        public IActionResult EditarIE(InstitucionesEmpresas ie)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var info = context.InstitucionesEmpresas.Where(i => i.IdIE != ie.IdIE).ToList();
                foreach (InstitucionesEmpresas item in info)
                {
                    if (item.Nombre == ie.Nombre && item.IesEmpresa == ie.IesEmpresa)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarInstiEmpre");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.InstitucionesEmpresas.Update(ie);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarInstiEmpre");
        }

        [Authorize]
        // laboratorio
        public IActionResult FormEditarLab(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            TipoLaboratorio lab;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                lab = context.TipoLaboratorio.Where(s => s.IdTipoLaboratorio == id).Single();
            }
            return View(lab);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarLab(TipoLaboratorio lab)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoLaboratorio.Where(l => l.IdTipoLaboratorio != lab.IdTipoLaboratorio).ToList();
                foreach (TipoLaboratorio item in info)
                {
                    if (item.Nombre == lab.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarLaboratorios");
                    }
                }
            }// guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoLaboratorio.Update(lab);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarLaboratorios");
        }

        [Authorize]
        // periodo escolar
        public IActionResult FormEditarPeriodo(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            TipoPeriodo per;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                per = context.TipoPeriodo.Where(s => s.IdPeriodo == id).Single();
            }
            return View(per);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarPeriodo(TipoPeriodo per)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoPeriodo.Where(p => p.IdPeriodo != per.IdPeriodo).ToList();
                foreach (TipoPeriodo item in info)
                {
                    if (item.Nombre == per.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarPeriodos");
                    }
                }
            }// guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoPeriodo.Update(per);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarPeriodos");
        }

        [Authorize]
        // tipo personal
        public IActionResult FormEditarTPersonal(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            TipoPersonal per;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                per = context.TipoPersonal.Where(s => s.IdTipoPersonal == id).Single();
            }
            return View(per);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // tipo de personal académico
        public IActionResult EditarPersonal(TipoPersonal per)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoPersonal.Where( p => p.IdTipoPersonal != per.IdTipoPersonal).ToList();
                foreach (TipoPersonal item in info)
                {
                    if (item.Nombre == per.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarPersonal");
                    }
                }
            } // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoPersonal.Update(per);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarPersonal");
        }

        [Authorize]
        // programa transversal
        public IActionResult FormEditarProTra(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            ProgramasTrasversales pro;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                pro = context.ProgramasTrasversales.Where(s => s.IdProgramasTrasversales == id).Single();
            }
            return View(pro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // programa transversal
        public IActionResult EditarProTra(ProgramasTrasversales pt)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            { 
                // verificamos que los datos no sean repetidos
                var info = context.ProgramasTrasversales.Where( p => p.IdProgramasTrasversales != pt.IdProgramasTrasversales).ToList();
                foreach (ProgramasTrasversales item in info)
                {
                    if (item.Nombre == pt.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarProTransversales");
                    }
                }
            } // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ProgramasTrasversales.Update(pt);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarProTransversales");
        }

        [Authorize]
        // puestos de experiencia profesional
        public IActionResult FormEditarPuesto(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            TipoPuesto puesto;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                puesto = context.TipoPuesto.Where(s => s.IdPuesto == id).Single();
            }
            return View(puesto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // puestos de experiencia profesioal
        public IActionResult EditarPuesto(TipoPuesto puesto)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoPuesto.Where(p => p.IdPuesto != puesto.IdPuesto).ToList();
                foreach (TipoPuesto item in info)
                {
                    if (item.Nombre == puesto.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarPuestos");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoPuesto.Update(puesto);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarPuestos");
        }

        [Authorize]
        // tipo de contratación
        public IActionResult FormEditarTContratacion(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            TipoContratacionee cont;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                cont = context.TipoContratacionee.Where(s => s.IdTipoContratacion == id).Single();
            }
            return View(cont);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // tipo de contratación
        public IActionResult EditarTContratacion(TipoContratacionee ee)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoContratacionee.Where(e => e.IdTipoContratacion != ee.IdTipoContratacion).ToList();
                foreach (TipoContratacionee item in info)
                {
                    if (item.Nombre == ee.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarTContratacion");
                    }
                }
            } // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoContratacionee.Update(ee);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("MostrarTContratacion");
        }


        [HttpGet]
        [Authorize]
        // programa educativo
        public IActionResult CrearPrograma()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearPrograma(ProgramaEducativo programa)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.ProgramaEducativo.ToList();
                foreach (ProgramaEducativo item in info)
                {
                    if (item.Nombre == programa.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarProgramas");
                    }
                }
            }// guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ProgramaEducativo.Add(programa);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarProgramas");
            }
        }
        [Authorize]
        // programas académicos
        public IActionResult MostrarProgramas()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.ProgramaEducativo.ToList();
                return View(lista);
            }

        }
        [Authorize]
        // programas aducativos
        public IActionResult DetallesPrograma(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.ProgramaEducativo.Where(s => s.IdProgramaEducativo == id).Single();
                return View(lista);
            }
        }
        [HttpGet]
        [Authorize]
        // programas educativos
        public IActionResult EditarPrograma(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.ProgramaEducativo.Where(o => o.IdProgramaEducativo == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // programas educativos
        public IActionResult EditarPrograma(ProgramaEducativo programa)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.ProgramaEducativo.Where(p => p.IdProgramaEducativo != programa.IdProgramaEducativo).ToList();
                foreach (ProgramaEducativo item in info)
                {
                    if (item.Nombre == programa.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarProgramas");
                    }
                }
            }// guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ProgramaEducativo.Update(programa);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarProgramas");
            }
        }
        [HttpGet]
        public IActionResult EliminarPrograma(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var programa = context.ProgramaEducativo.Where<ProgramaEducativo>(p => p.IdProgramaEducativo == id).Single<ProgramaEducativo>();
                if (programa == null) return NotFound();
                context.ProgramaEducativo.Remove(programa);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarProgramas");
            }
        }
        [HttpGet]
        [Authorize]
        // rubro de examen interno o externo
        public IActionResult CrearRubro()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearRubro(TbRubrosexamenes rubro)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TbRubrosexamenes.ToList();
                foreach (TbRubrosexamenes item in info)
                {
                    if (item.RubroExamen == rubro.RubroExamen && item.TipoExamen == rubro.TipoExamen)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarRubro");
                    }
                }
            } // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TbRubrosexamenes.Add(rubro);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarRubro");
            }
        }
        [Authorize]
        // rubros de examen interno o externo
        public IActionResult MostrarRubro()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.TbRubrosexamenes.ToList();
                return View(lista);
            }
        }
        [HttpGet]
        [Authorize]
        // rubro de examen interno o externo (vista)
        public IActionResult EditarRubro(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.TbRubrosexamenes.Where(o => o.IdTbRubrosExamenes == id).First();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // (metodo de guadadado)
        public IActionResult EditarRubro(TbRubrosexamenes rubro)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TbRubrosexamenes.Where(r => r.IdTbRubrosExamenes != rubro.IdTbRubrosExamenes).ToList();
                foreach (TbRubrosexamenes item in info)
                {
                    if (item.RubroExamen == rubro.RubroExamen && item.TipoExamen == rubro.TipoExamen)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarRubro");
                    }
                }
            } // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TbRubrosexamenes.Update(rubro);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarRubro");
            }
        }

        [HttpGet]
        public IActionResult EliminarRubro(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var rubro = context.TbRubrosexamenes.Where<TbRubrosexamenes>(r => r.IdTbRubrosExamenes == id).Single<TbRubrosexamenes>();
                if (rubro == null) return NotFound();
                context.TbRubrosexamenes.Remove(rubro);
                context.SaveChanges();
                TempData["Mensaje"] = "Eelemento elimindado";
                return RedirectToAction("MostrarRubro");
            }

        }
        [HttpGet]
        [Authorize]
        public IActionResult CrearSalon()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearSalon(TbSalones salon)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // // verificamos que los datos no sean repetidos
                var info = context.TbSalones.ToList();
                foreach (TbSalones item in info)
                {
                    if (item.ClaveSalon == salon.ClaveSalon && item.Edificio == salon.Edificio)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarSalon");
                    }
                }
            } // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TbSalones.Add(salon);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarSalon");
            }
        }
        [Authorize]
        public IActionResult MostrarSalon()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.TbSalones.ToList();
                return View(lista);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditarSalon(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.TbSalones.Where(o => o.IdTbSalones == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarSalon(TbSalones salon)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TbSalones.Where(s => s.IdTbSalones != salon.IdTbSalones).ToList();
                foreach (TbSalones item in info)
                {
                    if (item.ClaveSalon == salon.ClaveSalon && item.Edificio == salon.Edificio)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarSalon");
                    }
                }
            } // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TbSalones.Update(salon);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarSalon");
            }
        }
        [HttpGet]
        public IActionResult EliminarSalon(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var salon = context.TbSalones.Where<TbSalones>(p => p.IdTbSalones == id).Single<TbSalones>();
                if (salon == null) return NotFound();
                context.TbSalones.Remove(salon);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarSalon");
            }
        }
        [Authorize]
        [HttpGet]
        // area a la cual pertenencen las EE
        public IActionResult CrearArea()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearArea(AreaExperienciaEducativa area)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.AreaExperienciaEducativa.ToList();
                foreach (AreaExperienciaEducativa item in info)
                {
                    if (item.Nombre == area.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarArea");
                    }
                }
            } // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.AreaExperienciaEducativa.Add(area);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarArea");
            }
        }
        [Authorize]
        public IActionResult MostrarArea()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.AreaExperienciaEducativa.ToList();
                return View(lista);
            }
        }
        [Authorize]
        [HttpGet]
        // vista
        public IActionResult EditarArea(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.AreaExperienciaEducativa.Where(o => o.IdAreaExperienciaEducativa == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // método de guardado
        public IActionResult EditarArea(AreaExperienciaEducativa area)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var info = context.AreaExperienciaEducativa.Where( a => a.IdAreaExperienciaEducativa != area.IdAreaExperienciaEducativa).ToList();
                foreach (AreaExperienciaEducativa item in info)
                {
                    if (item.Nombre == area.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarArea");
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.AreaExperienciaEducativa.Update(area);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarArea");
            }
        }
        [HttpGet]
        public IActionResult EliminarArea(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var area = context.AreaExperienciaEducativa.Where<AreaExperienciaEducativa>(p => p.IdAreaExperienciaEducativa == id).Single<AreaExperienciaEducativa>();
                if (area == null) return NotFound();
                context.AreaExperienciaEducativa.Remove(area);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarArea");
            }
        }
        [Authorize]
        [HttpGet]
        // experiencia educativa (vista)
        public IActionResult CrearExperiencia()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.AreaExperienciaEducativa.ToList();
                ViewData["area"] = x;
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // experiencia educativa (método de guardado)
        public IActionResult CrearExperiencia(ExperienciaEducativa expe)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.ExperienciaEducativa.ToList();
                foreach (ExperienciaEducativa item in info)
                {
                    if (item.Nombre == expe.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarExperiencia");
                    }
                }
            }
            // verificamos que el area de para las EE exista
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (expe.IdArea == null)
                {
                    TempData["msg"] = "<script language='javascript'> swal({ title:'" + "No se ha encontrado el área de la Experiencia Educativa!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                    return RedirectToAction("CrearExperiencia");
                }
                // guardamos datos
                context.ExperienciaEducativa.Add(expe);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarExperiencia");
            }
        }
        [Authorize]
        // experiencia educativa
        public IActionResult MostrarExperiencia()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TablaExperiencia> list = new List<TablaExperiencia>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                list = (from a in context.AreaExperienciaEducativa
                        join
                        e in context.ExperienciaEducativa on a.IdAreaExperienciaEducativa equals e.IdArea
                        select
                        new TablaExperiencia
                        {
                            IdExperienciaEducativa = e.IdExperienciaEducativa,
                            Nombre = e.Nombre,
                            Creditos = e.Creditos,
                            Horas = e.Horas,
                            Nombrearea = a.Nombre
                        }).ToList();
                return View(list);
            }
        }
        [Authorize]
        [HttpGet]
        // experiencia educativa
        public IActionResult EditarExperiencia(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.AreaExperienciaEducativa.ToList();
                ViewData["areae"] = x;
                var objeto = context.ExperienciaEducativa.Where(o => o.IdExperienciaEducativa == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // experiencia edacativa
        public IActionResult EditarExperiencia(ExperienciaEducativa expe)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.ExperienciaEducativa.Where(e => e.IdArea != expe.IdArea).ToList();
                foreach (ExperienciaEducativa item in info)
                {
                    if (item.Nombre == expe.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarExperiencia");
                    }
                }
            } // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ExperienciaEducativa.Update(expe);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarExperiencia");
            }
        }
        [HttpGet]
        public IActionResult EliminarExperiencia(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var area = context.ExperienciaEducativa.Where<ExperienciaEducativa>(p => p.IdExperienciaEducativa == id).Single<ExperienciaEducativa>();
                if (area == null) return NotFound();
                context.ExperienciaEducativa.Remove(area);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarExperiencia");
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult CrearMovilidad()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // movilidades para los alumnos
        public IActionResult CrearMovilidad(CtMovilidades movi)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.CtMovilidades.ToList();
                foreach (CtMovilidades item in info)
                {
                    if (item.EntidadDestinoMovilidad == movi.EntidadDestinoMovilidad && item.PaisDestinoMovilidad == movi.PaisDestinoMovilidad && item.EscuelaDestinoMovilidad == movi.EscuelaDestinoMovilidad && item.TiempoPermanenciaMovilidad == movi.TiempoPermanenciaMovilidad)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarMovilidad");
                    }
                }
            } // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtMovilidades.Add(movi);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarMovilidad");
            }
        }
        [Authorize]
        // movilidades de alumnos
        public IActionResult MostrarMovilidad()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.CtMovilidades.ToList();
                return View(lista);
            }
        } // modalidades de alumnos
        [Authorize]
        public IActionResult DetallesMovilidad(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var detalle = context.CtMovilidades.Where(s => s.IdCtMovilidades == id).Single();
                return View(detalle);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditarMovilidad(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.CtMovilidades.Where(o => o.IdCtMovilidades == id).Single();

                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarMovilidad(CtMovilidades movi)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            { // verificamos que los datos no sean repetidos
                var info = context.CtMovilidades.Where(m => m.IdCtMovilidades != movi.IdCtMovilidades).ToList();
                foreach (CtMovilidades item in info)
                {
                    if (item.EntidadDestinoMovilidad == movi.EntidadDestinoMovilidad && item.PaisDestinoMovilidad == movi.PaisDestinoMovilidad && item.EscuelaDestinoMovilidad == movi.EscuelaDestinoMovilidad && item.TiempoPermanenciaMovilidad == movi.TiempoPermanenciaMovilidad)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarMovilidad");
                    }
                }
            } // guardamos los datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtMovilidades.Update(movi);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarMovilidad");
            }
        }
        [HttpGet]
        public IActionResult EliminarMovilidad(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var movi = context.CtMovilidades.Where<CtMovilidades>(p => p.IdCtMovilidades == id).Single<CtMovilidades>();
                if (movi == null) return NotFound();
                context.CtMovilidades.Remove(movi);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarMovilidad");
            }
        }
        [Authorize]
        [HttpGet]
        // modalidad de la calificación: primera, extra, repite, etc. (vista)
        public IActionResult CrearTipo()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // modalidad de la calificación: primera, extra, repite, etc. (método)
        public IActionResult CrearTipo(CtTipoCalificacion tip)
        {
            // verificamos que los datos no sean repetidos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var info = context.CtTipoCalificacion.ToList();
                foreach (CtTipoCalificacion item in info)
                {
                    if (item.Tipo == tip.Tipo )
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarTipo");
                    }
                }
            } // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtTipoCalificacion.Add(tip);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarTipo");
            }
        }
        [Authorize]
        // tipo de modalidad de calificación
        public IActionResult MostrarTipo()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.CtTipoCalificacion.ToList();
                return View(lista);
            }
        }
        [Authorize]
        [HttpGet]
        // tipo de modalidad de calificación (vista)
        public IActionResult EditarTipo(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.CtTipoCalificacion.Where(o => o.IdCtTipoCalificacion == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // tipo de modalidad de calificación (método)
        public IActionResult EditarTipo(CtTipoCalificacion cali)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // se guarda el archivo en el servidor
                var info = context.CtTipoCalificacion.Where(c => c.IdCtTipoCalificacion != cali.IdCtTipoCalificacion).ToList();
                foreach (CtTipoCalificacion item in info)
                {
                    if (item.Tipo == cali.Tipo)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarTipo");
                    }
                }
            } // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtTipoCalificacion.Update(cali);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarTipo");
            }
        }
        [HttpGet]
        public IActionResult EliminarTipo(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var tipo = context.CtTipoCalificacion.Where<CtTipoCalificacion>(p => p.IdCtTipoCalificacion == id).Single<CtTipoCalificacion>();
                if (tipo == null) return NotFound();
                context.CtTipoCalificacion.Remove(tipo);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarTipo");
            }
        }
        [Authorize]
        [HttpGet]
        // tipo de evento (vista)
        public IActionResult CrearTipoe()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // tipo de evento ( método)
        public IActionResult CrearTipoe(TipoEventos tipoe)
        {
            // verificamos que los datos no sean repetidos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var info = context.TipoEventos.ToList();
                foreach (TipoEventos item in info)
                {
                    if (item.Nombre == tipoe.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarTipoe");
                    }
                }
            }
            // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoEventos.Add(tipoe);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarTipoe");
            }
        }
        [Authorize]
        // tipo de evento
        public IActionResult MostrarTipoe()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var lista = context.TipoEventos.ToList();
                return View(lista);
            }
        }
        [Authorize]
        [HttpGet]
        // tipo de evento (vista)
        public IActionResult EditarTipoe(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var objeto = context.TipoEventos.Where(o => o.IdEventos == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // tipo de evento (método)
        public IActionResult EditarTipoe(TipoEventos tipoe)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TipoEventos.Where( t => t.IdEventos != tipoe.IdEventos).ToList();
                foreach (TipoEventos item in info)
                {
                    if (item.Nombre == tipoe.Nombre)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarTipoe");
                    }
                }
            }// guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoEventos.Update(tipoe);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarTipoe");
            }
        }
        [HttpGet]
        public IActionResult EliminarTipoe(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var tipoe = context.TipoEventos.Where<TipoEventos>(p => p.IdEventos == id).Single<TipoEventos>();
                if (tipoe == null) return NotFound();
                context.TipoEventos.Remove(tipoe);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarTipoe");
            }
        }
        [HttpGet]
        [Authorize]
        // evento académico ( vista)
        public IActionResult CrearEvento()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.TipoEventos.ToList();
                ViewData["e"] = x;
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // evento académico (método)
        public IActionResult CrearEvento(TbEventos evento)
        {   // verificamos que el tipo de evento exista
            using (sgcfieeContext context = new sgcfieeContext())
            {
                if (evento.RTioEvento == null)
                {
                    TempData["msg"] = "<script language='javascript'> swal({ title:'" + "No se ha encontrado el tipo del evento!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                    return RedirectToAction("CrearEvento");
                }
                // verificamos que los datos no sean repetidos
                var info = context.TbEventos.ToList();
                foreach (TbEventos item in info)
                {
                    if (item.Nombre == evento.Nombre && item.RTioEvento == evento.RTioEvento)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarEvento");
                    }
                }
            } // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TbEventos.Add(evento);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarEvento");
            }
        }
        [Authorize]
        // evento académico
        public IActionResult MostrarEvento()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<TablaEvento> list = new List<TablaEvento>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                list = (from t in context.TbEventos
                        join e in context.TipoEventos on t.RTioEvento equals e.IdEventos
                        select
                        new TablaEvento
                        {
                            IdEventos = t.IdEventos,
                            Nombre = e.Nombre,
                            NombreEvento = t.Nombre,
                            Status = t.Status
                        }).ToList();
                return View(list);
            }
        }
        [Authorize]
        [HttpGet]
        // evento académico ( vista)
        public IActionResult EditarEvento(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.TipoEventos.ToList();
                ViewData["evento"] = x;
                var objeto = context.TbEventos.Where(o => o.IdEventos == id).Single();
                return View(objeto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // evento académico (método)
        public IActionResult EditarEvento(TbEventos eve)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                // verificamos que los datos no sean repetidos
                var info = context.TbEventos.Where(e => e.IdEventos != eve.IdEventos).ToList();
                foreach (TbEventos item in info)
                {
                    if (item.Nombre == eve.Nombre && item.RTioEvento == eve.RTioEvento)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("MostrarEvento");
                    }
                }
            } // guardamos datos
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TbEventos.Update(eve);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("MostrarEvento");
            }
        }
        [HttpGet]
        // eventos académicos
        public IActionResult EliminarEventoe(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var evento = context.TbEventos.Where<TbEventos>(p => p.IdEventos == id).Single<TbEventos>();
                if (evento == null) return NotFound();
                context.TbEventos.Remove(evento);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("MostrarEvento");
            }
        }
    } 
}