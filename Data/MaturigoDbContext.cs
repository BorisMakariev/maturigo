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
        public DbSet<Attempt> Attempts { get; set; }
        public DbSet<GivenAnswer> GivenAnswers { get; set; }
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

            builder.Entity<Attempt>().HasKey(a => a.Id);
            builder.Entity<Attempt>().Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Entity<GivenAnswer>().HasKey(g => g.Id);
            builder.Entity<GivenAnswer>().Property(g => g.Id).ValueGeneratedOnAdd();
        }
    }
}
