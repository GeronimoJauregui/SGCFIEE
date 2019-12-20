using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Editorial
    {
        public Editorial()
        {
            CapLibro = new HashSet<CapLibro>();
            LibrosAcademicos = new HashSet<LibrosAcademicos>();
        }

        public int IdEditorial { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<CapLibro> CapLibro { get; set; }
        public virtual ICollection<LibrosAcademicos> LibrosAcademicos { get; set; }
    }
}
