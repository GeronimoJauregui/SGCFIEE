using System;
namespace SGCFIEE.Models
{
    public class TablaAcademia
    {
        public int IdCoordinadorAcademia { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String NombreAcademia { get; set; }
        public String Archivo { get; set; }
        public String PeriodoInicio { get; set; }
        public String PeriodoTermino { get; set; }
        public int? Status { get; set; }
    }
}
