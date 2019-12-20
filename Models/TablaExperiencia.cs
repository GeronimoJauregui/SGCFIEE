using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class TablaExperiencia
    {
        public int IdExperienciaEducativa { get; set; }
        public string Nombre { get; set; }
        public int? Creditos { get; set; }
        public string Nombrearea { get; set; }
        public int? Horas { get; set; }
        public int? Status { get; set; }
    }
}
