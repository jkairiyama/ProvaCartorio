using Domain.Data.Vendas;
using Domain.Repositories.Vendas;
using MediatR;

namespace AppCartorio.Vendas;

public class GetVendaByIdQueryHandler : IRequestHandler<GetVendaByIdQuery, Venda?>
{
    private readonly IVendaRepository _vendaRepository;

    public GetVendaByIdQueryHandler(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public async Task<Venda?> Handle(GetVendaByIdQuery request, CancellationToken cancellationToken)
    {

        return await _vendaRepository.Get(request.VendaId);

    }

}