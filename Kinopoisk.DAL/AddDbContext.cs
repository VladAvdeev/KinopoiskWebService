using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinopoisk.DAL
{
    public static class AddDbContext
    {
        public static void AddEfDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(dbContext =>
            {
                dbContext.UseNpgsql(configuration.GetConnectionString("Default"));
            });
        }
    }
}
