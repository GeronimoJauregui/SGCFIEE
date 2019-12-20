using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class EvaluacionConsejoTecnico
    {
        public int IdConsejoTecnico { get; set; }
        public int? IdAcademico { get; set; }
        public float? CalificacionDesempenio { get; set; }
        public float? CalificacionGestion { get; set; }
        public int? IdPeriodo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoPeriodo IdPeriodoNavigation { get; set; }
    }
}
