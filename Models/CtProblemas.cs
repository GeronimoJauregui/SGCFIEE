using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CtProblemas
    {
        public CtProblemas()
        {
            TbBuzonDeQuejas = new HashSet<TbBuzonDeQuejas>();
        }

        public int IdCtProblemas { get; set; }
        public string NombreProblemas { get; set; }

        public virtual ICollection<TbBuzonDeQuejas> TbBuzonDeQuejas { get; set; }
    }
}
