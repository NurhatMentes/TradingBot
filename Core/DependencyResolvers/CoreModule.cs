using Core.Configuration;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        private readonly IConfiguration _configuration;

        public CoreModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<ILogManager, LogManager>();

            // Redis Configuration
            var redisConfig = _configuration.GetSection("Redis").Get<RedisConfiguration>();
            if (redisConfig?.Enabled == true)
            {
                services.AddSingleton<ICacheManager>(_ =>
                    new RedisCacheManager(redisConfig.ConnectionString));
            }
        }
    }
}
