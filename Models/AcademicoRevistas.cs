using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academicorevistas
    {
        public int IdAcademicorevistas { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdRevista { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual Revistas IdRevistaNavigation { get; set; }
    }
}
