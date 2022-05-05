using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cbsStudents.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace CbsStudents.Data
{
    public class CbsStudentsContext : DbContext
    {
        public CbsStudentsContext (DbContextOptions<CbsStudentsContext> options)
            : base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>()
            .HasOne(p => p.Post)
            .WithMany(b => b.Comments);

        modelBuilder.Entity<Post>().HasData(new Post{PostId = 20, Title = "Marry me please desu", Text = "I'll be good waifu", Created = new DateTime(2015, 12, 25), Status = PostStatus.DRAFT});
        modelBuilder.Entity<Comment>().HasData(
            new { PostId = 20, CommentId = 2, Url = "https://www.youtube.com/watch?v=XNwoowL2u24" });
        modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(p => new {p.Id});
        
    }
        private void UsersSeed(ModelBuilder builder)
        {
            var user1 = new IdentityUser
            {
                Id = "1", Email = "chrk@kea.dk",
                EmailConfirmed = true, UserName = "chrk@kea.dk",
            };
            var user2 = new IdentityUser
            {
                Id = "2", Email = "test@kea.dk",
                EmailConfirmed = true, UserName = "test@kea.dk",
            };

        PasswordHasher<IdentityUser> passHash = new PasswordHasher<IdentityUser>();
            user1.PasswordHash = passHash.HashPassword(user1, "aA123456!");
            user2.PasswordHash = passHash.HashPassword(user2, "aA123456!");

            builder.Entity<IdentityUser>().HasData(
                user1, user2
            );
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<IdentityUser> IdentityUserClaim {get; set;}

        public DbSet<cbsStudents.Models.Entities.Event> Event { get; set; }

        


    }
}
