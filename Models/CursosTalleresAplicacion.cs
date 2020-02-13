using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CursosTalleresAplicacion
    {
        public CursosTalleresAplicacion()
        {
            AcademicosCursosTaller = new HashSet<AcademicosCursosTaller>();
        }

        public int IdCursosTalleres { get; set; }
        public int? CT { get; set; }
        public string Titulo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Archivo { get; set; }

        public virtual ICollection<AcademicosCursosTaller> AcademicosCursosTaller { get; set; }
    }
}
