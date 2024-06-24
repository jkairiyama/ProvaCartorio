using Domain.Data.Produtos;


namespace Domain.Repositories.Produtos;

public interface IProdutoRepository
{
    Task Save();
    Task Create(Produto produto);

    void Remove(Produto produto);

    Task Remove(int produtoId);

    void Update(Produto produto);

    Task<Produto?> Get(int produtoId);

    Task<ICollection<Produto>> GetByNome(string nome);


}
