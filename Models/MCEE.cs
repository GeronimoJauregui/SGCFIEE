using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class MCEE
    {
        public int IdMapaCurricular { get; set; }
        public int? IdExperienciaEducativa { get; set; }
        public string NombreEE { get; set; }
        public int? IdProgramaEducativo { get; set; }
        public string NombrePE { get; set; }
        public int? Estado { get; set; }
    }
}
