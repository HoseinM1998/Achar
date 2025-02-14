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
                .HasForeignKey(x => x.HomeServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Customer)
                .WithMany(y => y.Requests)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.AcceptedExpert)
                .WithMany(y => y.Requests)
                .HasForeignKey(x => x.AcceptedExpertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Bids)
                .WithOne(y => y.Request)
                .HasForeignKey(x => x.RequestId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Images)
                .WithOne(y => y.Request)
                .HasForeignKey(x => x.RequestId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
