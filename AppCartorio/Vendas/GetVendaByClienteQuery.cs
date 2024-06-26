using Contracts.ViewModels.Vendas;
using MediatR;

namespace AppCartorio.Vendas;

public record GetVendaByClienteQuery
(
    int ClienteId
) : IRequest<ICollection<VendaClienteVM>>;