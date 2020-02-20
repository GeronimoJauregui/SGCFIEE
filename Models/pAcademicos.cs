using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class pAcademicos
    {
        public int IdAcademicos { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Curp { get; set; }
        public string CorreoInstitucional { get; set; }
        public string CorreoAlternativo { get; set; }
        public string Celular { get; set; }
        public int? Sexo { get; set; }
        public string Nombre_Sexo { get; set; }
        public int? NumeroPersonal { get; set; }
        public int? IdProgramaEducativo { get; set; }
        public string ProgramaEducativo { get; set; }
        public DateTime? FechaIngresoUv { get; set; }
        public int? Status { get; set; }
        public string NombreStatus { get; set; }
        public int? RTipoPersonal { get; set; }
        public string tipoPersonal { get; set; }
        public string Rfc { get; set; }
    }
}
