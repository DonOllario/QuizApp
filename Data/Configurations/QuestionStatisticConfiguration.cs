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
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.TimeStarted)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder
                .Property(x => x.TimeEnded)
                .IsRequired(false);
        }
    }
}
