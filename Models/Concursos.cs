using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Concursos
    {
        public Concursos()
        {
            AcademicoConcursos = new HashSet<AcademicoConcursos>();
        }

        public int IdConcursos { get; set; }
        public int? IdNacInter { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }

        public virtual TipoLocNacInter IdNacInterNavigation { get; set; }
        public virtual ICollection<AcademicoConcursos> AcademicoConcursos { get; set; }
    }
}
