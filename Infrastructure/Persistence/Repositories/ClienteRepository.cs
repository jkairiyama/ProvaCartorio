using Domain.Data.Clientes;
using Domain.Data.Vendas;
using Domain.Repositories.Clientes;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly TestCartorioDbContext _dbContext;
    internal DbSet<Cliente> dbSet;
    private const int top = 10;

    public ClienteRepository(TestCartorioDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        dbSet = dbContext.Clientes;
    }

    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task Create(Cliente cliente)
    {
        //dbSet.Attach(cliente);
        //_dbContext.Entry(cliente).State = EntityState.Added;
        await dbSet.AddAsync(cliente);
    }
    public async Task<Cliente?> Get(int clienteId)
    {

        var cli = await dbSet
            .FindAsync(clienteId);

        if (cli is not null)
        {
            _dbContext.Entry(cli).State = EntityState.Detached;
        }
        return cli;
    }

    public async Task<ICollection<Cliente>> Get(string nome)
    {
        if (!string.IsNullOrWhiteSpace(nome))
        {
            var cli_lst = await dbSet
                .Where(c => c.Nome.ToLower().StartsWith(nome.ToLower())) //Melhorar, porque não consegue usar indice no banco
                .OrderBy(c => c.ClienteId)
                .Take(top)
                .ToListAsync();
            return cli_lst;
            //var cli_lst = await dbSet
            //    .Where(c => c.Nome.StartsWith(nome)) 
            //    .Take(top)
            //    .ToListAsync();
            //return cli_lst;
        }
        else
        {
            var cli_lst = await dbSet
                .Take(top)
                .ToListAsync();
            return cli_lst;
        }

    }
    public async Task Remove(int clienteId)
    {
        Cliente? clie = await dbSet.FindAsync(clienteId);
        if (clie is not null)
        {
            Remove(clie);
        }

    }
    public void Remove(Cliente cliente)
    {
        if (_dbContext.Entry(cliente).State == EntityState.Detached)
        {
            dbSet.Attach(cliente);
        }
        dbSet.Remove(cliente);

    }

    public void Update(Cliente cliente)
    {
        dbSet.Attach(cliente);
        _dbContext.Entry(cliente).State = EntityState.Modified;
    }



    // public async Task AddVenda(int clienteId, Venda venda)
    // {

    //     if (venda.Items is null || venda.Items.Count == 0)
    //     {
    //         return;
    //     }

    //     _dbContext.Entry(venda).State = EntityState.Added;
    //     foreach (var vi in venda.Items)
    //     {
    //         _dbContext.Entry(vi).State = EntityState.Added;
    //     }

    //     var cli = await dbSet
    //         .Include(cli => cli.Vendas)
    //             .ThenInclude(vend => vend.Items)
    //         .Where(cliente => cliente.ClienteId == clienteId)
    //         .FirstOrDefaultAsync();

    //     if (cli is null)
    //     {
    //         return;
    //     }

    //     //cli.Vendas ??= new List<Venda>();
    //     cli.Vendas ??= [];


    //     cli.Vendas.Add(venda);
    // }


}