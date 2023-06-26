using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace star.Models
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Datas> Datas { get; set; }

        private static readonly IConfigurationRoot _configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(path: "appsettings.json")
            .Build();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ServerVersion serverVersion = ServerVersion.Parse(_configBuilder["Data:ServerVersion"]);
            string connectionString = _configBuilder["Data:ConnectionString"];
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
