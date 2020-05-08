using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class InformacionPafiCompleta
    {
        public int? idpafi { get; set; }
        public String alumno { get; set; }
        public String academico { get; set; }
        public String matricula { get; set; }
        public String nombrePafi { get; set; }
        public int? Horas { get; set; }
        public String salon { get; set; }
        public String programa { get; set; }
        public String horario { get; set; }
        public int? tipoPafi { get; set; }
    }
}
