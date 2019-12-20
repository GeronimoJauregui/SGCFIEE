using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class ExperienciaEducativaPeriodo
    {
        public ExperienciaEducativaPeriodo()
        {
            TbHorario = new HashSet<TbHorario>();
        }

        public int IdExperienciaEducativaPeriodo { get; set; }
        public int? Nrc { get; set; }
        public int? IdPeriodo { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdInstitucionSuperior { get; set; }
        public int? IdContratacionEe { get; set; }
        public int? IdSalon { get; set; }
        public float? CalificacionAcademico { get; set; }
        public int? Status { get; set; }
        public int? IdMapaCurricular { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoContratacionee IdContratacionEeNavigation { get; set; }
        public virtual InstitucionesEmpresas IdInstitucionSuperiorNavigation { get; set; }
        public virtual MapaCurricular IdMapaCurricularNavigation { get; set; }
        public virtual TipoPeriodo IdPeriodoNavigation { get; set; }
        public virtual TbSalones IdSalonNavigation { get; set; }
        public virtual ICollection<TbHorario> TbHorario { get; set; }
    }
}
