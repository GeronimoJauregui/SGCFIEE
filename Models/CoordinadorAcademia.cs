using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CoordinadorAcademia
    {
        public int IdCoordinadorAcademia { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdAcadademia { get; set; }
        public string ArchivoActaA { get; set; }
        public int? IdFechaInicial { get; set; }
        public int? IdFechaCierre { get; set; }

        public virtual Academias IdAcadademiaNavigation { get; set; }
        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoPeriodo IdFechaCierreNavigation { get; set; }
        public virtual TipoPeriodo IdFechaInicialNavigation { get; set; }
    }
}
