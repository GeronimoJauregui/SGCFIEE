using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class JuradoExperienciaRecepcional
    {
        public int IdJer { get; set; }
        public int? IdAcademico { get; set; }
        public int? IdTr { get; set; }
        public int? JuradoPrejurado { get; set; }
        public string Archivo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TrabajosRecepcionales IdTrNavigation { get; set; }
    }
}
