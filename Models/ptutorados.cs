using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class ptutorados
    {
        public int? IdAcademicos { get; set; }
        public int? IdAlumno { get; set; }
        public int? Status { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public int Tipotutorado { get; set; }
    }
}
