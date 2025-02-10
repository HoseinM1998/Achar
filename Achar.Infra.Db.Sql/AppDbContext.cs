using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Proposal> Bids { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubServices { get; set; }
        public DbSet<AcharDomainCore.Entites.HomeService> HomeServices { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
