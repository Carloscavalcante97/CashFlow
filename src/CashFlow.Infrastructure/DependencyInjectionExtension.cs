using CashFlow.Domain.Repositories.Expenses;
using Microsoft.Extensions.DependencyInjection;
using CashFlow.Infrastructure.DataAccess.Repositories;
using CashFlow.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Infrastructure.Security.Tokens;
namespace CashFlow.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrasctruture(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddDbContext(services, configuration);
            AddHasher(services);
            AddToken(services, configuration);
        }
        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");
            var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");

           services.AddScoped<IAcessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepository>();
            services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
            services.AddScoped<IExpensesUpdateOnlyRepository, ExpensesRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        }
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));
            services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }
        private static void AddHasher(IServiceCollection services)
        {
            services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
        }
    }
}