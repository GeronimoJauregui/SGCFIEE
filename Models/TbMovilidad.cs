using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TbMovilidad
    {
        public int IdTbMovilidad { get; set; }
        public int? RPeriodo { get; set; }
        public int? RAlumno { get; set; }
        public int? RMovilidad { get; set; }

        public virtual Alumnos RAlumnoNavigation { get; set; }
        public virtual CtMovilidades RMovilidadNavigation { get; set; }
        public virtual TipoPeriodo RPeriodoNavigation { get; set; }
    }
}
