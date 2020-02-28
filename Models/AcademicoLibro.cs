using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academicolibro
    {
        public int IdAcademicoLibro { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdLibroAcad { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual LibrosAcademicos IdLibroAcadNavigation { get; set; }
    }
}
