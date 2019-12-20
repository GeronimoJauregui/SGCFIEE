using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CtTipoCalificacion
    {
        public CtTipoCalificacion()
        {
            TbCalificacion = new HashSet<TbCalificacion>();
        }

        public int IdCtTipoCalificacion { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<TbCalificacion> TbCalificacion { get; set; }
    }
}
