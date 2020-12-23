using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bodea_Denis.Models;

namespace Bodea_Denis.Data
{
    public class Bodea_DenisContext : DbContext
    {
        public Bodea_DenisContext (DbContextOptions<Bodea_DenisContext> options)
            : base(options)
        {
        }

        public DbSet<Bodea_Denis.Models.Masina> Masina { get; set; }

        public DbSet<Bodea_Denis.Models.Angajat> Angajat { get; set; }

        public DbSet<Bodea_Denis.Models.Dotare> Dotare { get; set; }
    }
}
