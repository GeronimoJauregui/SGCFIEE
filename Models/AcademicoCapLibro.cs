using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academicocaplibro
    {
        public int IdAcademicoCapLibro { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdCapLibro { get; set; }
        public int? Lider { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual CapLibro IdCapLibroNavigation { get; set; }
    }
}
