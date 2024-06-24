using Domain.Data.Produtos;
using MediatR;

namespace AppCartorio.Produtos;

public record RemoveProdutoCommand
(
    int ProdutoId
) : IRequest<Unit>;
