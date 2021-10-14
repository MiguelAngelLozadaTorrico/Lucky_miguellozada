using Lucky_miguellozada.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lucky_miguellozada.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Suerte> Suertesita { get; set; }
        public object Suerte { get; internal set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

    }
}
