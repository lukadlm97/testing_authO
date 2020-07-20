using auth_test.demo.Domain.Models;
using auth_test.demo.Domain.Services;
using auth_test.demo.Entityframework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;


namespace auth_test.demo.Services
{
    public class UserService : IUserService
    {
        private readonly AuthContext _context;

        public UserService(AuthContext context)
        {
            _context = context;
        }

        public async Task<User> Authentificate(string username, string password)
        {
            var users = await GetAll();

            foreach(User u in users)
            {
                if (u.Username == username && u.Password == password)
                {
                    Debug.WriteLine("User successfully authentificate.");
                    return u;
                }
            }
            Debug.WriteLine("User doesnt authentificate.");
            return null;
        }

        public async Task<User> Create(User user)
        {
            try
            { 
                EntityEntry<User> createdResult = await _context.Set<User>().AddAsync(user);
                await _context.SaveChangesAsync();
                Debug.WriteLine("User successfully created.");

                return createdResult.Entity;
            }catch(Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
                return null;
            }
        }

        public async  Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
    
    }
}
