using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CuerpoEstados
    {
        public CuerpoEstados()
        {
            CuerposAcademicos = new HashSet<CuerposAcademicos>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<CuerposAcademicos> CuerposAcademicos { get; set; }
    }
}
