using Domain.Data.Clientes;
using MediatR;
using Domain.Repositories.Clientes;

namespace AppCartorio.Clientes;

public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Cliente?>
{
    private readonly IClienteRepository _clienteRepository;

    public GetClienteByIdQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente?> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
    {

        return await _clienteRepository.Get(request.ClienteId);

    }

}
