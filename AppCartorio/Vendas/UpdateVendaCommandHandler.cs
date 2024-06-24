using Domain.Data.Vendas;
using MediatR;
using Domain.Repositories.Vendas;
using Domain.Data.Vendas.Entities;

namespace AppCartorio.Vendas;

public class UpdateVendaCommandHandler : IRequestHandler<UpdateVendaCommand, Venda>
{
    private readonly IVendaRepository _vendaRepository;

    public UpdateVendaCommandHandler(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public async Task<Venda> Handle(UpdateVendaCommand request, CancellationToken cancellationToken)
    {
        var vendaModificada = new Venda(clienteId: request.ClienteId, data: request.Data, vendaId: request.VendaId);
        foreach (var itm in request.Items)
        {
            vendaModificada.AddItem(
                new VendaItem(
                    vendaItemid: itm.VendaItemId,
                    vendaId: request.VendaId,
                    produtoId: itm.ProdutoId,
                    preco: itm.Preco,
                    quantidade: itm.Quantidade)
            );
        }

        var venda = await _vendaRepository.Update(vendaModificada);
        await _vendaRepository.Save();

        return venda;
    }
}
