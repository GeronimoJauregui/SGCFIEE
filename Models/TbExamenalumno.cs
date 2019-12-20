using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TbExamenalumno
    {
        public int IdTbExamenAlumno { get; set; }
        public int? IdAlumno { get; set; }
        public int? IdRubroExamen { get; set; }
        public int? TipoExamen { get; set; }
        public float? CalificacionExamen { get; set; }

        public virtual Alumnos IdAlumnoNavigation { get; set; }
        public virtual TbRubrosexamenes IdRubroExamenNavigation { get; set; }
    }
}
