using System;
namespace SGCFIEE.Models
{
    public class TablaJurExperiencia
    {
        public int IdJurado { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String NombreAlum { get; set; }
        public String ApellidoPaternoAlum { get; set; }
        public String ApellidoMaternoAlum { get; set; }
        public String Modalidad { get; set; }
        public String NombreTrabajo { get; set; }
        public String Fecha { get; set; }
        public String Archivo { get; set; }
        public int? JuradoPrejurado { get; set; }
        public int? Status { get; set; }
    }
}
