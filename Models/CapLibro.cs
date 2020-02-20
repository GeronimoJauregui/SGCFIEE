using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CapLibro
    {
        public int IdCapLibro { get; set; }
        public int? IdAcademico { get; set; }
        public string Titulo { get; set; }
        public int? IdEditorial { get; set; }
        public string Isbn { get; set; }
        public int? Anio { get; set; }
        public string Archivo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual Editorial IdEditorialNavigation { get; set; }
    }
}
