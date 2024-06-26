using Domain.Data.Vendas;
using Domain.Repositories.Vendas;
using MediatR;

namespace AppCartorio.Vendas;

public class GetVendaByDataHandler : IRequestHandler<GetVendaByDataQuery, ICollection<Venda>>
{
    private readonly IVendaRepository _vendaRepository;

    public GetVendaByDataHandler(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public async Task<ICollection<Venda>> Handle(GetVendaByDataQuery request, CancellationToken cancellationToken)
    {
        return await _vendaRepository.GetByData(request.Data);
    }

}