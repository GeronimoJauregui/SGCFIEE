using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class TbSalones
    {
        public TbSalones()
        {
            ExperienciaEducativaPeriodo = new HashSet<ExperienciaEducativaPeriodo>();
            PafisAcademicos = new HashSet<PafisAcademicos>();
        }

        public int IdTbSalones { get; set; }
        public string ClaveSalon { get; set; }
        public string Edificio { get; set; }

        public virtual ICollection<ExperienciaEducativaPeriodo> ExperienciaEducativaPeriodo { get; set; }
        public virtual ICollection<PafisAcademicos> PafisAcademicos { get; set; }
    }
}
