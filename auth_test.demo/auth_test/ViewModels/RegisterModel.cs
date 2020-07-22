using auth_test.demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace auth_test.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$",ErrorMessage ="Username must have characters and numbers")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Password must have characters and numbers")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password",ErrorMessage ="Confirm password must be same as password")]
        public string ConfirmPassword { get; set; }

        public static implicit operator User(RegisterModel model)
        {
            return new User
            {
                Id = 0,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password,
                Role = Role.User,
                Token = null
            };
        }
    
    }
}
