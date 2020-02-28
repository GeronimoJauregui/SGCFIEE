using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class PonenciasConferencias
    {
        public PonenciasConferencias()
        {
            Academicoponenciasconf = new HashSet<Academicoponenciasconf>();
        }

        public int IdPonencias { get; set; }
        public int? PonenciaConferencia { get; set; }
        public int? IdTipo { get; set; }
        public string Nombre { get; set; }
        public DateTime? Fecha { get; set; }
        public string Archivo { get; set; }

        public virtual TipoLocNacInter IdTipoNavigation { get; set; }
        public virtual ICollection<Academicoponenciasconf> Academicoponenciasconf { get; set; }
    }
}
