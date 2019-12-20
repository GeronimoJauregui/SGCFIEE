using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class MateriaDidactico
    {
        public int IdMateriaDidactico { get; set; }
        public int? IdAcademico { get; set; }
        public int? NotasClase { get; set; }
        public int? Acetatos { get; set; }
        public int? Videos { get; set; }
        public int? Programas { get; set; }
        public int? Prototipos { get; set; }
        public string Acta { get; set; }
        public int? IdPeriodo { get; set; }

        public virtual Academicos IdAcademicoNavigation { get; set; }
        public virtual TipoPeriodo IdPeriodoNavigation { get; set; }
    }
}
