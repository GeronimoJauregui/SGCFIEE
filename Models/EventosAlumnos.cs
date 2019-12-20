using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class EventosAlumnos
    {
        public int IdEventosAlumnos { get; set; }
        public int? RAlumno { get; set; }
        public int? REvento { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Status { get; set; }

        public virtual Alumnos RAlumnoNavigation { get; set; }
        public virtual TbEventos REventoNavigation { get; set; }
    }
}
