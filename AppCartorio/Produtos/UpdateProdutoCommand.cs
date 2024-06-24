using Domain.Data.Clientes;
using Domain.Data.Produtos;
using MediatR;

namespace AppCartorio.Produtos;

public record UpdateProdutoCommand
(
    int ProdutoId,
    string Nome,
    string Descricao,
    decimal Preco,
    int Estoque) : IRequest<Produto>;