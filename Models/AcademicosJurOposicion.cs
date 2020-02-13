using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class AcademicosJurOposicion
    {
        public int IdAcademicosJurOposicion { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdJurado { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual JuradoExamenOposicion IdJuradoNavigation { get; set; }
    }
}
