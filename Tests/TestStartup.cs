using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Mappings;
using System.Data.Common;
using System.Reflection;

namespace Tests
{
    public class TestStartup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<QuizAppDbContext>(options =>
            {
                options.UseSqlite(CreateInMemoryDatabase());
            }, ServiceLifetime.Singleton);

            services.AddAutoMapper(typeof(MappingConfiguration));

            services.AddControllers();
            services.AddMvcCore()
                .AddApplicationPart(Assembly.Load(new AssemblyName("QuizApp")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("DataSource=file::memory:?cache=shared");
            connection.Open();
            return connection;
        }
    }
}
