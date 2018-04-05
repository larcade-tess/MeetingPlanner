using MeetingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingPlanner.Data
{
    public class MeetingContext : DbContext
    {
        public MeetingContext(DbContextOptions<MeetingContext> options) : base(options)
        {
        }

        public DbSet<Bulletin> Bulletins { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bulletin>().ToTable("Bulletin");
            modelBuilder.Entity<Speaker>().ToTable("Speaker");
        }
    }
}