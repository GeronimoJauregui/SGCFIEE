using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class ConsejoTecnico
    {
        public int IdConsejoTecnico { get; set; }
        public int? IdAcademico { get; set; }
        public string ArchivoActaA { get; set; }
        public int? IdFechaInicial { get; set; }
        public int? IdFechaCierre { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoPeriodo IdFechaCierreNavigation { get; set; }
        public virtual TipoPeriodo IdFechaInicialNavigation { get; set; }
    }
}
