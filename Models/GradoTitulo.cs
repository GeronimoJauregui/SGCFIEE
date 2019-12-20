using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class GradoTitulo
    {
        public GradoTitulo()
        {
            Estudios = new HashSet<Estudios>();
            TrabajosRecepcionales = new HashSet<TrabajosRecepcionales>();
        }

        public int IdGradoTitulo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Estudios> Estudios { get; set; }
        public virtual ICollection<TrabajosRecepcionales> TrabajosRecepcionales { get; set; }
    }
}
