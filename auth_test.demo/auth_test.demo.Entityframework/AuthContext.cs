using auth_test.demo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace auth_test.demo.Entityframework
{
    public class AuthContext:DbContext
    {
        public AuthContext()
        {

        }
        public AuthContext(DbContextOptions<AuthContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }
    }
}
