
using Domain.Data.Vendas.Entities;

namespace Domain.Repositories.Vendas;

public interface IVendaItemRepository
{

    Task<int> GetCountByProduto(int produtoId);

    void Remove(VendaItem vendaItem);
}
