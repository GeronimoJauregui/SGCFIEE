using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoEvaluador
    {
        public TipoEvaluador()
        {
            EvaluadoresAcademicos = new HashSet<EvaluadoresAcademicos>();
        }

        public int IdTipoEvaluador { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<EvaluadoresAcademicos> EvaluadoresAcademicos { get; set; }
    }
}
