using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TbCalificacionTutor
    {
        public int IdTbCalificacionTutor { get; set; }
        public int? RPeriodo { get; set; }
        public float? Calificacion { get; set; }
        public int? RAcademicos { get; set; }

        public virtual Academicos RAcademicosNavigation { get; set; }
        public virtual TipoPeriodo RPeriodoNavigation { get; set; }
    }
}
