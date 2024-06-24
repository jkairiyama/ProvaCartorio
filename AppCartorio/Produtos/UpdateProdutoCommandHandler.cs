using Domain.Data.Produtos;
using MediatR;
using Domain.Repositories.Produtos;

namespace AppCartorio.Produtos;

public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, Produto>
{
    private readonly IProdutoRepository _produtoRepository;

    public UpdateProdutoCommandHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Produto> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
    {
        var prod = await _produtoRepository.Get(request.ProdutoId);
        if (prod is null)
        {
            throw new Exception("O Produto não foi achado.");
        }

        prod
            .SetPreco(request.Preco)
            .SetDescricao(request.Descricao)
            .SetEstoque(request.Estoque)
            .SetNome(request.Nome);

        _produtoRepository.Update(prod);
        await _produtoRepository.Save();

        return prod;
    }
}
