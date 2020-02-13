using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Congresos
    {
        public Congresos()
        {
            AcademicoCongresos = new HashSet<AcademicoCongresos>();
        }

        public int IdCongresos { get; set; }
        public int? IdNacInt { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }

        public virtual TipoLocNacInter IdNacIntNavigation { get; set; }
        public virtual ICollection<AcademicoCongresos> AcademicoCongresos { get; set; }
    }
}
