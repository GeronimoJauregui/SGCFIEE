using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class pPafisAcademicos
    {
        public int IdPafis { get; set; }
        public int? IdAcademico { get; set; }
        public string Nombre_academico { get; set; }
        public int? Npersonal { get; set; }
        public int? Tipopafi { get; set; }
        public int? Estado { get; set; }
        public sbyte? Solicitud { get; set; }
        public string Nombre_pafi { get; set; }
        public int? NumHoras { get; set; }
        public int? IdPeriodo { get; set; }
        public string Periodo { get; set; }
        public int? IdSalon { get; set; }
        public string Salon { get; set; }
        public string Edificio { get; set; }
        public int? IdProgramaImpacta { get; set; }
        public string PE { get; set; }
        public int? NumeroCt { get; set; }
        public string ArchivoPafi { get; set; }
        public string ArchivoActaA { get; set; }
        public string Horario { get; set; }
    }
}
