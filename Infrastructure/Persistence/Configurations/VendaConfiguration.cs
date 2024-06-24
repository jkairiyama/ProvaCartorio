using Domain.Data.Clientes;
using Domain.Data.Vendas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Infrastructure.Persistence.Configurations;

class VendaConfiguration : IEntityTypeConfiguration<Venda>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Venda> builder)
    {
        /*
            public int ClienteId { get; private set; }

            public DateTime Data { get; private set; }
            private List<VendaItem> _items;
        */
        builder.ToTable("Vendas");
        builder.HasKey(o => o.VendaId);

        // builder.Property(c => c.VendaId)
        //     .UseHiLo("vendaseq");

        builder
            .Property("ClienteId")
            .IsRequired(false);

        builder
            .HasOne<Cliente>()
            .WithMany()
            .IsRequired(false)
            .HasForeignKey("ClienteId");

        builder
            .Property("Data")
            .HasColumnType("date")
            .IsRequired();
        builder
            .HasIndex(v => v.Data)
            .IsUnique(false)
            .IsDescending(true);


        builder
            .HasMany(v => v.Items)
            .WithOne()
            .HasForeignKey(e => e.VendaId)
            .IsRequired();

        var navigation = builder.Metadata.FindNavigation(nameof(Venda.Items));
        navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

    }
}