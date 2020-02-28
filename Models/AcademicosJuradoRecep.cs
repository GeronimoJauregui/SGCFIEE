using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academicosjuradorecep
    {
        public int IdAcademicosJuradoRecep { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdJurado { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual JuradoExperienciaRecepcional IdJuradoNavigation { get; set; }
    }
}
