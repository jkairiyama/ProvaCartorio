using Domain.Data.Vendas;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories.Vendas;
using Domain.Data.Vendas.Entities;

namespace Infrastructure.Repositories;

public class VendaRepository : IVendaRepository
{


    private readonly TestCartorioDbContext _dbContext;
    internal DbSet<Venda> dbSet;

    public VendaRepository(TestCartorioDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        dbSet = dbContext.Vendas;
    }
    public async Task AddItem(
        int vendaId,
        int produtoId,
        int qnty,
        decimal preco)
    {
        var v = await dbSet.FindAsync(vendaId);

        v?.AddItem(produtoId, qnty, preco);
    }

    public async Task UpdateItem(VendaItem item)
    {
        var v = await dbSet
            .Include(v => v.Items)
            .Where(v => v.VendaId == item.VendaId)
            .FirstOrDefaultAsync();

    }

    public async Task<Venda> Create(int clienteId, DateTime data)
    {
        var v = new Venda(clienteId, data);
        //_dbContext.Entry(v).State = EntityState.Added;
        await dbSet.AddAsync(v);

        return v;
    }

    public async Task<Venda> Create(Venda venda)
    {
        await dbSet.AddAsync(venda);

        return venda;
    }



    public async Task<Venda?> Get(int vendaId)
    {
        var v = await dbSet.FirstOrDefaultAsync(v => v.VendaId == vendaId);
        return v;
    }

    public async Task<ICollection<Venda>?> GetByCliente(int clienteId)
    {
        var v = await dbSet
                .Where(v => v.ClienteId == clienteId)
                .ToListAsync();
        return v;
    }

    public async Task<int> GetCountByCliente(int clienteId)
    {
        var qnty = await dbSet.Where(v => v.ClienteId == clienteId).CountAsync();
        return qnty;
    }
    public async Task<ICollection<Venda>?> GetBydata(DateTime dataVenda)
    {
        var v = await dbSet
                .Where(v => v.Data == dataVenda)
                .ToListAsync();
        return v;
    }

    public void Remove(Venda venda)
    {
        if (_dbContext.Entry(venda).State == EntityState.Detached)
        {
            dbSet.Attach(venda);
        }
        dbSet.Remove(venda);
    }

    public async Task Remove(int vendaId)
    {
        Venda? venda = await dbSet.FindAsync(vendaId);
        if (venda is not null)
        {
            Remove(venda);
        }
    }

    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Update(Venda venda)
    {
        dbSet.Attach(venda);
        _dbContext.Entry(venda).State = EntityState.Modified;
    }
}