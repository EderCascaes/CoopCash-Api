using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace CoopCash.Infra.Persistence.Context
{
    public class CoopCashDbContextFactory : IDesignTimeDbContextFactory<CoopCashDbContext>
    {
        public CoopCashDbContext CreateDbContext(string[] args)
        {            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<CoopCashDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CoopCashDbContext(optionsBuilder.Options);
        }
    }
}
