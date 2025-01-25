using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserLike> Likes { get; set; }
         public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserLike>()
                .HasKey(k => new {k.SourceUserId, k.TargetUserId});
            
            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s =>s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade); // user DeleteBehavior.NoAction when using sql server

            builder.Entity<UserLike>()
                .HasOne(s => s.TargetUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s =>s.TargetUserId)
                .OnDelete(DeleteBehavior.Cascade);
            
             builder.Entity<Message>()
                .HasOne(s => s.Recipient)
                .WithMany(l => l.MessageReceived)
                .OnDelete(DeleteBehavior.Restrict);

             builder.Entity<Message>()
                .HasOne(s => s.Sender)
                .WithMany(l => l.MessageSent)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}