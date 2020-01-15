using System;
namespace SGCFIEE.Models
{
    public class TablaCA
    {
		public int IdCA { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Archivo { get; set; }
        public String NombreNivel { get; set; }
        public String NombreCuerpo { get; set; }
        public DateTime? Fecha { get; set; }
        public int? StatusAcademico { get; set; }
        public int? Status { get; set; }
    }
}
