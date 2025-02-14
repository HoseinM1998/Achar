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

            builder.HasData(new List<Customer>
            {
                new Customer ()
                {
                    Id = 1,
                    CityId = 6,
                    ApplicationUserId = 2
                },
                new Customer ()
                {
                    Id = 2,
                    CityId = 1,
                    ApplicationUserId = 3
                },
                new Customer ()
                {
                    Id = 3,
                    CityId = 1,
                    ApplicationUserId = 4
                }
            });

        }
    }
}
