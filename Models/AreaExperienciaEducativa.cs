using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class AreaExperienciaEducativa
    {
        public AreaExperienciaEducativa()
        {
            ExperienciaEducativa = new HashSet<ExperienciaEducativa>();
        }

        public int IdAreaExperienciaEducativa { get; set; }
        public string Nombre { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<ExperienciaEducativa> ExperienciaEducativa { get; set; }
    }
}
