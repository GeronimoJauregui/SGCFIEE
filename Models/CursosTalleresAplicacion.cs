using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class CursosTalleresAplicacion
    {
        public CursosTalleresAplicacion()
        {
            Academicoscursostaller = new HashSet<Academicoscursostaller>();
        }

        public int IdCursosTalleres { get; set; }
        public int? CT { get; set; }
        public string Titulo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Archivo { get; set; }

        public virtual ICollection<Academicoscursostaller> Academicoscursostaller { get; set; }
    }
}
