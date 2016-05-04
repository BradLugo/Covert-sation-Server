using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covert_sation_Server.Models
{
    public class CovertContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }

        public CovertContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMessage>()
               .HasKey(t => new { t.UserId, t.MessageId });
            modelBuilder.Entity<UserMessage>()
                .HasKey(t => new { t.UserId, t.MessageId });

            modelBuilder.Entity<UserMessage>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.Messages)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserMessage>()
                .HasOne(pt => pt.Message)
                .WithMany(t => t.Receivers)
                .HasForeignKey(pt => pt.MessageId);
        }
    }
}
