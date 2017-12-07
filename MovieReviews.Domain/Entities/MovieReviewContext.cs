namespace MovieReviews.Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MovieReviewContext : DbContext
    {
        public MovieReviewContext()
            : base("name=MovieReviewContext")
        {
        }

        public virtual DbSet<Critic> Critics { get; set; }
        public virtual DbSet<CriticsPhoto> CriticsPhotos { get; set; }
        public virtual DbSet<MoviePoster> MoviePosters { get; set; }
        public virtual DbSet<MovieReview> MovieReviews { get; set; }
        public virtual DbSet<Movy> Movies { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Critic>()
                .Property(e => e.CriticName)
                .IsUnicode(false);

            modelBuilder.Entity<Critic>()
                .Property(e => e.Publication)
                .IsUnicode(false);

            modelBuilder.Entity<Critic>()
                .HasMany(e => e.CriticsPhotos)
                .WithRequired(e => e.Critic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Critic>()
                .HasMany(e => e.MovieReviews)
                .WithRequired(e => e.Critic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MovieReview>()
                .Property(e => e.ReviewSynopsis)
                .IsUnicode(false);

            modelBuilder.Entity<MovieReview>()
                .Property(e => e.ReviewRatingNum)
                .HasPrecision(6, 2);

            modelBuilder.Entity<MovieReview>()
                .Property(e => e.ReviewRatingDen)
                .HasPrecision(6, 2);

            modelBuilder.Entity<MovieReview>()
                .Property(e => e.ReviewUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Movy>()
                .Property(e => e.MovieName)
                .IsUnicode(false);

            modelBuilder.Entity<Movy>()
                .Property(e => e.Rating)
                .IsUnicode(false);

            modelBuilder.Entity<Movy>()
                .Property(e => e.Director)
                .IsUnicode(false);

            modelBuilder.Entity<Movy>()
                .Property(e => e.Studio)
                .IsUnicode(false);

            modelBuilder.Entity<Movy>()
                .Property(e => e.Synopsis)
                .IsUnicode(false);

            modelBuilder.Entity<Movy>()
                .HasMany(e => e.MoviePosters)
                .WithRequired(e => e.Movy)
                .HasForeignKey(e => e.MovieId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movy>()
                .HasMany(e => e.MovieReviews)
                .WithRequired(e => e.Movy)
                .HasForeignKey(e => e.MovieId)
                .WillCascadeOnDelete(false);
        }
    }
}
