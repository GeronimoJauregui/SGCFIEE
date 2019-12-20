using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TbCalificacion
    {
        public TbCalificacion()
        {
            TbHorario = new HashSet<TbHorario>();
        }

        public int IdTbCalificacion { get; set; }
        public int? Calificacion { get; set; }
        public int? RTipoCalificacion { get; set; }
        public int? Status { get; set; }

        public virtual CtTipoCalificacion RTipoCalificacionNavigation { get; set; }
        public virtual ICollection<TbHorario> TbHorario { get; set; }
    }
}
