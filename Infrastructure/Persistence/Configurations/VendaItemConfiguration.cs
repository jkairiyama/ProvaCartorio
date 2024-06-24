using Domain.Data.Vendas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

class VendaItemConfiguration : IEntityTypeConfiguration<VendaItem>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<VendaItem> builder)
    {


        builder.ToTable("VendaItems");
        builder.HasKey(o => o.VendaItemId);

        // builder.Property(c => c.VendaItemId)
        //     .UseHiLo("vendaitemseq");

        builder
            .Property("VendaId")
            .IsRequired();

        builder
            .Property("ProdutoId")
            .HasMaxLength(256);
        builder
            .Property("Quantidade")
            .IsRequired();
        builder
            .Property("Preco")
            .IsRequired();
    }
}