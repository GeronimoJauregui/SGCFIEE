using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class AlumnoMovilidad
    {
        public int? idperiodo { get; set; }
        public int? tipomovi { get; set; }
        public string paisdestino { get; set; }
        public string entidaddestino { get; set; }
        public string escueladestino { get; set; }
        public string tiempoperma { get; set; }
    }
}
