using Domain.Data.Produtos;
using MediatR;
using Domain.Repositories.Produtos;

namespace AppCartorio.Produtos;

public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, Produto>
{
    private readonly IProdutoRepository _produtoRepository;

    public CreateProdutoCommandHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Produto> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
    {
        var prod = new Produto(
                nome: request.Nome,
                descricao: request.Descricao,
                preco: request.Preco,
                estoque: request.Estoque
            );

        await _produtoRepository.Create(prod);
        await _produtoRepository.Save();

        return prod;
    }
}
