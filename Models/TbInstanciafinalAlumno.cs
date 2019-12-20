using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TbInstanciafinalAlumno
    {
        public int IdTbInstanciaFinalAlumno { get; set; }
        public int? RAlumno { get; set; }
        public int? RExpRep { get; set; }
        public int? RServPrac { get; set; }

        public virtual Alumnos RAlumnoNavigation { get; set; }
        public virtual CtExperienciarecepcional RExpRepNavigation { get; set; }
        public virtual TbServiciopracticas RServPracNavigation { get; set; }
    }
}
