using Domain.Data.Vendas;
using MediatR;

namespace AppCartorio.Vendas;

public record UpdateVendaCommand
(
    int VendaId,
    int? ClienteId,
    DateTime Data,
    ICollection<UpdateVendaItemCommand> Items) : IRequest<Venda>;

public record UpdateVendaItemCommand
(
    int VendaItemId,
    int VendaId,
    int ProdutoId,
    decimal Preco,
    int Quantidade
);