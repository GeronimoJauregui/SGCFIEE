using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class TablaAlumno
    {   
        public int id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Matricula { get; set; }
        public string NombrePro { get; set; }
        public int Status { get; set; }

    }
}
