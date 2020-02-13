using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CaAcademicos
    {
        public CaAcademicos()
        {
            AcademicosCuerposAcad = new HashSet<AcademicosCuerposAcad>();
        }

        public int IdCa { get; set; }
        public int? IdCanivelJerarquico { get; set; }
        public int? IdCuerpoAcademico { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? Status { get; set; }
        public string Archivo { get; set; }

        public virtual CanivelJerarquico IdCanivelJerarquicoNavigation { get; set; }
        public virtual CuerposAcademicos IdCuerpoAcademicoNavigation { get; set; }
        public virtual ICollection<AcademicosCuerposAcad> AcademicosCuerposAcad { get; set; }
    }
}
