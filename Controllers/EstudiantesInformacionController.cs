using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net.Mail;
using System.Net;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SGCFIEE.Controllers
{
    public class EstudiantesInformacionController : Controller
    {
        private string from = "pruebasgcfiee@gmail.com";
        private string to = "";
        private string pass = "Qwerty.12";
        MailMessage m = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        private readonly IHostingEnvironment _hostingEnvironment;
        public EstudiantesInformacionController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [Authorize]
        public IActionResult Index()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int tipo = (int)HttpContext.Session.GetInt32("TipoUsuario");
            if (tipo == 3)
            {
                return RedirectToAction("Detalles");
            }
            List<TablaAlumno> ListAlumno = new List<TablaAlumno>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                ListAlumno = (from d in context.DatosPersonales
                              join
                              a in context.Alumnos on d.IdDatosPersonales equals a.RDatosPerson
                              join p in context.ProgramaEducativo on a.RProgramaEducativo equals p.IdProgramaEducativo
                              select
                              new TablaAlumno
                              {
                                  id = a.IdAlumnos,
                                  Nombre = d.Nombre,
                                  ApellidoPaterno = d.ApellidoPaterno,
                                  ApellidoMaterno = d.ApellidoMaterno,
                                  Matricula = a.Matricula,
                                  NombrePro = p.Nombre,
                                  Status = a.RStatus.Value
                              }
                              ).Where(s => s.Status == 0).ToList();
                return View(ListAlumno);
            }

        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.ProgramaEducativo.ToList();
                ViewData["progra"] = x;
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Alumnos datos)
        {
            string mat = datos.Matricula;
            Usuarios usu = null;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                usu = context.Usuarios.Where(s => s.Nombre.Equals(mat)).SingleOrDefault();
                if (usu == null)
                {
                    datos.RStatus = 0;
                    context.Alumnos.Add(datos);
                    context.SaveChanges();
                    Alumnos alu = context.Alumnos.Last();
                    Usuarios usunuevo = new Usuarios();
                    usunuevo.Nombre = alu.Matricula;
                    usunuevo.Tipo = 3;
                    usunuevo.IdAlumno = alu.IdAlumnos;
                    string curp = alu.RDatosPersonNavigation.Curp;
                    curp = curp.Substring(0, 10);
                    String contrasena = string.Concat(alu.Matricula, curp);
                    SHA1 sha1 = new SHA1CryptoServiceProvider();
                    byte[] input = (new UnicodeEncoding()).GetBytes(contrasena);
                    byte[] hash = sha1.ComputeHash(input);
                    string passwo = Convert.ToBase64String(hash);
                    usunuevo.Contrasenia = passwo;
                    context.Usuarios.Add(usunuevo);
                    context.SaveChanges();
                    EnviarCorreo("Crear cuenta", alu.RDatosPersonNavigation.Correo, alu.Matricula, alu.RDatosPersonNavigation.ApellidoPaterno);
                }
                else
                {
                    int idalu = usu.IdAlumno.Value;
                    Alumnos alu2 = context.Alumnos.Where(s => s.IdAlumnos == idalu).Single();
                    int alum = alu2.RDatosPerson.Value;
                    DatosPersonales dp = context.DatosPersonales.Where(s => s.IdDatosPersonales == alum).Single();
                    EnviarCorreo("Recordatorio de datos", dp.Correo, alu2.Matricula, dp.ApellidoPaterno);
                }
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("Index");

            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<DatosAlumno> ListAlumno = new List<DatosAlumno>();
            DatosAlumno datosalumno = new DatosAlumno();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.ProgramaEducativo.ToList();
                ViewData["programa"] = x;
                var alumno = context.Alumnos.Where(s => s.IdAlumnos == id).Single();
                var datos = context.DatosPersonales.Where(s => s.IdDatosPersonales == id).Single();
                datosalumno.IdDatosPersonales = id;
                datosalumno.Nombre = datos.Nombre;
                datosalumno.ApellidoPaterno = datos.ApellidoPaterno;
                datosalumno.ApellidoMaterno = datos.ApellidoMaterno;
                datosalumno.Correo = datos.Correo;
                datosalumno.FechaNacimiento = datos.FechaNacimiento;
                datosalumno.Nacionalidad = datos.Nacionalidad;
                datosalumno.EstadoCivil = datos.EstadoCivil;
                datosalumno.Genero = datos.Genero;
                datosalumno.Curp = datos.Curp;
                datosalumno.Calle = datos.Calle;
                datosalumno.Colonia = datos.Colonia;
                datosalumno.Ciudad = datos.Ciudad;
                datosalumno.Municipio = datos.Municipio;
                datosalumno.Estado = datos.Estado;
                datosalumno.Pais = datos.Pais;
                datosalumno.CodigoPostal = datos.CodigoPostal;
                datosalumno.Telefono = datos.Telefono;
                datosalumno.RecidenciaActual = datos.RecidenciaActual;
                datosalumno.Trabaja = datos.Trabaja;
                datosalumno.IngresoMensual = datos.IngresoMensual;
                datosalumno.Matricula = alumno.Matricula;
                datosalumno.CorreoInstitucional = alumno.CorreoInstitucional;
                datosalumno.RDatosPerson = datos.IdDatosPersonales;
                datosalumno.AnioIngreso = alumno.AnioIngreso;
                datosalumno.Modalidad = alumno.Modalidad;
                datosalumno.Bachillerato = alumno.Bachillerato;

                return View(datosalumno);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(DatosAlumno alumno)
        {
            DatosPersonales datos = new DatosPersonales();
            Alumnos alum = new Alumnos();
            ProgramaEducativo progra = new ProgramaEducativo();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                datos.IdDatosPersonales = alumno.IdDatosPersonales;
                datos.Nombre = alumno.Nombre;
                datos.ApellidoPaterno = alumno.ApellidoPaterno;
                datos.ApellidoMaterno = alumno.ApellidoMaterno;
                datos.Correo = alumno.Correo;
                datos.FechaNacimiento = alumno.FechaNacimiento;
                datos.Nacionalidad = alumno.Nacionalidad;
                datos.EstadoCivil = alumno.EstadoCivil;
                datos.Genero = alumno.Genero;
                datos.Curp = alumno.Curp;
                datos.Calle = alumno.Calle;
                datos.Colonia = alumno.Colonia;
                datos.Ciudad = alumno.Ciudad;
                datos.Municipio = alumno.Municipio;
                datos.Estado = alumno.Estado;
                datos.Pais = alumno.Pais;
                datos.CodigoPostal = alumno.CodigoPostal;
                datos.Telefono = alumno.Telefono;
                datos.RecidenciaActual = alumno.RecidenciaActual;
                datos.Trabaja = alumno.Trabaja;
                datos.IngresoMensual = alumno.IngresoMensual;
                alum.IdAlumnos = alumno.IdDatosPersonales;
                alum.RDatosPerson = alumno.IdDatosPersonales;
                alum.Matricula = alumno.Matricula;
                alum.CorreoInstitucional = alumno.CorreoInstitucional;
                alum.Modalidad = alumno.Modalidad;
                alum.RProgramaEducativo = alumno.RProgramaEducativo;
                alum.AnioIngreso = alumno.AnioIngreso;
                alum.Bachillerato = alumno.Bachillerato;
                alum.RStatus = 0;

                context.Alumnos.Update(alum);
                context.SaveChanges();
                
                context.DatosPersonales.Update(datos);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("Index");
            }

        }
        [Authorize]
        [HttpGet]
        public IActionResult Detalles(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            if (id == 0)
            {
                id = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            ViewData["alumno"] = id;
            CompletoAlumnos datosalumno = new CompletoAlumnos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                
                var datos = context.DatosPersonales.Where(s => s.IdDatosPersonales == id).FirstOrDefault();

                string fecha = datos.FechaNacimiento.ToString();
                string[] resultado = fecha.Split(' ');
                ViewData["fecha"] = resultado[0];

                datosalumno.IdDatosPersonales = id;
                datosalumno.Nombre = datos.Nombre;
                datosalumno.ApellidoPaterno = datos.ApellidoPaterno;
                datosalumno.ApellidoMaterno = datos.ApellidoMaterno;
                datosalumno.Correo = datos.Correo;
                //datosalumno.FechaNacimiento = datos.FechaNacimiento.ToString();
                datosalumno.Nacionalidad = datos.Nacionalidad;
                datosalumno.EstadoCivil = datos.EstadoCivil;
                datosalumno.Genero = datos.Genero;
                datosalumno.Curp = datos.Curp;
                datosalumno.Calle = datos.Calle;
                datosalumno.Colonia = datos.Colonia;
                datosalumno.Ciudad = datos.Ciudad;
                datosalumno.Municipio = datos.Municipio;
                datosalumno.Estado = datos.Estado;
                datosalumno.Pais = datos.Pais;
                datosalumno.CodigoPostal = datos.CodigoPostal;
                datosalumno.Telefono = datos.Telefono;
                datosalumno.RecidenciaActual = datos.RecidenciaActual;
                datosalumno.Trabaja = datos.Trabaja;
                datosalumno.IngresoMensual = datos.IngresoMensual;

                return View(datosalumno);
            }

        }
        [Authorize]
        [HttpGet]
        public IActionResult DetallesInfoAcademica(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            if (id == 0)
            {
                id = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            ViewData["alumno"] = id;
            CompletoAlumnos datosalumno = new CompletoAlumnos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var alumno = context.Alumnos.Where(s => s.IdAlumnos == id).FirstOrDefault();
                var programa = context.ProgramaEducativo.Where(s => s.IdProgramaEducativo == alumno.RProgramaEducativo).FirstOrDefault();
                

                datosalumno.Matricula = alumno.Matricula;
                datosalumno.CorreoInstitucional = alumno.CorreoInstitucional;
                datosalumno.AnioIngreso = alumno.AnioIngreso;
                datosalumno.Modalidad = alumno.Modalidad;
                datosalumno.Bachillerato = alumno.Bachillerato;
                datosalumno.Nombrepro = programa.Nombre;

                return View(datosalumno);
            }

        }
        [Authorize]
        [HttpGet]
        public IActionResult DetallesBoleta(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            if (id == 0)
            {
                id = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            ViewData["alumno"] = id;
            CompletoAlumnos datosalumno = new CompletoAlumnos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.TipoPeriodo.ToList();
                ViewData["periodo"] = x;
                
                
                List<TbHorario> horario = new List<TbHorario>();
                List<CalificacionAlumno> listcali = new List<CalificacionAlumno>();
                CalificacionAlumno cali = new CalificacionAlumno();
                
                horario = context.TbHorario.Where(s => s.RAlumno == id).ToList<TbHorario>();
                if (horario != null)
                {
                    foreach (var item in horario)
                    {
                        var a = context.ExperienciaEducativaPeriodo.Where(s => s.IdExperienciaEducativaPeriodo == item.RExperienciaPeriodo).FirstOrDefault();
                        var b = context.CtTipoCalificacion.Where(s => s.IdCtTipoCalificacion == item.RTipoCalif).FirstOrDefault();
                        var c = context.Academicos.Where(s => s.IdAcademicos == a.IdAcademico).FirstOrDefault();
                        var d = context.MapaCurricular.Where(s => s.IdMapaCurricular == a.IdMapaCurricular).FirstOrDefault();
                        var e = context.ExperienciaEducativa.Where(s => s.IdExperienciaEducativa == d.IdExperienciaEducativa).FirstOrDefault();
                        var f = context.TipoPeriodo.Where(s => s.IdPeriodo == a.IdPeriodo).FirstOrDefault();
                        cali.Nombreexpe = e.Nombre;
                        cali.Nrc = a.Nrc;
                        cali.IdPeriodo = f.IdPeriodo;
                        cali.Nombreaca = c.Nombre;
                        cali.Calificacion = item.Calificacion;
                        cali.tipocali = b.Tipo;
                        cali.creditos = e.Creditos;
                        listcali.Add(cali);
                        cali = new CalificacionAlumno();
                    }
                    ViewData["calificacion"] = listcali;
                }
                

                datosalumno.IdDatosPersonales = id;
                

                return View(datosalumno);
            }

        }
        [Authorize]
        [HttpGet]
        public IActionResult DetallesPafis(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            if (id == 0)
            {
                id = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            ViewData["alumno"] = id;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.TipoPeriodo.ToList();
                ViewData["periodo"] = x;
                
                List<TbPafisAlumno> pafi = new List<TbPafisAlumno>();
                List<AlumnoPafi> listpafi = new List<AlumnoPafi>();
                AlumnoPafi datospafi = new AlumnoPafi();
                
                pafi = context.TbPafisAlumno.Where(s => s.RAlumno == id).ToList<TbPafisAlumno>();
                if (pafi != null)
                {
                    foreach (var item in pafi)
                    {
                        var a = context.PafisAcademicos.Where(s => s.IdPafis == item.RInfopafi).FirstOrDefault();
                        var b = context.TbSalones.Where(s => s.IdTbSalones == a.IdSalon).FirstOrDefault();
                        var c = context.Academicos.Where(s => s.IdAcademicos == a.IdAcademico).FirstOrDefault();
                        var d = context.TipoPeriodo.Where(s => s.IdPeriodo == a.IdPeriodo).SingleOrDefault();
                        datospafi.nombrepafi = a.Nombre;
                        datospafi.acapafi = c.Nombre + " " + c.ApellidoPaterno + " " + c.ApellidoMaterno;
                        datospafi.horario = a.Horario;
                        datospafi.clave = b.ClaveSalon;
                        datospafi.salon = b.Edificio;
                        datospafi.idperiodo = d.IdPeriodo;
                        listpafi.Add(datospafi);
                        datospafi = new AlumnoPafi();

                    }
                    ViewData["pafi"] = listpafi;
                }
                

                return View();
            }

        }
        [Authorize]
        [HttpGet]
        public IActionResult DetallesExamen(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            if (id == 0)
            {
                id = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            ViewData["alumno"] = id;
            
            using (sgcfieeContext context = new sgcfieeContext())
            {
                List<TbExamenalumno> examen = new List<TbExamenalumno>();
                List<AlumnoExamen> listexamen = new List<AlumnoExamen>();
                AlumnoExamen datosexamen = new AlumnoExamen();
                
                examen = context.TbExamenalumno.Where(s => s.IdAlumno == id).ToList();
                if (examen != null)
                {
                    foreach (var item in examen)
                    {
                        var a = context.TbRubrosexamenes.Where(s => s.IdTbRubrosExamenes == item.IdRubroExamen).FirstOrDefault();
                        //datosexamen.tipoexa = item.TipoExamen;
                        datosexamen.calificacion = item.CalificacionExamen;
                        datosexamen.rubroexamen = a.RubroExamen;
                        datosexamen.tipoexa = a.TipoExamen;
                        listexamen.Add(datosexamen);
                        datosexamen = new AlumnoExamen();
                    }
                    ViewData["examen"] = listexamen;
                }

                return View();
            }

        }
        [Authorize]
        [HttpGet]
        public IActionResult DetallesEventos(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            if (id == 0)
            {
                id = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            ViewData["alumno"] = id;
            
            using (sgcfieeContext context = new sgcfieeContext())
            {
                
                List<EventosAlumnos> evento = new List<EventosAlumnos>();
                List<AlumnoEvento> listevento = new List<AlumnoEvento>();
                AlumnoEvento datoseve = new AlumnoEvento();
               
                
                evento = context.EventosAlumnos.Where(s => s.RAlumno == id).ToList();
                if (evento != null)
                {
                    foreach (var item in evento)
                    {
                        var a = context.TbEventos.Where(s => s.IdEventos == item.REvento).FirstOrDefault();
                        var b = context.TipoEventos.Where(s => s.IdEventos == a.RTioEvento).FirstOrDefault();
                        datoseve.nombreeve = a.Nombre;
                        datoseve.fecha = item.Fecha.ToString();
                        datoseve.tipoeve = b.Nombre;
                        listevento.Add(datoseve);
                        datoseve = new AlumnoEvento();
                    }
                    ViewData["evento"] = listevento;
                }
                

                return View();
            }

        }
        [Authorize]
        [HttpGet]
        public IActionResult DetallesMovilidad(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            if (id == 0)
            {
                id = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            ViewData["alumno"] = id;
            CompletoAlumnos datosalumno = new CompletoAlumnos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.TipoPeriodo.ToList();
                ViewData["periodo"] = x;
                
                List<TbMovilidad> movi = new List<TbMovilidad>();
                List<AlumnoMovilidad> listmovi = new List<AlumnoMovilidad>();
                AlumnoMovilidad datosmovi = new AlumnoMovilidad();
                
                
                movi = context.TbMovilidad.Where(s => s.RAlumno == id).ToList();
                if (movi != null)
                {
                    foreach (var item in movi)
                    {
                        var a = context.CtMovilidades.Where(s => s.IdCtMovilidades == item.RMovilidad).FirstOrDefault();
                        datosmovi.tipomovi = a.TipoMovilidades;
                        datosmovi.paisdestino = a.PaisDestinoMovilidad;
                        datosmovi.entidaddestino = a.EntidadDestinoMovilidad;
                        datosmovi.escueladestino = a.EscuelaDestinoMovilidad;
                        datosmovi.tiempoperma = a.TiempoPermanenciaMovilidad;
                        datosmovi.idperiodo = item.RPeriodo;
                        listmovi.Add(datosmovi);
                        datosmovi = new AlumnoMovilidad();

                    }
                    ViewData["movilidad"] = listmovi;
                }

                return View();
            }

        }
        [Authorize]
        [HttpGet]
        public IActionResult DetallesInstancias(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            if (id == 0)
            {
                id = (int)HttpContext.Session.GetInt32("IdUsu");
            }
            ViewData["alumno"] = id;
            CompletoAlumnos datosalumno = new CompletoAlumnos();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var alumno = context.Alumnos.Where(s => s.IdAlumnos == id).FirstOrDefault();
                var datos = context.DatosPersonales.Where(s => s.IdDatosPersonales == id).FirstOrDefault();
                var programa = context.ProgramaEducativo.Where(s => s.IdProgramaEducativo == alumno.RProgramaEducativo).FirstOrDefault();
                
                List<TbInstanciafinalAlumno> instancia = new List<TbInstanciafinalAlumno>();
                List<AlumnoFinal2> listfinal = new List<AlumnoFinal2>();
                AlumnoFinal2 datosfinal = new AlumnoFinal2();
                
                instancia = context.TbInstanciafinalAlumno.Where(s => s.RAlumno == id).ToList();
                if (instancia != null)
                {
                    foreach (var item in instancia)
                    {
                        if (item.RServPrac != null)
                        {
                            var b = context.TbServiciopracticas.Where(s => s.IdTbServicioPracticas == item.RServPrac).FirstOrDefault();
                            if (b.REmpresa != null)
                            {
                                var c = context.CtEmpresaServPrac.Where(s => s.IdCtEmpresas == b.REmpresa).FirstOrDefault();

                                string fechainicio = b.FechaInicio.ToString();
                                string[] resultadoinicio = fechainicio.Split(' ');

                                string fechafin = b.FechaInicio.ToString();
                                string[] resultadofin = fechafin.Split(' ');

                                datosfinal.fechainiserv = resultadoinicio;
                                datosfinal.fechafinserv = resultadofin;
                                datosfinal.nombreempresa = c.Nombre;
                                datosfinal.direccion = c.Direccion;
                                datosfinal.tiposervprac = b.Tipo;
                                datosfinal.telefono = c.Telefono;
                                listfinal.Add(datosfinal);
                                datosfinal = new AlumnoFinal2();
                            }
                        }
                        if (item.RExpRep != null)
                        {
                            var a = context.CtExperienciarecepcional.Where(s => s.IdCtExperienciaRecepcional == item.RExpRep).FirstOrDefault();
                            if (a.RAsesor != null)
                            {
                                var d = context.Academicos.Where(s => s.IdAcademicos == a.RAsesor).FirstOrDefault();

                                string fechafin = a.FechaFin.ToString();
                                string[] resultadofin = fechafin.Split(' ');

                                datosfinal.nombreexpre = a.Nombre;
                                datosfinal.fechafinexp = resultadofin;
                                datosfinal.tipoexpre = a.Tipo;
                                datosfinal.rexprep = item.RExpRep;
                                if (d != null) datosfinal.nombreasesor = d.Nombre;
                                listfinal.Add(datosfinal);
                                datosfinal = new AlumnoFinal2();
                            }
                        }
                    }
                    ViewData["Instancias"] = listfinal;
                }

                datosalumno.IdDatosPersonales = id;
                datosalumno.Nombre = datos.Nombre;
                datosalumno.ApellidoPaterno = datos.ApellidoPaterno;
                datosalumno.ApellidoMaterno = datos.ApellidoMaterno;
                datosalumno.Correo = datos.Correo;
                datosalumno.Matricula = alumno.Matricula;
                
                datosalumno.Nombrepro = programa.Nombre;

                return View(datosalumno);
            }

        }



        [Authorize]
        [HttpGet]
        public IActionResult CrearCali(int idalum)
        {
            int id = (int)HttpContext.Session.GetInt32("IdUsu");
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                
                
                ViewData["idalumno"] = idalum;
                return View();
            }

        }

        
        [HttpGet]
        public IActionResult Informacion()
        {
            
            int id = (int)HttpContext.Session.GetInt32("IdUsu");
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
            //using (sgcfieeContext context = new sgcfieeContext())
            //{
            //    var EE = context.ExperienciaEducativaPeriodo.Where(n => n.Nrc == nrc).Single();
                
            //    if(EE != null)
            //    {
            //        ModeloMCadd lista = (from z in context.ExperienciaEducativaPeriodo
            //                            join acad in context.Academicos on z.IdAcademico equals acad.IdAcademicos
            //                            join per in context.TipoPeriodo on z.IdPeriodo equals per.IdPeriodo
            //                            join sal in context.TbSalones on z.IdSalon equals sal.IdTbSalones
            //                            join mapa in context.MapaCurricular on z.IdMapaCurricular equals mapa.IdMapaCurricular
            //                            join Expe in context.ExperienciaEducativa on mapa.IdExperienciaEducativa equals Expe.IdExperienciaEducativa
            //                            select
            //                            new ModeloMCadd
            //                            {
            //                                IdExpericiaEducPerio = z.IdExperienciaEducativaPeriodo,
            //                                Nrc = z.Nrc,
            //                                Maestro = acad.Nombre + " " + acad.ApellidoPaterno + " " + acad.ApellidoMaterno,
            //                                Periodo = per.Nombre,
            //                                Salon = sal.Edificio + "-" + sal.ClaveSalon,
            //                                Experiencia = Expe.Nombre
            //                            }).Where(n=> n.Nrc == nrc).Single();
            //        ViewData["info"] = lista;
            //        ViewData["idalumno"] = idalumno;
                    
            //    }
            //    else
            //    {
            //        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "El NRC no existe!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
            //        return RedirectToAction("CrearCali", new { idalum = idalumno });
            //    }
                
            //}
            
            //return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CrearCali(CalificacionAlumno calialum)
        //{
        //    ExperienciaEducativaPeriodo experienciaperiodo = new ExperienciaEducativaPeriodo();
        //    TbCalificacion calificacion = new TbCalificacion();
        //    TbHorario horario = new TbHorario();
        //    using (sgcfieeContext context = new sgcfieeContext())
        //    {
        //        calificacion.RTipoCalificacion = calialum.RTipoCalificacion;
        //        calificacion.Calificacion = calialum.Calificacion;
        //        context.TbCalificacion.Add(calificacion);
        //        context.SaveChanges();

        //        experienciaperiodo.Nrc = calialum.Nrc;
        //        experienciaperiodo.IdPeriodo = calialum.IdPeriodo;
        //        experienciaperiodo.IdAcademico = calialum.IdAcademico;
        //        experienciaperiodo.IdSalon = calialum.IdSalon;
        //        experienciaperiodo.CalificacionAcademico = calialum.Calificacion;
        //        experienciaperiodo.IdMapaCurricular = calialum.IdMapaCurricular;
        //        context.ExperienciaEducativaPeriodo.Add(experienciaperiodo);
        //        context.SaveChanges();

        //        horario.RExperienciaPeriodo = experienciaperiodo.IdExperienciaEducativaPeriodo;
        //        horario.RAlumno = calialum.idalumno;
        //        horario.Calificacion = calialum.Calificacion;
        //        //horario.RSalon = calialum.IdSalon;
        //        horario.RTipoCalif = calialum.RTipoCalificacion;
        //        context.TbHorario.Add(horario);
        //        context.SaveChanges();
        //        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";

        //        return RedirectToAction("DetallesBoleta",new { id = calialum.idalumno });
        //    }
        //}
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var alum = context.Alumnos.Where<Alumnos>(p => p.IdAlumnos == id).Single<Alumnos>();
                if (alum == null) return NotFound();
                alum.RStatus = 2;
                context.Alumnos.Update(alum);
                context.SaveChanges();
                TempData["Mensaje"] = "Dato eliminado";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult CrearFinal(int idalum)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var x = context.Academicos.ToList();
                var y = context.CtEmpresaServPrac.ToList();
                ViewData["academicos"] = x;
                ViewData["idalumno"] = idalum;
                ViewData["empresa"] = y;
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearServicio(AlumnoFinal final)
        {
            TbInstanciafinalAlumno instancia = new TbInstanciafinalAlumno();
            TbServiciopracticas servprac = new TbServiciopracticas();

            using (sgcfieeContext context = new sgcfieeContext())
            {
                var insta = context.TbInstanciafinalAlumno.ToList();
                
                foreach (TbInstanciafinalAlumno item in insta)
                {
                    if (item.RAlumno == final.ralumno)
                    {
                        var serprac = context.TbServiciopracticas.Where(x => x.IdTbServicioPracticas == item.RServPrac).ToList();
                        foreach (TbServiciopracticas item2 in serprac)
                        {
                            if (item2.Tipo == final.tiposervprac)
                            {
                                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                                return RedirectToAction("DetallesInstancias", new { id = final.ralumno });
                            }
                        }
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                servprac.FechaInicio = final.fechainiserv;
                servprac.FechaFin = final.fechafinserv;
                servprac.REmpresa = final.rempresa;
                servprac.Tipo = final.tiposervprac;
                context.TbServiciopracticas.Add(servprac);
                context.SaveChanges();
                TempData["mensaje"] = "Dato guardado";
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                TbServiciopracticas ultimo = context.TbServiciopracticas.Last();

                instancia.RAlumno = final.ralumno;
                instancia.RServPrac = ultimo.IdTbServicioPracticas;
                context.TbInstanciafinalAlumno.Add(instancia);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";

                return RedirectToAction("DetallesInstancias",new { id = final.ralumno });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearExprecpcional(AlumnoFinal exprecepcional)
        {
            TbInstanciafinalAlumno instancia = new TbInstanciafinalAlumno();
            CtExperienciarecepcional experiencia = new CtExperienciarecepcional();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var insta = context.TbInstanciafinalAlumno.ToList();

                foreach (TbInstanciafinalAlumno item in insta)
                {
                    if (item.RAlumno == exprecepcional.ralumno && item.RExpRep != null)
                    {
                        
                            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                            return RedirectToAction("DetallesInstancias", new { id = exprecepcional.ralumno });
                           
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                experiencia.Nombre = exprecepcional.nombreexpre;
                experiencia.FechaFin = exprecepcional.fechafinexp;
                experiencia.Tipo = exprecepcional.tipoexpre;
                experiencia.RAsesor = exprecepcional.rasesor;
                context.CtExperienciarecepcional.Add(experiencia);
                context.SaveChanges();
                TempData["Mnesjae"] = "Dato guardado";
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                CtExperienciarecepcional ultimo = context.CtExperienciarecepcional.Last();

                instancia.RAlumno = exprecepcional.ralumno;
                instancia.RExpRep = ultimo.IdCtExperienciaRecepcional;
                context.TbInstanciafinalAlumno.Add(instancia);
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";


                return RedirectToAction("DetallesInstancias", new { id = exprecepcional.ralumno });
            }
        }
        [HttpGet]
        public IActionResult CrearEmpresa(int idalum)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            ViewData["idalumno"] = idalum;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearEmpresa(CtEmpresaServPrac empresa, int idalum)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var emp = context.CtEmpresaServPrac.ToList();
                foreach (CtEmpresaServPrac item in emp)
                {
                    if(item.Nombre == empresa.Nombre && item.Direccion == empresa.Direccion)
                    {
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("CrearFinal", new { idalum = idalum });
                    }
                }
            }
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtEmpresaServPrac.Add(empresa);
                context.SaveChanges();

                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
                return RedirectToAction("CrearFinal", new { idalum = idalum });
            }
        }
        [HttpGet]
        public IActionResult CrearReporte([FromQuery] int idalum)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            ViewData["idalumno"] = idalum;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void EnviarCorreo(String asunto, String correo, String cuenta, String contrasena)
        {
            try
            {
                to = correo;
                m.From = new MailAddress(from, "SGCFIEE");
                m.To.Add(new MailAddress(to));
                m.Subject = asunto;
                m.BodyEncoding = System.Text.Encoding.UTF8;
                m.Body = "Cuenta: " + cuenta + "\r\nContraseña: " + contrasena;
                m.IsBodyHtml = true;
                smtp.Host = "smtp.gmail.com";
                smtp.UseDefaultCredentials = true;
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(from, pass);
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}