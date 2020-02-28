using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Congresos
    {
        public Congresos()
        {
            Academicocongresos = new HashSet<Academicocongresos>();
        }

        public int IdCongresos { get; set; }
        public int? IdNacInt { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }

        public virtual TipoLocNacInter IdNacIntNavigation { get; set; }
        public virtual ICollection<Academicocongresos> Academicocongresos { get; set; }
    }
}
