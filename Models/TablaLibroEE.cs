using System;
namespace SGCFIEE.Models
{
    public class TablaLibroEE
    {
        public int IdLibroEE { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String NombreLibro { get; set; }
        public String Archivo { get; set; }
        public String Periodo { get; set; }
        public int? Status { get; set; }
    }
}
