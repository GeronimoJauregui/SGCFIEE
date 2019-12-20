using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TramitesAcademicos
    {
        public int IdTramitesAcademicos { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public DateTime? FechaRegreso { get; set; }
        public string Folio { get; set; }
        public string Observaciones { get; set; }
        public int? TipoTramite { get; set; }
        public int? RAcademicos { get; set; }

        public virtual Academicos RAcademicosNavigation { get; set; }
        public virtual TipoTramiteAcademicos TipoTramiteNavigation { get; set; }
    }
}
