using Domain.Data.Clientes;
using MediatR;

namespace AppCartorio.Clientes;

public record UpdateClienteCommand
(
    int ClienteId,
    string Nome,
    string Endereco,
    string Telefone,
    string Email) : IRequest<Cliente>;