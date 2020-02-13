using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CuerposAcademicos
    {
        public CuerposAcademicos()
        {
            CaAcademicos = new HashSet<CaAcademicos>();
            CaAlumnos = new HashSet<CaAlumnos>();
        }

        public int IdCuerpoAcademico { get; set; }
        public string Nombre { get; set; }
        public int? IdEstado { get; set; }

        public virtual CuerpoEstados IdEstadoNavigation { get; set; }
        public virtual ICollection<CaAcademicos> CaAcademicos { get; set; }
        public virtual ICollection<CaAlumnos> CaAlumnos { get; set; }
    }
}
