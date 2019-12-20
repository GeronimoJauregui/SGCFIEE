using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class PafisAcademicos
    {
        public PafisAcademicos()
        {
            TbPafisAlumno = new HashSet<TbPafisAlumno>();
        }

        public int IdPafis { get; set; }
        public int? IdAcademico { get; set; }
        public int? Tipopafi { get; set; }
        public int? Estado { get; set; }
        public sbyte? Solicitud { get; set; }
        public string Nombre { get; set; }
        public int? NumHoras { get; set; }
        public int? IdPeriodo { get; set; }
        public int? IdSalon { get; set; }
        public int? IdProgramaImpacta { get; set; }
        public int? NumeroCt { get; set; }
        public string ArchivoPafi { get; set; }
        public string ArchivoActaA { get; set; }
        public string Horario { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoPeriodo IdPeriodoNavigation { get; set; }
        public virtual ProgramaEducativo IdProgramaImpactaNavigation { get; set; }
        public virtual TbSalones IdSalonNavigation { get; set; }
        public virtual ICollection<TbPafisAlumno> TbPafisAlumno { get; set; }
    }
}
