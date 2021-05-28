using Data.Configurations;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class QuizAppDbContext : DbContext
    {
        public QuizAppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<GameRound> GameRounds { get; set; }
        public DbSet<QuestionStatistic> QuestionStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new GameRoundConfiguration())
                .ApplyConfiguration(new QuestionStatisticConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
