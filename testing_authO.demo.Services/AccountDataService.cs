using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using testing_authO.demo.Domain;
using testing_authO.demo.Domain.Services;
using testing_authO.demo.Models;
using testing_authO.demo.Models.Models;

namespace testing_authO.demo.Services
{
    public class AccountDataService : IDataService<RegUser>
    {

        private readonly AuthDbContextFactory _context;
        public AccountDataService(AuthDbContextFactory context)
        {
            _context = context;
        }


        public Task<RegUser> Create(RegUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RegUser>> GetAll()
        {
            using(AuthDbContext context= _context.CreateDbContext())
            {
                var entities = await context.Users.ToListAsync();

                return entities;
            }
        }

        public Task<RegUser> GetByUsername()
        {
            throw new NotImplementedException();
        }
    }
}
