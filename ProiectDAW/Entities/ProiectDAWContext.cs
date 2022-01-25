using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProiectDAW.Entities
{
    public class ProiectDAWContext : IdentityDbContext <User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Service_Auto> Service_Autos { get; set; }
        public DbSet<ServiceAutoAdress> ServiceAutoAdresses { get; set; }

        public DbSet<Employee> Employees {  get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Service_AutoClient> Service_AutoClients { get; set; }
        public ProiectDAWContext (DbContextOptions <ProiectDAWContext> options) : base (options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Service_Auto>()
            .HasOne(a => a.ServiceAutoAdress)
            .WithOne(aa => aa.Service_Auto);


            builder.Entity<Service_Auto>()
                .HasMany(a => a.Employees)
                .WithOne(aa => aa.Service_Auto);

            builder.Entity<Service_AutoClient>().HasKey(ac => new { ac.Service_AutoId, ac.ClientId });

            builder.Entity<Service_AutoClient>()
                .HasOne<Service_Auto>(ac => ac.Service_Auto)
                .WithMany(ac => ac.Service_AutoClients)
                .HasForeignKey(ac => ac.Service_AutoId);

            builder.Entity<Service_AutoClient>()
                .HasOne<Client>(ac => ac.Client)
                .WithMany(ac => ac.Service_AutoClients)
                .HasForeignKey(ac => ac.ClientId);
        }
    }
}
