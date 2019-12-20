using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TbPafisAlumno
    {
        public int IdTbPafisAlumno { get; set; }
        public int? RAlumno { get; set; }
        public int? RInfopafi { get; set; }

        public virtual Alumnos RAlumnoNavigation { get; set; }
        public virtual PafisAcademicos RInfopafiNavigation { get; set; }
    }
}
