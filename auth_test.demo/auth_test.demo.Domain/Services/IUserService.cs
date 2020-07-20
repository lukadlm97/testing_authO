using auth_test.demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace auth_test.demo.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Create(User user);
        User Authentificate(string username, string password);
    }
}
