using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academicoarticulos
    {
        public int IdAcademicoArticulos { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdArticulo { get; set; }
        public int? Lider { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual Articulos IdArticuloNavigation { get; set; }
    }
}
