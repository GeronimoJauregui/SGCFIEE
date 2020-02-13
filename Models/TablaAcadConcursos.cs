using System;
namespace SGCFIEE.Models
{
    public class TablaAcadConcursos
    {
        public int IdAcadConcursos { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public int? IdConcursos { get; set; }
    }
}
