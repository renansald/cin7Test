using WebApplication1.Business;
using WebApplication1.Business.Interfaces;

namespace WebApplication1
{
    public static class DependencyInjection
    {
        public static void Injections(this IServiceCollection services)
        {
            services.AddSingleton<IUrlBusiness, UrlBusiness>();
        }
    }
}
