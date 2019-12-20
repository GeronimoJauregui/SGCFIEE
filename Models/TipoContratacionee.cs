using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoContratacionee
    {
        public TipoContratacionee()
        {
            ExperienciaEducativaPeriodo = new HashSet<ExperienciaEducativaPeriodo>();
        }

        public int IdTipoContratacion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ExperienciaEducativaPeriodo> ExperienciaEducativaPeriodo { get; set; }
    }
}
