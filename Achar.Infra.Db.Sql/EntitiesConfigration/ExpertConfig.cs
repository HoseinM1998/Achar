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
            builder.Property(x => x.IsActive)
                .HasDefaultValue(false);
            builder.HasMany(x => x.Skills)
                .WithMany(x => x.Experts);

            builder
                .HasMany(e => e.Comments)
                .WithOne(c => c.Expert)
                .HasForeignKey(c => c.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Expert>
            {
                new Expert()
                {
                    Id = 1,
                    ApplicationUserId = 5,
                    CityId = 1
                },
                new Expert()
                {
                    Id = 2,
                    ApplicationUserId = 6,
                    CityId = 6
                }
            });
        }
    }
}
