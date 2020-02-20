using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class EvaluadoresAcademicos
    {
        public int IdEvaluadoresAcademicos { get; set; }
        public int? IdAcademicos { get; set; }
        public int? IdTipoEvaluador { get; set; }
        public int? RevisorEvaluador { get; set; }
        public int? Status { get; set; }
        public string Archivo { get; set; }

        public virtual Academicos IdAcademicosNavigation { get; set; }
        public virtual TipoEvaluador IdTipoEvaluadorNavigation { get; set; }
    }
}
