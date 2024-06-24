using Domain.Data.Vendas;
using Domain.Repositories.Produtos;
using Domain.Repositories.Vendas;
using MediatR;

namespace AppCartorio.Vendas;

public class CreateVendaCommandHandler : IRequestHandler<CreateVendaCommand, Venda>
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IProdutoRepository _produtoRepository;

    public CreateVendaCommandHandler(IVendaRepository pendaRepository, IProdutoRepository produtoRepository)
    {
        _vendaRepository = pendaRepository;
        _produtoRepository = produtoRepository;
    }

    public async Task<Venda> Handle(CreateVendaCommand request, CancellationToken cancellationToken)
    {
        //Verifica se tem estoque
        foreach (var item in request.Items)
        {
            var prod = await _produtoRepository.Get(item.ProdutoId);
            if (prod is null || prod.Estoque < item.Quantidade)
            {                
                throw new Exception($"O produto {prod?.Nome} não tem estoque suficiente.");
            }
            else
            {
                prod.SetEstoque(prod.Estoque - item.Quantidade);
                _produtoRepository.Update(prod);
            }
        }

        var vend = new Venda(clienteId: request.ClienteId, data: request.Data);
        foreach (var item in request.Items)
        {
            vend.AddItem(produtoId: item.ProdutoId, preco: item.Preco, quantidade: item.Quantidade);
        }

        await _vendaRepository.Create(vend);
        await _vendaRepository.Save();

        return vend;
    }
}