using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdAlumno { get; set; }
        public int Tipo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual Alumnos IdAlumnoNavigation { get; set; }
    }
}
