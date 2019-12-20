using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class PatentesAcademicos
    {
        public int IdPatentesAcademicos { get; set; }
        public int IdAcademico { get; set; }
        public int IdNacI { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoLocNacInter IdNacINavigation { get; set; }
    }
}
