using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class JuradoExamenOposicion
    {
        public JuradoExamenOposicion()
        {
            Academicosjuroposicion = new HashSet<Academicosjuroposicion>();
        }

        public int IdJexposicion { get; set; }
        public int? TipoExamen { get; set; }
        public int? IdEe { get; set; }
        public DateTime? Fecha { get; set; }
        public string Archivo { get; set; }

        public virtual ExperienciaEducativa IdEeNavigation { get; set; }
        public virtual ICollection<Academicosjuroposicion> Academicosjuroposicion { get; set; }
    }
}
