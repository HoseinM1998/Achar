using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achar.Infra.Db.SqLServer.EntitiesConfigration
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c => c.Image)
                .HasMaxLength(2000);
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);


            builder.HasData(
                new Category { Id = 1, Title = "تمیزکاری", Image = "/assets/img/category/TamizCari-con.png.png", IsDeleted = false},
                new Category { Id = 2, Title = "ساختمان ", Image = "/assets/img/category/Sakhtman-icon.png", IsDeleted = false },
                new Category { Id = 3, Title = "تعمیرات اشیا", Image = "/assets/img/category/Tamirat-icon.png", IsDeleted = false },
                new Category { Id = 4, Title = " اسباب کشی وحمل بار ", Image = "/assets/img/category/Asbabkeshi-icon.png", IsDeleted = false },
                new Category { Id = 5, Title = "خودرو ", Image = "/assets/img/category/Khodro-icon.png", IsDeleted = false },
                new Category { Id = 6, Title = " سلامت وزیبایی ", Image = "/assets/img/category/Salamat-icon.png", IsDeleted = false },
                new Category { Id = 7, Title = "سازمان ها و مجتمع ها ", Image = "/assets/img/category/Sazeman-icon.png", IsDeleted = false }
                );
        }
    }
}
