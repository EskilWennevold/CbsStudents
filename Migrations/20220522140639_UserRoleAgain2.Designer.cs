﻿// <auto-generated />
using System;
using CbsStudents.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace cbsStudents.Migrations
{
    [DbContext(typeof(CbsStudentsContext))]
    [Migration("20220522140639_UserRoleAgain2")]
    partial class UserRoleAgain2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("cbsStudents.Models.Entities.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Event");

                    b.HasData(
                        new
                        {
                            EventId = 20,
                            Date = new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Fredags Bar",
                            Location = "Guldbar",
                            Status = 1,
                            Text = "Første fredags bar kom glad og kom tørstig",
                            UserId = "1"
                        },
                        new
                        {
                            EventId = 22,
                            Date = new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Rustur",
                            Location = "Gilleleje Campingplads",
                            Status = 1,
                            Text = "Her kommer vi",
                            UserId = "2"
                        },
                        new
                        {
                            EventId = 21,
                            Date = new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Fredags Bar",
                            Location = "Guldbar",
                            Status = 1,
                            Text = "Anden fredags bar kom glad og kom tørstig",
                            UserId = "1"
                        });
                });

            modelBuilder.Entity("cbsStudents.Models.Entities.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 20,
                            Created = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0,
                            Text = "I'll be good waifu",
                            Title = "Happy wife happy life",
                            UserId = "1"
                        },
                        new
                        {
                            PostId = 22,
                            Created = new DateTime(2016, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0,
                            Text = "I'll be good waifu",
                            Title = "Marry me please desu",
                            UserId = "1"
                        },
                        new
                        {
                            PostId = 23,
                            Created = new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 0,
                            Text = "If you have seen the recent news you might realise that Hollywood is scary",
                            Title = "Johnny Deep is finally happy",
                            UserId = "2"
                        });
                });

            modelBuilder.Entity("Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            PostId = 20,
                            Url = "https://www.youtube.com/watch?v=XNwoowL2u24",
                            UserId = "2"
                        },
                        new
                        {
                            CommentId = 2,
                            PostId = 22,
                            Url = "Lorem ipsum exvacatum",
                            UserId = "2"
                        },
                        new
                        {
                            CommentId = 3,
                            PostId = 23,
                            Url = "Never say never",
                            UserId = "2"
                        });
                });

            modelBuilder.Entity("EventComment", b =>
                {
                    b.Property<int>("EventCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("EventCommentId");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("EventComment");

                    b.HasData(
                        new
                        {
                            EventCommentId = 1,
                            EventId = 20,
                            Text = "Det bliver fedt",
                            UserId = "1"
                        },
                        new
                        {
                            EventCommentId = 2,
                            EventId = 20,
                            Text = "Det bliver mega fedt",
                            UserId = "2"
                        },
                        new
                        {
                            EventCommentId = 3,
                            EventId = 21,
                            Text = "Det bliver bedre end den første",
                            UserId = "1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("IdentityUserClaim");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "eb3c1a83-c1c5-4952-a29d-337513e7fbb5",
                            Email = "chrk@kea.dk",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEPS8vIlks8QI6UjuNZwo3oK9+iadDe2nU2RLsDncHyb6Va4q9Xj/2lLg5CGnTMD1GQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "89743672-bf8b-4bd2-bd60-aa8db12e4d74",
                            TwoFactorEnabled = false,
                            UserName = "chrk@kea.dk"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f518ee56-14cf-4270-8b47-66f330ec9658",
                            Email = "test@kea.dk",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEL/3fljqafktn23GD8/ALyX3q3jMO9i+8tjxYNyHhbiQvCpKjczzQCN89Vz7Guwkvw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b06977b8-e11d-470c-b21f-e2535c9afaf8",
                            TwoFactorEnabled = false,
                            UserName = "test@kea.dk"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("IdentityUserClaim<string>");
                });

            modelBuilder.Entity("cbsStudents.Models.Entities.Event", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("cbsStudents.Models.Entities.Post", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Comment", b =>
                {
                    b.HasOne("cbsStudents.Models.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventComment", b =>
                {
                    b.HasOne("cbsStudents.Models.Entities.Event", "Event")
                        .WithMany("Comments")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("cbsStudents.Models.Entities.Event", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("cbsStudents.Models.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
