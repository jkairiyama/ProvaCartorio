using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AppCartorio;

public static class DependencyInjection
{
    public static IServiceCollection AddAppCartorio(
        this IServiceCollection services
    )
    {
        //services.AddInfrastructure(strCnn);
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        return services;
    }

}