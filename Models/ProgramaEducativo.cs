using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class ProgramaEducativo
    {
        public ProgramaEducativo()
        {
            Academicos = new HashSet<Academicos>();
            Alumnos = new HashSet<Alumnos>();
            MapaCurricular = new HashSet<MapaCurricular>();
            PafisAcademicos = new HashSet<PafisAcademicos>();
            RediseñoPlanEstudios = new HashSet<RediseñoPlanEstudios>();
        }

        public int IdProgramaEducativo { get; set; }
        public string Nombre { get; set; }
        public int? Creditos { get; set; }
        public string ClvPrograma { get; set; }
        public string Facultad { get; set; }
        public string Campus { get; set; }
        public string Nivel { get; set; }
        public int? CreditosMinXp { get; set; }
        public int? CreditosMaxXp { get; set; }
        public string Area { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Academicos> Academicos { get; set; }
        public virtual ICollection<Alumnos> Alumnos { get; set; }
        public virtual ICollection<MapaCurricular> MapaCurricular { get; set; }
        public virtual ICollection<PafisAcademicos> PafisAcademicos { get; set; }
        public virtual ICollection<RediseñoPlanEstudios> RediseñoPlanEstudios { get; set; }
    }
}
