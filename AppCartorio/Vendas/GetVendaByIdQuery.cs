using Domain.Data.Vendas;
using MediatR;

namespace AppCartorio.Vendas;

public record GetVendaByIdQuery
(
    int VendaId
) : IRequest<Venda?>;