using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class AlumnoFinal
    {
        public int? ralumno { get; set; }
        public int? rexprep { get; set; }
        public int? rservprac { get; set; }
        public int rasesor { get; set; }
        public int rempresa {get; set;}
        public string nombreexpre { get; set; }
        public string nombreasesor { get; set; }
        public DateTime? fechafinexp { get; set; }
        public int? tipoexpre { get; set; }
        public DateTime? fechainiserv { get; set; }
        public DateTime? fechafinserv { get; set; }
        public string nombreempresa { get; set; }
        public string direccion { get; set; }
        public int? tiposervprac { get; set; }
        public string telefono { get; set; }
        public int idinstancia { get; set; }
        public int idexperiencia { get; set; }
        public int idservicio { get; set; }
        public int idempresa { get; set; }

    }
}
