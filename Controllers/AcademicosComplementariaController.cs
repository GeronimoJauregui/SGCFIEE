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
    public class AcademicosComplementariaController : Controller
    {
        [Authorize]
        public IActionResult VistaOpcionesCatalogos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [Authorize]
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
        public IActionResult MostrarTTitulo()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<NombreTitulo> titulo = new List<NombreTitulo>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                titulo = context.NombreTitulo.ToList();
            }
                return View(titulo);
        }

        [Authorize]
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
        public IActionResult CrearPersonal(TipoPersonal personal)
        {
            using(sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoPersonal.Add(personal);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarPersonal");
        }

        [Authorize]
        public IActionResult InsertarPuestos()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearPuesto(TipoPuesto puesto)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoPuesto.Add(puesto);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarPuestos");
        }

        [Authorize]
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
                context.TipoLaboratorio.Add(lab);
                context.SaveChanges();
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
                context.TipoPeriodo.Add(periodo);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarPeriodos");
        }

        [Authorize]
        public IActionResult InsertarTTitulo()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearTTitulo(NombreTitulo titulo)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.NombreTitulo.Add(titulo);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarTTitulo");
        }

        [Authorize]
        public IActionResult InsertarGTitulo()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearGTitulo(GradoTitulo titulo)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.GradoTitulo.Add(titulo);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarGTitulo");
        }

        [Authorize]
        public IActionResult InsertarDistincionesTA()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearDistincionTA(TipoDistincionTa distincion)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoDistincionTa.Add(distincion);
                context.SaveChanges();
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
                context.TipoCertificacion.Add(certificado);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarCertificacion");
        }

        [Authorize]
        public IActionResult InsertarIE()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearIE(InstitucionesEmpresas IE)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.InstitucionesEmpresas.Add(IE);
                context.SaveChanges();
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
                context.Academias.Add(aca);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarAcademias");
        }

        [Authorize]
        public IActionResult InsertarPTransversal()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearPTransversal(ProgramasTrasversales PT)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.ProgramasTrasversales.Add(PT);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarProTransversales");
        }

        [Authorize]
        public IActionResult InsertarTContratacion()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearTContratacion(TipoContratacionee ee)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoContratacionee.Add(ee);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarTContratacion");
        }

        [Authorize]
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

        public IActionResult CrearMapaC(int id)
        {
            MapaCurricular mc = new MapaCurricular();
            mc.IdExperienciaEducativa = id;
            int pe = (int)HttpContext.Session.GetInt32("programaE");
            mc.IdProgramaEducativo = pe;
            mc.Estado = 1;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.MapaCurricular.Add(mc);
                context.SaveChanges();
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

        public IActionResult EliminarTTitulo(int id)
        {
            NombreTitulo nt;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                nt = context.NombreTitulo.Where(s => s.IdNombreTitulo == id).Single();
                context.NombreTitulo.Remove(nt);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarTTitulo");
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
            using(sgcfieeContext context = new sgcfieeContext())
            {
                context.Academias.Update(aca);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarAcademias");
        }

        [Authorize]
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
            using(sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoCertificacion.Update(cert);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarCertificacion");
        }

        [Authorize]
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
        public IActionResult EditarDistincion(TipoDistincionTa ta)
        {
            using(sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoDistincionTa.Update(ta);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarDistincionesTA");
        }

        [Authorize]
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
        public IActionResult EditarGTitulo(GradoTitulo gt)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.GradoTitulo.Update(gt);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarGTitulo");
        }

        [Authorize]
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
        public IActionResult EditarIE(InstitucionesEmpresas ie)
        {
            using(sgcfieeContext context = new sgcfieeContext())
            {
                context.InstitucionesEmpresas.Update(ie);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarInstiEmpre");
        }

        [Authorize]
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
            using(sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoLaboratorio.Update(lab);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarLaboratorios");
        }

        [Authorize]
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
            using(sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoPeriodo.Update(per);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarPeriodos");
        }

        [Authorize]
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
        public IActionResult EditarPersonal(TipoPersonal per)
        {
            using(sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoPersonal.Update(per);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarPersonal");
        }

        [Authorize]
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
        public IActionResult EditarProTra(ProgramasTrasversales pt)
        {
            using(sgcfieeContext context = new sgcfieeContext())
            {
                context.ProgramasTrasversales.Update(pt);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarProTransversales");
        }

        [Authorize]
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
        public IActionResult EditarPuesto(TipoPuesto puesto)
        {
            using(sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoPuesto.Update(puesto);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarPuestos");
        }

        [Authorize]
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
        public IActionResult EditarTContratacion(TipoContratacionee ee)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.TipoContratacionee.Update(ee);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarTContratacion");
        }

        [Authorize]
        public IActionResult FormEditarNomTitulo(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            NombreTitulo tit;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                tit = context.NombreTitulo.Where(s => s.IdNombreTitulo == id).Single();
            }
            return View(tit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarNomTitulo(NombreTitulo tit)
        {
            using(sgcfieeContext context = new sgcfieeContext())
            {
                context.NombreTitulo.Update(tit);
                context.SaveChanges();
            }
            return RedirectToAction("MostrarTTitulo");
        }
    } 
}