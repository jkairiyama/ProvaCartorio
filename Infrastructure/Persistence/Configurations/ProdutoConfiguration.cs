using Domain.Data.Produtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
    {

        builder.ToTable("Produtos");
        builder.HasKey(o => o.ProdutoId);

        // builder.Property(c => c.ProdutoId)
        //     .UseHiLo("produtoseq");
        builder
            .Property("Nome")
            .IsRequired()
            .HasMaxLength(256);

        builder
            .Property("Descricao")
            .HasMaxLength(256);
        builder
            .Property("Preco")
            .IsRequired();
        builder
            .Property("Estoque")
            .IsRequired();
    }
}