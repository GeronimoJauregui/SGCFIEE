using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CtMovilidades
    {
        public CtMovilidades()
        {
            TbMovilidad = new HashSet<TbMovilidad>();
        }

        public int IdCtMovilidades { get; set; }
        public int? TipoMovilidades { get; set; }
        public string PaisDestinoMovilidad { get; set; }
        public string EntidadDestinoMovilidad { get; set; }
        public string EscuelaDestinoMovilidad { get; set; }
        public string TiempoPermanenciaMovilidad { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<TbMovilidad> TbMovilidad { get; set; }
    }
}
