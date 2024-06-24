using Domain.Data.Clientes;
using MediatR;
using Domain.Logic.Clientes;

namespace AppCartorio.Clientes;

public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Cliente>
{
    private readonly IClienteRepository _clienteRepository;

    public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var cli = await _clienteRepository.Get(request.ClienteId);
        if (cli is null)
        {
            throw new Exception("Cliente não foi achado.");
        }

        await _clienteRepository.Create(cli);
        _clienteRepository.Save();

        return cli;
    }
}
