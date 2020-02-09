using System;
namespace SGCFIEE.Models
{
    public class TablaPonenciasConferencias
    {
        public int IdPonenConfer { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Archivo { get; set; }
        public String Fecha { get; set; }
        public String NombrePonConf { get; set; }
        public String tipo { get; set; }
        public int? TipoPonenConfe { get; set; }
        public int? Status { get; set; }
    }
}
