using Domain.Data.Vendas;
using Domain.Repositories.Vendas;
using MediatR;
using Contracts.ViewModels.Vendas;
using Mapster;
using System.Diagnostics.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppCartorio.Vendas;

public class GetVendaByClienteHandler : IRequestHandler<GetVendaByClienteQuery, ICollection<VendaClienteVM>>
{
    private readonly IVendaRepository _vendaRepository;

    public GetVendaByClienteHandler(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public async Task<ICollection<VendaClienteVM>> Handle(GetVendaByClienteQuery request, CancellationToken cancellationToken)
    {
        TypeAdapterConfig<Venda, VendaClienteVM>.NewConfig()
            .Map(dest => dest.ClienteNome, src => src.Cliente.Nome);


        var vendas = await _vendaRepository.GetByCliente(request.ClienteId);

        return vendas.Adapt<ICollection<VendaClienteVM>>();

    }

    /*
     * Adapt<Contracts.ViewModels.Vendas.Venda>
     * 
     * 
public record Venda(
    int ClienteId,
    string ClienteNome,
    DateTime Data,
    ICollection<ItemVenda> Items
);

public record ItemVenda(
    int VendaItemId,
    int VendaId,
    int ProdutoId,
    string ProdutoNome,
    int Quantidade,
    decimal Preco,
    decimal Total
);     
     */
}