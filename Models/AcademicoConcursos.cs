using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academicoconcursos
    {
        public int IdAcademicoConcursos { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdConcursos { get; set; }
        public int? Lider { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual Concursos IdConcursosNavigation { get; set; }
    }
}
