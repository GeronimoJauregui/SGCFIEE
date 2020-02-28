using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class PatentesAcademicos
    {
        public PatentesAcademicos()
        {
            Academicospatentes = new HashSet<Academicospatentes>();
        }

        public int IdPatentesAcademicos { get; set; }
        public int IdNacI { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }

        public virtual TipoLocNacInter IdNacINavigation { get; set; }
        public virtual ICollection<Academicospatentes> Academicospatentes { get; set; }
    }
}
