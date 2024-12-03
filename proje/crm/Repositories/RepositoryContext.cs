using System.Reflection;
using Entities.Models;
using Iyzipay;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
    public class RepositoryContext : IdentityDbContext<AppUser>
    {
        public DbSet<Meet> meets { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MeetSlot> MeetSlots { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
       : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}