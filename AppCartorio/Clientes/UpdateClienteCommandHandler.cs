using Domain.Data.Clientes;
using MediatR;
using Domain.Repositories.Clientes;

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
        cli.SetNome(request.Nome);
        cli.SetEmail(request.Email);
        cli.SetEndereco(request.Endereco);
        cli.SetTelefone(request.Telefone);

        _clienteRepository.Update(cli);
        await _clienteRepository.Save();

        return cli;
    }
}
