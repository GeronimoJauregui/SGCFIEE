using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TipoPeriodo
    {
        public TipoPeriodo()
        {
            ConsejoTecnicoIdFechaCierreNavigation = new HashSet<ConsejoTecnico>();
            ConsejoTecnicoIdFechaInicialNavigation = new HashSet<ConsejoTecnico>();
            CoordinadorAcademiaIdFechaCierreNavigation = new HashSet<CoordinadorAcademia>();
            CoordinadorAcademiaIdFechaInicialNavigation = new HashSet<CoordinadorAcademia>();
            CoordinadorProgramaTransversalIdFechaCierreNavigation = new HashSet<CoordinadorProgramaTransversal>();
            CoordinadorProgramaTransversalIdFechaInicialNavigation = new HashSet<CoordinadorProgramaTransversal>();
            EvaluacionConsejoTecnico = new HashSet<EvaluacionConsejoTecnico>();
            EvaluacionEstudiantes = new HashSet<EvaluacionEstudiantes>();
            ExperienciaEducativaPeriodo = new HashSet<ExperienciaEducativaPeriodo>();
            Libroee = new HashSet<Libroee>();
            ManualesPractica = new HashSet<ManualesPractica>();
            MateriaDidactico = new HashSet<MateriaDidactico>();
            PafisAcademicos = new HashSet<PafisAcademicos>();
            ProyectoEducativos = new HashSet<ProyectoEducativos>();
            RecursosExternos = new HashSet<RecursosExternos>();
            TbBuzonAcademicos = new HashSet<TbBuzonAcademicos>();
            TbBuzonDeQuejas = new HashSet<TbBuzonDeQuejas>();
            TbCalificacionTutor = new HashSet<TbCalificacionTutor>();
            TbMovilidad = new HashSet<TbMovilidad>();
        }

        public int IdPeriodo { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public virtual ICollection<ConsejoTecnico> ConsejoTecnicoIdFechaCierreNavigation { get; set; }
        public virtual ICollection<ConsejoTecnico> ConsejoTecnicoIdFechaInicialNavigation { get; set; }
        public virtual ICollection<CoordinadorAcademia> CoordinadorAcademiaIdFechaCierreNavigation { get; set; }
        public virtual ICollection<CoordinadorAcademia> CoordinadorAcademiaIdFechaInicialNavigation { get; set; }
        public virtual ICollection<CoordinadorProgramaTransversal> CoordinadorProgramaTransversalIdFechaCierreNavigation { get; set; }
        public virtual ICollection<CoordinadorProgramaTransversal> CoordinadorProgramaTransversalIdFechaInicialNavigation { get; set; }
        public virtual ICollection<EvaluacionConsejoTecnico> EvaluacionConsejoTecnico { get; set; }
        public virtual ICollection<EvaluacionEstudiantes> EvaluacionEstudiantes { get; set; }
        public virtual ICollection<ExperienciaEducativaPeriodo> ExperienciaEducativaPeriodo { get; set; }
        public virtual ICollection<Libroee> Libroee { get; set; }
        public virtual ICollection<ManualesPractica> ManualesPractica { get; set; }
        public virtual ICollection<MateriaDidactico> MateriaDidactico { get; set; }
        public virtual ICollection<PafisAcademicos> PafisAcademicos { get; set; }
        public virtual ICollection<ProyectoEducativos> ProyectoEducativos { get; set; }
        public virtual ICollection<RecursosExternos> RecursosExternos { get; set; }
        public virtual ICollection<TbBuzonAcademicos> TbBuzonAcademicos { get; set; }
        public virtual ICollection<TbBuzonDeQuejas> TbBuzonDeQuejas { get; set; }
        public virtual ICollection<TbCalificacionTutor> TbCalificacionTutor { get; set; }
        public virtual ICollection<TbMovilidad> TbMovilidad { get; set; }
    }
}
