using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class pTipoContratacion
    {
        public int IdContrato { get; set; }
        public int? IdAcademico { get; set; }
        public DateTime? FechaNombramiento { get; set; }
        public string Archivo { get; set; }
        public int IdLaboratorio { get; set; }
        public int tipopersonal { get; set; }
        public int? IdTipoLaboratorio { get; set; }
        public int? Status { get; set; }

    }
}
