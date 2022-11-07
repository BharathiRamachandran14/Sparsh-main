using System;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Sparsh.Models.Database;

namespace Sparsh
{
    public class SparshDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Storehouse> Storehouse { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<WishList> Wishlist { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        )
        {
            optionsBuilder.UseNpgsql(GetConnectionString());
        }

        private static string GetConnectionString()
        {
            var databaseUrl =
                Environment.GetEnvironmentVariable("DATABASE_URL");
            if (databaseUrl == null)
            {
                throw new Exception("Environment variable 'DATABASE_URL' must not be null");
            }

            bool useSsl = true;
            var useSslVariable = Environment.GetEnvironmentVariable("USE_SSL");
            if (useSslVariable != null)
            {
                if (!Boolean.TryParse(useSslVariable, out useSsl))
                {
                    throw new Exception("Environment variable 'USE_SSL' must be parse-able as bool");
                }
            }

            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            var builder =
                new NpgsqlConnectionStringBuilder {
                    Host = databaseUri.Host,
                    Port = databaseUri.Port,
                    Username = userInfo[0],
                    Password = userInfo[1],
                    Database = databaseUri.LocalPath.TrimStart('/')
                };
            if (useSsl)
            {
                builder.SslMode = SslMode.Require;
                builder.TrustServerCertificate = true;
            }

            return builder.ToString();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
