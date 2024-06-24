using Domain.Data.Clientes;
using MediatR;

namespace AppCartorio.Clientes;

public record CreateClienteCommand
(
    string Nome,
    string Endereco,
    string Telefone,
    string Email) : IRequest<Cliente>;