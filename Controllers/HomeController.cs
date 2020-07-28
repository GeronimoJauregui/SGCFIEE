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
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Principal(SGCFIEE.Models.UsuarioLogin user)
        {
            String usuario = user.matricula.ToLower();
            if (usuario.Equals("administrador"))
            {
                using(sgcfieeContext context = new sgcfieeContext())
                {
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

                    String p = string.Concat("15344", "POBL660419");
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
            var x = 2;
            Usuarios usu = new Usuarios();
            String pass = string.Concat(user.matricula.ToLower(), user.password);
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] input = (new UnicodeEncoding()).GetBytes(pass);
            byte[] hash = sha1.ComputeHash(input);
            string passwo = Convert.ToBase64String(hash);
            string contra = user.password;
            user.password = passwo;
            using(sgcfieeContext context = new sgcfieeContext())
            {
                usu = context.Usuarios.Where(e => e.Nombre.Equals(user.matricula) && e.Contrasenia.Equals(user.password)).SingleOrDefault();
                if (usu != null)
                {
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
                HttpContext.Session.SetString("Matricula", usu.Nombre);
                HttpContext.Session.SetInt32("TipoUsuario", usu.Tipo);
                if(usu.Tipo == 3)
                {
                    HttpContext.Session.SetInt32 ("IdUsu", usu.IdAlumno.Value);
                    using (sgcfieeContext context = new sgcfieeContext())
                    {
                        Alumnos alum = context.Alumnos.Where(w => w.IdAlumnos == usu.IdAlumno).Single();
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
                        {
                            return RedirectToAction("CambioContraseña", new { id = usu.IdUsuario });
                        }

                    }
                }
                else
                {
                    HttpContext.Session.SetInt32("IdUsu", usu.IdAcademico.Value);
                    using (sgcfieeContext context = new sgcfieeContext())
                    {
                        Academicos aca = context.Academicos.Where(w => w.IdAcademicos == usu.IdAcademico).Single();
                        string subcurp;
                        if (aca.Curp == null){
                            subcurp = aca.Curp;
                        }
                        else {
                            subcurp = aca.Curp.Substring(0, 10);
                        }
                        if (subcurp == contra) {
                            return RedirectToAction("CambioContraseña", new {id = usu.IdUsuario });
                        }

                    }
                }

                return RedirectToAction("Default");
            }
            else
            {
                return RedirectToAction("Index");
            }
            //return View();
        }

        public IActionResult Default()
        {   
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            return View();
        }

        public IActionResult CambioContraseña(int id)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                Usuarios usu = context.Usuarios.Where(e => e.IdUsuario == id).Single();
                return View(usu);
            }
            
        }

        public IActionResult actualizarcontrasenia(Usuarios usu)
        {
            ViewData["tipo"] = (int)HttpContext.Session.GetInt32("TipoUsuario");
            using (sgcfieeContext context = new sgcfieeContext())
            {
                String p = string.Concat(usu.Nombre, usu.Contrasenia);
                SHA1 sha = new SHA1CryptoServiceProvider();
                byte[] input2 = (new UnicodeEncoding()).GetBytes(p);
                byte[] h = sha.ComputeHash(input2);
                string pa = Convert.ToBase64String(h);
                usu.Contrasenia = pa;
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

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("PKAT");
            HttpContext.Session.Remove("Matricula");
            HttpContext.Session.Remove("TipoUsuario");
            HttpContext.Session.Remove("IdUsu");
            return RedirectToAction("Index");

        }
    }
}
