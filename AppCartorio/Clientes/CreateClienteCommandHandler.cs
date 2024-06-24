using Domain.Data.Clientes;
using MediatR;
using Domain.Repositories.Clientes;

namespace AppCartorio.Clientes;

public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Cliente>
{
    private readonly IClienteRepository _clienteRepository;

    public CreateClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var cli = new Cliente(
                nome: request.Nome,
                endereco: request.Endereco,
                telefone: request.Telefone,
                email: request.Email
            );

        await _clienteRepository.Create(cli);
        await _clienteRepository.Save();

        return cli;
    }
}
