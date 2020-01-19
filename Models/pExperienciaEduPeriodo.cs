using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class pExperienciaEduPeriodo
    {
        public int IdExperienciaEducativaPeriodo { get; set; }
        public int? Nrc { get; set; }
        public int? IdPeriodo { get; set; }
        public string periodo { get; set; }
        public int? IdAcademico { get; set; }
        public int? Npersonal { get; set; }
        public string academico { get; set; }
        public int? IdInstitucionSuperior { get; set; }
        public string institucion { get; set; }
        public int? IdContratacionEe { get; set; }
        public string tipo_contratacion { get; set; }
        public int? IdSalon { get; set; }
        public string salon { get; set; }
        public float? CalificacionAcademico { get; set; }
        public int? Status { get; set; }
        public int? IdMapaCurricular { get; set; }
        public string EE { get; set; }
        public string PE { get; set; }
        public int? creditos { get; set; }
        public string area { get; set; }
        public int? horas { get; set; }

    }
}
