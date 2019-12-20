using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class ProgramasTrasversales
    {
        public ProgramasTrasversales()
        {
            CoordinadorProgramaTransversal = new HashSet<CoordinadorProgramaTransversal>();
        }

        public int IdProgramasTrasversales { get; set; }
        public string Nombre { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<CoordinadorProgramaTransversal> CoordinadorProgramaTransversal { get; set; }
    }
}
