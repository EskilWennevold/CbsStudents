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
            this.UsersSeed(modelBuilder);
            this.PostsSeed(modelBuilder);
            this.CommentsSeed(modelBuilder);
        modelBuilder.Entity<EventComment>()
            .HasOne(p => p.Event)
            .WithMany(b => b.Comments);
            this.EventsSeed(modelBuilder);
            this.EventCommentsSeed(modelBuilder);
        
        
    }
        public void EventsSeed(ModelBuilder builder) {
            builder.Entity<Event>().HasData(
                new Event{EventId = 20, EventName="Fredags Bar", Text="Første fredags bar kom glad og kom tørstig", Location="Guldbar", Date=new DateTime(2022,7,10), Status=PostStatus.PUBLISHED,UserId="1"},
                new Event{EventId = 22, EventName="Rustur", Text="Her kommer vi", Location="Gilleleje Campingplads", Date=new DateTime(2022,8,10), Status=PostStatus.PUBLISHED,UserId="2"},
                new Event{EventId = 21, EventName="Fredags Bar", Text="Anden fredags bar kom glad og kom tørstig", Location="Guldbar", Date=new DateTime(2022,7,10), Status=PostStatus.PUBLISHED,UserId="1"}
                );
        }
        public void EventCommentsSeed(ModelBuilder builder) {
            builder.Entity<EventComment>().HasData(
                new EventComment{EventCommentId=1, EventId = 20, Text="Det bliver fedt", UserId="1"},
                new EventComment{EventCommentId=2,EventId = 20, Text="Det bliver mega fedt", UserId="2"},
                new EventComment{EventCommentId=3,EventId = 21, Text="Det bliver bedre end den første", UserId="1"}
                );
        }
        private void PostsSeed(ModelBuilder builder){
            builder.Entity<Post>().HasData(
                new Post{PostId = 20, Title = "Happy wife happy life", Text = "I'll be good waifu", Created = new DateTime(2015, 12, 25), Status = PostStatus.DRAFT, UserId="1"},
                new Post{PostId = 22, Title = "Marry me please desu", Text = "I'll be good waifu", Created = new DateTime(2016, 12, 25), Status = PostStatus.DRAFT,UserId="1"},
                new Post{PostId = 23, Title = "Johnny Deep is finally happy", Text = "If you have seen the recent news you might realise that Hollywood is scary", Created = new DateTime(2022, 6, 1), Status = PostStatus.DRAFT,UserId="2"}

                );
        }
        public void CommentsSeed(ModelBuilder builder) 
        { 
            builder.Entity<Comment>().HasData(
                new { PostId = 20, CommentId = 1, Url = "https://www.youtube.com/watch?v=XNwoowL2u24",UserId="2"},
                new { PostId = 22, CommentId = 2, Url = "Lorem ipsum exvacatum",UserId="2" },
                new { PostId = 23, CommentId = 3, Url = "Never say never",UserId="2"}

            );
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
            builder.Entity<IdentityUserClaim<string>>().HasKey(p => new {p.Id});
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<IdentityUser> IdentityUserClaim {get; set;}

        public DbSet<cbsStudents.Models.Entities.Event> Event { get; set; }

        public DbSet<EventComment> EventComment { get; set; }

        


    }
}
