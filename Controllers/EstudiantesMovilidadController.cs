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
    public class EstudiantesMovilidadController : Controller
    {
        // GET: EstudiantesMovilidad
        [Authorize]
        //Función para acceder a la vista que muestra los lugares que hay de movilidad en la universidad.
        public ActionResult Index(int tipo)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Se consulta los lugares de movilidad segun el tipo(nacional/internacional).
                var movilidades = context.CtMovilidades.Where(s => s.TipoMovilidades.Equals(tipo)).ToList();
                //Envio de datos a la vista por medio del diccionario ViewData.
                ViewData["Movilidades"] = movilidades;
                ViewData["tipoMovi"] = tipo;
            }
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }


        [Authorize]
        //Función que muestra la vista principal del submenu movilidad.
        //En esta vista se muestran los dos tipos de movilidad (nacional/internacional).
        public IActionResult EleccionMovilidades()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }


        // GET: EstudiantesMovilidad/Edit/5
        [Authorize]
        //Función para acceder a la vista de edición de la información de los datos de movilidad.
        public IActionResult Editar(int id, int tipo)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            CtMovilidades datosMovi;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                datosMovi = context.CtMovilidades.Where(d => d.IdCtMovilidades == id).Single(); //Consulta para obtener los datos de la movilidad a modificar.
                ViewData["tipoMovi"] = tipo;
            }
            return View(datosMovi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Función para guardar los datos obtenidos en la vista de edición.
        public IActionResult GuardarEdicion(CtMovilidades movilidades, int tipo)
        {
            using (sgcfieeContext context = new sgcfieeContext())
            {
                context.CtMovilidades.Update(movilidades); //Guardado de datos.
                context.SaveChanges();
                TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Actualizado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            }
            return RedirectToAction("Index", new { tipo = tipo});
        }

        [Authorize]
        
        //Función que muestra un select para empezar a inscribir a un alumno en una movilidad, empezando por seleccionar el periodo.
        public IActionResult FormInscribir(int id, int tipo)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                var y = context.ProgramaEducativo.ToList(); //Obtención de los programas educativos.
                //Envio de datos a la vista por modio del diccionario ViewData.
                ViewData["clv"] = id; //id de la movilidad escogida.
                ViewData["Programas"] = y; //lista de los programas educativos.
                ViewData["tipoMovi"] = tipo; //id del tipo de movilidad.
            }
            return View();
        }

        [Authorize]
        //Función que muestra los alumnos que pertenecen al programa educativo seleccionado de la vista FormInscribir.
        public IActionResult MostrarListaAlumnos(FormInscribirMovilidad movi, int tipo)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int x = movi.idMovilidad;
            int progra = movi.idAlumno;
            List<TablaAlumno> tb = new List<TablaAlumno>();
            List<ProgramaEducativo> y = new List<ProgramaEducativo>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Consulta para obtener los datos de todos los alumnos registrados en el sistema.
                tb = (from d in context.DatosPersonales
                      join a in context.Alumnos on d.IdDatosPersonales equals a.RDatosPerson
                      join p in context.ProgramaEducativo on a.RProgramaEducativo equals p.IdProgramaEducativo
                      select
                      new TablaAlumno
                      {
                          id = a.IdAlumnos,
                          Nombre = d.Nombre,
                          ApellidoPaterno = d.ApellidoPaterno,
                          ApellidoMaterno = d.ApellidoMaterno,
                          Matricula = a.Matricula,
                          NombrePro = p.Nombre
                      }).ToList();
                y = context.ProgramaEducativo.ToList(); //Obtención de los programas educativos.
                ViewData["clv"] = x;
                ViewData["Programas"] = y;
                ViewData["tipoMovi"] = tipo;
            }
            String nombrePe = "";
            //Ciclo para encontrar el programa educativo seleccionado anteriormente.
            foreach (ProgramaEducativo pe in y)
            {
                if (progra == pe.IdProgramaEducativo)
                {
                    nombrePe = pe.Nombre;
                }
            }
            //Ciclo para obtener a los alumnos pertenecientes al programa educativo.
            List<TablaAlumno> correcto = new List<TablaAlumno>();
            foreach (TablaAlumno t in tb)
            {
                if (t.NombrePro.Equals(nombrePe))
                {
                    correcto.Add(t);
                }
            }
            ViewData["Alumnos"] = correcto;
            return View();
        }

        [Authorize]
        //Función para acceder a la vista donde se muestran todos los datos ha guardar, seleccionar el periodo y confirmar la inscripción del alumno a la movilidad.
        public IActionResult MostrarInformacionInscripcion(FormInscribirMovilidad movi, int tipo)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            int movilidad = movi.idMovilidad;
            int alumno = movi.idAlumno;
            DatosPersonales dp;
            CtMovilidades mov;
            Alumnos alu;
            FormInscribirMovilidad formulario = new FormInscribirMovilidad();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Obtención de los datos (información del alumno, Lugar de movilidad y periodo).
                dp = context.DatosPersonales.Where(s => s.IdDatosPersonales == alumno).SingleOrDefault();
                mov = context.CtMovilidades.Where(m => m.IdCtMovilidades == movilidad).SingleOrDefault();
                alu = context.Alumnos.Where(a => a.IdAlumnos == alumno).SingleOrDefault();
                var periodo = context.TipoPeriodo.ToList();
                ViewData["periodo"] = periodo;
            }
            formulario.NombreAlumno = dp.Nombre + " " + dp.ApellidoPaterno + " " + dp.ApellidoMaterno;
            formulario.idAlumno = alumno;
            formulario.idMovilidad = movilidad;
            //Envio de datos a la vista.
            ViewData["dtMovi"] = mov;
            ViewData["dtPAlu"] = dp;
            ViewData["dtEAlu"] = alu;
            ViewData["dt"] = formulario;
            ViewData["tipoMovi"] = tipo;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Función para guardar al alumno en la movilidad seleccionada.
        public IActionResult GuardarInscripcion(FormInscribirMovilidad formovi, int tipo)
        {
            //Paso de información a sus campos correspondientes.
            TbMovilidad tb = new TbMovilidad();
            tb.RAlumno = formovi.idAlumno;
            tb.RMovilidad = formovi.idMovilidad;
            tb.RPeriodo = formovi.idPeriodo;
            List<TbMovilidad> datosmovilidad = new List<TbMovilidad>();
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Ahora se verifica que la información a guardar no se encuentre ya registrada en la tabla "TbMovilidad".
                datosmovilidad = context.TbMovilidad.ToList(); //Se obtienen los registros de la tabla.
                foreach (TbMovilidad item in datosmovilidad)
                {
                    if (item.RAlumno == formovi.idAlumno && item.RMovilidad == formovi.idMovilidad && item.RPeriodo==formovi.idPeriodo)
                    {
                        //Se comparan los datos ha guardar con cada registro obtenido anteriormente. Si se comple la condición, se redireccionara al index y no se guardaran los datos.
                        TempData["msg"] = "<script language='javascript'> swal({ title:'" + "La información ya se encuentra registrada!" + "', timer:'" + "3500" + "',type: '" + "info" + "', showConfirmButton: false })" + "</script>";
                        return RedirectToAction("Index",new { tipo = tipo});
                    }
                }
                context.TbMovilidad.Add(tb); //Guardado de la información.
                context.SaveChanges();
            }
            TempData["msg"] = "<script language='javascript'> swal({ title:'" + "Guardado exitosamente!" + "', timer:'" + "2000" + "',type: '" + "success" + "', showConfirmButton: false })" + "</script>";
            return RedirectToAction("Index", new { tipo = tipo });
        }

        [Authorize]
        //Función a la cual, solo el usuario alumno puede acceder, muestra el estado de avance para poder tener acceso a movilidad.
        public IActionResult ConsultarEstatus()
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            List<Calificaciones_Alumno_Movilidad> cam;
            int idAlumno = (int)HttpContext.Session.GetInt32("IdUsu"); //idAlumno guarda al ID del usuario segun la tabla de usuario de la base de datos.
            //int idAlumno = 1;
            ProgramaEducativo pe;
            Alumnos alu;
            using (sgcfieeContext context = new sgcfieeContext())
            {
                //Función que muestra las calificaciones de cada Experiencia Educativa con respecto al usuario que este consultando.
                cam = (from ex in context.ExperienciaEducativaPeriodo
                       join mc in context.MapaCurricular
                       on ex.IdMapaCurricular equals mc.IdMapaCurricular
                       join ee in context.ExperienciaEducativa
                       on mc.IdExperienciaEducativa equals ee.IdExperienciaEducativa
                       join t in context.TbHorario
                       on ex.IdExperienciaEducativaPeriodo equals t.RExperienciaPeriodo
                       join ca in context.TbCalificacion
                       on t.RTipoCalif equals ca.IdTbCalificacion
                       select
                       new Calificaciones_Alumno_Movilidad
                       {
                           calificacion = ca.Calificacion.Value,
                           creditos = ee.Creditos.Value,
                           idAlu = t.RAlumno.Value,
                           NombreMateria = ee.Nombre
                       }).Where(s => s.calificacion > 5 && s.idAlu == idAlumno).ToList();
                alu = context.Alumnos.Where(a => a.IdAlumnos == idAlumno).Single();
                pe = context.ProgramaEducativo.Where(b => b.IdProgramaEducativo == alu.RProgramaEducativo.Value).Single();
            }
            //Sumatoria de los creditos cursados.
            int suma = 0;
            foreach (Calificaciones_Alumno_Movilidad calif in cam)
            {
                suma = suma + calif.creditos;
            }
            //Divición de los creditos totales del programa educativo.
            int total = pe.Creditos.Value / 2;
            //Mensaje que se mostrara al usuario segun la condición que se cumpla.
            if (suma >= total)
            {
                ViewData["consejo"] = "El total de tus creditos: " + suma + " supera a la mitad de los creditos de tu carrera, ve con tu tutor a checar tus opciones\nTotal de creditos necesarios: " + total;
            }
            else
            {
                ViewData["consejo"] = "El total de tus creditos: " + suma + " no supera a la mitad de los creditos de tu carrera, te recomendamos checar en futuros periodos\nTotal de creditos necesarios: " + total;
            }
            return View(cam);
        }
    }
}