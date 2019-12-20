using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoDistincionTa
    {
        public TipoDistincionTa()
        {
            DistincionesTa = new HashSet<DistincionesTa>();
        }

        public int IdDistincion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<DistincionesTa> DistincionesTa { get; set; }
    }
}
