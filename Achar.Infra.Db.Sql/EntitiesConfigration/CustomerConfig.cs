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
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder  .HasKey(c => c.Id);
            builder .Property(c => c.Id)
                .IsRequired();
            builder .Property(c => c.FirstName)
                .HasMaxLength(50);
            builder
                .Property(c => c.LastName)
                .HasMaxLength(50);
            builder.Property(c => c.ProfileImageUrl)
                .HasMaxLength(500);
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.HasData(new List<Customer>
            {
                new Customer ()
                {
                    Id = 1,
                    FirstName = "حسین",
                    LastName = "مصلحی",
                    CityId = 6,
                    ProfileImageUrl = "/UserAssets/img/customer/1.jpg",
                    ApplicationUserId = 2
                },

                new Customer ()
                {
                    Id = 2,
                    FirstName = "جواد",
                    LastName = "مرادی",
                    CityId = 1,
                    ProfileImageUrl = "/UserAssets/img/customer/2.jpg",
                    ApplicationUserId = 3
                },

                new Customer ()
                {
                    Id = 3,
                    FirstName = "عارف",
                    LastName = "بهمنی",
                    CityId = 1,
                    ProfileImageUrl = "/UserAssets/img/customer/3.jpg",
                    ApplicationUserId = 4
                }
            });

        }
    }
}
