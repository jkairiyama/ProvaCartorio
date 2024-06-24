using MediatR;

namespace AppCartorio.Clientes;

public record RemoveClienteCommand
(
    int ClienteId
) : IRequest<Unit>;