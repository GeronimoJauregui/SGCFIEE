using System;
namespace SGCFIEE.Models
{
    public class TablaTrabajosRecep
    {
		public int IdTrabajos { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String NombreAlum { get; set; }
        public String ApellidoPaternoAlum { get; set; }
        public String ApellidoMaternoAlum { get; set; }
        public String Modalidad { get; set; }
        public String Grado { get; set; }
        public String Academia { get; set; }
        public int? Proceso { get; set; }
        public String Fecha { get; set; }
        public int? NumCT { get; set; }
        public String Archivo { get; set; }
        public String NombreTrabajo { get; set; }
        public int? Status { get; set; }
	}
}
