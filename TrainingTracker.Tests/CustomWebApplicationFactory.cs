using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TrainingTracker.Tests
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Here we can customize the services for testing, e.g., use an in-memory database

                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(Microsoft.EntityFrameworkCore.DbContextOptions<TrainingTrackerAPI.Data.ApplicationDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                //Test database connection
                var dbConnectionDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(SqlConnection));

                if (dbConnectionDescriptor != null)
                {
                    services.Remove(dbConnectionDescriptor);
                }

                services.AddSingleton<SqlConnection>(container =>
                {
                    var connection = new SqlConnection("DataSource=:memory:");
                    connection.Open();
                    return connection;
                });

                services.AddDbContext<TrainingTrackerAPI.Data.ApplicationDbContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<SqlConnection>();
                    options.UseSqlServer(connection);

                });

            });
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            var host = base.CreateHost(builder);
            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TrainingTrackerAPI.Data.ApplicationDbContext>();
            db.Database.EnsureCreated();
            return host;
        }
    }
}
