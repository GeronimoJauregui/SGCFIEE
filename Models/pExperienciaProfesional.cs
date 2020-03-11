using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class pExperienciaProfesional
    {
        public int IdEp { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdEmpresa { get; set; }
        public string empresa { get; set; }
        public int? IdTipoPuesto { get; set; }
        public string TipoPuesto { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int? antiguedad { get; set; }
        public string Archivo { get; set; }
        public string AreaDesarrollo { get; set; }
    }
}
