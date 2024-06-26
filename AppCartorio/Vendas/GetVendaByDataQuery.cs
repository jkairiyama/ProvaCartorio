using Domain.Data.Vendas;
using MediatR;

namespace AppCartorio.Vendas;

public record GetVendaByDataQuery
(
    DateTime Data
) : IRequest<ICollection<Venda>>;