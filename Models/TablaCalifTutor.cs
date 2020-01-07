using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace SGCFIEE.Models
{
    public class TablaCalifTutor
    {
        public int IdCalifTutor { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public float? Calificacion { get; set; }
        public String Periodo { get; set; }
        public int? Status { get; set; }
    }
}
