using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CaAlumnos
    {
        public int IdCa { get; set; }
        public int? IdAlumno { get; set; }
        public int? IdCanivelJerarquico { get; set; }
        public int? IdCuerpoAcademico { get; set; }

        public virtual Alumnos IdAlumnoNavigation { get; set; }
        public virtual CanivelJerarquico IdCanivelJerarquicoNavigation { get; set; }
        public virtual CuerposAcademicos IdCuerpoAcademicoNavigation { get; set; }
    }
}
