using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public partial class DatosAlumno
    {
        public int IdDatosPersonales { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string EstadoCivil { get; set; }
        public int? Genero { get; set; }
        public string Curp { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string Ciudad { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public int? CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public int? Status { get; set; }
        public string RecidenciaActual { get; set; }
        public int? Trabaja { get; set; }
        public int? IngresoMensual { get; set; }
        public string Matricula { get; set; }
        public string CorreoInstitucional { get; set; }
        public int? AnioIngreso { get; set; }
        public string Modalidad { get; set; }
        public int? RProgramaEducativo { get; set; }
        public int? RDatosPerson { get; set; }
        public int? RStatus { get; set; }
        public string Bachillerato { get; set; }

    }
}
