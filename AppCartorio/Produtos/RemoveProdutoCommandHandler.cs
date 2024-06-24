using Domain.Data.Produtos;
using MediatR;
using Domain.Repositories.Produtos;
using Domain.Repositories.Vendas;

namespace AppCartorio.Produtos;

public class RemoveProdutoCommandHandler : IRequestHandler<RemoveProdutoCommand, Unit>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IVendaItemRepository _vendaItemRepository;

    public RemoveProdutoCommandHandler(
        IProdutoRepository produtoRepository,
        IVendaItemRepository vendaItemRepository)
    {
        _produtoRepository = produtoRepository;
        _vendaItemRepository = vendaItemRepository;
    }

    public async Task<Unit> Handle(
        RemoveProdutoCommand request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var prod = await _produtoRepository.Get(request.ProdutoId);
        if (prod is null)
        {
            throw new Exception("Produto não foi achado.");
        }

        var qnty = await _vendaItemRepository.GetCountByProduto(request.ProdutoId);
        if (qnty > 0)
        {
            throw new Exception("Produto ja tem sido comprado, e não pode ser excluido.");
        }

        _produtoRepository.Remove(prod);

        await _produtoRepository.Save();

        return Unit.Value;
    }
}
