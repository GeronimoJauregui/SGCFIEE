using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class FormInscribirMovilidad
    {
        public int idAlumno { get; set; }
        public int idMovilidad { get; set; }
        public String NombreAlumno { get; set; }
        public String NombreMovilidad { get; set; }
        public int idPeriodo { get; set; }
    }
}
