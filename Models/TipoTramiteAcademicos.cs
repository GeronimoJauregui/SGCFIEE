using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoTramiteAcademicos
    {
        public TipoTramiteAcademicos()
        {
            TramitesAcademicos = new HashSet<TramitesAcademicos>();
        }

        public int IdTipoTramiteAcademicos { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TramitesAcademicos> TramitesAcademicos { get; set; }
    }
}
