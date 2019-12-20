using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoPersonal
    {
        public TipoPersonal()
        {
            Academicos = new HashSet<Academicos>();
        }

        public int IdTipoPersonal { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Academicos> Academicos { get; set; }
    }
}
