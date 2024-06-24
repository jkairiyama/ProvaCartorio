using Domain.Data.Vendas;
using Domain.Data.Vendas.Entities;


namespace Domain.Logic.Vendas;

public interface IVendaRepository
{
    void Save();
    Task<Venda> Create(int ClienteId, DateTime data);

    void Remove(Venda venda);

    Task Remove(int vendaId);

    void Update(Venda venda);

    Task<Venda?> Get(int vendaId);

    Task AddItem(
        int vendaId,
        int produtoId,
        int qnty,
        decimal preco);

    Task<ICollection<Venda>?> GetBydata(DateTime dataVenda);

    Task<ICollection<Venda>?> GetByCliente(int clienteId);

    Task<int> GetCountByCliente(int clienteId);

    //Task<ICollection<VendaItem>?> GetItems(int vendaId);


}
