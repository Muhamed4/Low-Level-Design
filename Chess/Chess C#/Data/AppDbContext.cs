using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Chess_C_.Data
{
    public class AppDbContext: DbContext
    {
        private static readonly object _lock = new object();
        private static AppDbContext? dbContext;
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerPhone> PlayerPhones{ get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerGame> PlayerGames { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        // private AppDbContext() { }
        // Apply Singleton Design Pattern
        // public static AppDbContext Instance 
        // {
        //     get 
        //     {
        //         // Using double checking for thread safety
        //         if(dbContext == null) 
        //         {
        //             lock (_lock) {
        //                 if(dbContext == null)
        //                     dbContext = new AppDbContext();
        //             }
        //         }
        //         return dbContext;
        //     }
        // }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = config.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}