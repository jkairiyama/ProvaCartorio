using Domain.Data.Produtos;
using MediatR;

namespace AppCartorio.Produtos;

public record CreateProdutoCommand
(
    string Nome,
    string Descricao,
    decimal Preco,
    int Estoque) : IRequest<Produto>;
