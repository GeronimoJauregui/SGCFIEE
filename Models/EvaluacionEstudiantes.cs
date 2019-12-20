using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class EvaluacionEstudiantes
    {
        public int IdEvaluacionEstudiantes { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdPeriodo { get; set; }
        public float? Calificacion { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoPeriodo IdPeriodoNavigation { get; set; }
    }
}
