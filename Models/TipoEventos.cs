using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoEventos
    {
        public TipoEventos()
        {
            TbEventos = new HashSet<TbEventos>();
        }

        public int IdEventos { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TbEventos> TbEventos { get; set; }
    }
}
