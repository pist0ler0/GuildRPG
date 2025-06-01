using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GuildRPG.Models;

namespace GuildRPG.Data
{
    public class GuildRPGContext : DbContext
    {
        public GuildRPGContext (DbContextOptions<GuildRPGContext> options)
            : base(options)
        {
        }

        public DbSet<GuildRPG.Models.Mercenary> Mercenary { get; set; } = default!;
    }
}
