using Domain.Data.Clientes;
using MediatR;

namespace AppCartorio.Clientes;

public record GetClienteByIdQuery
(
    int ClienteId
) : IRequest<Cliente?>;