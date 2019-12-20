using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoCertificacion
    {
        public TipoCertificacion()
        {
            Certificaciones = new HashSet<Certificaciones>();
        }

        public int IdCertificacion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Certificaciones> Certificaciones { get; set; }
    }
}
