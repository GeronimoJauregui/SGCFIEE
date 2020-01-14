using System;
namespace SGCFIEE.Models
{
    public class TablaArticulos
    {
        public int IdArticulos { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Archivo { get; set; }
        public String Tipo { get; set; }
        public int? Registro { get; set; }
        public int? Arbitrada { get; set; }
        public String NombreArticulo { get; set; }
        public int? Status { get; set; }
    }
}
