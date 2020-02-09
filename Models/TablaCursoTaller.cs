using System;
namespace SGCFIEE.Models
{
    public class TablaCursoTaller
    {
        public int IdCursoTaller { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Archivo { get; set; }
        public int? Tipo { get; set; }
        public String Titulo { get; set; }
        public String Fecha { get; set; }
        public int? Status { get; set; }
    }
}
