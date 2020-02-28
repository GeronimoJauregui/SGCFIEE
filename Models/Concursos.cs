using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Concursos
    {
        public Concursos()
        {
            Academicoconcursos = new HashSet<Academicoconcursos>();
        }

        public int IdConcursos { get; set; }
        public int? IdNacInter { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }

        public virtual TipoLocNacInter IdNacInterNavigation { get; set; }
        public virtual ICollection<Academicoconcursos> Academicoconcursos { get; set; }
    }
}
