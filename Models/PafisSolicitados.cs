using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class PafisSolicitados
    {
        public int IdpafisSolicitados { get; set; }
        public string NombreSolicitados { get; set; }
        public string HorarioPosible { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdPeriodo { get; set; }
        public int? IdAlumno { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual Alumnos IdAlumnoNavigation { get; set; }
        public virtual TipoPeriodo IdPeriodoNavigation { get; set; }
    }
}
