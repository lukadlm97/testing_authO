using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace auth_test.ViewModels
{
    public class AuthenticateModel
    {
        [StringLength(50,MinimumLength = 8)]
        [Required]
        public string Username { get; set; }
        [StringLength(50, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }
    }
}
