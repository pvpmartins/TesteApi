using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProvaContext>
    {
        public ProvaContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../WebApi/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<ProvaContext>();
            var connectionString = configuration.GetConnectionString("TesteApiConnection");
            builder.UseSqlServer(connectionString);
            return new ProvaContext(builder.Options);
        }
    }
}
