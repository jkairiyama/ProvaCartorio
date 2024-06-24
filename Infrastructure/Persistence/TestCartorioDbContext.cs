using System.Dynamic;
using System.Reflection;
using Domain.Data.Clientes;
using Domain.Data.Produtos;
using Domain.Data.Vendas;
using Domain.Data.Vendas.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Configurations;

namespace Infrastructure.Persistence;

public class TestCartorioDbContext : DbContext
{
    public TestCartorioDbContext(DbContextOptions<TestCartorioDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.UseIdentityByDefaultColumns();
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        modelBuilder.ApplyConfiguration(new VendaConfiguration());
        modelBuilder.ApplyConfiguration(new VendaItemConfiguration());
    }

    // private const string ConnectionString = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=Cartorio;";
    // protected override void OnConfiguring(
    //    DbContextOptionsBuilder optionsBuilder)
    // {
    //     //base.OnConfiguring(optionsBuilder);
    //     optionsBuilder.UseNpgsql(ConnectionString);
    // }


    public DbSet<Cliente> Clientes { get; set; } = null!;

    public DbSet<Venda> Vendas { get; set; } = null!;

    public DbSet<VendaItem> VendaItems { get; set; } = null!;

    public DbSet<Produto> Produtos { get; set; } = null!;

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    //}
}