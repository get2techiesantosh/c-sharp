using ContentRepository.Infrastructure.Interface;
using ContentRepository.Infrastructure.SQL;
using ContentRepository.Services;
using ContentRepository.Services.Interface;
using Framework;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;

namespace Santu.Test.Api
{
    public static class StartupExtensions
    {

        public static void AddContentRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceArgsHelper, ServiceArgsHelper>();
            services.AddScoped<ServiceArgs>();
            AddServices(services);
            AddDbRepositoroy(services);

        }
        private static void AddServices(IServiceCollection services)
        {

            //services.AddScoped<ContentService>();

            //services.AddScoped<ContentServiceResolver>(serviceProvider => (ConnectionString) =>
            //{
            //    ObjectFactory contentServiceFactory = ActivatorUtilities.CreateFactory(typeof(ContentService), new Type[] { typeof(string) });
            //    return contentServiceFactory.Invoke(serviceProvider, new object[] { ConnectionString }) as IContentService;
            //});


            services.AddScoped<ContentService>();
            services.AddScoped<ContentServiceResolver>(serviceProvider => (serviceArgs) =>
            {
                ObjectFactory contentServiceFactory = ActivatorUtilities.CreateFactory(typeof(ContentService), new Type[] { typeof(ServiceArgs) });
                return contentServiceFactory.Invoke(serviceProvider, new object[] { serviceArgs }) as IContentService;
            });


        }
        private static void AddDbRepositoroy(IServiceCollection services)
        {
            //services.AddDbContextPool<ContentRepositoryContext>((serviceProvider, options) =>
            //{
            //    var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
            //}, 250);

            services.AddScoped<ContentDBRepository>();
            //services.AddScoped<ContentRepositoryServiceResolver>(serviceProvider => (ConnectionString) =>
            //{
            //    ObjectFactory repoSqlFactory = ActivatorUtilities.CreateFactory(typeof(ContentDBRepository), new Type[] { typeof(string) });
            //    return repoSqlFactory.Invoke(serviceProvider, new object[] { ConnectionString }) as IContentRepository;

            //});



            services.AddScoped<ContentRepositoryServiceResolver>(serviceProvider => (serviceArgs) =>
            {
               
                ObjectFactory repoSqlFactory = ActivatorUtilities.CreateFactory(typeof(ContentDBRepository), new Type[] { typeof(ServiceArgs) });
                return repoSqlFactory.Invoke(serviceProvider, new object[] { serviceArgs }) as IContentRepository;
               
            });

        }
    }
}
