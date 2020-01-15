using System;
namespace SGCFIEE.Models
{
    public class TablaEvaluadores
    {
        public int IdEvaluadores { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Archivo { get; set; }
        public String Tipo { get; set; }
        public int? RevisorEvaluador { get; set; }
        public int? StatusEvaluador { get; set; }
        public int? Status { get; set; }
    }
}
