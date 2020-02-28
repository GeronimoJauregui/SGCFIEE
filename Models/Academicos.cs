using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academicos
    {
        public Academicos()
        {
            Academicoarticulos = new HashSet<Academicoarticulos>();
            Academicocaplibro = new HashSet<Academicocaplibro>();
            Academicoconcursos = new HashSet<Academicoconcursos>();
            Academicocongresos = new HashSet<Academicocongresos>();
            Academicolibro = new HashSet<Academicolibro>();
            Academicoponenciasconf = new HashSet<Academicoponenciasconf>();
            Academicoreportest = new HashSet<Academicoreportest>();
            Academicorevistas = new HashSet<Academicorevistas>();
            Academicoscuerposacad = new HashSet<Academicoscuerposacad>();
            Academicoscursostaller = new HashSet<Academicoscursostaller>();
            Academicosevaluadores = new HashSet<Academicosevaluadores>();
            Academicosjuradorecep = new HashSet<Academicosjuradorecep>();
            Academicosjuroposicion = new HashSet<Academicosjuroposicion>();
            Academicospatentes = new HashSet<Academicospatentes>();
            Academicotrabajosrecep = new HashSet<Academicotrabajosrecep>();
            Asistencias = new HashSet<Asistencias>();
            Certificaciones = new HashSet<Certificaciones>();
            ConsejoTecnico = new HashSet<ConsejoTecnico>();
            ContratacionPtc = new HashSet<ContratacionPtc>();
            CoordinadorAcademia = new HashSet<CoordinadorAcademia>();
            CoordinadorProgramaTransversal = new HashSet<CoordinadorProgramaTransversal>();
            CtExperienciarecepcional = new HashSet<CtExperienciarecepcional>();
            CursosDiplomadoFormacion = new HashSet<CursosDiplomadoFormacion>();
            DistincionesTa = new HashSet<DistincionesTa>();
            Estudios = new HashSet<Estudios>();
            EvaluacionConsejoTecnico = new HashSet<EvaluacionConsejoTecnico>();
            EvaluacionEstudiantes = new HashSet<EvaluacionEstudiantes>();
            ExperienciaEducativaPeriodo = new HashSet<ExperienciaEducativaPeriodo>();
            ExperienciaProfesional = new HashSet<ExperienciaProfesional>();
            Laboratorio = new HashSet<Laboratorio>();
            Libroee = new HashSet<Libroee>();
            ManualesPractica = new HashSet<ManualesPractica>();
            MateriaDidactico = new HashSet<MateriaDidactico>();
            PafisAcademicos = new HashSet<PafisAcademicos>();
            Pagos = new HashSet<Pagos>();
            ParticipacionPladea = new HashSet<ParticipacionPladea>();
            ProyectoEducativos = new HashSet<ProyectoEducativos>();
            RecursosExternos = new HashSet<RecursosExternos>();
            RediseñoPlanEstudios = new HashSet<RediseñoPlanEstudios>();
            TbBuzonAcademicos = new HashSet<TbBuzonAcademicos>();
            TbCalificacionTutor = new HashSet<TbCalificacionTutor>();
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
        public string Rfc { get; set; }

        public virtual ProgramaEducativo IdProgramaEducativoNavigation { get; set; }
        public virtual TipoPersonal RTipoPersonalNavigation { get; set; }
        public virtual ICollection<Academicoarticulos> Academicoarticulos { get; set; }
        public virtual ICollection<Academicocaplibro> Academicocaplibro { get; set; }
        public virtual ICollection<Academicoconcursos> Academicoconcursos { get; set; }
        public virtual ICollection<Academicocongresos> Academicocongresos { get; set; }
        public virtual ICollection<Academicolibro> Academicolibro { get; set; }
        public virtual ICollection<Academicoponenciasconf> Academicoponenciasconf { get; set; }
        public virtual ICollection<Academicoreportest> Academicoreportest { get; set; }
        public virtual ICollection<Academicorevistas> Academicorevistas { get; set; }
        public virtual ICollection<Academicoscuerposacad> Academicoscuerposacad { get; set; }
        public virtual ICollection<Academicoscursostaller> Academicoscursostaller { get; set; }
        public virtual ICollection<Academicosevaluadores> Academicosevaluadores { get; set; }
        public virtual ICollection<Academicosjuradorecep> Academicosjuradorecep { get; set; }
        public virtual ICollection<Academicosjuroposicion> Academicosjuroposicion { get; set; }
        public virtual ICollection<Academicospatentes> Academicospatentes { get; set; }
        public virtual ICollection<Academicotrabajosrecep> Academicotrabajosrecep { get; set; }
        public virtual ICollection<Asistencias> Asistencias { get; set; }
        public virtual ICollection<Certificaciones> Certificaciones { get; set; }
        public virtual ICollection<ConsejoTecnico> ConsejoTecnico { get; set; }
        public virtual ICollection<ContratacionPtc> ContratacionPtc { get; set; }
        public virtual ICollection<CoordinadorAcademia> CoordinadorAcademia { get; set; }
        public virtual ICollection<CoordinadorProgramaTransversal> CoordinadorProgramaTransversal { get; set; }
        public virtual ICollection<CtExperienciarecepcional> CtExperienciarecepcional { get; set; }
        public virtual ICollection<CursosDiplomadoFormacion> CursosDiplomadoFormacion { get; set; }
        public virtual ICollection<DistincionesTa> DistincionesTa { get; set; }
        public virtual ICollection<Estudios> Estudios { get; set; }
        public virtual ICollection<EvaluacionConsejoTecnico> EvaluacionConsejoTecnico { get; set; }
        public virtual ICollection<EvaluacionEstudiantes> EvaluacionEstudiantes { get; set; }
        public virtual ICollection<ExperienciaEducativaPeriodo> ExperienciaEducativaPeriodo { get; set; }
        public virtual ICollection<ExperienciaProfesional> ExperienciaProfesional { get; set; }
        public virtual ICollection<Laboratorio> Laboratorio { get; set; }
        public virtual ICollection<Libroee> Libroee { get; set; }
        public virtual ICollection<ManualesPractica> ManualesPractica { get; set; }
        public virtual ICollection<MateriaDidactico> MateriaDidactico { get; set; }
        public virtual ICollection<PafisAcademicos> PafisAcademicos { get; set; }
        public virtual ICollection<Pagos> Pagos { get; set; }
        public virtual ICollection<ParticipacionPladea> ParticipacionPladea { get; set; }
        public virtual ICollection<ProyectoEducativos> ProyectoEducativos { get; set; }
        public virtual ICollection<RecursosExternos> RecursosExternos { get; set; }
        public virtual ICollection<RediseñoPlanEstudios> RediseñoPlanEstudios { get; set; }
        public virtual ICollection<TbBuzonAcademicos> TbBuzonAcademicos { get; set; }
        public virtual ICollection<TbCalificacionTutor> TbCalificacionTutor { get; set; }
        public virtual ICollection<TramitesAcademicos> TramitesAcademicos { get; set; }
        public virtual ICollection<TutoradosExternos> TutoradosExternos { get; set; }
        public virtual ICollection<Tutores> Tutores { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
