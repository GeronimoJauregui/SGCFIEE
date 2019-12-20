using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class CalificacionAlumno
    {
        public int IdExperienciaEducativaPeriodo { get; set; }
        public int idalumno { get; set; }
        public int? Nrc { get; set; }
        public int? creditos { get; set; }
        public int? IdPeriodo { get; set; }
        public int? IdAcademico { get; set; }
        public string Nombreaca { get; set; }
       // public int? IdInstitucionSuperior { get; set; }
        //public int? IdContratacionEe { get; set; }
        public int? IdSalon { get; set; }
        //public float? CalificacionAcademico { get; set; }
        public int? Status { get; set; }
        public int? IdMapaCurricular { get; set; }
        public int? IdExperienciaEducativa { get; set; }
        public string Nombreexpe { get; set; }
        public string tipocali { get; set; }
        public int? IdProgramaEducativo { get; set; }
        public int IdTbCalificacion { get; set; }
        public int? Calificacion { get; set; }
        public int? RTipoCalificacion { get; set; }
        

    }
}
