using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistralAssignment.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ShowType> ShowTypes { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowActor> ShowActors { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Show>(entity =>
            {
                entity.HasKey(e => e.ShowId);

                entity.HasMany(e => e.Ratings).WithOne(e => e.Show).HasForeignKey(e => e.ShowId);
            });

            builder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.ActorId);
            });

            builder.Entity<ShowActor>(entity =>
            {
                entity.HasKey(new string[] {"ShowId", "ActorId"});

                entity.HasOne(e => e.Actor).WithMany(e => e.ActorShows).HasForeignKey(e => e.ActorId);
                entity.HasOne(e => e.Show).WithMany(e => e.Cast).HasForeignKey(e => e.ShowId);
            });
        }
    }
}
