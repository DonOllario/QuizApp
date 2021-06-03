using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Configurations
{
    public class GameRoundConfiguration : IEntityTypeConfiguration<GameRound>
    {
        public void Configure(EntityTypeBuilder<GameRound> builder)
        {
            builder
                .HasKey(x => x.GameRoundId);

            builder
                .Property(x => x.GameRoundId)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.TimeStarted)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder
                .Property(x => x.TimeEnded)
                .IsRequired(false);

            builder
                .HasMany(q => q.QuestionStatistics)
                .WithOne(g => g.GameRound)
                .HasForeignKey(q => q.QuestionStatisticId);
        }
    }
}
