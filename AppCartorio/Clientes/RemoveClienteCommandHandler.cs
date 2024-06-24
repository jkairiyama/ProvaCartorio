using Domain.Data.Clientes;
using MediatR;
using Domain.Logic.Clientes;
using Domain.Logic.Vendas;

namespace AppCartorio.Clientes;

public class RemoveClienteCommandHandler : IRequestHandler<RemoveClienteCommand, Unit>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IVendaRepository _vendaRepository;

    public RemoveClienteCommandHandler(
        IClienteRepository clienteRepository,
        IVendaRepository vendaRepository)
    {
        _clienteRepository = clienteRepository;
        _vendaRepository = vendaRepository;
    }

    public async Task<Unit> Handle(RemoveClienteCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var cli = await _clienteRepository.Get(request.ClienteId);
        if (cli is null)
        {
            throw new Exception("Cliente não foi achado.");
        }

        var qnty = await _vendaRepository.GetCountByCliente(request.ClienteId);
        if (qnty > 0)
        {
            throw new Exception("Cliente ja tem comprado, e não pode ser excluido.");
        }

        _clienteRepository.Remove(cli);

        _clienteRepository.Save();

        return Unit.Value;
    }


}
