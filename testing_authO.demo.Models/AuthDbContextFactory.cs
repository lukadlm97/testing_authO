using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using testing_authO.demo.Domain;

namespace testing_authO.demo.Models
{
    public class AuthDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
    {
        public AuthDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<AuthDbContext>();
            options.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = Auth_O_Dev; Trusted_Connection = True; MultipleActiveResultSets = true");

            return new AuthDbContext(options.Options);
        }
    }
}
