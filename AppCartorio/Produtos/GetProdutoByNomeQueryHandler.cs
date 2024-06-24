using Domain.Data.Produtos;
using MediatR;
using Domain.Repositories.Produtos;

namespace AppCartorio.Produtos;

public class GetProdutoByNomeQueryHandler : IRequestHandler<GetProdutoByNomeQuery, ICollection<Produto>>
{
    private readonly IProdutoRepository _produtoRepository;

    public GetProdutoByNomeQueryHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ICollection<Produto>> Handle(GetProdutoByNomeQuery request, CancellationToken cancellationToken)
    {

        return await _produtoRepository.GetByNome(request.Nome);

    }

}
