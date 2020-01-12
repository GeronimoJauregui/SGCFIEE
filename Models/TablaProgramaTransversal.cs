using System;
namespace SGCFIEE.Models
{
    public class TablaProgramaTransversal
    {
        public int IdCoordinadorPrograma { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String NombrePrograma { get; set; }
        public String Archivo { get; set; }
        public String PeriodoInicio { get; set; }
        public String PeriodoTermino { get; set; }
        public int? Status { get; set; }
    }
}
