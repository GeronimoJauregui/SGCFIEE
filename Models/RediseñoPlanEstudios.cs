using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class RediseñoPlanEstudios
    {
        public int IdRediseñoActualizacionEstudios { get; set; }
        public int? IdAcademico { get; set; }
        public string Area { get; set; }
        public int? IdPrograma { get; set; }
        public sbyte? CoordinadorColaborador { get; set; }
        public string Archivo { get; set; }
        public int? Status { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual ProgramaEducativo IdProgramaNavigation { get; set; }
    }
}
