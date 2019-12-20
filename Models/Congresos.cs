using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Congresos
    {
        public int IdCongresos { get; set; }
        public int? IdNacInt { get; set; }
        public int? IdAcademico { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoLocNacInter IdNacIntNavigation { get; set; }
    }
}
