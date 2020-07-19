using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using testing_authO.demo;
using testing_authO.demo.Models.Models;

namespace testing_authO.demo.Domain
{
    public class AuthDbContext:DbContext
    {
        public DbSet<RegUser> Users;
        public AuthDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
