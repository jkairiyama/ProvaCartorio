using Domain.Data.Produtos;
using MediatR;

namespace AppCartorio.Produtos;

public record GetProdutoByIdQuery
(
    int ProdutoId
) : IRequest<Produto?>;