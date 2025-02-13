using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Achar.Infra.Db.SqLServer.EntitiesConfigration
{
    public class SubCategoryConfig : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        
            builder.HasOne(x => x.Category)
                .WithMany(y => y.SubCategories)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.HomeServices)
                .WithOne(y => y.SubCategory)
                .HasForeignKey(y => y.SubCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new SubCategory { Id = 1, Title = "نظافت و پذیرایی", Image = "/assets/img/subcategory/Tamiz-1-mage.png", CategoryId = 1, IsDeleted = false },
                new SubCategory { Id = 2, Title = "شستشو", Image = "/assets/img/subcategory/Tamiz-2-mage.png", CategoryId = 1, IsDeleted = false },
                new SubCategory { Id = 3, Title = " آشپزی", Image = "/assets/img/subcategory/Tamiz-3-mage.png", CategoryId = 1, IsDeleted = false },
                new SubCategory { Id = 4, Title = "سرمایش و گرمایش", Image = "/assets/img/subcategory/Sakhtman-1-image.png", CategoryId = 2, IsDeleted = false },
                new SubCategory { Id = 5, Title = "تعمیرات ساختمان", Image = "/assets/img/subcategory/Sakhtman-2-image.png", CategoryId = 2, IsDeleted = false },
                new SubCategory { Id = 6, Title = "لوله کشی", Image = "/assets/img/subcategory/Sakhtman-3-image.png", CategoryId = 2, IsDeleted = false },
                new SubCategory { Id = 7, Title = "برقکاری", Image = "/assets/img/subcategory/Sakhtman-4-image.png", CategoryId = 2, IsDeleted = false },
                new SubCategory { Id = 8, Title = "چوب وکابینت", Image = "/assets/img/subcategory/Sakhtman-6-image.png", CategoryId = 2, IsDeleted = false },
                new SubCategory { Id = 9, Title = "خدمات شیشه ای ساختمان", Image = "/assets/img/subcategory/Sakhtman-7-image.png", CategoryId = 2, IsDeleted = false },
                new SubCategory { Id = 10, Title = "سرمایش وگرمایش", Image = "/assets/img/subcategory/", CategoryId = 3, IsDeleted = false },
                new SubCategory { Id = 11, Title = "نصب و تعمیرات لوارم خانگی", Image = "/assets/img/subcategory/Tamirat-1-image.png", CategoryId = 3, IsDeleted = false },
                new SubCategory { Id = 12, Title = "خدمات کامپیوتری", Image = "/assets/img/subcategory/Tamirat-2-image.png", CategoryId = 3, IsDeleted = false },
                new SubCategory { Id = 13, Title = "تعمیرات موبایل", Image = "/assets/img/subcategory/Tamirat-3-image.png", CategoryId = 3, IsDeleted = false },
                new SubCategory { Id = 14, Title = "باربری و جابه جایی", Image = "/assets/img/subcategory/asbabkeshi.jpg", CategoryId = 4, IsDeleted = false },
                new SubCategory { Id = 15, Title = "خدمات و تعمیرات خودرو", Image = "/assets/img/subcategoryKhodro-1-image.png/", CategoryId = 5, IsDeleted = false },
                new SubCategory { Id = 16, Title = "کارواش و دیتلینگ", Image = "/assets/img/subcategory/Khodro-2-image.png", CategoryId = 5, IsDeleted = false },
                new SubCategory { Id = 17, Title = "زیبایی بانوان", Image = "/assets/img/subcategory/Salamat-1-image.png", CategoryId = 6, IsDeleted = false },
                new SubCategory { Id = 18, Title = "پزشکی و پرستاری", Image = "/assets/img/subcategory/Salamat-2-image.png", CategoryId = 6, IsDeleted = false },
                new SubCategory { Id = 19, Title = "حیوانات خانگی", Image = "/assets/img/subcategory/Salamat-3-image.png", CategoryId = 6, IsDeleted = false },
                new SubCategory { Id = 20, Title = "مشاوره", Image = "/assets/img/subcategory/Salamat-4-image.png", CategoryId = 6, IsDeleted = false },
                new SubCategory { Id = 21, Title = "پیرایش و زیبایی آقایان", Image = "/assets/img/subcategory/Salamat-5-image.png", CategoryId = 6, IsDeleted = false },
                new SubCategory { Id = 22, Title = "تندرستی و ورزش", Image = "/assets/img/subcategory/Salamat-6-image.png", CategoryId = 6, IsDeleted = false },
                new SubCategory { Id = 23, Title = "خدمات شرکتی", Image = "/assets/img/subcategory/Sazeman-1-image.png", CategoryId = 7, IsDeleted = false },
                new SubCategory { Id = 24, Title = "تامین نیروی انسانی", Image = "/assets/img/subcategory/Sazeman-1-image.png", CategoryId = 7, IsDeleted = false }

            );
        }
    }
}
