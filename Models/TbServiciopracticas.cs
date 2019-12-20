using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TbServiciopracticas
    {
        public TbServiciopracticas()
        {
            TbInstanciafinalAlumno = new HashSet<TbInstanciafinalAlumno>();
        }

        public int IdTbServicioPracticas { get; set; }
        public int? REmpresa { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? Tipo { get; set; }

        public virtual CtEmpresaServPrac REmpresaNavigation { get; set; }
        public virtual ICollection<TbInstanciafinalAlumno> TbInstanciafinalAlumno { get; set; }
    }
}
