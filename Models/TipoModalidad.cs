using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoModalidad
    {
        public TipoModalidad()
        {
            TrabajosRecepcionales = new HashSet<TrabajosRecepcionales>();
        }

        public int IdModalidad { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TrabajosRecepcionales> TrabajosRecepcionales { get; set; }
    }
}
