using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Entites;

namespace Achar.Infra.Db.SqLServer.EntitiesConfigration
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            {
                builder.HasKey(i => i.Id);

                builder.Property(i => i.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                builder.Property(i => i.ImgPath)
                    .IsRequired()
                    .HasMaxLength(100);
            }

        }
    }
}
