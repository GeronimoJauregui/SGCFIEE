using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class pCertificaciones
    {
        public int IdCertificaciones { get; set; }
        public string Nombre { get; set; }
        public int IdTipoCertificacion { get; set; }
        public string TipoCertificacion { get; set; }
        public int IdAcademico { get; set; }
        public string Archivo { get; set; }
    }
}
