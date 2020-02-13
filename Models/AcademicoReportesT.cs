using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class AcademicoReportesT
    {
        public int IdAcademicoReportesT { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdReportesTec { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual ReportesTecnicos IdReportesTecNavigation { get; set; }
    }
}
