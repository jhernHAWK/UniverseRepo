using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniverseRepo.Models;

namespace UniverseRepo.Data
{
    public class UniverseRepoContext : DbContext
    {
        public UniverseRepoContext (DbContextOptions<UniverseRepoContext> options)
            : base(options)
        {
        }

        public DbSet<UniverseRepo.Models.Universe> Universe { get; set; } = default!;
        public DbSet<UniverseRepo.Models.Character> Character { get; set; } = default!;
    }
}
