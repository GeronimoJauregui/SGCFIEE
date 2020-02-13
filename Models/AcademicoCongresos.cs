using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class AcademicoCongresos
    {
        public int IdAcademicoCongresos { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdCongreso { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual Congresos IdCongresoNavigation { get; set; }
    }
}
