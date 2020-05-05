using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SGCFIEE.Models
{
    public partial class sgcfieeContext : DbContext
    {
        public sgcfieeContext()
        {
        }

        public sgcfieeContext(DbContextOptions<sgcfieeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Academias> Academias { get; set; }
        public virtual DbSet<Academicoarticulos> Academicoarticulos { get; set; }
        public virtual DbSet<Academicocaplibro> Academicocaplibro { get; set; }
        public virtual DbSet<Academicoconcursos> Academicoconcursos { get; set; }
        public virtual DbSet<Academicocongresos> Academicocongresos { get; set; }
        public virtual DbSet<Academicolibro> Academicolibro { get; set; }
        public virtual DbSet<Academicoponenciasconf> Academicoponenciasconf { get; set; }
        public virtual DbSet<Academicoreportest> Academicoreportest { get; set; }
        public virtual DbSet<Academicorevistas> Academicorevistas { get; set; }
        public virtual DbSet<Academicos> Academicos { get; set; }
        public virtual DbSet<Academicoscuerposacad> Academicoscuerposacad { get; set; }
        public virtual DbSet<Academicoscursostaller> Academicoscursostaller { get; set; }
        public virtual DbSet<Academicosevaluadores> Academicosevaluadores { get; set; }
        public virtual DbSet<Academicosjuradorecep> Academicosjuradorecep { get; set; }
        public virtual DbSet<Academicosjuroposicion> Academicosjuroposicion { get; set; }
        public virtual DbSet<Academicospatentes> Academicospatentes { get; set; }
        public virtual DbSet<Academicotrabajosrecep> Academicotrabajosrecep { get; set; }
        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<AreaExperienciaEducativa> AreaExperienciaEducativa { get; set; }
        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Asistencias> Asistencias { get; set; }
        public virtual DbSet<CaAcademicos> CaAcademicos { get; set; }
        public virtual DbSet<CaAlumnos> CaAlumnos { get; set; }
        public virtual DbSet<CanivelJerarquico> CanivelJerarquico { get; set; }
        public virtual DbSet<CapLibro> CapLibro { get; set; }
        public virtual DbSet<Certificaciones> Certificaciones { get; set; }
        public virtual DbSet<Concursos> Concursos { get; set; }
        public virtual DbSet<Congresos> Congresos { get; set; }
        public virtual DbSet<ConsejoTecnico> ConsejoTecnico { get; set; }
        public virtual DbSet<ContratacionPtc> ContratacionPtc { get; set; }
        public virtual DbSet<CoordinadorAcademia> CoordinadorAcademia { get; set; }
        public virtual DbSet<CoordinadorProgramaTransversal> CoordinadorProgramaTransversal { get; set; }
        public virtual DbSet<CtEmpresaServPrac> CtEmpresaServPrac { get; set; }
        public virtual DbSet<CtExperienciarecepcional> CtExperienciarecepcional { get; set; }
        public virtual DbSet<CtMovilidades> CtMovilidades { get; set; }
        public virtual DbSet<CtProblemas> CtProblemas { get; set; }
        public virtual DbSet<CtTipoCalificacion> CtTipoCalificacion { get; set; }
        public virtual DbSet<CuerpoEstados> CuerpoEstados { get; set; }
        public virtual DbSet<CuerposAcademicos> CuerposAcademicos { get; set; }
        public virtual DbSet<CursosDiplomadoFormacion> CursosDiplomadoFormacion { get; set; }
        public virtual DbSet<CursosTalleresAplicacion> CursosTalleresAplicacion { get; set; }
        public virtual DbSet<DatosPersonales> DatosPersonales { get; set; }
        public virtual DbSet<DistincionesTa> DistincionesTa { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public virtual DbSet<Estudios> Estudios { get; set; }
        public virtual DbSet<EvaluacionConsejoTecnico> EvaluacionConsejoTecnico { get; set; }
        public virtual DbSet<EvaluacionEstudiantes> EvaluacionEstudiantes { get; set; }
        public virtual DbSet<EvaluadoresAcademicos> EvaluadoresAcademicos { get; set; }
        public virtual DbSet<EventosAlumnos> EventosAlumnos { get; set; }
        public virtual DbSet<ExperienciaEducativa> ExperienciaEducativa { get; set; }
        public virtual DbSet<ExperienciaEducativaPeriodo> ExperienciaEducativaPeriodo { get; set; }
        public virtual DbSet<ExperienciaProfesional> ExperienciaProfesional { get; set; }
        public virtual DbSet<GradoTitulo> GradoTitulo { get; set; }
        public virtual DbSet<InstitucionesEmpresas> InstitucionesEmpresas { get; set; }
        public virtual DbSet<JuradoExamenOposicion> JuradoExamenOposicion { get; set; }
        public virtual DbSet<JuradoExperienciaRecepcional> JuradoExperienciaRecepcional { get; set; }
        public virtual DbSet<Laboratorio> Laboratorio { get; set; }
        public virtual DbSet<Libroee> Libroee { get; set; }
        public virtual DbSet<LibrosAcademicos> LibrosAcademicos { get; set; }
        public virtual DbSet<ManualesPractica> ManualesPractica { get; set; }
        public virtual DbSet<MapaCurricular> MapaCurricular { get; set; }
        public virtual DbSet<MateriaDidactico> MateriaDidactico { get; set; }
        public virtual DbSet<NombreTitulo> NombreTitulo { get; set; }
        public virtual DbSet<PafisAcademicos> PafisAcademicos { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<ParticipacionPladea> ParticipacionPladea { get; set; }
        public virtual DbSet<PatentesAcademicos> PatentesAcademicos { get; set; }
        public virtual DbSet<PonenciasConferencias> PonenciasConferencias { get; set; }
        public virtual DbSet<ProgramaEducativo> ProgramaEducativo { get; set; }
        public virtual DbSet<ProgramasTrasversales> ProgramasTrasversales { get; set; }
        public virtual DbSet<ProyectoEducativos> ProyectoEducativos { get; set; }
        public virtual DbSet<RecursosExternos> RecursosExternos { get; set; }
        public virtual DbSet<RediseñoPlanEstudios> RediseñoPlanEstudios { get; set; }
        public virtual DbSet<ReportesTecnicos> ReportesTecnicos { get; set; }
        public virtual DbSet<Revistas> Revistas { get; set; }
        public virtual DbSet<TbBuzonAcademicos> TbBuzonAcademicos { get; set; }
        public virtual DbSet<TbBuzonDeQuejas> TbBuzonDeQuejas { get; set; }
        public virtual DbSet<TbCalificacion> TbCalificacion { get; set; }
        public virtual DbSet<TbCalificacionTutor> TbCalificacionTutor { get; set; }
        public virtual DbSet<TbEventos> TbEventos { get; set; }
        public virtual DbSet<TbExamenalumno> TbExamenalumno { get; set; }
        public virtual DbSet<TbHorario> TbHorario { get; set; }
        public virtual DbSet<TbInstanciafinalAlumno> TbInstanciafinalAlumno { get; set; }
        public virtual DbSet<TbMovilidad> TbMovilidad { get; set; }
        public virtual DbSet<TbPafisAlumno> TbPafisAlumno { get; set; }
        public virtual DbSet<TbRubrosexamenes> TbRubrosexamenes { get; set; }
        public virtual DbSet<TbSalones> TbSalones { get; set; }
        public virtual DbSet<TbServiciopracticas> TbServiciopracticas { get; set; }
        public virtual DbSet<TipoCertificacion> TipoCertificacion { get; set; }
        public virtual DbSet<TipoContratacionee> TipoContratacionee { get; set; }
        public virtual DbSet<TipoDistincionTa> TipoDistincionTa { get; set; }
        public virtual DbSet<TipoEvaluador> TipoEvaluador { get; set; }
        public virtual DbSet<TipoEventos> TipoEventos { get; set; }
        public virtual DbSet<TipoLaboratorio> TipoLaboratorio { get; set; }
        public virtual DbSet<TipoLocNacInter> TipoLocNacInter { get; set; }
        public virtual DbSet<TipoModalidad> TipoModalidad { get; set; }
        public virtual DbSet<TipoPeriodo> TipoPeriodo { get; set; }
        public virtual DbSet<TipoPersonal> TipoPersonal { get; set; }
        public virtual DbSet<TipoPuesto> TipoPuesto { get; set; }
        public virtual DbSet<TipoTramiteAcademicos> TipoTramiteAcademicos { get; set; }
        public virtual DbSet<TipoTramiteAlumnos> TipoTramiteAlumnos { get; set; }
        public virtual DbSet<TrabajosRecepcionales> TrabajosRecepcionales { get; set; }
        public virtual DbSet<TramitesAcademicos> TramitesAcademicos { get; set; }
        public virtual DbSet<TramitesAlumnos> TramitesAlumnos { get; set; }
        public virtual DbSet<TutoradosExternos> TutoradosExternos { get; set; }
        public virtual DbSet<Tutores> Tutores { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=sgcfiee;User=root;Password=1234567890;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Academias>(entity =>
            {
                entity.HasKey(e => e.IdAcademias)
                    .HasName("PRIMARY");

                entity.ToTable("academias");

                entity.Property(e => e.IdAcademias).HasColumnName("idAcademias");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Academicoarticulos>(entity =>
            {
                entity.HasKey(e => e.IdAcademicoArticulos)
                    .HasName("PRIMARY");

                entity.ToTable("academicoarticulos");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_academico_idx");

                entity.HasIndex(e => e.IdArticulo)
                    .HasName("fk_tabla_articulos_idx");

                entity.Property(e => e.IdAcademicoArticulos).HasColumnName("idAcademicoArticulos");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdArticulo).HasColumnName("idArticulo");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicoarticulos)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_acadArticulo_academico");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.Academicoarticulos)
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("fk_tabla_articulos");
            });

            modelBuilder.Entity<Academicocaplibro>(entity =>
            {
                entity.HasKey(e => e.IdAcademicoCapLibro)
                    .HasName("PRIMARY");

                entity.ToTable("academicocaplibro");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_academico_idx");

                entity.HasIndex(e => e.IdCapLibro)
                    .HasName("fk_tabla_capLibro_idx");

                entity.Property(e => e.IdAcademicoCapLibro).HasColumnName("idAcademicoCapLibro");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdCapLibro).HasColumnName("idCapLibro");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicocaplibro)
                    .HasForeignKey(d => d.IdAcademico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tablaCapLibro_academico");

                entity.HasOne(d => d.IdCapLibroNavigation)
                    .WithMany(p => p.Academicocaplibro)
                    .HasForeignKey(d => d.IdCapLibro)
                    .HasConstraintName("fk_tabla_capLibro");
            });

            modelBuilder.Entity<Academicoconcursos>(entity =>
            {
                entity.HasKey(e => e.IdAcademicoConcursos)
                    .HasName("PRIMARY");

                entity.ToTable("academicoconcursos");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_academicos_idx");

                entity.HasIndex(e => e.IdConcursos)
                    .HasName("fk_tabla_concursos_idx");

                entity.Property(e => e.IdAcademicoConcursos).HasColumnName("idAcademicoConcursos");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdConcursos).HasColumnName("idConcursos");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicoconcursos)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_AcadConcurso_academicos");

                entity.HasOne(d => d.IdConcursosNavigation)
                    .WithMany(p => p.Academicoconcursos)
                    .HasForeignKey(d => d.IdConcursos)
                    .HasConstraintName("fk_tabla_concursos");
            });

            modelBuilder.Entity<Academicocongresos>(entity =>
            {
                entity.HasKey(e => e.IdAcademicoCongresos)
                    .HasName("PRIMARY");

                entity.ToTable("academicocongresos");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_Academico_idx");

                entity.HasIndex(e => e.IdCongreso)
                    .HasName("fk_tabla_Congreso_idx");

                entity.Property(e => e.IdAcademicoCongresos).HasColumnName("idAcademicoCongresos");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdCongreso).HasColumnName("idCongreso");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicocongresos)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_acadcongreso_Academico");

                entity.HasOne(d => d.IdCongresoNavigation)
                    .WithMany(p => p.Academicocongresos)
                    .HasForeignKey(d => d.IdCongreso)
                    .HasConstraintName("fk_tabla_Congreso");
            });

            modelBuilder.Entity<Academicolibro>(entity =>
            {
                entity.HasKey(e => e.IdAcademicoLibro)
                    .HasName("PRIMARY");

                entity.ToTable("academicolibro");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_Academico_idx");

                entity.HasIndex(e => e.IdLibroAcad)
                    .HasName("fk_tabla_Libro_idx");

                entity.Property(e => e.IdAcademicoLibro).HasColumnName("idAcademicoLibro");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdLibroAcad).HasColumnName("idLibroAcad");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicolibro)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_acadLibro_Academico");

                entity.HasOne(d => d.IdLibroAcadNavigation)
                    .WithMany(p => p.Academicolibro)
                    .HasForeignKey(d => d.IdLibroAcad)
                    .HasConstraintName("fk_tabla_Libro");
            });

            modelBuilder.Entity<Academicoponenciasconf>(entity =>
            {
                entity.HasKey(e => e.IdAcademicoPonenciasConf)
                    .HasName("PRIMARY");

                entity.ToTable("academicoponenciasconf");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_academicos_idx");

                entity.HasIndex(e => e.IdPonenciasConf)
                    .HasName("fk_tabla_ponenciaconf_idx");

                entity.Property(e => e.IdAcademicoPonenciasConf).HasColumnName("idAcademicoPonenciasConf");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdPonenciasConf).HasColumnName("idPonenciasConf");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicoponenciasconf)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_AcadPonencia_academicos");

                entity.HasOne(d => d.IdPonenciasConfNavigation)
                    .WithMany(p => p.Academicoponenciasconf)
                    .HasForeignKey(d => d.IdPonenciasConf)
                    .HasConstraintName("fk_tabla_ponenciaconf");
            });

            modelBuilder.Entity<Academicoreportest>(entity =>
            {
                entity.HasKey(e => e.IdAcademicoReportesT)
                    .HasName("PRIMARY");

                entity.ToTable("academicoreportest");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_academicos_idx");

                entity.HasIndex(e => e.IdReportesTec)
                    .HasName("fk_tabla_reportes_idx");

                entity.Property(e => e.IdAcademicoReportesT).HasColumnName("idAcademicoReportesT");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdReportesTec).HasColumnName("idReportesTec");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicoreportest)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_tabla_academicos");

                entity.HasOne(d => d.IdReportesTecNavigation)
                    .WithMany(p => p.Academicoreportest)
                    .HasForeignKey(d => d.IdReportesTec)
                    .HasConstraintName("fk_tabla_reportes");
            });

            modelBuilder.Entity<Academicorevistas>(entity =>
            {
                entity.HasKey(e => e.IdAcademicorevistas)
                    .HasName("PRIMARY");

                entity.ToTable("academicorevistas");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_academico_idx");

                entity.HasIndex(e => e.IdRevista)
                    .HasName("fk_tabla_revistas_idx");

                entity.Property(e => e.IdAcademicorevistas).HasColumnName("idAcademicorevistas");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdRevista).HasColumnName("idRevista");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicorevistas)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_tabla_academico");

                entity.HasOne(d => d.IdRevistaNavigation)
                    .WithMany(p => p.Academicorevistas)
                    .HasForeignKey(d => d.IdRevista)
                    .HasConstraintName("fk_tabla_revistas");
            });

            modelBuilder.Entity<Academicos>(entity =>
            {
                entity.HasKey(e => e.IdAcademicos)
                    .HasName("PRIMARY");

                entity.ToTable("academicos");

                entity.HasIndex(e => e.IdProgramaEducativo)
                    .HasName("fk_academicos_programaE_idx");

                entity.HasIndex(e => e.RTipoPersonal)
                    .HasName("fk_academicos_Tipo_Personal_idx");

                entity.Property(e => e.IdAcademicos).HasColumnName("idAcademicos");

                entity.Property(e => e.ApellidoMaterno)
                    .HasColumnName("Apellido_Materno")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.ApellidoPaterno)
                    .HasColumnName("Apellido_Paterno")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Celular).HasColumnType("varchar(45)");

                entity.Property(e => e.CorreoAlternativo)
                    .HasColumnName("Correo_Alternativo")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.CorreoInstitucional)
                    .HasColumnName("Correo_Institucional")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Curp)
                    .HasColumnName("CURP")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.FechaIngresoUv)
                    .HasColumnName("Fecha_ingreso_uv")
                    .HasColumnType("date");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("Fecha_Nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IdProgramaEducativo).HasColumnName("Id_ProgramaEducativo");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.Property(e => e.RTipoPersonal).HasColumnName("R_Tipo_Personal");

                entity.Property(e => e.Rfc)
                    .HasColumnName("RFC")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Sexo).HasColumnName("sexo");

                entity.HasOne(d => d.IdProgramaEducativoNavigation)
                    .WithMany(p => p.Academicos)
                    .HasForeignKey(d => d.IdProgramaEducativo)
                    .HasConstraintName("fk_academicos_programaE");

                entity.HasOne(d => d.RTipoPersonalNavigation)
                    .WithMany(p => p.Academicos)
                    .HasForeignKey(d => d.RTipoPersonal)
                    .HasConstraintName("fk_academicos_Tipo_Personal");
            });

            modelBuilder.Entity<Academicoscuerposacad>(entity =>
            {
                entity.HasKey(e => e.IdAcademicosCuerposAcad)
                    .HasName("PRIMARY");

                entity.ToTable("academicoscuerposacad");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_academicos_idx");

                entity.HasIndex(e => e.IdCuerpoAcad)
                    .HasName("fk_tabla_cuerpo_idx");

                entity.Property(e => e.IdAcademicosCuerposAcad).HasColumnName("idAcademicosCuerposAcad");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdCuerpoAcad).HasColumnName("idCuerpoAcad");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicoscuerposacad)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_AcadCuerpo_academicos");

                entity.HasOne(d => d.IdCuerpoAcadNavigation)
                    .WithMany(p => p.Academicoscuerposacad)
                    .HasForeignKey(d => d.IdCuerpoAcad)
                    .HasConstraintName("fk_tabla_cuerpo");
            });

            modelBuilder.Entity<Academicoscursostaller>(entity =>
            {
                entity.HasKey(e => e.IdAcademicosCursosTaller)
                    .HasName("PRIMARY");

                entity.ToTable("academicoscursostaller");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_academico_idx");

                entity.HasIndex(e => e.IdCursosDiplo)
                    .HasName("fk_tabla_CursoTaller_idx");

                entity.Property(e => e.IdAcademicosCursosTaller).HasColumnName("idAcademicosCursosTaller");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdCursosDiplo).HasColumnName("idCursosDiplo");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicoscursostaller)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_AcadCurso_academico");

                entity.HasOne(d => d.IdCursosDiploNavigation)
                    .WithMany(p => p.Academicoscursostaller)
                    .HasForeignKey(d => d.IdCursosDiplo)
                    .HasConstraintName("fk_AcadCursos_CursoTaller");
            });

            modelBuilder.Entity<Academicosevaluadores>(entity =>
            {
                entity.HasKey(e => e.IdAcademicosEvaluadores)
                    .HasName("PRIMARY");

                entity.ToTable("academicosevaluadores");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_academicos_idx");

                entity.HasIndex(e => e.IdEvaluadores)
                    .HasName("fk_tabla_evaluadores_idx");

                entity.Property(e => e.IdAcademicosEvaluadores).HasColumnName("idAcademicosEvaluadores");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdEvaluadores).HasColumnName("idEvaluadores");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicosevaluadores)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_AcadEval_academicos");

                entity.HasOne(d => d.IdEvaluadoresNavigation)
                    .WithMany(p => p.Academicosevaluadores)
                    .HasForeignKey(d => d.IdEvaluadores)
                    .HasConstraintName("fk_tabla_evaluadores");
            });

            modelBuilder.Entity<Academicosjuradorecep>(entity =>
            {
                entity.HasKey(e => e.IdAcademicosJuradoRecep)
                    .HasName("PRIMARY");

                entity.ToTable("academicosjuradorecep");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_academico_idx");

                entity.HasIndex(e => e.IdJurado)
                    .HasName("fk_tabla_jurado_idx");

                entity.Property(e => e.IdAcademicosJuradoRecep).HasColumnName("idAcademicosJuradoRecep");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdJurado).HasColumnName("idJurado");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicosjuradorecep)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_AcadJurRecep_academico");

                entity.HasOne(d => d.IdJuradoNavigation)
                    .WithMany(p => p.Academicosjuradorecep)
                    .HasForeignKey(d => d.IdJurado)
                    .HasConstraintName("fk_tabla_jurado");
            });

            modelBuilder.Entity<Academicosjuroposicion>(entity =>
            {
                entity.HasKey(e => e.IdAcademicosJurOposicion)
                    .HasName("PRIMARY");

                entity.ToTable("academicosjuroposicion");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_academico_idx");

                entity.HasIndex(e => e.IdJurado)
                    .HasName("fk_tabla_jurado_idx");

                entity.Property(e => e.IdAcademicosJurOposicion).HasColumnName("idAcademicosJurOposicion");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdJurado).HasColumnName("idJurado");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicosjuroposicion)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_AcadJurOpo_academico");

                entity.HasOne(d => d.IdJuradoNavigation)
                    .WithMany(p => p.Academicosjuroposicion)
                    .HasForeignKey(d => d.IdJurado)
                    .HasConstraintName("fk_tablaJurOpo_jurado");
            });

            modelBuilder.Entity<Academicospatentes>(entity =>
            {
                entity.HasKey(e => e.IdAcademicosPatentes)
                    .HasName("PRIMARY");

                entity.ToTable("academicospatentes");

                entity.HasIndex(e => e.IdAcademicos)
                    .HasName("fk_tabla_academicos_idx");

                entity.HasIndex(e => e.IdPatentes)
                    .HasName("fk_tabla_patentes_idx");

                entity.Property(e => e.IdAcademicosPatentes).HasColumnName("idAcademicosPatentes");

                entity.Property(e => e.IdAcademicos).HasColumnName("idAcademicos");

                entity.Property(e => e.IdPatentes).HasColumnName("idPatentes");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicosNavigation)
                    .WithMany(p => p.Academicospatentes)
                    .HasForeignKey(d => d.IdAcademicos)
                    .HasConstraintName("fk_tablaPatente_academicos");

                entity.HasOne(d => d.IdPatentesNavigation)
                    .WithMany(p => p.Academicospatentes)
                    .HasForeignKey(d => d.IdPatentes)
                    .HasConstraintName("fk_tabla_patentes");
            });

            modelBuilder.Entity<Academicotrabajosrecep>(entity =>
            {
                entity.HasKey(e => e.IdAcademicoTrabajosRecep)
                    .HasName("PRIMARY");

                entity.ToTable("academicotrabajosrecep");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_tabla_academico_idx");

                entity.HasIndex(e => e.IdTrabajosRecep)
                    .HasName("fk_tabla_trabajosrecep_idx");

                entity.Property(e => e.IdAcademicoTrabajosRecep).HasColumnName("idAcademicoTrabajosRecep");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdTrabajosRecep).HasColumnName("idTrabajosRecep");

                entity.Property(e => e.Lider).HasColumnName("lider");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Academicotrabajosrecep)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_tablaTrabajos_academico");

                entity.HasOne(d => d.IdTrabajosRecepNavigation)
                    .WithMany(p => p.Academicotrabajosrecep)
                    .HasForeignKey(d => d.IdTrabajosRecep)
                    .HasConstraintName("fk_tabla_trabajosrecep");
            });

            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.IdAlumnos)
                    .HasName("PRIMARY");

                entity.ToTable("alumnos");

                entity.HasIndex(e => e.RDatosPerson)
                    .HasName("fk_alumnos_datos_idx");

                entity.HasIndex(e => e.RProgramaEducativo)
                    .HasName("fk_alumno_programaedu_idx");

                entity.Property(e => e.IdAlumnos).HasColumnName("idAlumnos");

                entity.Property(e => e.AnioIngreso).HasColumnName("Anio_Ingreso");

                entity.Property(e => e.Bachillerato).HasColumnType("varchar(200)");

                entity.Property(e => e.CorreoInstitucional)
                    .HasColumnName("Correo_Institucional")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Matricula).HasColumnType("varchar(45)");

                entity.Property(e => e.Modalidad).HasColumnType("varchar(200)");

                entity.Property(e => e.RDatosPerson).HasColumnName("R_Datos_Person");

                entity.Property(e => e.RProgramaEducativo).HasColumnName("R_ProgramaEducativo");

                entity.Property(e => e.RStatus).HasColumnName("R_Status");

                entity.HasOne(d => d.RDatosPersonNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.RDatosPerson)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_alumnos_datos");

                entity.HasOne(d => d.RProgramaEducativoNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.RProgramaEducativo)
                    .HasConstraintName("fk_alumno_programaedu");
            });

            modelBuilder.Entity<AreaExperienciaEducativa>(entity =>
            {
                entity.HasKey(e => e.IdAreaExperienciaEducativa)
                    .HasName("PRIMARY");

                entity.ToTable("area_experiencia_educativa");

                entity.Property(e => e.IdAreaExperienciaEducativa).HasColumnName("idArea_Experiencia_Educativa");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Articulos>(entity =>
            {
                entity.HasKey(e => e.IdArticulos)
                    .HasName("PRIMARY");

                entity.ToTable("articulos");

                entity.HasIndex(e => e.IdTipoNI)
                    .HasName("fk_Arti_N_I_idx");

                entity.Property(e => e.IdArticulos).HasColumnName("id_articulos");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdTipoNI).HasColumnName("id_tipoN_I");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdTipoNINavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdTipoNI)
                    .HasConstraintName("fk_Arti_N_I");
            });

            modelBuilder.Entity<Asistencias>(entity =>
            {
                entity.HasKey(e => e.IdAsistencias)
                    .HasName("PRIMARY");

                entity.ToTable("asistencias");

                entity.HasIndex(e => e.RAcademicos)
                    .HasName("fk_asistencias_academicos_idx");

                entity.Property(e => e.IdAsistencias).HasColumnName("idAsistencias");

                entity.Property(e => e.Entrada).HasColumnType("time");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.HorasDescontadas).HasColumnName("Horas_descontadas");

                entity.Property(e => e.Observaciones).HasColumnType("varchar(500)");

                entity.Property(e => e.RAcademicos).HasColumnName("R_academicos");

                entity.Property(e => e.Salida).HasColumnType("time");

                entity.HasOne(d => d.RAcademicosNavigation)
                    .WithMany(p => p.Asistencias)
                    .HasForeignKey(d => d.RAcademicos)
                    .HasConstraintName("fk_asistencias_academicos");
            });

            modelBuilder.Entity<CaAcademicos>(entity =>
            {
                entity.HasKey(e => e.IdCa)
                    .HasName("PRIMARY");

                entity.ToTable("ca_academicos");

                entity.HasIndex(e => e.IdCanivelJerarquico)
                    .HasName("fk_cuerpoacademico_nivel_idx");

                entity.HasIndex(e => e.IdCuerpoAcademico)
                    .HasName("fk_cuerpoacademico_tipo_idx");

                entity.Property(e => e.IdCa).HasColumnName("id_CA");

                entity.Property(e => e.Archivo)
                    .HasColumnName("archivo")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("Fecha_Registro")
                    .HasColumnType("date");

                entity.Property(e => e.IdCanivelJerarquico).HasColumnName("id_CANivel_jerarquico");

                entity.Property(e => e.IdCuerpoAcademico).HasColumnName("id_cuerpo_academico");

                entity.HasOne(d => d.IdCanivelJerarquicoNavigation)
                    .WithMany(p => p.CaAcademicos)
                    .HasForeignKey(d => d.IdCanivelJerarquico)
                    .HasConstraintName("fk_cuerpoacademico_nivel");

                entity.HasOne(d => d.IdCuerpoAcademicoNavigation)
                    .WithMany(p => p.CaAcademicos)
                    .HasForeignKey(d => d.IdCuerpoAcademico)
                    .HasConstraintName("fk_cuerpoacademico_tipo");
            });

            modelBuilder.Entity<CaAlumnos>(entity =>
            {
                entity.HasKey(e => e.IdCa)
                    .HasName("PRIMARY");

                entity.ToTable("ca_alumnos");

                entity.HasIndex(e => e.IdAlumno)
                    .HasName("id_alumnos_idx");

                entity.HasIndex(e => e.IdCanivelJerarquico)
                    .HasName("id_jerarquia_idx");

                entity.HasIndex(e => e.IdCuerpoAcademico)
                    .HasName("id_cuerpo_academico_idx");

                entity.Property(e => e.IdCa).HasColumnName("id_CA");

                entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");

                entity.Property(e => e.IdCanivelJerarquico).HasColumnName("id_CANivel_jerarquico");

                entity.Property(e => e.IdCuerpoAcademico).HasColumnName("id_cuerpo_academico");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.CaAlumnos)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_alumnos");

                entity.HasOne(d => d.IdCanivelJerarquicoNavigation)
                    .WithMany(p => p.CaAlumnos)
                    .HasForeignKey(d => d.IdCanivelJerarquico)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_jerarquia");

                entity.HasOne(d => d.IdCuerpoAcademicoNavigation)
                    .WithMany(p => p.CaAlumnos)
                    .HasForeignKey(d => d.IdCuerpoAcademico)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_cuerpo_academico");
            });

            modelBuilder.Entity<CanivelJerarquico>(entity =>
            {
                entity.HasKey(e => e.IdCanivelJerarquico)
                    .HasName("PRIMARY");

                entity.ToTable("canivel_jerarquico");

                entity.Property(e => e.IdCanivelJerarquico).HasColumnName("id_CANivel_jerarquico");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<CapLibro>(entity =>
            {
                entity.HasKey(e => e.IdCapLibro)
                    .HasName("PRIMARY");

                entity.ToTable("cap_libro");

                entity.HasIndex(e => e.IdEditorial)
                    .HasName("fk_CapL_Editorial_idx");

                entity.Property(e => e.IdCapLibro).HasColumnName("id_cap_Libro");

                entity.Property(e => e.Anio).HasColumnName("anio");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdEditorial).HasColumnName("id_Editorial");

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Titulo).HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.CapLibro)
                    .HasForeignKey(d => d.IdEditorial)
                    .HasConstraintName("fk_CapL_Editorial");
            });

            modelBuilder.Entity<Certificaciones>(entity =>
            {
                entity.HasKey(e => e.IdCertificaciones)
                    .HasName("PRIMARY");

                entity.ToTable("certificaciones");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_certificacion_academicos_idx");

                entity.HasIndex(e => e.IdTipoCertificacion)
                    .HasName("fk_certificacion_certificacion_idx");

                entity.Property(e => e.IdCertificaciones).HasColumnName("id_certificaciones");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdAcademico).HasColumnName("id_Academico");

                entity.Property(e => e.IdTipoCertificacion).HasColumnName("id_tipo_certificacion");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Certificaciones)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_certificacion_academicos");

                entity.HasOne(d => d.IdTipoCertificacionNavigation)
                    .WithMany(p => p.Certificaciones)
                    .HasForeignKey(d => d.IdTipoCertificacion)
                    .HasConstraintName("fk_certificacion_certificacion");
            });

            modelBuilder.Entity<Concursos>(entity =>
            {
                entity.HasKey(e => e.IdConcursos)
                    .HasName("PRIMARY");

                entity.ToTable("concursos");

                entity.HasIndex(e => e.IdNacInter)
                    .HasName("fk_concursos_NacInt_idx");

                entity.Property(e => e.IdConcursos).HasColumnName("id_concursos");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdNacInter).HasColumnName("id_Nac_Inter");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdNacInterNavigation)
                    .WithMany(p => p.Concursos)
                    .HasForeignKey(d => d.IdNacInter)
                    .HasConstraintName("fk_concursos_NacInt");
            });

            modelBuilder.Entity<Congresos>(entity =>
            {
                entity.HasKey(e => e.IdCongresos)
                    .HasName("PRIMARY");

                entity.ToTable("congresos");

                entity.HasIndex(e => e.IdNacInt)
                    .HasName("fk_congresos_N_I_idx");

                entity.Property(e => e.IdCongresos).HasColumnName("id_congresos");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdNacInt).HasColumnName("id_Nac_Int");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdNacIntNavigation)
                    .WithMany(p => p.Congresos)
                    .HasForeignKey(d => d.IdNacInt)
                    .HasConstraintName("fk_congresos_N_I");
            });

            modelBuilder.Entity<ConsejoTecnico>(entity =>
            {
                entity.HasKey(e => e.IdConsejoTecnico)
                    .HasName("PRIMARY");

                entity.ToTable("consejo_tecnico");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_CT_academicos_idx");

                entity.HasIndex(e => e.IdFechaCierre)
                    .HasName("fk_CT_periodo2_idx");

                entity.HasIndex(e => e.IdFechaInicial)
                    .HasName("fk_CT_periodo_idx");

                entity.Property(e => e.IdConsejoTecnico).HasColumnName("idConsejo_tecnico");

                entity.Property(e => e.ArchivoActaA)
                    .HasColumnName("Archivo_ActaA")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdFechaCierre).HasColumnName("id_Fecha_Cierre");

                entity.Property(e => e.IdFechaInicial).HasColumnName("id_Fecha_Inicial");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.ConsejoTecnico)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_CT_acade");

                entity.HasOne(d => d.IdFechaCierreNavigation)
                    .WithMany(p => p.ConsejoTecnicoIdFechaCierreNavigation)
                    .HasForeignKey(d => d.IdFechaCierre)
                    .HasConstraintName("fk_CT_periodo2");

                entity.HasOne(d => d.IdFechaInicialNavigation)
                    .WithMany(p => p.ConsejoTecnicoIdFechaInicialNavigation)
                    .HasForeignKey(d => d.IdFechaInicial)
                    .HasConstraintName("fk_CT_periodo1");
            });

            modelBuilder.Entity<ContratacionPtc>(entity =>
            {
                entity.HasKey(e => e.IdContrato)
                    .HasName("PRIMARY");

                entity.ToTable("contratacion_ptc");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_contratacion_ptc_academicos_idx");

                entity.HasIndex(e => e.IdContrato)
                    .HasName("id_contrato_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdContrato).HasColumnName("id_contrato");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.FechaNombramiento)
                    .HasColumnName("fecha_nombramiento")
                    .HasColumnType("date");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.ContratacionPtc)
                    .HasForeignKey(d => d.IdAcademico)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_contratacion_ptc_academicos");
            });

            modelBuilder.Entity<CoordinadorAcademia>(entity =>
            {
                entity.HasKey(e => e.IdCoordinadorAcademia)
                    .HasName("PRIMARY");

                entity.ToTable("coordinador_academia");

                entity.HasIndex(e => e.IdAcadademia)
                    .HasName("fk_CA_academias_idx");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_CA_academicos_idx");

                entity.HasIndex(e => e.IdFechaCierre)
                    .HasName("fk_CA_periodo2_idx");

                entity.HasIndex(e => e.IdFechaInicial)
                    .HasName("fk_CA_periodo1_idx");

                entity.Property(e => e.IdCoordinadorAcademia).HasColumnName("idCoordinador_Academia");

                entity.Property(e => e.ArchivoActaA)
                    .HasColumnName("Archivo_ActaA")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.IdAcadademia).HasColumnName("id_acadademia");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdFechaCierre).HasColumnName("id_Fecha_cierre");

                entity.Property(e => e.IdFechaInicial).HasColumnName("id_Fecha_Inicial");

                entity.HasOne(d => d.IdAcadademiaNavigation)
                    .WithMany(p => p.CoordinadorAcademia)
                    .HasForeignKey(d => d.IdAcadademia)
                    .HasConstraintName("fk_CA_academias");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.CoordinadorAcademia)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_CA_academicos");

                entity.HasOne(d => d.IdFechaCierreNavigation)
                    .WithMany(p => p.CoordinadorAcademiaIdFechaCierreNavigation)
                    .HasForeignKey(d => d.IdFechaCierre)
                    .HasConstraintName("fk_CA_periodo2");

                entity.HasOne(d => d.IdFechaInicialNavigation)
                    .WithMany(p => p.CoordinadorAcademiaIdFechaInicialNavigation)
                    .HasForeignKey(d => d.IdFechaInicial)
                    .HasConstraintName("fk_CA_periodo1");
            });

            modelBuilder.Entity<CoordinadorProgramaTransversal>(entity =>
            {
                entity.HasKey(e => e.IdCoordinadorProgramaTransversal)
                    .HasName("PRIMARY");

                entity.ToTable("coordinador_programa_transversal");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_CPT_academicos_idx");

                entity.HasIndex(e => e.IdFechaCierre)
                    .HasName("fk_CPT_periodo2_idx");

                entity.HasIndex(e => e.IdFechaInicial)
                    .HasName("fk_CPT_periodo1_idx");

                entity.HasIndex(e => e.IdPt)
                    .HasName("fk_CPT_ProgramasT_idx");

                entity.Property(e => e.IdCoordinadorProgramaTransversal).HasColumnName("idCoordinador_Programa_Transversal");

                entity.Property(e => e.Evidencia)
                    .HasColumnName("evidencia")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdFechaCierre).HasColumnName("id_Fecha_cierre");

                entity.Property(e => e.IdFechaInicial).HasColumnName("id_Fecha_Inicial");

                entity.Property(e => e.IdPt).HasColumnName("id_PT");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.CoordinadorProgramaTransversal)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_CPT_academicos");

                entity.HasOne(d => d.IdFechaCierreNavigation)
                    .WithMany(p => p.CoordinadorProgramaTransversalIdFechaCierreNavigation)
                    .HasForeignKey(d => d.IdFechaCierre)
                    .HasConstraintName("fk_CPT_periodo2");

                entity.HasOne(d => d.IdFechaInicialNavigation)
                    .WithMany(p => p.CoordinadorProgramaTransversalIdFechaInicialNavigation)
                    .HasForeignKey(d => d.IdFechaInicial)
                    .HasConstraintName("fk_CPT_periodo1");

                entity.HasOne(d => d.IdPtNavigation)
                    .WithMany(p => p.CoordinadorProgramaTransversal)
                    .HasForeignKey(d => d.IdPt)
                    .HasConstraintName("fk_CPT_ProgramasT");
            });

            modelBuilder.Entity<CtEmpresaServPrac>(entity =>
            {
                entity.HasKey(e => e.IdCtEmpresas)
                    .HasName("PRIMARY");

                entity.ToTable("ct_empresa_serv_prac");

                entity.Property(e => e.IdCtEmpresas).HasColumnName("idCt_Empresas");

                entity.Property(e => e.Direccion).HasColumnType("varchar(200)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.Property(e => e.Telefono).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<CtExperienciarecepcional>(entity =>
            {
                entity.HasKey(e => e.IdCtExperienciaRecepcional)
                    .HasName("PRIMARY");

                entity.ToTable("ct_experienciarecepcional");

                entity.HasIndex(e => e.RAsesor)
                    .HasName("fk_asesorAcademico_er_idx");

                entity.Property(e => e.IdCtExperienciaRecepcional).HasColumnName("idCt_ExperienciaRecepcional");

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.Property(e => e.RAsesor).HasColumnName("R_Asesor");

                entity.HasOne(d => d.RAsesorNavigation)
                    .WithMany(p => p.CtExperienciarecepcional)
                    .HasForeignKey(d => d.RAsesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_asesorAcademico_er");
            });

            modelBuilder.Entity<CtMovilidades>(entity =>
            {
                entity.HasKey(e => e.IdCtMovilidades)
                    .HasName("PRIMARY");

                entity.ToTable("ct_movilidades");

                entity.Property(e => e.IdCtMovilidades).HasColumnName("idCt_Movilidades");

                entity.Property(e => e.EntidadDestinoMovilidad)
                    .HasColumnName("Entidad_destino_movilidad")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.EscuelaDestinoMovilidad)
                    .HasColumnName("Escuela_destino_movilidad")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PaisDestinoMovilidad)
                    .HasColumnName("Pais_destino_movilidad")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TiempoPermanenciaMovilidad)
                    .HasColumnName("Tiempo_permanencia_movilidad")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.TipoMovilidades).HasColumnName("tipo_movilidades");
            });

            modelBuilder.Entity<CtProblemas>(entity =>
            {
                entity.HasKey(e => e.IdCtProblemas)
                    .HasName("PRIMARY");

                entity.ToTable("ct_problemas");

                entity.Property(e => e.IdCtProblemas).HasColumnName("idCt_Problemas");

                entity.Property(e => e.NombreProblemas)
                    .HasColumnName("Nombre_Problemas")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<CtTipoCalificacion>(entity =>
            {
                entity.HasKey(e => e.IdCtTipoCalificacion)
                    .HasName("PRIMARY");

                entity.ToTable("ct_tipo_calificacion");

                entity.Property(e => e.IdCtTipoCalificacion).HasColumnName("id_Ct_Tipo_Calificacion");

                entity.Property(e => e.Tipo).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<CuerpoEstados>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PRIMARY");

                entity.ToTable("cuerpo_estados");

                entity.Property(e => e.IdEstado).HasColumnName("id_Estado");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<CuerposAcademicos>(entity =>
            {
                entity.HasKey(e => e.IdCuerpoAcademico)
                    .HasName("PRIMARY");

                entity.ToTable("cuerpos_academicos");

                entity.HasIndex(e => e.IdEstado)
                    .HasName("tk_cuerpo_estado_idx");

                entity.Property(e => e.IdCuerpoAcademico).HasColumnName("id_Cuerpo_Academico");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.CuerposAcademicos)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("tk_cuerpo_estado");
            });

            modelBuilder.Entity<CursosDiplomadoFormacion>(entity =>
            {
                entity.HasKey(e => e.IdCD)
                    .HasName("PRIMARY");

                entity.ToTable("cursos/diplomado_formacion");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_C/D_academicos_idx");

                entity.HasIndex(e => e.IdIesEmpresa)
                    .HasName("fk_C/D_Iinstituciones/Empresa_idx");

                entity.Property(e => e.IdCD).HasColumnName("id_C/D");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.CursoDiplomado).HasColumnName("Curso/Diplomado");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdIesEmpresa).HasColumnName("id_IES/Empresa");

                entity.Property(e => e.Lugar).HasColumnType("varchar(200)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.Property(e => e.PD).HasColumnName("P/D");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.CursosDiplomadoFormacion)
                    .HasForeignKey(d => d.IdAcademico)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_C_D_academicos");

                entity.HasOne(d => d.IdIesEmpresaNavigation)
                    .WithMany(p => p.CursosDiplomadoFormacion)
                    .HasForeignKey(d => d.IdIesEmpresa)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_C_D_Iinstituciones/Empresa");
            });

            modelBuilder.Entity<CursosTalleresAplicacion>(entity =>
            {
                entity.HasKey(e => e.IdCursosTalleres)
                    .HasName("PRIMARY");

                entity.ToTable("cursos/talleres_aplicacion");

                entity.Property(e => e.IdCursosTalleres).HasColumnName("id_Cursos_Talleres");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.CT).HasColumnName("C/T");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Titulo).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<DatosPersonales>(entity =>
            {
                entity.HasKey(e => e.IdDatosPersonales)
                    .HasName("PRIMARY");

                entity.ToTable("datos_personales");

                entity.Property(e => e.IdDatosPersonales).HasColumnName("id_Datos_Personales");

                entity.Property(e => e.ApellidoMaterno)
                    .HasColumnName("Apellido_Materno")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.ApellidoPaterno)
                    .HasColumnName("Apellido_Paterno")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Calle).HasColumnType("varchar(200)");

                entity.Property(e => e.Ciudad).HasColumnType("varchar(200)");

                entity.Property(e => e.CodigoPostal).HasColumnName("Codigo_Postal");

                entity.Property(e => e.Colonia).HasColumnType("varchar(200)");

                entity.Property(e => e.Correo).HasColumnType("varchar(200)");

                entity.Property(e => e.Curp)
                    .HasColumnName("CURP")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Estado).HasColumnType("varchar(45)");

                entity.Property(e => e.EstadoCivil)
                    .HasColumnName("Estado_Civil")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("Fecha_Nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IngresoMensual).HasColumnName("Ingreso_Mensual");

                entity.Property(e => e.Municipio).HasColumnType("varchar(200)");

                entity.Property(e => e.Nacionalidad).HasColumnType("varchar(200)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.Property(e => e.Pais).HasColumnType("varchar(45)");

                entity.Property(e => e.RecidenciaActual)
                    .HasColumnName("Recidencia_Actual")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Telefono).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<DistincionesTa>(entity =>
            {
                entity.HasKey(e => e.IdDistinciones)
                    .HasName("PRIMARY");

                entity.ToTable("distinciones_ta");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("id_academico_idx");

                entity.HasIndex(e => e.IdDistincion)
                    .HasName("id_distincion_idx");

                entity.HasIndex(e => e.IdDistinciones)
                    .HasName("id_distinciones_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdDistinciones).HasColumnName("id_distinciones");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdAcademico).HasColumnName("id_Academico");

                entity.Property(e => e.IdDistincion).HasColumnName("id_distincion");

                entity.Property(e => e.Vigencia)
                    .HasColumnName("vigencia")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.DistincionesTa)
                    .HasForeignKey(d => d.IdAcademico)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_academico");

                entity.HasOne(d => d.IdDistincionNavigation)
                    .WithMany(p => p.DistincionesTa)
                    .HasForeignKey(d => d.IdDistincion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_distincion");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.HasKey(e => e.IdEditorial)
                    .HasName("PRIMARY");

                entity.ToTable("editorial");

                entity.Property(e => e.IdEditorial).HasColumnName("idEditorial");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Estudios>(entity =>
            {
                entity.HasKey(e => e.IdEstudios)
                    .HasName("PRIMARY");

                entity.ToTable("estudios");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_estudios_academico_idx");

                entity.HasIndex(e => e.IdGradoTitulo)
                    .HasName("fk_estudios_grado_titulo_idx");

                entity.HasIndex(e => e.IdInstitucion)
                    .HasName("fk_estudios_institucion_idx");

                entity.HasIndex(e => e.IdNombreTitulo)
                    .HasName("fk_estudios_titulo_idx");

                entity.Property(e => e.IdEstudios).HasColumnName("idEstudios");

                entity.Property(e => e.AcrePnpc).HasColumnName("ACRE/PNPC");

                entity.Property(e => e.ArchivoCedula).HasColumnType("varchar(500)");

                entity.Property(e => e.ArchivoTitulo).HasColumnType("varchar(500)");

                entity.Property(e => e.FechaDeEgreso)
                    .HasColumnName("fecha_de_egreso")
                    .HasColumnType("date");

                entity.Property(e => e.FechaDeTitulacion)
                    .HasColumnName("fecha_de_titulacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdAcademico).HasColumnName("id_Academico");

                entity.Property(e => e.IdGradoTitulo).HasColumnName("id_grado_titulo");

                entity.Property(e => e.IdInstitucion).HasColumnName("idInstitucion");

                entity.Property(e => e.IdNombreTitulo).HasColumnName("idNombreTitulo");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Estudios)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_estudios_academico");

                entity.HasOne(d => d.IdGradoTituloNavigation)
                    .WithMany(p => p.Estudios)
                    .HasForeignKey(d => d.IdGradoTitulo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_estudios_grado_titulo");

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.Estudios)
                    .HasForeignKey(d => d.IdInstitucion)
                    .HasConstraintName("fk_estudios_institucion");

                entity.HasOne(d => d.IdNombreTituloNavigation)
                    .WithMany(p => p.Estudios)
                    .HasForeignKey(d => d.IdNombreTitulo)
                    .HasConstraintName("fk_estudios_titulo");
            });

            modelBuilder.Entity<EvaluacionConsejoTecnico>(entity =>
            {
                entity.HasKey(e => e.IdConsejoTecnico)
                    .HasName("PRIMARY");

                entity.ToTable("evaluacion_consejo_tecnico");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_CT_academicos_idx");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fk_ECT_tipo_periodo_idx");

                entity.Property(e => e.IdConsejoTecnico).HasColumnName("idConsejoTecnico");

                entity.Property(e => e.CalificacionDesempenio).HasColumnName("Calificacion_Desempenio");

                entity.Property(e => e.CalificacionGestion).HasColumnName("Calificacion_Gestion");

                entity.Property(e => e.IdAcademico).HasColumnName("Id_academico");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_Periodo");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.EvaluacionConsejoTecnico)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_CT_academicos");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.EvaluacionConsejoTecnico)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("fk_ECT_tipo_periodo");
            });

            modelBuilder.Entity<EvaluacionEstudiantes>(entity =>
            {
                entity.HasKey(e => e.IdEvaluacionEstudiantes)
                    .HasName("PRIMARY");

                entity.ToTable("evaluacion_estudiantes");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_evaluacionE_academico_idx");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fk_evaluacionE_tipo_periodo_idx");

                entity.Property(e => e.IdEvaluacionEstudiantes).HasColumnName("idEvaluacion_Estudiantes");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.EvaluacionEstudiantes)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_evaluacionE_academico");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.EvaluacionEstudiantes)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("fk_evaluacionE_tipo_periodo");
            });

            modelBuilder.Entity<EvaluadoresAcademicos>(entity =>
            {
                entity.HasKey(e => e.IdEvaluadoresAcademicos)
                    .HasName("PRIMARY");

                entity.ToTable("evaluadores_academicos");

                entity.HasIndex(e => e.IdTipoEvaluador)
                    .HasName("fk_evaluadores_tipo_idx");

                entity.Property(e => e.IdEvaluadoresAcademicos).HasColumnName("idEvaluadores_Academicos");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdTipoEvaluador).HasColumnName("idTipo_Evaluador");

                entity.Property(e => e.RevisorEvaluador).HasColumnName("Revisor/Evaluador");

                entity.HasOne(d => d.IdTipoEvaluadorNavigation)
                    .WithMany(p => p.EvaluadoresAcademicos)
                    .HasForeignKey(d => d.IdTipoEvaluador)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_evaluadores_tipo");
            });

            modelBuilder.Entity<EventosAlumnos>(entity =>
            {
                entity.HasKey(e => e.IdEventosAlumnos)
                    .HasName("PRIMARY");

                entity.ToTable("eventos_alumnos");

                entity.HasIndex(e => e.RAlumno)
                    .HasName("fk_eventos_alumnos_idx");

                entity.HasIndex(e => e.REvento)
                    .HasName("fk_eventos_eventos_fecha_idx");

                entity.Property(e => e.IdEventosAlumnos).HasColumnName("idEventos_Alumnos");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.RAlumno).HasColumnName("R_Alumno");

                entity.Property(e => e.REvento).HasColumnName("R_Evento");

                entity.HasOne(d => d.RAlumnoNavigation)
                    .WithMany(p => p.EventosAlumnos)
                    .HasForeignKey(d => d.RAlumno)
                    .HasConstraintName("fk_eventos_alumnos");

                entity.HasOne(d => d.REventoNavigation)
                    .WithMany(p => p.EventosAlumnos)
                    .HasForeignKey(d => d.REvento)
                    .HasConstraintName("fk_eventos_eventos");
            });

            modelBuilder.Entity<ExperienciaEducativa>(entity =>
            {
                entity.HasKey(e => e.IdExperienciaEducativa)
                    .HasName("PRIMARY");

                entity.ToTable("experiencia_educativa");

                entity.HasIndex(e => e.IdArea)
                    .HasName("fk_ee_area_idx");

                entity.Property(e => e.IdExperienciaEducativa).HasColumnName("idExperiencia_Educativa");

                entity.Property(e => e.IdArea).HasColumnName("idArea");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.ExperienciaEducativa)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("fk_ee_area");
            });

            modelBuilder.Entity<ExperienciaEducativaPeriodo>(entity =>
            {
                entity.HasKey(e => e.IdExperienciaEducativaPeriodo)
                    .HasName("PRIMARY");

                entity.ToTable("experiencia_educativa_periodo");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_eep_academicos_idx");

                entity.HasIndex(e => e.IdContratacionEe)
                    .HasName("fk_eep_TCEE_idx");

                entity.HasIndex(e => e.IdInstitucionSuperior)
                    .HasName("fk_eep_InstEmpr_idx");

                entity.HasIndex(e => e.IdMapaCurricular)
                    .HasName("fk_eep_mapaC_idx");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fk_eep_periodo_idx");

                entity.HasIndex(e => e.IdSalon)
                    .HasName("fk_eep_salones_idx");

                entity.Property(e => e.IdExperienciaEducativaPeriodo).HasColumnName("idExperiencia_Educativa_Periodo");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdContratacionEe).HasColumnName("id_ContratacionEE");

                entity.Property(e => e.IdInstitucionSuperior).HasColumnName("id_InstitucionSuperior");

                entity.Property(e => e.IdMapaCurricular).HasColumnName("id_mapa_curricular");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_Periodo");

                entity.Property(e => e.IdSalon).HasColumnName("id_Salon");

                entity.Property(e => e.Nrc).HasColumnName("NRC");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.ExperienciaEducativaPeriodo)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_eep_academicos");

                entity.HasOne(d => d.IdContratacionEeNavigation)
                    .WithMany(p => p.ExperienciaEducativaPeriodo)
                    .HasForeignKey(d => d.IdContratacionEe)
                    .HasConstraintName("fk_eep_TCEE");

                entity.HasOne(d => d.IdInstitucionSuperiorNavigation)
                    .WithMany(p => p.ExperienciaEducativaPeriodo)
                    .HasForeignKey(d => d.IdInstitucionSuperior)
                    .HasConstraintName("fk_eep_InstEmpr");

                entity.HasOne(d => d.IdMapaCurricularNavigation)
                    .WithMany(p => p.ExperienciaEducativaPeriodo)
                    .HasForeignKey(d => d.IdMapaCurricular)
                    .HasConstraintName("fk_eep_mapaC");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.ExperienciaEducativaPeriodo)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("fk_eep_periodo");

                entity.HasOne(d => d.IdSalonNavigation)
                    .WithMany(p => p.ExperienciaEducativaPeriodo)
                    .HasForeignKey(d => d.IdSalon)
                    .HasConstraintName("fk_eep_salones");
            });

            modelBuilder.Entity<ExperienciaProfesional>(entity =>
            {
                entity.HasKey(e => e.IdEp)
                    .HasName("PRIMARY");

                entity.ToTable("experiencia_profesional");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_Experiencia_academico_idx");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("fk_Esperiencia_Intituciones/Empresas_idx");

                entity.HasIndex(e => e.IdTipoPuesto)
                    .HasName("fk_Experiencia_Tipopuesto_idx");

                entity.Property(e => e.IdEp).HasColumnName("id_EP");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.AreaDesarrollo)
                    .HasColumnName("Area_Desarrollo")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fecha_fin")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fecha_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

                entity.Property(e => e.IdTipoPuesto).HasColumnName("id_tipo_puesto");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.ExperienciaProfesional)
                    .HasForeignKey(d => d.IdAcademico)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_Experiencia_academico");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.ExperienciaProfesional)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_Esperiencia_Intituciones/Empresas");

                entity.HasOne(d => d.IdTipoPuestoNavigation)
                    .WithMany(p => p.ExperienciaProfesional)
                    .HasForeignKey(d => d.IdTipoPuesto)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_Experiencia_Tipopuesto");
            });

            modelBuilder.Entity<GradoTitulo>(entity =>
            {
                entity.HasKey(e => e.IdGradoTitulo)
                    .HasName("PRIMARY");

                entity.ToTable("grado_titulo");

                entity.Property(e => e.IdGradoTitulo).HasColumnName("idGrado_Titulo");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<InstitucionesEmpresas>(entity =>
            {
                entity.HasKey(e => e.IdIE)
                    .HasName("PRIMARY");

                entity.ToTable("instituciones/empresas");

                entity.Property(e => e.IdIE).HasColumnName("id_I/E");

                entity.Property(e => e.IesEmpresa).HasColumnName("ies/empresa");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<JuradoExamenOposicion>(entity =>
            {
                entity.HasKey(e => e.IdJexposicion)
                    .HasName("PRIMARY");

                entity.ToTable("jurado_examen_oposicion");

                entity.HasIndex(e => e.IdEe)
                    .HasName("fk_Jexposicion_EE_idx");

                entity.Property(e => e.IdJexposicion).HasColumnName("id_JExposicion");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdEe).HasColumnName("id_EE");

                entity.Property(e => e.TipoExamen).HasColumnName("tipo_examen");

                entity.HasOne(d => d.IdEeNavigation)
                    .WithMany(p => p.JuradoExamenOposicion)
                    .HasForeignKey(d => d.IdEe)
                    .HasConstraintName("fk_exposicion_EE");
            });

            modelBuilder.Entity<JuradoExperienciaRecepcional>(entity =>
            {
                entity.HasKey(e => e.IdJer)
                    .HasName("PRIMARY");

                entity.ToTable("jurado_experiencia_recepcional");

                entity.HasIndex(e => e.IdTr)
                    .HasName("fk_JER_TR_idx");

                entity.Property(e => e.IdJer).HasColumnName("id_JER");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdTr).HasColumnName("id_TR");

                entity.Property(e => e.JuradoPrejurado).HasColumnName("Jurado/Prejurado");

                entity.HasOne(d => d.IdTrNavigation)
                    .WithMany(p => p.JuradoExperienciaRecepcional)
                    .HasForeignKey(d => d.IdTr)
                    .HasConstraintName("fk_JER_TR");
            });

            modelBuilder.Entity<Laboratorio>(entity =>
            {
                entity.HasKey(e => e.IdLaboratorio)
                    .HasName("PRIMARY");

                entity.ToTable("laboratorio");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_labo_academico_idx");

                entity.HasIndex(e => e.IdTipoLaboratorio)
                    .HasName("fk_labo_tipo_idx");

                entity.Property(e => e.IdLaboratorio).HasColumnName("id_Laboratorio");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdTipoLaboratorio).HasColumnName("id_tipo_laboratorio");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Laboratorio)
                    .HasForeignKey(d => d.IdAcademico)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_labo_academico");

                entity.HasOne(d => d.IdTipoLaboratorioNavigation)
                    .WithMany(p => p.Laboratorio)
                    .HasForeignKey(d => d.IdTipoLaboratorio)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_labo_tipo");
            });

            modelBuilder.Entity<Libroee>(entity =>
            {
                entity.HasKey(e => e.IdLibroEe)
                    .HasName("PRIMARY");

                entity.ToTable("libroee");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_libroEE_academico_idx");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fk_libroEE_TipoPeriodo_idx");

                entity.Property(e => e.IdLibroEe).HasColumnName("id_libroEE");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_Periodo");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Libroee)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_libroEE_academico");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.Libroee)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("fk_libroEE_TipoPeriodo");
            });

            modelBuilder.Entity<LibrosAcademicos>(entity =>
            {
                entity.HasKey(e => e.IdLibrosAcademicos)
                    .HasName("PRIMARY");

                entity.ToTable("libros_academicos");

                entity.HasIndex(e => e.IdEditorial)
                    .HasName("fk_libros_editorial_idx");

                entity.Property(e => e.IdLibrosAcademicos).HasColumnName("idLibros_Academicos");

                entity.Property(e => e.Anio).HasColumnName("anio");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdEditorial).HasColumnName("id_Editorial");

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.LibrosAcademicos)
                    .HasForeignKey(d => d.IdEditorial)
                    .HasConstraintName("fk_libros_editorial");
            });

            modelBuilder.Entity<ManualesPractica>(entity =>
            {
                entity.HasKey(e => e.IdMaterialesPractica)
                    .HasName("PRIMARY");

                entity.ToTable("manuales_practica");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_manuales_academicos_idx");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fk_manuales_idx");

                entity.Property(e => e.IdMaterialesPractica).HasColumnName("id_Materiales_Practica");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_Periodo");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.ManualesPractica)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_manuales_academicos");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.ManualesPractica)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("fk_manuales_TipoPeriodo");
            });

            modelBuilder.Entity<MapaCurricular>(entity =>
            {
                entity.HasKey(e => e.IdMapaCurricular)
                    .HasName("PRIMARY");

                entity.ToTable("mapa_curricular");

                entity.HasIndex(e => e.IdExperienciaEducativa)
                    .HasName("fk_mapa_ee_idx");

                entity.HasIndex(e => e.IdProgramaEducativo)
                    .HasName("fk_mapa_programaeducativo_idx");

                entity.Property(e => e.IdMapaCurricular).HasColumnName("idMapa_Curricular");

                entity.Property(e => e.IdExperienciaEducativa).HasColumnName("idExperienciaEducativa");

                entity.Property(e => e.IdProgramaEducativo).HasColumnName("idPrograma_Educativo");

                entity.HasOne(d => d.IdExperienciaEducativaNavigation)
                    .WithMany(p => p.MapaCurricular)
                    .HasForeignKey(d => d.IdExperienciaEducativa)
                    .HasConstraintName("fk_mapa_ee");

                entity.HasOne(d => d.IdProgramaEducativoNavigation)
                    .WithMany(p => p.MapaCurricular)
                    .HasForeignKey(d => d.IdProgramaEducativo)
                    .HasConstraintName("fk_mapa_programaeducativo");
            });

            modelBuilder.Entity<MateriaDidactico>(entity =>
            {
                entity.HasKey(e => e.IdMateriaDidactico)
                    .HasName("PRIMARY");

                entity.ToTable("materia_didactico");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_material_academico_idx");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fk_material_tipoperido_idx");

                entity.Property(e => e.IdMateriaDidactico).HasColumnName("id_Materia_Didactico");

                entity.Property(e => e.Acta).HasColumnType("varchar(500)");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_Periodo");

                entity.Property(e => e.NotasClase).HasColumnName("Notas_Clase");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.MateriaDidactico)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_material_academico");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.MateriaDidactico)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("fk_material_tipoperido");
            });

            modelBuilder.Entity<NombreTitulo>(entity =>
            {
                entity.HasKey(e => e.IdNombreTitulo)
                    .HasName("PRIMARY");

                entity.ToTable("nombre_titulo");

                entity.Property(e => e.IdNombreTitulo).HasColumnName("idNombre_Titulo");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<PafisAcademicos>(entity =>
            {
                entity.HasKey(e => e.IdPafis)
                    .HasName("PRIMARY");

                entity.ToTable("pafis_academicos");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_pafis_academicos_idx");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fk_pafis_periodo_idx");

                entity.HasIndex(e => e.IdProgramaImpacta)
                    .HasName("fk_pafis_programa_idx");

                entity.HasIndex(e => e.IdSalon)
                    .HasName("fk_pafis_Tb_salones_idx");

                entity.Property(e => e.IdPafis).HasColumnName("id_pafis");

                entity.Property(e => e.ArchivoActaA)
                    .HasColumnName("Archivo_actaA")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ArchivoPafi)
                    .HasColumnName("Archivo_pafi")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Horario).HasColumnType("varchar(200)");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.Property(e => e.IdProgramaImpacta).HasColumnName("id_programa_impacta");

                entity.Property(e => e.IdSalon).HasColumnName("id_salon");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.Property(e => e.NumHoras).HasColumnName("Num_Horas");

                entity.Property(e => e.NumeroCt).HasColumnName("Numero_CT");

                entity.Property(e => e.Solicitud).HasColumnName("solicitud");

                entity.Property(e => e.Tipopafi).HasColumnName("tipopafi");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.PafisAcademicos)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_pafis_academicos");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.PafisAcademicos)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("fk_pafis_periodo");

                entity.HasOne(d => d.IdProgramaImpactaNavigation)
                    .WithMany(p => p.PafisAcademicos)
                    .HasForeignKey(d => d.IdProgramaImpacta)
                    .HasConstraintName("fk_pafis_programa");

                entity.HasOne(d => d.IdSalonNavigation)
                    .WithMany(p => p.PafisAcademicos)
                    .HasForeignKey(d => d.IdSalon)
                    .HasConstraintName("fk_pafis_Tb_salones");
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.HasKey(e => e.IdPagos)
                    .HasName("PRIMARY");

                entity.ToTable("pagos");

                entity.HasIndex(e => e.RAcademicos)
                    .HasName("fk_Pagos_academicos_idx");

                entity.Property(e => e.IdPagos).HasColumnName("idPagos");

                entity.Property(e => e.FinQuincena)
                    .HasColumnName("Fin_quincena")
                    .HasColumnType("date");

                entity.Property(e => e.InicioQuincena)
                    .HasColumnName("Inicio_quincena")
                    .HasColumnType("date");

                entity.Property(e => e.RAcademicos).HasColumnName("R_academicos");

                entity.HasOne(d => d.RAcademicosNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.RAcademicos)
                    .HasConstraintName("fk_Pagos_academicos");
            });

            modelBuilder.Entity<ParticipacionPladea>(entity =>
            {
                entity.HasKey(e => e.IdPladea)
                    .HasName("PRIMARY");

                entity.ToTable("participacion_pladea");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_PLADEA_academicos_idx");

                entity.Property(e => e.IdPladea).HasColumnName("id_Pladea");

                entity.Property(e => e.Accion).HasColumnType("varchar(500)");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.Comision).HasColumnType("varchar(500)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.Meta).HasColumnType("varchar(500)");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.ParticipacionPladea)
                    .HasForeignKey(d => d.IdAcademico)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_PLADEA_academicos");
            });

            modelBuilder.Entity<PatentesAcademicos>(entity =>
            {
                entity.HasKey(e => e.IdPatentesAcademicos)
                    .HasName("PRIMARY");

                entity.ToTable("patentes_academicos");

                entity.HasIndex(e => e.IdNacI)
                    .HasName("fk_patentes_N_I_idx");

                entity.Property(e => e.IdPatentesAcademicos).HasColumnName("idPatentes_Academicos");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdNacI).HasColumnName("id_Nac_I");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdNacINavigation)
                    .WithMany(p => p.PatentesAcademicos)
                    .HasForeignKey(d => d.IdNacI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_patentes_N_I");
            });

            modelBuilder.Entity<PonenciasConferencias>(entity =>
            {
                entity.HasKey(e => e.IdPonencias)
                    .HasName("PRIMARY");

                entity.ToTable("ponencias/conferencias");

                entity.HasIndex(e => e.IdTipo)
                    .HasName("fk_ponencia_tipo_idx");

                entity.Property(e => e.IdPonencias).HasColumnName("id_ponencias");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.Property(e => e.PonenciaConferencia).HasColumnName("Ponencia/Conferencia");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.PonenciasConferencias)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("fk_ponencia_tipo");
            });

            modelBuilder.Entity<ProgramaEducativo>(entity =>
            {
                entity.HasKey(e => e.IdProgramaEducativo)
                    .HasName("PRIMARY");

                entity.ToTable("programa_educativo");

                entity.Property(e => e.IdProgramaEducativo).HasColumnName("idPrograma_Educativo");

                entity.Property(e => e.Area).HasColumnType("varchar(200)");

                entity.Property(e => e.Campus).HasColumnType("varchar(200)");

                entity.Property(e => e.ClvPrograma)
                    .HasColumnName("Clv_Programa")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.CreditosMaxXp).HasColumnName("Creditos_MaxXP");

                entity.Property(e => e.CreditosMinXp).HasColumnName("Creditos_MinXP");

                entity.Property(e => e.Facultad).HasColumnType("varchar(200)");

                entity.Property(e => e.Nivel).HasColumnType("varchar(200)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<ProgramasTrasversales>(entity =>
            {
                entity.HasKey(e => e.IdProgramasTrasversales)
                    .HasName("PRIMARY");

                entity.ToTable("programas_trasversales");

                entity.Property(e => e.IdProgramasTrasversales).HasColumnName("idProgramas_Trasversales");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<ProyectoEducativos>(entity =>
            {
                entity.HasKey(e => e.IdProyectoEducativos)
                    .HasName("PRIMARY");

                entity.ToTable("proyecto_educativos");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_proyecto_academicos_idx");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fk_proyecto_TipoPeriodo_idx");

                entity.Property(e => e.IdProyectoEducativos).HasColumnName("id_Proyecto_Educativos");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.Descripcion).HasColumnType("varchar(500)");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_Periodo");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.ProyectoEducativos)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_proyecto_academicos");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.ProyectoEducativos)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("fk_proyecto_TipoPeriodo");
            });

            modelBuilder.Entity<RecursosExternos>(entity =>
            {
                entity.HasKey(e => e.IdRecursosExternos)
                    .HasName("PRIMARY");

                entity.ToTable("recursos_externos");

                entity.HasIndex(e => e.IdAcademicos)
                    .HasName("fk_Recursos_Academicos_idx");

                entity.HasIndex(e => e.IdPeriodo)
                    .HasName("fk_Recursos_TipoPeriodo_idx");

                entity.Property(e => e.IdRecursosExternos).HasColumnName("id_Recursos_Externos");

                entity.Property(e => e.IdAcademicos).HasColumnName("id_academicos");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_Periodo");

                entity.Property(e => e.Ingreso).HasColumnName("ingreso");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdAcademicosNavigation)
                    .WithMany(p => p.RecursosExternos)
                    .HasForeignKey(d => d.IdAcademicos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Recursos_Academicos");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.RecursosExternos)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("fk_Recursos_TipoPeriodo");
            });

            modelBuilder.Entity<RediseñoPlanEstudios>(entity =>
            {
                entity.HasKey(e => e.IdRediseñoActualizacionEstudios)
                    .HasName("PRIMARY");

                entity.ToTable("rediseño_plan_estudios");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_redisenio_academico_idx");

                entity.HasIndex(e => e.IdPrograma)
                    .HasName("fk_redesenio_programa_idx");

                entity.Property(e => e.IdRediseñoActualizacionEstudios).HasColumnName("id_Rediseño_Actualizacion_Estudios");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.Area).HasColumnType("varchar(200)");

                entity.Property(e => e.CoordinadorColaborador).HasColumnName("Coordinador/Colaborador");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.IdPrograma).HasColumnName("id_programa");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.RediseñoPlanEstudios)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_redisenio_acad");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.RediseñoPlanEstudios)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("fk_redesenio_prog");
            });

            modelBuilder.Entity<ReportesTecnicos>(entity =>
            {
                entity.HasKey(e => e.IdReportesTecnicos)
                    .HasName("PRIMARY");

                entity.ToTable("reportes_tecnicos");

                entity.Property(e => e.IdReportesTecnicos).HasColumnName("id_Reportes_Tecnicos");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.LugarEmpresaSector).HasColumnName("Lugar_Empresa/Sector");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Revistas>(entity =>
            {
                entity.HasKey(e => e.IdRevistas)
                    .HasName("PRIMARY");

                entity.ToTable("revistas");

                entity.HasIndex(e => e.IdNI)
                    .HasName("fk_revistas_N_I_idx");

                entity.Property(e => e.IdRevistas).HasColumnName("id_revistas");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.IdNI).HasColumnName("id_N_I");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdNINavigation)
                    .WithMany(p => p.Revistas)
                    .HasForeignKey(d => d.IdNI)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_revistas_N_I");
            });

            modelBuilder.Entity<TbBuzonAcademicos>(entity =>
            {
                entity.HasKey(e => e.IdBuzonAcademicos)
                    .HasName("PRIMARY");

                entity.ToTable("tb_buzon_academicos");

                entity.HasIndex(e => e.RAcademicos)
                    .HasName("fk_buzon_academico_academico_idx");

                entity.HasIndex(e => e.RAlumno)
                    .HasName("fk_buzon_academico_alumno_idx");

                entity.HasIndex(e => e.RPeriodo)
                    .HasName("fk_buzon_academico_periodo_idx");

                entity.Property(e => e.IdBuzonAcademicos).HasColumnName("idBuzonAcademicos");

                entity.Property(e => e.Propuesta)
                    .HasColumnName("propuesta")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.RAcademicos).HasColumnName("r_academicos");

                entity.Property(e => e.RAlumno).HasColumnName("r_alumno");

                entity.Property(e => e.RPeriodo).HasColumnName("r_periodo");

                entity.Property(e => e.Sugerencia)
                    .HasColumnName("sugerencia")
                    .HasColumnType("varchar(500)");

                entity.HasOne(d => d.RAcademicosNavigation)
                    .WithMany(p => p.TbBuzonAcademicos)
                    .HasForeignKey(d => d.RAcademicos)
                    .HasConstraintName("fk_buzon_academico_academico");

                entity.HasOne(d => d.RAlumnoNavigation)
                    .WithMany(p => p.TbBuzonAcademicos)
                    .HasForeignKey(d => d.RAlumno)
                    .HasConstraintName("fk_buzon_academico_alumno");

                entity.HasOne(d => d.RPeriodoNavigation)
                    .WithMany(p => p.TbBuzonAcademicos)
                    .HasForeignKey(d => d.RPeriodo)
                    .HasConstraintName("fk_buzon_academico_periodo");
            });

            modelBuilder.Entity<TbBuzonDeQuejas>(entity =>
            {
                entity.HasKey(e => e.IdTbBuzonDeQuejas)
                    .HasName("PRIMARY");

                entity.ToTable("tb_buzon_de_quejas");

                entity.HasIndex(e => e.RAlumno)
                    .HasName("fk_alumno_buzonQuejas_idx");

                entity.HasIndex(e => e.RPeriodo)
                    .HasName("fk_periodo_buzonQuejas_idx");

                entity.HasIndex(e => e.RProblema)
                    .HasName("fk_problema_buzonQuejas_idx");

                entity.Property(e => e.IdTbBuzonDeQuejas).HasColumnName("idTb_Buzon_de_Quejas");

                entity.Property(e => e.Propuesta).HasColumnType("varchar(500)");

                entity.Property(e => e.RAlumno).HasColumnName("R_Alumno");

                entity.Property(e => e.RPeriodo).HasColumnName("R_Periodo");

                entity.Property(e => e.RProblema).HasColumnName("R_Problema");

                entity.Property(e => e.Sugerencia).HasColumnType("varchar(500)");

                entity.HasOne(d => d.RAlumnoNavigation)
                    .WithMany(p => p.TbBuzonDeQuejas)
                    .HasForeignKey(d => d.RAlumno)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_alumno_buzonQuejas");

                entity.HasOne(d => d.RPeriodoNavigation)
                    .WithMany(p => p.TbBuzonDeQuejas)
                    .HasForeignKey(d => d.RPeriodo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_periodo_buzonQuejas");

                entity.HasOne(d => d.RProblemaNavigation)
                    .WithMany(p => p.TbBuzonDeQuejas)
                    .HasForeignKey(d => d.RProblema)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_problema_buzonQuejas");
            });

            modelBuilder.Entity<TbCalificacion>(entity =>
            {
                entity.HasKey(e => e.IdTbCalificacion)
                    .HasName("PRIMARY");

                entity.ToTable("tb_calificacion");

                entity.HasIndex(e => e.RTipoCalificacion)
                    .HasName("fk_calif_tipcalif_idx");

                entity.Property(e => e.IdTbCalificacion).HasColumnName("id_Tb_calificacion");

                entity.Property(e => e.RTipoCalificacion).HasColumnName("R_tipo_calificacion");

                entity.HasOne(d => d.RTipoCalificacionNavigation)
                    .WithMany(p => p.TbCalificacion)
                    .HasForeignKey(d => d.RTipoCalificacion)
                    .HasConstraintName("fk_calif_tipcalif");
            });

            modelBuilder.Entity<TbCalificacionTutor>(entity =>
            {
                entity.HasKey(e => e.IdTbCalificacionTutor)
                    .HasName("PRIMARY");

                entity.ToTable("tb_calificacion_tutor");

                entity.HasIndex(e => e.RAcademicos)
                    .HasName("fk_califtutor_academicos_idx");

                entity.HasIndex(e => e.RPeriodo)
                    .HasName("fk_califtutor_periodo_idx");

                entity.Property(e => e.IdTbCalificacionTutor).HasColumnName("id_Tb_calificacion_tutor");

                entity.Property(e => e.RAcademicos).HasColumnName("R_academicos");

                entity.Property(e => e.RPeriodo).HasColumnName("R_periodo");

                entity.HasOne(d => d.RAcademicosNavigation)
                    .WithMany(p => p.TbCalificacionTutor)
                    .HasForeignKey(d => d.RAcademicos)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_califtutor_academicos");

                entity.HasOne(d => d.RPeriodoNavigation)
                    .WithMany(p => p.TbCalificacionTutor)
                    .HasForeignKey(d => d.RPeriodo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_califtutor_periodo");
            });

            modelBuilder.Entity<TbEventos>(entity =>
            {
                entity.HasKey(e => e.IdEventos)
                    .HasName("PRIMARY");

                entity.ToTable("tb_eventos");

                entity.HasIndex(e => e.RTioEvento)
                    .HasName("fk_eventos_tipo_eventos_idx");

                entity.Property(e => e.IdEventos).HasColumnName("id_Eventos");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.Property(e => e.RTioEvento).HasColumnName("R_Tio_Evento");

                entity.HasOne(d => d.RTioEventoNavigation)
                    .WithMany(p => p.TbEventos)
                    .HasForeignKey(d => d.RTioEvento)
                    .HasConstraintName("fk_eventos_tipo_eventos");
            });

            modelBuilder.Entity<TbExamenalumno>(entity =>
            {
                entity.HasKey(e => e.IdTbExamenAlumno)
                    .HasName("PRIMARY");

                entity.ToTable("tb_examenalumno");

                entity.HasIndex(e => e.IdAlumno)
                    .HasName("fk_interno_alumno_idx");

                entity.HasIndex(e => e.IdRubroExamen)
                    .HasName("fk_rubroexamenes_calificaciones_idx");

                entity.Property(e => e.IdTbExamenAlumno).HasColumnName("id_Tb_ExamenAlumno");

                entity.Property(e => e.CalificacionExamen).HasColumnName("calificacion_examen");

                entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");

                entity.Property(e => e.IdRubroExamen).HasColumnName("id_Rubro_Examen");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.TbExamenalumno)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_interno_alumno");

                entity.HasOne(d => d.IdRubroExamenNavigation)
                    .WithMany(p => p.TbExamenalumno)
                    .HasForeignKey(d => d.IdRubroExamen)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_rubroexamenes_calificaciones");
            });

            modelBuilder.Entity<TbHorario>(entity =>
            {
                entity.HasKey(e => e.IdPeriodoActual)
                    .HasName("PRIMARY");

                entity.ToTable("tb_horario");

                entity.HasIndex(e => e.RAlumno)
                    .HasName("fk_periodo_alumno_idx");

                entity.HasIndex(e => e.RExperienciaPeriodo)
                    .HasName("fk_horario_exp_educ_periodo_idx");

                entity.HasIndex(e => e.RSalon)
                    .HasName("fk_horario_salon_idx");

                entity.HasIndex(e => e.RTipoCalif)
                    .HasName("fk_horario_calificacion_idx");

                entity.Property(e => e.IdPeriodoActual).HasColumnName("id_periodo_Actual");

                entity.Property(e => e.RAlumno).HasColumnName("R_alumno");

                entity.Property(e => e.RExperienciaPeriodo).HasColumnName("R_Experiencia_Periodo");

                entity.Property(e => e.RSalon).HasColumnName("R_Salon");

                entity.Property(e => e.RTipoCalif).HasColumnName("R_Tipo_Calif");

                entity.HasOne(d => d.RAlumnoNavigation)
                    .WithMany(p => p.TbHorario)
                    .HasForeignKey(d => d.RAlumno)
                    .HasConstraintName("fk_horario_alum");

                entity.HasOne(d => d.RExperienciaPeriodoNavigation)
                    .WithMany(p => p.TbHorario)
                    .HasForeignKey(d => d.RExperienciaPeriodo)
                    .HasConstraintName("fk_horario_exp_educ_periodo");

                entity.HasOne(d => d.RSalonNavigation)
                    .WithMany(p => p.TbHorario)
                    .HasForeignKey(d => d.RSalon)
                    .HasConstraintName("fk_horario_salon");

                entity.HasOne(d => d.RTipoCalifNavigation)
                    .WithMany(p => p.TbHorario)
                    .HasForeignKey(d => d.RTipoCalif)
                    .HasConstraintName("fk_horario_calif");
            });

            modelBuilder.Entity<TbInstanciafinalAlumno>(entity =>
            {
                entity.HasKey(e => e.IdTbInstanciaFinalAlumno)
                    .HasName("PRIMARY");

                entity.ToTable("tb_instanciafinal_alumno");

                entity.HasIndex(e => e.RAlumno)
                    .HasName("fk_InstanciaF_Alumno_idx");

                entity.HasIndex(e => e.RExpRep)
                    .HasName("fk_InstanciaF_ER_idx");

                entity.HasIndex(e => e.RServPrac)
                    .HasName("fk_InstanciaF_SP_idx");

                entity.Property(e => e.IdTbInstanciaFinalAlumno).HasColumnName("idTB_InstanciaFinal_Alumno");

                entity.Property(e => e.RAlumno).HasColumnName("R_Alumno");

                entity.Property(e => e.RExpRep).HasColumnName("R_ExpRep");

                entity.Property(e => e.RServPrac).HasColumnName("R_ServPrac");

                entity.HasOne(d => d.RAlumnoNavigation)
                    .WithMany(p => p.TbInstanciafinalAlumno)
                    .HasForeignKey(d => d.RAlumno)
                    .HasConstraintName("fk_InstanciaF_Alumno");

                entity.HasOne(d => d.RExpRepNavigation)
                    .WithMany(p => p.TbInstanciafinalAlumno)
                    .HasForeignKey(d => d.RExpRep)
                    .HasConstraintName("fk_InstanciaF_ER");

                entity.HasOne(d => d.RServPracNavigation)
                    .WithMany(p => p.TbInstanciafinalAlumno)
                    .HasForeignKey(d => d.RServPrac)
                    .HasConstraintName("fk_InstanciaF_SP");
            });

            modelBuilder.Entity<TbMovilidad>(entity =>
            {
                entity.HasKey(e => e.IdTbMovilidad)
                    .HasName("PRIMARY");

                entity.ToTable("tb_movilidad");

                entity.HasIndex(e => e.RAlumno)
                    .HasName("fk_movilidad_alumno_idx");

                entity.HasIndex(e => e.RMovilidad)
                    .HasName("fk_alumovilidad_dt_movilidad_idx");

                entity.HasIndex(e => e.RPeriodo)
                    .HasName("fk_movilidad_tipoperi_idx");

                entity.Property(e => e.IdTbMovilidad).HasColumnName("id_Tb_Movilidad");

                entity.Property(e => e.RAlumno).HasColumnName("R_alumno");

                entity.Property(e => e.RMovilidad).HasColumnName("R_Movilidad");

                entity.Property(e => e.RPeriodo).HasColumnName("R_Periodo");

                entity.HasOne(d => d.RAlumnoNavigation)
                    .WithMany(p => p.TbMovilidad)
                    .HasForeignKey(d => d.RAlumno)
                    .HasConstraintName("fk_movilidad_alumno");

                entity.HasOne(d => d.RMovilidadNavigation)
                    .WithMany(p => p.TbMovilidad)
                    .HasForeignKey(d => d.RMovilidad)
                    .HasConstraintName("fk_alumovilidad_dt_movilidad");

                entity.HasOne(d => d.RPeriodoNavigation)
                    .WithMany(p => p.TbMovilidad)
                    .HasForeignKey(d => d.RPeriodo)
                    .HasConstraintName("fk_movilidad_tipoperi");
            });

            modelBuilder.Entity<TbPafisAlumno>(entity =>
            {
                entity.HasKey(e => e.IdTbPafisAlumno)
                    .HasName("PRIMARY");

                entity.ToTable("tb_pafis_alumno");

                entity.HasIndex(e => e.RAlumno)
                    .HasName("fk_pafisalum_alumno_idx");

                entity.HasIndex(e => e.RInfopafi)
                    .HasName("fk_pafisalum_pafiasacad_idx");

                entity.Property(e => e.IdTbPafisAlumno).HasColumnName("id_Tb_pafis_alumno");

                entity.Property(e => e.RAlumno).HasColumnName("R_alumno");

                entity.Property(e => e.RInfopafi).HasColumnName("R_infopafi");

                entity.HasOne(d => d.RAlumnoNavigation)
                    .WithMany(p => p.TbPafisAlumno)
                    .HasForeignKey(d => d.RAlumno)
                    .HasConstraintName("fk_pafisalum_alumno");

                entity.HasOne(d => d.RInfopafiNavigation)
                    .WithMany(p => p.TbPafisAlumno)
                    .HasForeignKey(d => d.RInfopafi)
                    .HasConstraintName("fk_pafisalum_pafiasacad");
            });

            modelBuilder.Entity<TbRubrosexamenes>(entity =>
            {
                entity.HasKey(e => e.IdTbRubrosExamenes)
                    .HasName("PRIMARY");

                entity.ToTable("tb_rubrosexamenes");

                entity.Property(e => e.IdTbRubrosExamenes).HasColumnName("id_Tb_Rubros_Examenes");

                entity.Property(e => e.RubroExamen)
                    .HasColumnName("Rubro_Examen")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.TipoExamen).HasColumnName("tipo_examen");
            });

            modelBuilder.Entity<TbSalones>(entity =>
            {
                entity.HasKey(e => e.IdTbSalones)
                    .HasName("PRIMARY");

                entity.ToTable("tb_salones");

                entity.Property(e => e.IdTbSalones).HasColumnName("idTb_Salones");

                entity.Property(e => e.ClaveSalon)
                    .HasColumnName("Clave_salon")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Edificio).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<TbServiciopracticas>(entity =>
            {
                entity.HasKey(e => e.IdTbServicioPracticas)
                    .HasName("PRIMARY");

                entity.ToTable("tb_serviciopracticas");

                entity.HasIndex(e => e.REmpresa)
                    .HasName("fk_empresaServ_idx");

                entity.Property(e => e.IdTbServicioPracticas).HasColumnName("idTB_ServicioPracticas");

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.REmpresa).HasColumnName("R_Empresa");

                entity.HasOne(d => d.REmpresaNavigation)
                    .WithMany(p => p.TbServiciopracticas)
                    .HasForeignKey(d => d.REmpresa)
                    .HasConstraintName("fk_empresaServ");
            });

            modelBuilder.Entity<TipoCertificacion>(entity =>
            {
                entity.HasKey(e => e.IdCertificacion)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_certificacion");

                entity.Property(e => e.IdCertificacion).HasColumnName("id_certificacion");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TipoContratacionee>(entity =>
            {
                entity.HasKey(e => e.IdTipoContratacion)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_contratacionee");

                entity.Property(e => e.IdTipoContratacion).HasColumnName("id_Tipo_Contratacion");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TipoDistincionTa>(entity =>
            {
                entity.HasKey(e => e.IdDistincion)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_distincion_ta");

                entity.HasIndex(e => e.IdDistincion)
                    .HasName("id_distincion_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdDistincion).HasColumnName("id_distincion");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TipoEvaluador>(entity =>
            {
                entity.HasKey(e => e.IdTipoEvaluador)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_evaluador");

                entity.Property(e => e.IdTipoEvaluador).HasColumnName("idTipo_Evaluador");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TipoEventos>(entity =>
            {
                entity.HasKey(e => e.IdEventos)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_eventos");

                entity.Property(e => e.IdEventos).HasColumnName("idEventos");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TipoLaboratorio>(entity =>
            {
                entity.HasKey(e => e.IdTipoLaboratorio)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_laboratorio");

                entity.Property(e => e.IdTipoLaboratorio).HasColumnName("id_Tipo_Laboratorio");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TipoLocNacInter>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_loc_nac_inter");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TipoModalidad>(entity =>
            {
                entity.HasKey(e => e.IdModalidad)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_modalidad");

                entity.Property(e => e.IdModalidad).HasColumnName("id_modalidad");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TipoPeriodo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_periodo");

                entity.Property(e => e.IdPeriodo).HasColumnName("id_periodo");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TipoPersonal>(entity =>
            {
                entity.HasKey(e => e.IdTipoPersonal)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_personal");

                entity.Property(e => e.IdTipoPersonal).HasColumnName("idTipo_Personal");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TipoPuesto>(entity =>
            {
                entity.HasKey(e => e.IdPuesto)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_puesto");

                entity.Property(e => e.IdPuesto).HasColumnName("id_Puesto");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TipoTramiteAcademicos>(entity =>
            {
                entity.HasKey(e => e.IdTipoTramiteAcademicos)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_tramite_academicos");

                entity.Property(e => e.IdTipoTramiteAcademicos).HasColumnName("idTipo_Tramite_Academicos");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TipoTramiteAlumnos>(entity =>
            {
                entity.HasKey(e => e.IdTipoTramiteAlumnos)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_tramite_alumnos");

                entity.Property(e => e.IdTipoTramiteAlumnos).HasColumnName("idTipo_Tramite_Alumnos");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TrabajosRecepcionales>(entity =>
            {
                entity.HasKey(e => e.IdTrabajosRecepcionales)
                    .HasName("PRIMARY");

                entity.ToTable("trabajos_recepcionales");

                entity.HasIndex(e => e.IdAcademia)
                    .HasName("fk_recep_academias_idx");

                entity.HasIndex(e => e.IdAlumno)
                    .HasName("fk_recep_alumno_idx");

                entity.HasIndex(e => e.IdGrado)
                    .HasName("fk_recep_grado_idx");

                entity.HasIndex(e => e.IdModalidad)
                    .HasName("fk_recep_modalidad_idx");

                entity.Property(e => e.IdTrabajosRecepcionales).HasColumnName("id_Trabajos_Recepcionales");

                entity.Property(e => e.Archivo).HasColumnType("varchar(500)");

                entity.Property(e => e.FechaPresentacion)
                    .HasColumnName("Fecha_Presentacion")
                    .HasColumnType("date");

                entity.Property(e => e.IdAcademia).HasColumnName("id_academia");

                entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");

                entity.Property(e => e.IdGrado).HasColumnName("id_grado");

                entity.Property(e => e.IdModalidad).HasColumnName("id_modalidad");

                entity.Property(e => e.NombreTrabajo)
                    .HasColumnName("Nombre_Trabajo")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.NumeroConsejoT).HasColumnName("numero_ConsejoT");

                entity.HasOne(d => d.IdAcademiaNavigation)
                    .WithMany(p => p.TrabajosRecepcionales)
                    .HasForeignKey(d => d.IdAcademia)
                    .HasConstraintName("fk_recep_academias");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.TrabajosRecepcionales)
                    .HasForeignKey(d => d.IdAlumno)
                    .HasConstraintName("fk_recep_alumno");

                entity.HasOne(d => d.IdGradoNavigation)
                    .WithMany(p => p.TrabajosRecepcionales)
                    .HasForeignKey(d => d.IdGrado)
                    .HasConstraintName("fk_recep_grado");

                entity.HasOne(d => d.IdModalidadNavigation)
                    .WithMany(p => p.TrabajosRecepcionales)
                    .HasForeignKey(d => d.IdModalidad)
                    .HasConstraintName("fk_recep_modalidad");
            });

            modelBuilder.Entity<TramitesAcademicos>(entity =>
            {
                entity.HasKey(e => e.IdTramitesAcademicos)
                    .HasName("PRIMARY");

                entity.ToTable("tramites_academicos");

                entity.HasIndex(e => e.RAcademicos)
                    .HasName("fk_TramitesAcademicos_Academicos_idx");

                entity.HasIndex(e => e.TipoTramite)
                    .HasName("fk_TramitesAcademicos_TipoTramiteAcademicos_idx");

                entity.Property(e => e.IdTramitesAcademicos).HasColumnName("idTramites_Academicos");

                entity.Property(e => e.FechaEnvio)
                    .HasColumnName("Fecha_envio")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaRegreso)
                    .HasColumnName("Fecha_regreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.Folio).HasColumnType("varchar(200)");

                entity.Property(e => e.Observaciones).HasColumnType("varchar(500)");

                entity.Property(e => e.RAcademicos).HasColumnName("R_academicos");

                entity.Property(e => e.TipoTramite).HasColumnName("Tipo_tramite");

                entity.HasOne(d => d.RAcademicosNavigation)
                    .WithMany(p => p.TramitesAcademicos)
                    .HasForeignKey(d => d.RAcademicos)
                    .HasConstraintName("fk_TramitesAcademicos_Academicos");

                entity.HasOne(d => d.TipoTramiteNavigation)
                    .WithMany(p => p.TramitesAcademicos)
                    .HasForeignKey(d => d.TipoTramite)
                    .HasConstraintName("fk_TramitesAcademicos_TipoTramiteAcademicos");
            });

            modelBuilder.Entity<TramitesAlumnos>(entity =>
            {
                entity.HasKey(e => e.IdTramitesAlumnos)
                    .HasName("PRIMARY");

                entity.ToTable("tramites_alumnos");

                entity.HasIndex(e => e.RAlumnos)
                    .HasName("fk_Tramites_Alumnos_idx");

                entity.HasIndex(e => e.TipoTramite)
                    .HasName("fk_Tramites_TipoTramiteAlumnos_idx");

                entity.Property(e => e.IdTramitesAlumnos).HasColumnName("idTramites_Alumnos");

                entity.Property(e => e.FechaEnvio)
                    .HasColumnName("Fecha_envio")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaRegreso)
                    .HasColumnName("Fecha_regreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.Folio).HasColumnType("varchar(200)");

                entity.Property(e => e.Observacioes).HasColumnType("varchar(500)");

                entity.Property(e => e.RAlumnos).HasColumnName("R_alumnos");

                entity.Property(e => e.TipoTramite).HasColumnName("Tipo_tramite");

                entity.HasOne(d => d.RAlumnosNavigation)
                    .WithMany(p => p.TramitesAlumnos)
                    .HasForeignKey(d => d.RAlumnos)
                    .HasConstraintName("fk_Tramites_Alumnos");

                entity.HasOne(d => d.TipoTramiteNavigation)
                    .WithMany(p => p.TramitesAlumnos)
                    .HasForeignKey(d => d.TipoTramite)
                    .HasConstraintName("fk_Tramites_TipoTramiteAlumnos");
            });

            modelBuilder.Entity<TutoradosExternos>(entity =>
            {
                entity.HasKey(e => e.IdTutoradosExternos)
                    .HasName("PRIMARY");

                entity.ToTable("tutorados_externos");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_TE_academicos_idx");

                entity.Property(e => e.IdTutoradosExternos).HasColumnName("idTutorados_Externos");

                entity.Property(e => e.IdAcademico).HasColumnName("id_academico");

                entity.Property(e => e.Matricula).HasColumnType("varchar(45)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.TutoradosExternos)
                    .HasForeignKey(d => d.IdAcademico)
                    .HasConstraintName("fk_TE_academicos");
            });

            modelBuilder.Entity<Tutores>(entity =>
            {
                entity.HasKey(e => e.IdTutores)
                    .HasName("PRIMARY");

                entity.ToTable("tutores");

                entity.HasIndex(e => e.IdAcademicos)
                    .HasName("fk_tutor_academico_idx");

                entity.HasIndex(e => e.IdAlumno)
                    .HasName("fk_tutor_alumno_idx");

                entity.Property(e => e.IdTutores).HasColumnName("idTutores");

                entity.Property(e => e.IdAcademicos).HasColumnName("idAcademicos");

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.HasOne(d => d.IdAcademicosNavigation)
                    .WithMany(p => p.Tutores)
                    .HasForeignKey(d => d.IdAcademicos)
                    .HasConstraintName("fk_tutor_academico");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Tutores)
                    .HasForeignKey(d => d.IdAlumno)
                    .HasConstraintName("fk_tutor_alumno");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.IdAcademico)
                    .HasName("fk_usuarios_academicos_idx");

                entity.HasIndex(e => e.IdAlumno)
                    .HasName("fk_usuarios_alumnos_idx");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasColumnName("contrasenia")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IdAcademico).HasColumnName("idAcademico");

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.HasOne(d => d.IdAcademicoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdAcademico)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_usuarios_academicos");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_usuarios_alumnos");
            });
        }
    }
}
