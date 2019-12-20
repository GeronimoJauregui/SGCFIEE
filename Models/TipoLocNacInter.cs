using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoLocNacInter
    {
        public TipoLocNacInter()
        {
            Articulos = new HashSet<Articulos>();
            Concursos = new HashSet<Concursos>();
            Congresos = new HashSet<Congresos>();
            PatentesAcademicos = new HashSet<PatentesAcademicos>();
            PonenciasConferencias = new HashSet<PonenciasConferencias>();
            Revistas = new HashSet<Revistas>();
        }

        public int IdTipo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Articulos> Articulos { get; set; }
        public virtual ICollection<Concursos> Concursos { get; set; }
        public virtual ICollection<Congresos> Congresos { get; set; }
        public virtual ICollection<PatentesAcademicos> PatentesAcademicos { get; set; }
        public virtual ICollection<PonenciasConferencias> PonenciasConferencias { get; set; }
        public virtual ICollection<Revistas> Revistas { get; set; }
    }
}
