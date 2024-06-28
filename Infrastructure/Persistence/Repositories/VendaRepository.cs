using Domain.Data.Vendas;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories.Vendas;
using Domain.Data.Vendas.Entities;
using Domain.Data.Produtos;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Runtime.CompilerServices;

namespace Infrastructure.Repositories;

public class VendaRepository : IVendaRepository
{


    private readonly TestCartorioDbContext _dbContext;
    internal DbSet<Venda> dbSet;
    internal DbSet<Produto> dbSetProduto;

    public VendaRepository(TestCartorioDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        dbSet = dbContext.Vendas;
        dbSetProduto = dbContext.Produtos;
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
        var venda = await dbSet
            .Include(v => v.Items)
            .Where(v => v.VendaId == item.VendaId)
            .FirstOrDefaultAsync();

        if (venda is null)
        {
            throw new Exception($"Venda ({item.VendaId}) não foi achada.");
        }

        var itm = venda.Items.Where(itm => itm.VendaItemId == item.VendaItemId).FirstOrDefault();
        if (itm is null)
        {
            throw new Exception($"Item ({item.VendaItemId}) não foi achado.");
        }

        itm
            .SetQuantidade(item.Quantidade)
            .SetPreco(item.Preco)
            .SetProdutoId(item.ProdutoId);

        _dbContext.Entry(itm).State = EntityState.Modified;
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
        var v = await dbSet
            .Include(v => v.Items)
            .ThenInclude(itm => itm.Produto)
            .Include(v => v.Cliente)
            .FirstOrDefaultAsync(v => v.VendaId == vendaId);

        return v;
    }

    public async Task<ICollection<Venda>> GetByCliente(int clienteId)
    {
        var v = await dbSet
        .Include(v => v.Items)
                .Include(v => v.Cliente)
                .Where(v => v.ClienteId == clienteId)
                .ToListAsync();
        return v;
    }

    public async Task<int> GetCountByCliente(int clienteId)
    {
        var qnty = await dbSet.Where(v => v.ClienteId == clienteId).CountAsync();
        return qnty;
    }
    public async Task<ICollection<Venda>> GetByData(DateTime dataVenda)
    {
        var v = await dbSet
                .Where(v => v.Data == dataVenda)
                .Include(v => v.ClienteId)
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

    public async Task<Venda> Update(Venda venda)
    {
        var vendaDb = await this.Get(venda.VendaId);
        if (vendaDb is null)
        {
            throw new Exception("A Venda não foi achada.");
        }

        vendaDb
            .SetCliente(venda.ClienteId)
            .SetData(venda.Data);

        //1. Os items que foram apagados agora da venda
        ExcluirItemVenda(venda, vendaDb);

        foreach (var itmNew in venda.Items)
        {
            var prod = await dbSetProduto.FindAsync(itmNew.ProdutoId) ??
                throw new Exception($"Não foi achado o produto ({itmNew.ProdutoId})");
            
            if (itmNew.VendaItemId != default)
            {
                //2. Ja tinha o item, so atualiza a quantidade o preco e estoque (no produto)
                ModificarItemVenda(vendaDb, itmNew, prod);
            }            
            else
            {
                //3. Item novo
                AdicionarItemVenda(venda, vendaDb, itmNew, prod);
            }
            _dbContext.Entry(prod).State = EntityState.Modified;
        }

        _dbContext.Entry(vendaDb).State = EntityState.Modified;
        return vendaDb;
    }

    private void ExcluirItemVenda(Venda venda, Venda? vendaDb)
    {
        var imtExcluir = vendaDb?.Items.Except(venda.Items);
        imtExcluir?.ToList().ForEach(async (vi) =>
        {
            //Correge o estoque
            var prod = await dbSetProduto.FindAsync(vi.ProdutoId) ?? throw new Exception($"Não foi achado o produto ({vi.ProdutoId})");
            prod?.SetEstoque(prod.Estoque + vi.Quantidade);
            //Marca para excluir o item da venda no banco
            _dbContext.Entry(vi).State = EntityState.Deleted;
        });
    }

    private void AdicionarItemVenda(Venda venda, Venda? vendaDb, VendaItem itmNew, Produto prod)
    {
        prod.SetEstoque(prod.Estoque - itmNew.Quantidade);

        var item = new VendaItem(
            venda.VendaId,
            itmNew.ProdutoId,
            itmNew.Quantidade,
            itmNew.Preco);
        //_dbContext.Entry(item).State = EntityState.Added;

        vendaDb.AddItem(item);
    }

    private void ModificarItemVenda(Venda? vendaDb, VendaItem itmNew, Produto prod)
    {
        var itmOld = vendaDb.Items.Where(itm => itm.VendaItemId == itmNew.VendaItemId).FirstOrDefault() ??
            throw new Exception($"O item ({itmNew.VendaItemId}) foi editado mas não foi achado no banco.");

        //O estoque tmb corrige se for diferentes quantidades
        if (itmOld.Quantidade != itmNew.Quantidade)
        {
            prod.SetEstoque(prod.Estoque + itmOld.Quantidade - itmNew.Quantidade);
        }

        itmOld
            .SetQuantidade(itmNew.Quantidade)
            .SetPreco(itmNew.Preco);
        //.SetProdutoId(itmNew.ProdutoId); //Regra Negocio: nao pode modificar o produto num item da venda

        _dbContext.Entry(itmOld).State = EntityState.Modified;
    }
}