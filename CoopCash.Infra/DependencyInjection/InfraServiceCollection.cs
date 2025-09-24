using CoopCash.App.Interfaces.Repositories;
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
            services.AddDbContext<CoopCashDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // 🔹 Repositórios (Genérico + Específicos)
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRepositoryAuth, RepositoryAuth>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IInviteEmailService, InviteEmailService>();
            services.AddScoped<IAssociateService, AssociateService>();

            return services;
        }
    }
}