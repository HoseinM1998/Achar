using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achar.Infra.Db.SqLServer.EntitiesConfigration
{
    public class ExpertConfig : IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(100);

            builder .Property(x => x.LastName)
                .HasMaxLength(100);

            builder
                .Property(x => x.Street)
                .HasMaxLength(250);

            builder
                .Property(x => x.IsActive)
                .HasDefaultValue(false);

            builder
                .Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder
                .HasMany(e => e.Comments)
                .WithOne(c => c.Expert)
                .HasForeignKey(c => c.ExpertId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new List<Expert>
            {
                new Expert()
                {
                    Id = 1,
                    FirstName = "سعید",
                    LastName = "لک‌",
                    ProfileImage = "/UserAssets/img/expert/1.jpg",
                    ApplicationUserId = 5
                },
                new Expert()
                {
                    Id = 2,
                    FirstName = "سحر",
                    ProfileImage = "/UserAssets/img/expert/1.jpg",
                    ApplicationUserId = 6
                }
            });
        }
    }
}
