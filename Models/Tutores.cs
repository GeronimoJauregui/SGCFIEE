using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Tutores
    {
        public int IdTutores { get; set; }
        public int? IdAcademicos { get; set; }
        public int? IdAlumno { get; set; }
        public int? Status { get; set; }

        public virtual Academicos IdAcademicosNavigation { get; set; }
        public virtual Alumnos IdAlumnoNavigation { get; set; }
    }
}
