using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TbHorario
    {
        public int IdPeriodoActual { get; set; }
        public int? RExperienciaPeriodo { get; set; }
        public int? RAlumno { get; set; }
        public int? Status { get; set; }
        public int? Calificacion { get; set; }
        public int? RSalon { get; set; }
        public int? RTipoCalif { get; set; }

        public virtual Alumnos RAlumnoNavigation { get; set; }
        public virtual ExperienciaEducativaPeriodo RExperienciaPeriodoNavigation { get; set; }
        public virtual TbSalones RSalonNavigation { get; set; }
        public virtual TbCalificacion RTipoCalifNavigation { get; set; }
    }
}
