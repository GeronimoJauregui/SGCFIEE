using System;
namespace SGCFIEE.Models
{
    public class TablaRedisenio
    {
		public int IdPlan { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Area { get; set; }
        public String NombrePrograma { get; set; }
        public String Archivo { get; set; }
        public sbyte? Tipo { get; set; }
        public int? Status { get; set; }
    }
}
