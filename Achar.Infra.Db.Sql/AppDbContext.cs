using Achar.Infra.Db.SqLServer.EntitiesConfigration;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Achar.Infra.Db.Sql
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {

        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=LAPTOP-GM2D722B; Initial Catalog=Achar; User Id=sa; Password=13771377; TrustServerCertificate=True;");
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplicationUserConfig.SeedUsers(modelBuilder);
            modelBuilder.ApplyConfiguration(new AdminConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CityConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new ExpertConfig());
            modelBuilder.ApplyConfiguration(new HomeServiceConfig());
            modelBuilder.ApplyConfiguration(new BidConfig());
            modelBuilder.ApplyConfiguration(new RequestConfig());
            modelBuilder.ApplyConfiguration(new SubCategoryConfig());
            base.OnModelCreating(modelBuilder);
        }


      

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<AcharDomainCore.Entites.HomeService> HomeServices { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
