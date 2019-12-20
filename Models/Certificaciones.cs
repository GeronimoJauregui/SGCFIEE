using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Certificaciones
    {
        public int IdCertificaciones { get; set; }
        public string Nombre { get; set; }
        public int IdTipoCertificacion { get; set; }
        public int IdAcademico { get; set; }
        public string Archivo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoCertificacion IdTipoCertificacionNavigation { get; set; }
    }
}
