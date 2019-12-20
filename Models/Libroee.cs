using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Libroee
    {
        public int IdLibroEe { get; set; }
        public int? IdAcademico { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }
        public int? IdPeriodo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoPeriodo IdPeriodoNavigation { get; set; }
    }
}
