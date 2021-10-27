﻿using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<Platform> Platfroms { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(p => p.Platform)
                .HasForeignKey(p => p.PlatformId);
            modelBuilder
                .Entity<Command>()
                .HasOne(c => c.Platform)
                .WithMany(c => c.Commands)
                .HasForeignKey(c => c.PlatformId);
        }
    }
}
