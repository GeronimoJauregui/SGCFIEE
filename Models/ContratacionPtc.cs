using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class ContratacionPtc
    {
        public int IdContrato { get; set; }
        public int? IdAcademico { get; set; }
        public DateTime? FechaNombramiento { get; set; }
        public string Archivo { get; set; }
        public int? Status { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
    }
}
