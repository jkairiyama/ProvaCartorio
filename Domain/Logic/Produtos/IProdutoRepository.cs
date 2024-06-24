using Domain.Data.Produtos;


namespace Domain.Logic.Produtos;

public interface IProdutoRepository
{
    void Save();
    Task Create(Produto produto);

    void Remove(Produto produto);

    Task Remove(int produtoId);

    void Update(Produto produto);

    Task<Produto?> Get(int produtoId);

    Task<Produto?> GetByNome(string nome);


}
