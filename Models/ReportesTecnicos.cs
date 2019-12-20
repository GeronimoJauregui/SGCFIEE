using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class ReportesTecnicos
    {
        public int IdReportesTecnicos { get; set; }
        public int? LugarEmpresaSector { get; set; }
        public int? IdAcademico { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
    }
}
