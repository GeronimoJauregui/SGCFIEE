using System;
namespace SGCFIEE.Models
{
    public class TablaMaterialD
    {
        public int IdMDidactico { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public int? NotasClase { get; set; }
        public int? Acetatos { get; set; }
        public int? Videos { get; set; }
        public int? Programas { get; set; }
        public int? Prototipos { get; set; }
        public String Archivo { get; set; }
        public String Periodo { get; set; }
        public int? Status { get; set; }
    }
}
