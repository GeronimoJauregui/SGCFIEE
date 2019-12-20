using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academias
    {
        public Academias()
        {
            CoordinadorAcademia = new HashSet<CoordinadorAcademia>();
            TrabajosRecepcionales = new HashSet<TrabajosRecepcionales>();
        }

        public int IdAcademias { get; set; }
        public string Nombre { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<CoordinadorAcademia> CoordinadorAcademia { get; set; }
        public virtual ICollection<TrabajosRecepcionales> TrabajosRecepcionales { get; set; }
    }
}
