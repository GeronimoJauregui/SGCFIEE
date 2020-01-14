using System;
namespace SGCFIEE.Models
{
    public class TablaRevistas
    {
		public int IdRevistas { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Archivo { get; set; }
        public String Tipo { get; set; }
        public String NombreRevista { get; set; }
        public int? Registro { get; set; }
        public int? Arbitrada { get; set; }
        public int? Status { get; set; }
    }
}
