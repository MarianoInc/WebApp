using ClientRegister.Data.Seeds;
using ClientRegister.Support.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ClientRegister.Data.DataContext
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Client>()
                .Property(b => b.Properties)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v));

            builder.ApplyConfiguration(new ClientSeed());
            builder.ApplyConfiguration(new UserSeed());
            builder.ApplyConfiguration(new RolSeed());
        }
    }
}
