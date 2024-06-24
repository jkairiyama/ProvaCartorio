using Domain.Data.Vendas;
using Domain.Data.Vendas.Entities;


namespace Domain.Repositories.Vendas;

public interface IVendaRepository
{
    Task Save();
    Task<Venda> Create(int ClienteId, DateTime data);

    Task<Venda> Create(Venda venda);

    void Remove(Venda venda);

    Task Remove(int vendaId);

    Task<Venda> Update(Venda venda);

    Task<Venda?> Get(int vendaId);

    Task AddItem(
        int vendaId,
        int produtoId,
        int qnty,
        decimal preco);

    // void RemoveItem(
    //     int VendaItemId
    // );

    Task UpdateItem(VendaItem item);

    Task<ICollection<Venda>?> GetBydata(DateTime dataVenda);

    Task<ICollection<Venda>?> GetByCliente(int clienteId);

    Task<int> GetCountByCliente(int clienteId);

    //Task<ICollection<VendaItem>?> GetItems(int vendaId);


}
