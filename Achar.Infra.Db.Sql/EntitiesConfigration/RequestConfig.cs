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
    public class RequestConfig : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(sr => sr.Id);
            builder.Property(sr => sr.Id)
                .IsRequired();
            builder.Property(sr => sr.Description)
                .HasMaxLength(4000)
                .IsRequired();
            builder.Property(sr => sr.Status)
                .IsRequired();
            builder.Property(sr => sr.Price)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
            builder.HasOne(x => x.Service)
                .WithMany(y => y.Requests)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                .WithMany(y => y.Requests)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AcceptedExpert)
                .WithMany(y => y.AcceptedRequests)
                .HasForeignKey(x => x.AcceptedExpertId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Proposals)
                .WithOne(y => y.Request)
                .HasForeignKey(x => x.RequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
