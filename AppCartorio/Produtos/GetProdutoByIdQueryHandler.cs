using Domain.Data.Produtos;
using MediatR;
using Domain.Repositories.Produtos;

namespace AppCartorio.Produtos;

public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, Produto?>
{
    private readonly IProdutoRepository _produtoRepository;

    public GetProdutoByIdQueryHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Produto?> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
    {

        return await _produtoRepository.Get(request.ProdutoId);

    }

}
