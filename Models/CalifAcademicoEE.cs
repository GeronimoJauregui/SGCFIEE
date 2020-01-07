using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace SGCFIEE.Models
{
    public class CalifAcademicoEE
    {
        public int IdCalifEE { get; set; }
        public int? IdAcademico {get; set;}
        public int? IdPeriodo {get; set;}
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String Institucion {get; set;}
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String ExperienciaE { get; set; }
        public int? Nrc { get; set; }
        public float? Calificacion { get; set; }
        public String Periodo { get; set; }
    }
}