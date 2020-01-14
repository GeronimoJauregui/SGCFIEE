using System;
namespace SGCFIEE.Models
{
    public class TablaReportesTecnicos
    {
        public int IdReporteTecnico { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Archivo { get; set; }
        public String NombreReporte { get; set; }
        public int? Empresa_Sector { get; set; }
        public int? Status { get; set; }
    }
}
