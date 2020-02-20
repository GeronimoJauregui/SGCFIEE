using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CaAcademicos
    {
        public int IdCa { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdCanivelJerarquico { get; set; }
        public int? IdCuerpoAcademico { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? Status { get; set; }
        public string Archivo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual CanivelJerarquico IdCanivelJerarquicoNavigation { get; set; }
        public virtual CuerposAcademicos IdCuerpoAcademicoNavigation { get; set; }
    }
}
