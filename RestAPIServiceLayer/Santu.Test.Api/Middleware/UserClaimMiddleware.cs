using Framework;

namespace Santu.Test.Api.Middleware
{
    public class UserClaimMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configurationSettings;
        public UserClaimMiddleware(RequestDelegate next, IConfiguration optionsSetttings)
        {
            _next = next;
            _configurationSettings = optionsSetttings;
        }

        public async Task Invoke(HttpContext context, IConfiguration optionsSettings)
        {
            var serviceArgs = new ServiceArgs()
            {

                DatabaseRepositoryType = "Sql",
                ConnectionString = _configurationSettings["ConnectionStrings:Default"],
                FileSystemType = "onedrive",
                TenantId = "Tenant1",
                UserId = new Guid(),
                UserName = "santosh",

            };
            //context.Features.Set(serviceArgs);
            context.Features.Set<ServiceArgs>(serviceArgs);
            await _next(context);
        }
    }

    public static class UserClaimMiddlewareExtensions
    {
        public static IApplicationBuilder SetClaimsAsServiceArgs(
            this IApplicationBuilder builder) => builder.UseMiddleware<UserClaimMiddleware>();
    }
}
