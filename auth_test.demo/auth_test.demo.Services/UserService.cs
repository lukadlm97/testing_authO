using auth_test.demo.Domain.Helpers;
using auth_test.demo.Domain.Models;
using auth_test.demo.Domain.Services;
using auth_test.demo.Entityframework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace auth_test.demo.Services
{
    public class UserService : IUserService
    {
        private readonly AuthContext _context;
        private readonly AppSettings _appSettings;

        public UserService(AuthContext context,IOptions<AppSettings> options)
        {
            _context = context;
            _appSettings = options.Value;
        }

        public User Authentificate(string username, string password)
        {
            var user =  _context.Users
                .SingleOrDefaultAsync(x => x.Username == username && x.Password==password);

            if (user.Result == null)
            {
                Debug.WriteLine("User doesnt authentificate.");
                return null;
            }
           
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Result.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Result.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Result.Token = tokenHandler.WriteToken(token);

            Debug.WriteLine("User successfully authentificate.");
            return user.Result.WithoutPassword();
        }

        public async Task<User> Create(User user)
        {
            try
            { 
                EntityEntry<User> createdResult = await _context.Set<User>().AddAsync(user);
                await _context.SaveChangesAsync();
                Debug.WriteLine("User successfully created.");

                return createdResult.Entity.WithoutPassword();
            }catch(Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
                return null;
            }
        }

        public bool DoesUserExist(string username)
        {
            var user = _context.Users.SingleOrDefaultAsync(x => x.Username == username);

            if (user.Result == null)
                return false;

            return true;
        }

        public async  Task<IEnumerable<User>> GetAll()
        {
            var users =  _context.Users;
            
            return users.WithoutPasswords();
        }
    
    }
}
