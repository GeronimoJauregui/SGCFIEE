using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TbEventos
    {
        public TbEventos()
        {
            EventosAlumnos = new HashSet<EventosAlumnos>();
        }

        public int IdEventos { get; set; }
        public string Nombre { get; set; }
        public int? RTioEvento { get; set; }
        public int? Status { get; set; }

        public virtual TipoEventos RTioEventoNavigation { get; set; }
        public virtual ICollection<EventosAlumnos> EventosAlumnos { get; set; }
    }
}
