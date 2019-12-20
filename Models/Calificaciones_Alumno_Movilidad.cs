using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class Calificaciones_Alumno_Movilidad
    {
        public int calificacion { get; set; }
        public int creditos { get; set; }
        public int idhorario { get; set; }
        public int idAlu { get; set; }
        public String NombreMateria { get; set; }
    }
}
