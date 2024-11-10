using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class TradingBotDbContextFactory : IDesignTimeDbContextFactory<TradingBotDbContext>
    {
        public TradingBotDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TradingBotDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new TradingBotDbContext(optionsBuilder.Options);
        }
    }
}
