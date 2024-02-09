using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Voting_App2.Models.Entities;
using VOTING_APP2.Models;
using VOTING_APP2.Models.Entities;

namespace VOTING_APP2.ontext
{
    public class VoteContext : DbContext
    {
      public string connectionString = "server=localhost;user=root;password=Basbal2a;Database=framework;";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL(connectionString);
        }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Party> Parties { get; set;}
        public DbSet<Voter> Voters {get; set;}
        public DbSet<Position> Positions {get; set;}
        public DbSet<VoteSession> Sessions {get; set; }
        public DbSet<User> Users {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
       
            modelBuilder.Entity<User>().HasData(
                new User{
                     Password = "Password",
                     Role = "SuperAdmin",
                    UserEmail = "user@example.com",
                    Id = "abcd"                    
                }
            );
        //DATA OPTIMIZATION USING INDEXING
        
          modelBuilder.Entity<Contestant>().HasIndex(a => a.Party);
          modelBuilder.Entity<Contestant>().HasIndex(a => a.Position);
          modelBuilder.Entity<Contestant>().HasIndex(a => a.IsVoting);
          modelBuilder.Entity<Voter>().HasIndex(a => a.HasVoted);
           
        }
    }
}