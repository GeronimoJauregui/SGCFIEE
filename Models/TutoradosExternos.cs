using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TutoradosExternos
    {
        public int IdTutoradosExternos { get; set; }
        public int? IdAcademico { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
    }
}
