using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class LibrosAcademicos
    {
        public LibrosAcademicos()
        {
            Academicolibro = new HashSet<Academicolibro>();
        }

        public int IdLibrosAcademicos { get; set; }
        public string Titulo { get; set; }
        public int? IdEditorial { get; set; }
        public string Isbn { get; set; }
        public int? Anio { get; set; }
        public int? Tiraje { get; set; }
        public string Archivo { get; set; }

        public virtual Editorial IdEditorialNavigation { get; set; }
        public virtual ICollection<Academicolibro> Academicolibro { get; set; }
    }
}
