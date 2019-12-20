using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoLaboratorio
    {
        public TipoLaboratorio()
        {
            Laboratorio = new HashSet<Laboratorio>();
        }

        public int IdTipoLaboratorio { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Laboratorio> Laboratorio { get; set; }
    }
}
