using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class ExperienciaEducativa
    {
        public ExperienciaEducativa()
        {
            JuradoExamenOposicion = new HashSet<JuradoExamenOposicion>();
            MapaCurricular = new HashSet<MapaCurricular>();
        }

        public int IdExperienciaEducativa { get; set; }
        public string Nombre { get; set; }
        public int? Creditos { get; set; }
        public int? IdArea { get; set; }
        public int? Horas { get; set; }
        public int? Status { get; set; }

        public virtual AreaExperienciaEducativa IdAreaNavigation { get; set; }
        public virtual ICollection<JuradoExamenOposicion> JuradoExamenOposicion { get; set; }
        public virtual ICollection<MapaCurricular> MapaCurricular { get; set; }
    }
}
