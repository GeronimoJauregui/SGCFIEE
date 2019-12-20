using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class InformacionPafiCompleta
    {
        public int idPafi { get; set; }
        public String nombrePafi { get; set; }
        public String nombreMaestro { get; set; }
        public String ApePaterno { get; set; }
        public String ApeMaterno { get; set; }
        public String clave_salon { get; set; }
        public String edo { get; set; }
        public int estado { get; set; }
        public int? totHoras { get; set; }
        public String Horario { get; set; }
    }
}
