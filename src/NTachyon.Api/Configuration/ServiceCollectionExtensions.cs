using NTachyon.Api.Crontab;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCrontab(this IServiceCollection services)
        {
            services.AddTransient<ICrontab, NTachyon.Api.Crontab.NCrontab>();
        }
    }
}