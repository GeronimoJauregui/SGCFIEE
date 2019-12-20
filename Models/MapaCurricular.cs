using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class MapaCurricular
    {
        public MapaCurricular()
        {
            ExperienciaEducativaPeriodo = new HashSet<ExperienciaEducativaPeriodo>();
        }

        public int IdMapaCurricular { get; set; }
        public int? IdExperienciaEducativa { get; set; }
        public int? IdProgramaEducativo { get; set; }
        public int? Estado { get; set; }

        public virtual ExperienciaEducativa IdExperienciaEducativaNavigation { get; set; }
        public virtual ProgramaEducativo IdProgramaEducativoNavigation { get; set; }
        public virtual ICollection<ExperienciaEducativaPeriodo> ExperienciaEducativaPeriodo { get; set; }
    }
}
