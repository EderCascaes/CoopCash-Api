using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoopCash.App.Interfaces.Services;
using CoopCash.App.Services;
using CoopCash.Infra.Persistence.Context;
using CoopCash.Infra.Persistence.Repositories;
using CoopCash.Infra.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoopCash.Infra.DependencyInjection
{
    public static class InfraServiceCollection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // 🔹 Exemplo: Configuração do DbContext com SQL Server
            services.AddDbContext<CoopCashDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // 🔹 Repositórios (Genérico + Específicos)
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}