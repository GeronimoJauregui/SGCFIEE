using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Revistas
    {
        public int IdRevistas { get; set; }
        public int? IdNI { get; set; }
        public int? Registro { get; set; }
        public int? Arbitrada { get; set; }
        public int? IdAcademico { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoLocNacInter IdNINavigation { get; set; }
    }
}
