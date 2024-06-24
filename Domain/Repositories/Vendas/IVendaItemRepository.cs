
namespace Domain.Repositories.Vendas;

public interface IVendaItemRepository
{

    Task<int> GetCountByProduto(int produtoId);


}
