using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class ReportesTecnicos
    {
        public ReportesTecnicos()
        {
            AcademicoReportesT = new HashSet<AcademicoReportesT>();
        }

        public int IdReportesTecnicos { get; set; }
        public int? LugarEmpresaSector { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }

        public virtual ICollection<AcademicoReportesT> AcademicoReportesT { get; set; }
    }
}
