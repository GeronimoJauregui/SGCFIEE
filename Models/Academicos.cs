using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academicos
    {
        public Academicos()
        {
            Articulos = new HashSet<Articulos>();
            Asistencias = new HashSet<Asistencias>();
            CaAcademicos = new HashSet<CaAcademicos>();
            CapLibro = new HashSet<CapLibro>();
            Certificaciones = new HashSet<Certificaciones>();
            Concursos = new HashSet<Concursos>();
            Congresos = new HashSet<Congresos>();
            ConsejoTecnico = new HashSet<ConsejoTecnico>();
            ContratacionPtc = new HashSet<ContratacionPtc>();
            CoordinadorAcademia = new HashSet<CoordinadorAcademia>();
            CoordinadorProgramaTransversal = new HashSet<CoordinadorProgramaTransversal>();
            CtExperienciarecepcional = new HashSet<CtExperienciarecepcional>();
            CursosDiplomadoFormacion = new HashSet<CursosDiplomadoFormacion>();
            CursosTalleresAplicacion = new HashSet<CursosTalleresAplicacion>();
            DistincionesTa = new HashSet<DistincionesTa>();
            Estudios = new HashSet<Estudios>();
            EvaluacionConsejoTecnico = new HashSet<EvaluacionConsejoTecnico>();
            EvaluacionEstudiantes = new HashSet<EvaluacionEstudiantes>();
            EvaluadoresAcademicos = new HashSet<EvaluadoresAcademicos>();
            ExperienciaEducativaPeriodo = new HashSet<ExperienciaEducativaPeriodo>();
            ExperienciaProfesional = new HashSet<ExperienciaProfesional>();
            JuradoExamenOposicion = new HashSet<JuradoExamenOposicion>();
            JuradoExperienciaRecepcional = new HashSet<JuradoExperienciaRecepcional>();
            Laboratorio = new HashSet<Laboratorio>();
            Libroee = new HashSet<Libroee>();
            LibrosAcademicos = new HashSet<LibrosAcademicos>();
            ManualesPractica = new HashSet<ManualesPractica>();
            MateriaDidactico = new HashSet<MateriaDidactico>();
            PafisAcademicos = new HashSet<PafisAcademicos>();
            Pagos = new HashSet<Pagos>();
            ParticipacionPladea = new HashSet<ParticipacionPladea>();
            PatentesAcademicos = new HashSet<PatentesAcademicos>();
            PonenciasConferencias = new HashSet<PonenciasConferencias>();
            ProyectoEducativos = new HashSet<ProyectoEducativos>();
            RecursosExternos = new HashSet<RecursosExternos>();
            RediseñoPlanEstudios = new HashSet<RediseñoPlanEstudios>();
            ReportesTecnicos = new HashSet<ReportesTecnicos>();
            Revistas = new HashSet<Revistas>();
            TbBuzonAcademicos = new HashSet<TbBuzonAcademicos>();
            TbCalificacionTutor = new HashSet<TbCalificacionTutor>();
            TrabajosRecepcionales = new HashSet<TrabajosRecepcionales>();
            TramitesAcademicos = new HashSet<TramitesAcademicos>();
            TutoradosExternos = new HashSet<TutoradosExternos>();
            Tutores = new HashSet<Tutores>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdAcademicos { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Curp { get; set; }
        public string CorreoInstitucional { get; set; }
        public string CorreoAlternativo { get; set; }
        public string Celular { get; set; }
        public int? Sexo { get; set; }
        public int? NumeroPersonal { get; set; }
        public int? IdProgramaEducativo { get; set; }
        public DateTime? FechaIngresoUv { get; set; }
        public int? Status { get; set; }
        public int? RTipoPersonal { get; set; }

        public virtual ProgramaEducativo IdProgramaEducativoNavigation { get; set; }
        public virtual TipoPersonal RTipoPersonalNavigation { get; set; }
        public virtual ICollection<Articulos> Articulos { get; set; }
        public virtual ICollection<Asistencias> Asistencias { get; set; }
        public virtual ICollection<CaAcademicos> CaAcademicos { get; set; }
        public virtual ICollection<CapLibro> CapLibro { get; set; }
        public virtual ICollection<Certificaciones> Certificaciones { get; set; }
        public virtual ICollection<Concursos> Concursos { get; set; }
        public virtual ICollection<Congresos> Congresos { get; set; }
        public virtual ICollection<ConsejoTecnico> ConsejoTecnico { get; set; }
        public virtual ICollection<ContratacionPtc> ContratacionPtc { get; set; }
        public virtual ICollection<CoordinadorAcademia> CoordinadorAcademia { get; set; }
        public virtual ICollection<CoordinadorProgramaTransversal> CoordinadorProgramaTransversal { get; set; }
        public virtual ICollection<CtExperienciarecepcional> CtExperienciarecepcional { get; set; }
        public virtual ICollection<CursosDiplomadoFormacion> CursosDiplomadoFormacion { get; set; }
        public virtual ICollection<CursosTalleresAplicacion> CursosTalleresAplicacion { get; set; }
        public virtual ICollection<DistincionesTa> DistincionesTa { get; set; }
        public virtual ICollection<Estudios> Estudios { get; set; }
        public virtual ICollection<EvaluacionConsejoTecnico> EvaluacionConsejoTecnico { get; set; }
        public virtual ICollection<EvaluacionEstudiantes> EvaluacionEstudiantes { get; set; }
        public virtual ICollection<EvaluadoresAcademicos> EvaluadoresAcademicos { get; set; }
        public virtual ICollection<ExperienciaEducativaPeriodo> ExperienciaEducativaPeriodo { get; set; }
        public virtual ICollection<ExperienciaProfesional> ExperienciaProfesional { get; set; }
        public virtual ICollection<JuradoExamenOposicion> JuradoExamenOposicion { get; set; }
        public virtual ICollection<JuradoExperienciaRecepcional> JuradoExperienciaRecepcional { get; set; }
        public virtual ICollection<Laboratorio> Laboratorio { get; set; }
        public virtual ICollection<Libroee> Libroee { get; set; }
        public virtual ICollection<LibrosAcademicos> LibrosAcademicos { get; set; }
        public virtual ICollection<ManualesPractica> ManualesPractica { get; set; }
        public virtual ICollection<MateriaDidactico> MateriaDidactico { get; set; }
        public virtual ICollection<PafisAcademicos> PafisAcademicos { get; set; }
        public virtual ICollection<Pagos> Pagos { get; set; }
        public virtual ICollection<ParticipacionPladea> ParticipacionPladea { get; set; }
        public virtual ICollection<PatentesAcademicos> PatentesAcademicos { get; set; }
        public virtual ICollection<PonenciasConferencias> PonenciasConferencias { get; set; }
        public virtual ICollection<ProyectoEducativos> ProyectoEducativos { get; set; }
        public virtual ICollection<RecursosExternos> RecursosExternos { get; set; }
        public virtual ICollection<RediseñoPlanEstudios> RediseñoPlanEstudios { get; set; }
        public virtual ICollection<ReportesTecnicos> ReportesTecnicos { get; set; }
        public virtual ICollection<Revistas> Revistas { get; set; }
        public virtual ICollection<TbBuzonAcademicos> TbBuzonAcademicos { get; set; }
        public virtual ICollection<TbCalificacionTutor> TbCalificacionTutor { get; set; }
        public virtual ICollection<TrabajosRecepcionales> TrabajosRecepcionales { get; set; }
        public virtual ICollection<TramitesAcademicos> TramitesAcademicos { get; set; }
        public virtual ICollection<TutoradosExternos> TutoradosExternos { get; set; }
        public virtual ICollection<Tutores> Tutores { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
