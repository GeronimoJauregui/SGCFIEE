using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academicoponenciasconf
    {
        public int IdAcademicoPonenciasConf { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdPonenciasConf { get; set; }
        public int? Lider { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual PonenciasConferencias IdPonenciasConfNavigation { get; set; }
    }
}
