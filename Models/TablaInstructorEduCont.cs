using System;
namespace SGCFIEE.Models
{
    public class TablaInstructorEduCont
    {
        public int IdInstructorEdu { get; set; }
        public int? NumPersonal { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String NomIngreso { get; set; }
        public float? Ingreso { get; set; }
        public String Periodo { get; set; }
        public int? Status { get; set; }
    }
}
