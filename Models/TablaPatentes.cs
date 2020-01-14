using System;
namespace SGCFIEE.Models
{
    public class TablaPatentes
    {
        public int IdPatentes { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Archivo { get; set; }
        public String NombrePatente { get; set; }
        public String Tipo { get; set; }
        public int? Status { get; set; }
    }
}
