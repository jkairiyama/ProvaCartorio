using Domain.Data.Produtos;
using MediatR;

namespace AppCartorio.Produtos;

public record GetProdutoByNomeQuery
(
    string Nome
) : IRequest<ICollection<Produto>>;