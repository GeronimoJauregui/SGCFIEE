using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TrabajosRecepcionales
    {
        public TrabajosRecepcionales()
        {
            Academicotrabajosrecep = new HashSet<Academicotrabajosrecep>();
            JuradoExperienciaRecepcional = new HashSet<JuradoExperienciaRecepcional>();
        }

        public int IdTrabajosRecepcionales { get; set; }
        public int? IdAlumno { get; set; }
        public int? IdModalidad { get; set; }
        public int? IdGrado { get; set; }
        public string NombreTrabajo { get; set; }
        public int? IdAcademia { get; set; }
        public int? Proceso { get; set; }
        public DateTime? FechaPresentacion { get; set; }
        public int? NumeroConsejoT { get; set; }
        public string Archivo { get; set; }

        public virtual Academias IdAcademiaNavigation { get; set; }
        public virtual Alumnos IdAlumnoNavigation { get; set; }
        public virtual GradoTitulo IdGradoNavigation { get; set; }
        public virtual TipoModalidad IdModalidadNavigation { get; set; }
        public virtual ICollection<Academicotrabajosrecep> Academicotrabajosrecep { get; set; }
        public virtual ICollection<JuradoExperienciaRecepcional> JuradoExperienciaRecepcional { get; set; }
    }
}
