using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class ExperienciaProfesional
    {
        public int IdEp { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdTipoPuesto { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Archivo { get; set; }
        public string AreaDesarrollo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual InstitucionesEmpresas IdEmpresaNavigation { get; set; }
        public virtual TipoPuesto IdTipoPuestoNavigation { get; set; }
    }
}
