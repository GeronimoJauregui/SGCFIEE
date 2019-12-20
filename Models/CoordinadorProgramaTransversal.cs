using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CoordinadorProgramaTransversal
    {
        public int IdCoordinadorProgramaTransversal { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdPt { get; set; }
        public int? IdFechaInicial { get; set; }
        public int? IdFechaCierre { get; set; }
        public string Evidencia { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoPeriodo IdFechaCierreNavigation { get; set; }
        public virtual TipoPeriodo IdFechaInicialNavigation { get; set; }
        public virtual ProgramasTrasversales IdPtNavigation { get; set; }
    }
}
