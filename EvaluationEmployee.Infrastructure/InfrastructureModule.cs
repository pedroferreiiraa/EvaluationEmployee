using _5W2H.Core.Repositories;
using _5W2H.Core.Services;
using _5W2H.Infrastructure.AuthServices;
using _5W2H.Infrastructure.Persistence;
using _5W2H.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _5W2H.Infrastructure;

public static class InfrastructureModule 
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRepositories()
            .AddData(configuration);

        return services;
    }

    private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AvaliationDbContext>(o => o.UseSqlServer(connectionString));
        return services;
        
    }

    
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {

        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserEvaluationRepository, UserEvaluationRepository>();
        services.AddScoped<IUserQuestionRepository, UserQuestionRepository>();
        services.AddScoped<IUserAnswerRepository, UserAnswerRepository>();
        services.AddScoped<ILeaderEvaluationRepository, LeaderEvaluationRepository>();
        services.AddScoped<ILeaderQuestionRepository, LeaderQuestionRepository>();
        services.AddScoped<ILeaderAnswerRepository, LeaderAnswerRepository>();

    

        return services;

    }

    
}