using Domain.Data.Produtos;
using Domain.Data.Vendas;
using Domain.Repositories.Produtos;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly TestCartorioDbContext _dbContext;
    internal DbSet<Produto> dbSet;

    private const int top = 10;

    public ProdutoRepository(TestCartorioDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        dbSet = dbContext.Produtos;
    }

    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }
    public async Task Create(Produto produto)
    {
        //_dbContext.Entry(produto).State = EntityState.Added;
        await dbSet.AddAsync(produto);
    }

    public async Task<Produto?> Get(int produtoId)
    {

        var cli = await dbSet
            .FindAsync(produtoId);

        if (cli is not null)
        {
            _dbContext.Entry(cli).State = EntityState.Detached;
        }
        return cli;
    }

    public async Task<ICollection<Produto>> GetByNome(string nome)
    {
        return await dbSet
            .Where(p => p.Nome.ToLower().StartsWith(nome.ToLower())) //Melhorar, porque não consegue usar indice no banco
            .OrderBy(p => p.ProdutoId)
            .Take(top)
            .ToListAsync();
    }


    public async Task Remove(int produtoId)
    {
        Produto? clie = await dbSet.FindAsync(produtoId);
        if (clie is not null)
        {
            Remove(clie);
        }

    }
    public void Remove(Produto produto)
    {
        if (_dbContext.Entry(produto).State == EntityState.Detached)
        {
            dbSet.Attach(produto);
        }
        dbSet.Remove(produto);

    }

    public void Update(Produto produto)
    {
        dbSet.Attach(produto);
        _dbContext.Entry(produto).State = EntityState.Modified;
    }
}