using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class DatosPersonales
    {
        public DatosPersonales()
        {
            Alumnos = new HashSet<Alumnos>();
        }

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

        public virtual ICollection<Alumnos> Alumnos { get; set; }
    }
}
