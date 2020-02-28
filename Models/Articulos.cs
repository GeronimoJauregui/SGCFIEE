using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Articulos
    {
        public Articulos()
        {
            Academicoarticulos = new HashSet<Academicoarticulos>();
        }

        public int IdArticulos { get; set; }
        public int? Registro { get; set; }
        public int? Arbitrada { get; set; }
        public int? IdTipoNI { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }

        public virtual TipoLocNacInter IdTipoNINavigation { get; set; }
        public virtual ICollection<Academicoarticulos> Academicoarticulos { get; set; }
    }
}
