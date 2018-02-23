using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MantDocente.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Usuario { get; set; } = String.Empty;
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;
    }
}