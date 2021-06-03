using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Configurations
{
    public class QuestionStatisticConfiguration : IEntityTypeConfiguration<QuestionStatistic>
    {
        public void Configure(EntityTypeBuilder<QuestionStatistic> builder)
        {
            builder
                .HasKey(x => x.QuestionStatisticId);

            builder
                .Property(x => x.QuestionStatisticId)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.TimeStarted)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder
                .Property(x => x.TimeEnded)
                .IsRequired(false);

            builder
                .HasOne(g => g.GameRound)
                .WithMany(q => q.QuestionStatistics)
                .HasForeignKey(g => g.GameRoundId);
        }
    }
}
