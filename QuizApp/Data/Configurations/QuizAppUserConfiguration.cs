using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class QuizAppUserConfiguration : IEntityTypeConfiguration<QuizAppUser>
    {
        public void Configure(EntityTypeBuilder<QuizAppUser> builder)
        {
            builder
                .Ignore(x => x.Claims);
        }
    }
}
