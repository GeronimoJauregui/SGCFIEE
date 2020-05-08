using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class TablaPafi
    {
        public int idPafi { get; set; }
        public String NombrePafi { get; set; }
        public String Horario { get; set; }
        public int estado { get; set; }
        public String NombreMaestro { get; set; }
        public String ApePaterno { get; set; }
        public String ApeMaterno { get; set; }
        public String ClvSalon { get; set; }
        public String ProgrmaEdu { get; set; }
        public int TotalAlum { get; set; }
        public int ocupado { get; set; }

    }
}
