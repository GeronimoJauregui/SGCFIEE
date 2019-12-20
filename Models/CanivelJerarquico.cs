using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CanivelJerarquico
    {
        public CanivelJerarquico()
        {
            CaAcademicos = new HashSet<CaAcademicos>();
            CaAlumnos = new HashSet<CaAlumnos>();
        }

        public int IdCanivelJerarquico { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<CaAcademicos> CaAcademicos { get; set; }
        public virtual ICollection<CaAlumnos> CaAlumnos { get; set; }
    }
}
