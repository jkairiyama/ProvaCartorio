using Domain.Data.Clientes;
using MediatR;
using Domain.Repositories.Clientes;

namespace AppCartorio.Clientes;

public class GetClienteByNomeQueryHandler : IRequestHandler<GetClienteByNomeQuery, ICollection<Cliente>>
{
    private readonly IClienteRepository _clienteRepository;

    public GetClienteByNomeQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ICollection<Cliente>> Handle(GetClienteByNomeQuery request, CancellationToken cancellationToken)
    {

        return await _clienteRepository.Get(request.Nome);

    }

}
