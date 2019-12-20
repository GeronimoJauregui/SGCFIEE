using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SGCFIEE.Models
{
    public class UsuarioLogin
    {
        [DisplayName("matricula")]
        public String matricula { get; set; }
        [DisplayName("password")]
        public String password { get; set; }
    }
}
