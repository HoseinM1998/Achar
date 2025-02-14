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
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired();
            builder.Property(c => c.Description)
                .HasMaxLength(4000)
                .IsRequired();
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(x => x.IsAccept)
                .HasDefaultValue(false);
            builder.HasOne(c => c.Customer)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.CustomerId) 
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.Expert)
                .WithMany(e => e.Comments)
                .HasForeignKey(c => c.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
