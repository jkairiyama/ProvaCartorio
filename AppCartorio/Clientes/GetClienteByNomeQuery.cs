using Domain.Data.Clientes;
using MediatR;

namespace AppCartorio.Clientes;

public record GetClienteByNomeQuery
(
    string Nome
) : IRequest<ICollection<Cliente>>;