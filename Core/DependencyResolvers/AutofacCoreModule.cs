using Autofac;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.Security.Hashing;
using Core.Security.JWT;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;


namespace Core.DependencyResolvers
{
    public class AutofacCoreModule : Module
    {
        private readonly IConfiguration _configuration;

        public AutofacCoreModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Configuration Registration
            builder.RegisterInstance(_configuration)
                .As<IConfiguration>()
                .SingleInstance();

            // Security Services Registration
            builder.RegisterType<HashingHelper>()
                .As<IHashingHelper>()
                .SingleInstance();

            builder.RegisterType<JwtHelper>()
                .As<ITokenHelper>()
                .SingleInstance();

            // Cache Manager Registration
            var redisEnabled = _configuration.GetValue<bool>("Redis:Enabled");
            var redisConnectionString = _configuration.GetValue<IConfiguration>("Redis:ConnectionString");

            if (redisEnabled && redisConnectionString != null)
            {
                builder.RegisterInstance(new RedisCacheManager(redisConnectionString))
                    .As<ICacheManager>()
                    .SingleInstance();
            }
            else
            {
                builder.RegisterType<MemoryCacheManager>()
                    .As<ICacheManager>()
                    .SingleInstance();
            }

            builder.RegisterType<LogManager>()
                .As<ILogManager>()
                .SingleInstance();
        }
    }
}