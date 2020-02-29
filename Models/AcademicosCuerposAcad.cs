using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academicoscuerposacad
    {
        public int IdAcademicosCuerposAcad { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdCuerpoAcad { get; set; }
        public int? Lider { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual CaAcademicos IdCuerpoAcadNavigation { get; set; }
    }
}
