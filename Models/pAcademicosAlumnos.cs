using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class pAcademicosAlumnos
    {
        public int IdAlumnos { get; set; }
        public string matricula { get; set; }
        public int? RDatosPerson { get; set; }
        public string Nombre { get; set; }
        public string A_paterno { get; set; }
        public string A_materno { get; set; }
    }
}
