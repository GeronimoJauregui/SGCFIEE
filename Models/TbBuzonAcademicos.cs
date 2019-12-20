using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TbBuzonAcademicos
    {
        public int IdBuzonAcademicos { get; set; }
        public int RAlumno { get; set; }
        public int RAcademicos { get; set; }
        public int RPeriodo { get; set; }
        public string Propuesta { get; set; }
        public string Sugerencia { get; set; }

        public virtual Academicos RAcademicosNavigation { get; set; }
        public virtual Alumnos RAlumnoNavigation { get; set; }
        public virtual TipoPeriodo RPeriodoNavigation { get; set; }
    }
}
