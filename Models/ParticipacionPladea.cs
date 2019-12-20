using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class ParticipacionPladea
    {
        public int IdPladea { get; set; }
        public int? IdAcademico { get; set; }
        public string Comision { get; set; }
        public string Meta { get; set; }
        public string Accion { get; set; }
        public DateTime? Fecha { get; set; }
        public string Archivo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
    }
}
