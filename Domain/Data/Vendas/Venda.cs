using Domain.Data.Clientes;
using Domain.Data.Vendas.Entities;

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
        int clienteId,
        DateTime data
    ) : this()
    {
        ClienteId = clienteId;
        Data = data;
    }


    public void AddItem(int produtoId, int qnty, decimal preco)
    {
        var item = _items.SingleOrDefault(o => o.ProdutoId == produtoId);

        if (item is not null)
        {
            item.SetQnty(item.Quantidade + qnty);
            item.setPreco(preco);
        }
        else
        {
            item = new VendaItem(
                this.VendaId,
                produtoId,
                qnty,
                preco);

            _items.Add(item);
        }
    }

    public Venda SetCliente(int clienteId)
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