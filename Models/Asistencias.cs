using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Asistencias
    {
        public int IdAsistencias { get; set; }
        public TimeSpan? Entrada { get; set; }
        public TimeSpan? Salida { get; set; }
        public DateTime? Fecha { get; set; }
        public int? HorasDescontadas { get; set; }
        public string Observaciones { get; set; }
        public int? RAcademicos { get; set; }

        public virtual Academicos RAcademicosNavigation { get; set; }
    }
}
