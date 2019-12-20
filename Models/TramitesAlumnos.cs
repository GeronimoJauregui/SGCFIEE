using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TramitesAlumnos
    {
        public int IdTramitesAlumnos { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public DateTime? FechaRegreso { get; set; }
        public string Folio { get; set; }
        public string Observacioes { get; set; }
        public int? TipoTramite { get; set; }
        public int? RAlumnos { get; set; }

        public virtual Alumnos RAlumnosNavigation { get; set; }
        public virtual TipoTramiteAlumnos TipoTramiteNavigation { get; set; }
    }
}
