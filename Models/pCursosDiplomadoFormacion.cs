using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class pCursosDiplomadoFormacion
    {
        public int IdCD { get; set; }
        public int? IdAcademico { get; set; }
        public string Nombre { get; set; }
        public int? CursoDiplomado { get; set; }
        public int? PD { get; set; }
        public int? Horas { get; set; }
        public int? IdIesEmpresa { get; set; }
        public string institucion { get; set; }
        public string Lugar { get; set; }
        public DateTime? Fecha { get; set; }
        public string Archivo { get; set; }
    }
}
