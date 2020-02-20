using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Concursos
    {
        public int IdConcursos { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdNacInter { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoLocNacInter IdNacInterNavigation { get; set; }
    }
}
