using Domain.Data.Clientes;
using Domain.Data.Vendas.Entities;
using Domain.Repositories.Vendas;

namespace Domain.Data.Vendas;

public class Venda
{
    public int VendaId { get; private set; }

    public int? ClienteId { get; private set; }

    public Cliente? Cliente { get; }

    public DateTime Data { get; private set; }
    private List<VendaItem> _items;
    public IReadOnlyCollection<VendaItem> Items => _items.AsReadOnly();

    protected Venda()
    {
        _items = [];
    }

    public Venda(
        int? clienteId,
        DateTime data
    ) : this()
    {
        ClienteId = clienteId;
        Data = data;
    }

    public Venda(
        int? clienteId,
        DateTime data,
        int vendaId
    ) : this(clienteId, data)
    {
        VendaId = vendaId;
    }

    public void AddItem(VendaItem item)
    {
        _items.Add(item);
    }
    public void AddItem(int produtoId, int quantidade, decimal preco)
    {
        var item = _items.SingleOrDefault(o => o.ProdutoId == produtoId);

        if (item is not null)
        {
            item
                .SetQuantidade(item.Quantidade + quantidade)
                .SetPreco(preco)
                .SetProdutoId(produtoId);
        }
        else
        {
            item = new VendaItem(
                this.VendaId,
                produtoId,
                quantidade,
                preco);

            _items.Add(item);
        }
    }

    public void AddListItems(ICollection<VendaItem> items)
    {
        this._items = items.ToList();

        // foreach (var itmNew in items)
        // {
        //     if (itmNew.VendaItemId != default)
        //     {
        //         var itmOld = _items.Find(itm => itm.VendaItemId == itmNew.VendaItemId);
        //         itmOld?
        //             .SetQuantidade(itmNew.Quantidade)
        //             .SetPreco(itmNew.Preco)
        //             .SetProdutoId(itmNew.ProdutoId);
        //     }
        //     else
        //     {
        //         var item = new VendaItem(
        //             this.VendaId,
        //             itmNew.ProdutoId,
        //             itmNew.Quantidade,
        //             itmNew.Preco);

        //         _items.Add(item);
        //     }
        // }

        // var lst_ItmsNew = items.ToList();
        // foreach (var itmOld in _items)
        // {
        //     var itmNew = lst_ItmsNew.Find(itm => itm.VendaItemId == itmOld.VendaItemId);
        //     if (itmNew is null)
        //     {
        //         _vendaItemRepository.Remove(itmOld);
        //     }
        // }
    }

    public Venda SetCliente(int? clienteId)
    {
        ClienteId = clienteId;
        return this;
    }

    public Venda SetData(DateTime data)
    {
        Data = data;
        return this;
    }

}