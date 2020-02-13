using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class AcademicoConcursos
    {
        public int IdAcademicoConcursos { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdConcursos { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual Concursos IdConcursosNavigation { get; set; }
    }
}
