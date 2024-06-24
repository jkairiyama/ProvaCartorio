using Domain.Data.Produtos;
using Domain.Data.Vendas;
using Domain.Logic.Produtos;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly TestCartorioDbContext _dbContext;
    internal DbSet<Produto> dbSet;

    public ProdutoRepository(TestCartorioDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        dbSet = dbContext.Produtos;
    }

    public void Save()
    {
        _dbContext.SaveChanges();
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

    public async Task<Produto?> GetByNome(string nome)
    {
        var cli = await dbSet
            .Where(cli => cli.Nome.StartsWith(nome))
            .FirstOrDefaultAsync();

        if (cli is not null)
        {
            _dbContext.Entry(cli).State = EntityState.Detached;
        }
        return cli;
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