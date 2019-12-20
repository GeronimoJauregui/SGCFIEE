using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class NombreTitulo
    {
        public NombreTitulo()
        {
            Estudios = new HashSet<Estudios>();
        }

        public int IdNombreTitulo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Estudios> Estudios { get; set; }
    }
}
