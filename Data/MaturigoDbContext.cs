using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using maturigo.Models.Entities;

namespace maturigo.Data
{
    public class MaturigoDbContext : IdentityDbContext
    {
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public MaturigoDbContext(DbContextOptions<MaturigoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Exam>().HasKey(e => e.Id);
            builder.Entity<Exam>().Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Entity<Question>().HasKey(q => q.Id);
            builder.Entity<Question>().Property(q => q.Id).ValueGeneratedOnAdd();

            builder.Entity<Answer>().HasKey(a => a.Id);
            builder.Entity<Answer>().Property(a => a.Id).ValueGeneratedOnAdd();
        }
    }
}
