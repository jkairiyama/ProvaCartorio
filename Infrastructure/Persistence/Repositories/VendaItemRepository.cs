
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories.Vendas;
using Domain.Data.Vendas.Entities;


namespace Infrastructure.Repositories;

public class VendaItemRepository : IVendaItemRepository
{


    private readonly TestCartorioDbContext _dbContext;
    internal DbSet<VendaItem> dbSet;

    public VendaItemRepository(TestCartorioDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        dbSet = dbContext.VendaItems;
    }

    public async Task<int> GetCountByProduto(int produtoId)
    {
        var qnty = await dbSet.Where(v => v.ProdutoId == produtoId).CountAsync();
        return qnty;
    }

}