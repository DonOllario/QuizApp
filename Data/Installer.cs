using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class Installer
    {
        public static void SetupDatabaseWithEntityFramework(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<QuizAppDbContext>(options =>
            {
                options.UseSqlServer(connectionString, soa =>
                {
                    soa.MigrationsAssembly("Data");
                });
            });
        }
    }
}
