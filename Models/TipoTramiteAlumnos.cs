using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoTramiteAlumnos
    {
        public TipoTramiteAlumnos()
        {
            TramitesAlumnos = new HashSet<TramitesAlumnos>();
        }

        public int IdTipoTramiteAlumnos { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TramitesAlumnos> TramitesAlumnos { get; set; }
    }
}
