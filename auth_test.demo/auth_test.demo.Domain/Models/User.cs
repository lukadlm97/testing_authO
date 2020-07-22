using System;
using System.Collections.Generic;
using System.Text;

namespace auth_test.demo.Domain.Models
{
    public class User:DomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
      
    }
}
