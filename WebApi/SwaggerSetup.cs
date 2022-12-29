using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title= "TesteApi",
                    Version = "v1",
                    
                });
            });
        }
    }
}
