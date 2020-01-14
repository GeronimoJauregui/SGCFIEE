using System;
namespace SGCFIEE.Models
{
    public class TablaCongresos
    {
		public int IdCongresos { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Archivo { get; set; }
        public String Tipo { get; set; }
        public String NombreCongreso { get; set; }
        public int? Status { get; set; }
	}
}
