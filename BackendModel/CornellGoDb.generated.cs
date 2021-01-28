//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v3.0.2.0
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendModel
{
   /// <summary>
   /// Model of the CornellGO backend
   /// </summary>
   public partial class CornellGoDb : DbContext
   {
      #region DbSets

      /// <summary>
      /// Repository for global::BackendModel.Authenticator - User authentication data
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::BackendModel.Authenticator> Authenticators { get; set; }

      /// <summary>
      /// Repository for global::BackendModel.Challenge - A challenge with a place associated
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::BackendModel.Challenge> Challenges { get; set; }

      /// <summary>
      /// Repository for global::BackendModel.Feedback - Feedback created by the user
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::BackendModel.Feedback> Feedbacks { get; set; }

      /// <summary>
      /// Repository for global::BackendModel.Group - A group containing members
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::BackendModel.Group> Groups { get; set; }

      /// <summary>
      /// Repository for global::BackendModel.GroupMember - A member of a group
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::BackendModel.GroupMember> GroupMembers { get; set; }

      /// <summary>
      /// Repository for global::BackendModel.PrevChallenge - A user&apos;s previous challenge
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::BackendModel.PrevChallenge> PrevChallenges { get; set; }

      /// <summary>
      /// Repository for global::BackendModel.Suggestion - Place suggestion created by the
      /// user
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::BackendModel.Suggestion> Suggestions { get; set; }

      /// <summary>
      /// Repository for global::BackendModel.User - A user with an associated group
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::BackendModel.User> Users { get; set; }

      /// <summary>
      /// Repository for global::BackendModel.UserSession - A user&apos;s session with the server
      /// </summary>
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::BackendModel.UserSession> UserSessions { get; set; }

      #endregion DbSets

      /// <inheritdoc />
      public CornellGoDb(DbContextOptions<CornellGoDb> options) : base(options)
      {
      }

      partial void CustomInit(DbContextOptionsBuilder optionsBuilder);

      /// <inheritdoc />
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         CustomInit(optionsBuilder);
      }

      partial void OnModelCreatingImpl(ModelBuilder modelBuilder);
      partial void OnModelCreatedImpl(ModelBuilder modelBuilder);

      /// <inheritdoc />
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         OnModelCreatingImpl(modelBuilder);

         modelBuilder.HasDefaultSchema("dbo");

         modelBuilder.Entity<global::BackendModel.Authenticator>()
                     .ToTable("Authenticators")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::BackendModel.Authenticator>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Authenticator>()
                     .Property(t => t.Email)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Authenticator>()
                     .Property(t => t.Password)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Authenticator>()
                     .Property(t => t.Timestamp)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Authenticator>().Navigation(e => e.User).IsRequired();
         modelBuilder.Entity<global::BackendModel.Authenticator>()
                     .HasOne<global::BackendModel.User>(p => p.User)
                     .WithOne()
                     .HasForeignKey("Authenticator", "UserId")
                     .OnDelete(DeleteBehavior.NoAction);

         modelBuilder.Entity<global::BackendModel.Challenge>()
                     .ToTable("Challenges")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::BackendModel.Challenge>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Challenge>()
                     .Property(t => t.Name)
                     .HasMaxLength(60)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Challenge>()
                     .Property(t => t.Description)
                     .HasMaxLength(100)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Challenge>()
                     .Property(t => t.Points)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Challenge>()
                     .Property(t => t.LongLat)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Challenge>()
                     .Property(t => t.Radius)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Challenge>()
                     .Property(t => t.ImageJPG)
                     .IsRequired();

         modelBuilder.Entity<global::BackendModel.Feedback>()
                     .ToTable("Feedbacks")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::BackendModel.Feedback>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Feedback>()
                     .Property(t => t.Message)
                     .HasMaxLength(250)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Feedback>()
                     .Property(t => t.Timestamp)
                     .IsRequired();

         modelBuilder.Entity<global::BackendModel.Group>()
                     .ToTable("Groups")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::BackendModel.Group>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Group>()
                     .Property(t => t.Version)
                     .IsRowVersion()
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Group>().Navigation(e => e.Challenge).IsRequired();
         modelBuilder.Entity<global::BackendModel.Group>()
                     .HasOne<global::BackendModel.Challenge>(p => p.Challenge)
                     .WithOne()
                     .HasForeignKey("Group", "ChallengeId")
                     .OnDelete(DeleteBehavior.NoAction);
         modelBuilder.Entity<global::BackendModel.Group>()
                     .HasMany<global::BackendModel.Challenge>(p => p.PrevChallenges)
                     .WithOne()
                     .HasForeignKey("GroupPrevChallengesId")
                     .OnDelete(DeleteBehavior.NoAction);
         modelBuilder.Entity<global::BackendModel.Group>()
                     .HasMany<global::BackendModel.GroupMember>(p => p.GroupMembers)
                     .WithOne(p => p.Group)
                     .HasForeignKey("GroupId");
         modelBuilder.Entity<global::BackendModel.GroupMember>().Navigation(e => e.Group).IsRequired();

         modelBuilder.Entity<global::BackendModel.GroupMember>()
                     .ToTable("GroupMembers")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::BackendModel.GroupMember>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.GroupMember>()
                     .Property(t => t.IsHost)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.GroupMember>()
                     .Property(t => t.IsDone)
                     .IsRequired();

         modelBuilder.Entity<global::BackendModel.PrevChallenge>()
                     .ToTable("PrevChallenges")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::BackendModel.PrevChallenge>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.PrevChallenge>()
                     .Property(t => t.Timestamp)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.PrevChallenge>().Navigation(e => e.Challenge).IsRequired();
         modelBuilder.Entity<global::BackendModel.PrevChallenge>()
                     .HasOne<global::BackendModel.Challenge>(p => p.Challenge)
                     .WithOne()
                     .HasForeignKey("PrevChallenge", "ChallengeId")
                     .OnDelete(DeleteBehavior.NoAction);

         modelBuilder.Entity<global::BackendModel.Suggestion>()
                     .ToTable("Suggestions")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::BackendModel.Suggestion>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Suggestion>()
                     .Property(t => t.ImageJPG)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Suggestion>()
                     .Property(t => t.LongLat)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Suggestion>()
                     .Property(t => t.Name)
                     .HasMaxLength(60)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Suggestion>()
                     .Property(t => t.Desc)
                     .HasMaxLength(100)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.Suggestion>()
                     .Property(t => t.Timestamp)
                     .IsRequired();

         modelBuilder.Entity<global::BackendModel.User>()
                     .ToTable("Users")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::BackendModel.User>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.User>()
                     .Property(t => t.Score)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.User>()
                     .Property(t => t.Username)
                     .HasMaxLength(120)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.User>()
                     .Property(t => t.Email)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.User>()
                     .HasMany<global::BackendModel.PrevChallenge>(p => p.PrevChallenges)
                     .WithOne()
                     .HasForeignKey("UserPrevChallengesId")
                     .OnDelete(DeleteBehavior.Cascade);
         modelBuilder.Entity<global::BackendModel.User>()
                     .HasMany<global::BackendModel.Suggestion>(p => p.Suggestions)
                     .WithOne(p => p.User)
                     .HasForeignKey("UserId")
                     .OnDelete(DeleteBehavior.NoAction);
         modelBuilder.Entity<global::BackendModel.Suggestion>().Navigation(e => e.User).IsRequired();
         modelBuilder.Entity<global::BackendModel.User>()
                     .HasMany<global::BackendModel.Feedback>(p => p.Feedbacks)
                     .WithOne(p => p.User)
                     .HasForeignKey("UserId")
                     .OnDelete(DeleteBehavior.NoAction);
         modelBuilder.Entity<global::BackendModel.Feedback>().Navigation(e => e.User).IsRequired();
         modelBuilder.Entity<global::BackendModel.User>()
                     .HasOne<global::BackendModel.GroupMember>(p => p.GroupMember)
                     .WithOne(p => p.User)
                     .HasForeignKey("GroupMember", "UserId")
                     .OnDelete(DeleteBehavior.Cascade)
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.GroupMember>().Navigation(e => e.User).IsRequired();
         modelBuilder.Entity<global::BackendModel.User>()
                     .HasOne<global::BackendModel.UserSession>(p => p.UserSession)
                     .WithOne(p => p.User)
                     .HasForeignKey("UserSession", "UserId");
         modelBuilder.Entity<global::BackendModel.UserSession>().Navigation(e => e.User).IsRequired();

         modelBuilder.Entity<global::BackendModel.UserSession>()
                     .ToTable("UserSessions")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::BackendModel.UserSession>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::BackendModel.UserSession>()
                     .Property(t => t.Timestamp)
                     .IsRequired();

         OnModelCreatedImpl(modelBuilder);
      }
   }
}
