using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CtEmpresaServPrac
    {
        public CtEmpresaServPrac()
        {
            TbServiciopracticas = new HashSet<TbServiciopracticas>();
        }

        public int IdCtEmpresas { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<TbServiciopracticas> TbServiciopracticas { get; set; }
    }
}
