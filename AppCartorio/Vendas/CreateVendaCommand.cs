using Domain.Data.Vendas;
using MediatR;

namespace AppCartorio.Vendas;

public record CreateVendaCommand
(
    int ClienteId,
    DateTime Data,
    ICollection<CreateVendaItemCommand> Items) : IRequest<Venda>;


public record CreateVendaItemCommand
(
    int ProdutoId,
    decimal Preco,
    int Quantidade
);
