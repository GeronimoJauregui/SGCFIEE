using System;
namespace SGCFIEE.Models
{
    public class TablaPladea
    {
        public int IdJurado { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Comision { get; set; }
        public String Meta { get; set; }
        public String Accion { get; set; }
        public String Fecha { get; set; }
        public String Archivo { get; set; }
        public int? Status { get; set; }
    }
}
