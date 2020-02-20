using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CtExperienciarecepcional
    {
        public CtExperienciarecepcional()
        {
            TbInstanciafinalAlumno = new HashSet<TbInstanciafinalAlumno>();
        }

        public int IdCtExperienciaRecepcional { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? Tipo { get; set; }
        public int RAsesor { get; set; }

        public virtual Academicos RAsesorNavigation { get; set; }
        public virtual ICollection<TbInstanciafinalAlumno> TbInstanciafinalAlumno { get; set; }
    }
}
