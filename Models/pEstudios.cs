using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class pEstudios
    {
        public int IdEstudios { get; set; }
        public int IdNombreTitulo { get; set; }
        public string NombreTitulo { get; set; }
        public int IdInstitucion { get; set; }
        public string Institucion { get; set; }
        public int IdAcademico { get; set; }
        public int? IdGradoTitulo { get; set; }
        public string GradoTitulo { get; set; }
        public string FechaDeEgreso { get; set; }
        public string FechaDeTitulacion { get; set; }
        public int? AcrePnpc { get; set; }
        public string Reconocimiento { get; set; }
        public string ArchivoTitulo { get; set; }
        public string ArchivoCedula { get; set; }
    }
}
