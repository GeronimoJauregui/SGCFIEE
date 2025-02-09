﻿using System;
using System.Collections.Generic;

namespace SGCFIEE.Models
{
    public partial class Academicospatentes
    {
        public int IdAcademicosPatentes { get; set; }
        public int? IdAcademicos { get; set; }
        public int? IdPatentes { get; set; }
        public int? Lider { get; set; }

        public virtual Academicos IdAcademicosNavigation { get; set; }
        public virtual PatentesAcademicos IdPatentesNavigation { get; set; }
    }
}
