using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TbRubrosexamenes
    {
        public TbRubrosexamenes()
        {
            TbExamenalumno = new HashSet<TbExamenalumno>();
        }

        public int IdTbRubrosExamenes { get; set; }
        public string RubroExamen { get; set; }
        public int? TipoExamen { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<TbExamenalumno> TbExamenalumno { get; set; }
    }
}
