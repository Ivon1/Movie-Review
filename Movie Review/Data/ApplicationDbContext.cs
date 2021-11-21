using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie_Review.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Review.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public DbSet<Janre> Janre { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public DbSet<Film> Film { get; set; }
    }
}
