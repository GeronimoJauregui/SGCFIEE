using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class RecursosExternos
    {
        public int IdRecursosExternos { get; set; }
        public int IdAcademicos { get; set; }
        public string Nombre { get; set; }
        public float? Ingreso { get; set; }
        public int? IdPeriodo { get; set; }

        public virtual Academicos IdAcademicosNavigation { get; set; }
        public virtual TipoPeriodo IdPeriodoNavigation { get; set; }
    }
}
