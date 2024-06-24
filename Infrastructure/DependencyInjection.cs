using Domain.Repositories.Clientes;
using Domain.Repositories.Produtos;
using Domain.Repositories.Vendas;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string strCnn
    )
    {
        services.AddDbContext<TestCartorioDbContext>(options =>
            options.UseNpgsql(strCnn)
            );
        //services.AddScoped<IMapper, ServiceMapper>();
        //services.AddMapster();

        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IVendaRepository, VendaRepository>();
        services.AddScoped<IVendaItemRepository, VendaItemRepository>();



        return services;
    }




}