using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Pagos
    {
        public int IdPagos { get; set; }
        public float? Monto { get; set; }
        public int? RAcademicos { get; set; }
        public DateTime? InicioQuincena { get; set; }
        public DateTime? FinQuincena { get; set; }

        public virtual Academicos RAcademicosNavigation { get; set; }
    }
}
