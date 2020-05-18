using System;
namespace SGCFIEE.Models
{
    public class TablaJurOposicion
    {
        public int IdJurado { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Ee { get; set; }
        public String Pe { get; set; }
        public int? TipoExamen { get; set; }
        public String Fecha { get; set; }
        public String Archivo { get; set; }
        public int? Status { get; set; }
    }
}
