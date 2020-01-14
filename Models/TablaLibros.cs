using System;
namespace SGCFIEE.Models
{
    public class TablaLibros
    {
		public int IdLibro { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Archivo { get; set; }
        public String Titulo { get; set; }
        public String ISBN { get; set; }
        public String Editorial { get; set; }
        public int? Anio { get; set; }
        public int? Tiraje { get; set; }
        public int? Status { get; set; }
    }
}
