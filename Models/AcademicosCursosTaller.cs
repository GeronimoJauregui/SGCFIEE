using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academicoscursostaller
    {
        public int IdAcademicosCursosTaller { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdCursosDiplo { get; set; }
        public int? Lider { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual CursosTalleresAplicacion IdCursosDiploNavigation { get; set; }
    }
}
