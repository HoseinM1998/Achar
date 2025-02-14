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

            builder.HasData(new List<Admin>
            {
                new Admin()
                {
                    Id = 1,
                    ApplicationUserId = 1
                }
            });
        }
    }
}
