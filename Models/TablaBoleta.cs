using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class TablaBoleta
    {
        public int IdExpericiaEducPerio { get; set; }
        public int IdHorario { get; set; }
        public int? IdTipoCalif { get; set; }
        public int? Nrc { get; set; }
        public String Maestro { get; set; }
        public String Periodo { get; set; }
        public String Salon { get; set; }
        public String Experiencia { get; set; }
        public int? Calif { get; set; }
    }
}
