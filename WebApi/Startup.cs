using Application.Context;
using Application.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // services.AddDbContext<ProvaContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("TestApiConnection")));
            services.AddControllers();
            Console.WriteLine(Configuration.GetConnectionString("TesteApiConnection"));

            services.AddDbContextPool<DbContext, ProvaContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TesteApiConnection"));
            });
            services.AddDbContext<ProvaContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("TestApiConnection"), assembly => assembly.MigrationsAssembly(typeof(ProvaContext).Assembly.FullName)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
