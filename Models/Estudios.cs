using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Estudios
    {
        public int IdEstudios { get; set; }
        public int IdNombreTitulo { get; set; }
        public int IdInstitucion { get; set; }
        public int IdAcademico { get; set; }
        public int? IdGradoTitulo { get; set; }
        public DateTime? FechaDeEgreso { get; set; }
        public DateTime? FechaDeTitulacion { get; set; }
        public int? AcrePnpc { get; set; }
        public string ArchivoTitulo { get; set; }
        public string ArchivoCedula { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual GradoTitulo IdGradoTituloNavigation { get; set; }
        public virtual InstitucionesEmpresas IdInstitucionNavigation { get; set; }
        public virtual NombreTitulo IdNombreTituloNavigation { get; set; }
    }
}
