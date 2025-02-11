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
    public class ProposalConfig : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
            builder .HasKey(p => p.Id);
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
            builder .Property(p => p.Description)
                .HasMaxLength(4000)
                .IsRequired();

        }
    }
}
