using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            CaAlumnos = new HashSet<CaAlumnos>();
            EventosAlumnos = new HashSet<EventosAlumnos>();
            PafisSolicitados = new HashSet<PafisSolicitados>();
            TbBuzonAcademicos = new HashSet<TbBuzonAcademicos>();
            TbBuzonDeQuejas = new HashSet<TbBuzonDeQuejas>();
            TbExamenalumno = new HashSet<TbExamenalumno>();
            TbHorario = new HashSet<TbHorario>();
            TbInstanciafinalAlumno = new HashSet<TbInstanciafinalAlumno>();
            TbMovilidad = new HashSet<TbMovilidad>();
            TbPafisAlumno = new HashSet<TbPafisAlumno>();
            TrabajosRecepcionales = new HashSet<TrabajosRecepcionales>();
            TramitesAlumnos = new HashSet<TramitesAlumnos>();
            Tutores = new HashSet<Tutores>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdAlumnos { get; set; }
        public string Matricula { get; set; }
        public string CorreoInstitucional { get; set; }
        public int? AnioIngreso { get; set; }
        public string Modalidad { get; set; }
        public int? RProgramaEducativo { get; set; }
        public int? RDatosPerson { get; set; }
        public int? RStatus { get; set; }
        public string Bachillerato { get; set; }

        public virtual DatosPersonales RDatosPersonNavigation { get; set; }
        public virtual ProgramaEducativo RProgramaEducativoNavigation { get; set; }
        public virtual ICollection<CaAlumnos> CaAlumnos { get; set; }
        public virtual ICollection<EventosAlumnos> EventosAlumnos { get; set; }
        public virtual ICollection<PafisSolicitados> PafisSolicitados { get; set; }
        public virtual ICollection<TbBuzonAcademicos> TbBuzonAcademicos { get; set; }
        public virtual ICollection<TbBuzonDeQuejas> TbBuzonDeQuejas { get; set; }
        public virtual ICollection<TbExamenalumno> TbExamenalumno { get; set; }
        public virtual ICollection<TbHorario> TbHorario { get; set; }
        public virtual ICollection<TbInstanciafinalAlumno> TbInstanciafinalAlumno { get; set; }
        public virtual ICollection<TbMovilidad> TbMovilidad { get; set; }
        public virtual ICollection<TbPafisAlumno> TbPafisAlumno { get; set; }
        public virtual ICollection<TrabajosRecepcionales> TrabajosRecepcionales { get; set; }
        public virtual ICollection<TramitesAlumnos> TramitesAlumnos { get; set; }
        public virtual ICollection<Tutores> Tutores { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
