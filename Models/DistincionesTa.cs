using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class DistincionesTa
    {
        public int IdDistinciones { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdDistincion { get; set; }
        public DateTime? Vigencia { get; set; }
        public string Archivo { get; set; }
        public int? Status { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoDistincionTa IdDistincionNavigation { get; set; }
    }
}
