using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLib.Context
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions options) :base (options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) =>
                builder
                .UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=beauty_salon");
    }
}
