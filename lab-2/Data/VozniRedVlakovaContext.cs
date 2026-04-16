using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VozniRedVlakova.Models;

namespace VozniRedVlakova.Data
{
    public class VozniRedVlakovaContext : DbContext
    {
        public VozniRedVlakovaContext (DbContextOptions<VozniRedVlakovaContext> options)
            : base(options)
        {
        }

        public DbSet<VozniRedVlakova.Models.Vlak> Vlak { get; set; } = default!;
    }
}
