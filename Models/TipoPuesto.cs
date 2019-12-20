using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoPuesto
    {
        public TipoPuesto()
        {
            ExperienciaProfesional = new HashSet<ExperienciaProfesional>();
        }

        public int IdPuesto { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ExperienciaProfesional> ExperienciaProfesional { get; set; }
    }
}
