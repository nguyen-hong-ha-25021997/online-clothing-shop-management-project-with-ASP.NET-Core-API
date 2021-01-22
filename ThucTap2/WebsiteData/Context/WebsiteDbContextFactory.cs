using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace WebsiteData.Data.Context
{
    class WebsiteDbContextFactory:IDesignTimeDbContextFactory<WebsiteDbContext>
    {
        public WebsiteDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DbWebQAConnection");

            var opinionsBulider = new DbContextOptionsBuilder<WebsiteDbContext>();
            opinionsBulider.UseSqlServer(connectionString);

            return new WebsiteDbContext(opinionsBulider.Options);
        }
    }
}
