using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Laboratorio
    {
        public int IdLaboratorio { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdTipoLaboratorio { get; set; }
        public int? Status { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoLaboratorio IdTipoLaboratorioNavigation { get; set; }
    }
}
