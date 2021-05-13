using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor2.Models
{
    public class LoginModel
    {
        [Display(Name = "Nombre de Usuario")]
        public string Usuario { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
