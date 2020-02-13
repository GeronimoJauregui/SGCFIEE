using System;
namespace SGCFIEE.Models
{
    public class TablaAcadRevistas
    {
        public int IdAcadRevistas { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public int? IdRevistas { get; set; }
    }
}
