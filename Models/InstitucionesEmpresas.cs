using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class InstitucionesEmpresas
    {
        public InstitucionesEmpresas()
        {
            CursosDiplomadoFormacion = new HashSet<CursosDiplomadoFormacion>();
            Estudios = new HashSet<Estudios>();
            ExperienciaEducativaPeriodo = new HashSet<ExperienciaEducativaPeriodo>();
            ExperienciaProfesional = new HashSet<ExperienciaProfesional>();
        }

        public int IdIE { get; set; }
        public string Nombre { get; set; }
        public int? IesEmpresa { get; set; }

        public virtual ICollection<CursosDiplomadoFormacion> CursosDiplomadoFormacion { get; set; }
        public virtual ICollection<Estudios> Estudios { get; set; }
        public virtual ICollection<ExperienciaEducativaPeriodo> ExperienciaEducativaPeriodo { get; set; }
        public virtual ICollection<ExperienciaProfesional> ExperienciaProfesional { get; set; }
    }
}
