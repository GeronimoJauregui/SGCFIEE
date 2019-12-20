using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class BuzonSugerencias
    {
        public int Idtabla { get; set; }
        public int? RProblema { get; set; }
        public string NombreProblema { get; set; }
        public int RAcademicos { get; set; }
        public int? RAlumno { get; set; }
        public int? RPeriodo { get; set; }
        public string Propuesta { get; set; }
        public string Sugerencia { get; set; }
    }
}
