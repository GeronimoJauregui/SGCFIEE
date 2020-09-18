using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SGCFIEE.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace SGCFIEE.Controllers
{
    public class HomeController : Controller
    {
        // en este controlador verificamos las credenciales para el login, cambio de contraseña y creación del primer usuario
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Principal(SGCFIEE.Models.UsuarioLogin user)
        {   // passamos a minusculas todos los caracteres de la matricula
            String usuario = user.matricula.ToLower();
            // aqui creamos al usuario director el cual tiene acceso a todo el sistema
            if (usuario.Equals("administrador"))
            {
                using(sgcfieeContext context = new sgcfieeContext())
                {   // creamos los registros necesarios para este primer usuario
                    TipoPersonal tp = new TipoPersonal();
                    tp.Nombre = "Profesor de Tiempo Completo (PTC)";
                    context.TipoPersonal.Add(tp);
                    context.SaveChanges();
                    TipoPersonal tp2 = context.TipoPersonal.Last();
                    int tipoPer = tp2.IdTipoPersonal;
                    ProgramaEducativo pe = new ProgramaEducativo();
                    pe.Nombre = "Ingeniería Informática";
                    context.ProgramaEducativo.Add(pe);
                    context.SaveChanges();
                    ProgramaEducativo pe2 = context.ProgramaEducativo.Last();
                    int ProEdu = pe2.IdProgramaEducativo;
                    Academicos aca = new Academicos();
                    aca.IdProgramaEducativo = ProEdu;
                    aca.RTipoPersonal = tipoPer;
                    aca.Nombre = "LUIS HECTOR";
                    aca.ApellidoPaterno = "PORRAGAS";
                    aca.ApellidoMaterno = "BELTRAN";
                    // la CURP siempre debe ser en mayuscula
                    aca.Curp = "POBL660419HVZRLS02";
                    context.Academicos.Add(aca);
                    context.SaveChanges();
                    Academicos aca2 = context.Academicos.Last();
                    int idUsu = aca2.IdAcademicos;
                    ContratacionPtc Cptc = new ContratacionPtc();
                    Cptc.IdAcademico = idUsu;
                    context.ContratacionPtc.Add(Cptc);
                    context.SaveChanges();
                    Usuarios usunuevo = new Usuarios();
                    usunuevo.IdAcademico = idUsu;
                    usunuevo.Nombre = "15344";
                    usunuevo.Tipo = 1;
                    // la contraseña default es la concatenacion del usuario y los primeros 10 digitos de la CURP
                    String p = string.Concat("15344", "POBL660419");
                    // se encripta la contraseña
                    SHA1 sha = new SHA1CryptoServiceProvider();
                    byte[] input2 = (new UnicodeEncoding()).GetBytes(p);
                    byte[] h = sha.ComputeHash(input2);
                    string pa = Convert.ToBase64String(h);
                    usunuevo.Contrasenia = pa;
                    context.Usuarios.Add(usunuevo);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            // esta variable es una bandera para permitir el acceso al sistema 
            // 1 = si, 2 = no
            var x = 2;
            Usuarios usu = new Usuarios();
            //hacemos el proceso de encriptación de la contraseña proporcionada
            String pass = string.Concat(user.matricula.ToLower(), user.password);
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] input = (new UnicodeEncoding()).GetBytes(pass);
            byte[] hash = sha1.ComputeHash(input);
            string passwo = Convert.ToBase64String(hash);
            string contra = user.password;
            // reasignamos la contraseña ya encriptada a las credenciales que nos dio el usuario
            user.password = passwo;
            using(sgcfieeContext context = new sgcfieeContext())
            {   // buscamos al usuario en la db y verificamos que las credenciales sean correectas
                usu = context.Usuarios.Where(e => e.Nombre.Equals(user.matricula) && e.Contrasenia.Equals(user.password)).SingleOrDefault();
                if (usu != null)
                {  // si las credenciales son correctas damos acceso al sistema
                    x = 1;
                }
            }
            if (x == 1)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.matricula));
                var userIdentity = new ClaimsIdentity(claims, "login");
                var principal = new ClaimsPrincipal(userIdentity);
                HttpContext.SignInAsync("PKAT", principal);
                // asignamos variables de sesion que nos ayudan a distinguir entre usuarios 
                HttpContext.Session.SetString("Matricula", usu.Nombre);
                HttpContext.Session.SetInt32("TipoUsuario", usu.Tipo);
                // si se trata de un alumno
                if(usu.Tipo == 3)
                {
                    HttpContext.Session.SetInt32 ("IdUsu", usu.IdAlumno.Value);
                    using (sgcfieeContext context = new sgcfieeContext())
                    {
                        Alumnos alum = context.Alumnos.Where(w => w.IdAlumnos == usu.IdAlumno).Single();
                        // este proceso es para verificar que la contraseña no sea la asignada por el sistema (o sea que haya cambiado la contraseña el usuario)
                        DatosPersonales dp = context.DatosPersonales.Where(w => w.IdDatosPersonales == alum.RDatosPerson).Single();
                        string subcurp;
                        if (dp.Curp == null)
                        {
                            subcurp = alum.RDatosPersonNavigation.Curp;
                        }
                        else
                        {
                            subcurp = alum.RDatosPersonNavigation.Curp.Substring(0, 10);
                        }
                        if (subcurp == contra)
                        { // si el usuario sigue teniendo la contraseña default, lo redireccionamos a la vista de cambio de contraseña
                            return RedirectToAction("CambioContraseña", new { id = usu.IdUsuario });
                        }

                    }
                } // si se trata de un academico en general
                else
                {
                    HttpContext.Session.SetInt32("IdUsu", usu.IdAcademico.Value);
                    using (sgcfieeContext context = new sgcfieeContext())
                    { // este proceso es para verificar que la contraseña no sea la asignada por el sistema (o sea que haya cambiado la contraseña el usuario)
                        Academicos aca = context.Academicos.Where(w => w.IdAcademicos == usu.IdAcademico).Single();
                        string subcurp;
                        if (aca.Curp == null){
                            subcurp = aca.Curp;
                        }
                        else {
                            subcurp = aca.Curp.Substring(0, 10);
                        } // si el usuario sigue teniendo la contraseña default, lo redireccionamos a la vista de cambio de contraseña
                        if (subcurp == contra) {
                            return RedirectToAction("CambioContraseña", new {id = usu.IdUsuario });
                        }

                    }
                }
                // redireccionamos a la vista principal del sistema
                return RedirectToAction("Default");
            } // si las credenciales no fueron validas retornamos a la misma vista de login
            else
            {
                return RedirectToAction("Index");
            }
            //return View();
        }
        // vista principal del sistema
        public IActionResult Default()
        {   
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }
        // vista donde se le pide al usuario ingresar una nueva contraseña
        public IActionResult CambioContraseña(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Usuarios usu = context.Usuarios.Where(e => e.IdUsuario == id).Single();
                return View(usu);
            }
            
        }
        // guardar la nueva contraseña
        public IActionResult actualizarcontrasenia(Usuarios usu)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            { // proceso de encriptado de la nueva contraseña
                String p = string.Concat(usu.Nombre, usu.Contrasenia);
                SHA1 sha = new SHA1CryptoServiceProvider();
                byte[] input2 = (new UnicodeEncoding()).GetBytes(p);
                byte[] h = sha.ComputeHash(input2);
                string pa = Convert.ToBase64String(h);
                usu.Contrasenia = pa;
                //actualizamos datos
                context.Usuarios.Update(usu);
                context.SaveChanges();
            }
            
            return RedirectToAction("Default");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // cerrado de sesion
        public IActionResult Logout()
        {   // eliminamos las variables de sesion
            HttpContext.SignOutAsync("PKAT");
            HttpContext.Session.Remove("Matricula");
            HttpContext.Session.Remove("TipoUsuario");
            HttpContext.Session.Remove("IdUsu");
            return RedirectToAction("Index");

        }
    }
}
