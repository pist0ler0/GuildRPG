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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            modelBuilder.Entity<Mercenary>().HasData(
                new Mercenary { Id = 1, Name = "Arthur", Level = 5, MaxHealth = 100, Damage = 15, CurrentHealth = 100, ExperiencePoints = 100, Gold = 42198 },
                new Mercenary { Id = 2, Name = "Lancelot", Level = 7, MaxHealth = 120, Damage = 20, CurrentHealth = 120, ExperiencePoints = 100, Gold = 42198 },
                new Mercenary { Id = 3, Name = "Paulina Heros", Level = 25, MaxHealth = 10000, Damage = 1500, CurrentHealth = 10000, ExperiencePoints = 100, Gold = 42198 },
                new Mercenary { Id = 4, Name = "Cieć Boss", Level = 99, MaxHealth = 100000, Damage = 100000, CurrentHealth = 100000, ExperiencePoints = 100, Gold = 42198 },
                new Mercenary { Id = 5, Name = "Zwykły Maciek", Level = 8, MaxHealth = 100, Damage = 15, CurrentHealth = 100, ExperiencePoints = 100, Gold = 42198 },
                new Mercenary { Id = 6, Name = "Kasztan ze wsi", Level = 1, MaxHealth = 100, Damage = 15, CurrentHealth = 100, ExperiencePoints = 100, Gold = 42198 },
                new Mercenary { Id = 7, Name = "Dres spod żabki", Level = 9, MaxHealth = 100, Damage = 15, CurrentHealth = 100, ExperiencePoints = 100, Gold = 42198 },
                new Mercenary { Id = 8, Name = "Nie mam Więcej pomysłów", Level = 5, MaxHealth = 100, Damage = 15, CurrentHealth = 100, ExperiencePoints = 100, Gold = 42198 }
            );

            modelBuilder.Entity<Monster>().HasData(
                new Monster { Id = 1, Name = "Smokuch", Health = 2000, Damage = 200 },
                new Monster { Id = 2, Name = "Goblin", Health = 100, Damage = 5 },
                new Monster { Id = 3, Name = "Paulina Wiedźma", Health = 800, Damage = 100 },
                new Monster { Id = 4, Name = "Ork", Health = 500, Damage = 50 },
                new Monster { Id = 5, Name = "Czerwony Ork", Health = 1500, Damage = 150 },
                new Monster { Id = 6, Name = "Bestia z Groty", Health = 2000, Damage = 200 },
                new Monster { Id = 7, Name = "Żul Mietek", Health = 10, Damage = 1 },
                new Monster { Id = 8, Name = "Mamlambo", Health = 10000, Damage = 1000 },
                new Monster { Id = 9, Name = "Diabeł", Health = 999999, Damage = 999999 }
            );

            modelBuilder.Entity<Quest>().HasData(
                new Quest { Id = 1, Name = "Smocza Grota", Location = "Góry Mroczne",Description = "aaaaaaaaaaaaaaaaaaaa", Diff = Difficulty.uberHard, EnemyId=1},
                new Quest { Id = 2, Name = "Goblińska Wioska", Location = "Las Cienia",Description = "BBBBBBBBBBBBBBBB" ,Diff = Difficulty.notSoEasy, EnemyId = 2}
            );
        }

        public DbSet<GuildRPG.Models.Mercenary> Mercenary { get; set; } = default!;
        public DbSet<GuildRPG.Models.Monster> Monster { get; set; } = default!;
        public DbSet<GuildRPG.Models.Quest> Quest { get; set; } = default!;
    }
}
