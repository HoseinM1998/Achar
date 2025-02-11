using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Achar.Infra.Db.SqLServer.EntitiesConfigration
{
    public class AdminConfig : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .IsRequired();
            builder.Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(a => a.LastName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(a => a.ProfileImageUrl)
                .HasMaxLength(4000);

            builder.HasData(new List<Admin>
            {
                new Admin()
                {
                    Id = 1,
                    FirstName = "ادمین",
                    LastName = "ادمین",
                    ProfileImageUrl = "/UserAssets/img/admin/1.jpg",
                    ApplicationUserId = 1
                }
            });
        }
    }
}
