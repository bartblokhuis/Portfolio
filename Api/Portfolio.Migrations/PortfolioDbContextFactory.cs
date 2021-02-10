using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Portfolio.Database;

namespace Portfolio.Migrations
{
    public class PortfolioDbContextFactory : IDesignTimeDbContextFactory<PortfolioContext>
    {
        public PortfolioContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("dataSettings.json")
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<PortfolioContext>();
            var connectionString = configuration["ConnectionString:DefaultConnection"];

            dbContextBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Portfolio.Migrations"));

            return new PortfolioContext(dbContextBuilder.Options);
        }
    }
}
