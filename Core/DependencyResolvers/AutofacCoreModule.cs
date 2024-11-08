using Autofac;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
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
            builder.RegisterType<MemoryCache>()
                .As<IMemoryCache>()
                .SingleInstance();

            builder.RegisterInstance(_configuration)
                .As<IConfiguration>()
                .SingleInstance();

            builder.RegisterType<RedisCacheManager>()
                .As<ICacheManager>()
                .SingleInstance();

            builder.RegisterType<LogManager>()
                .As<ILogManager>()
                .SingleInstance();
        }
    }
}