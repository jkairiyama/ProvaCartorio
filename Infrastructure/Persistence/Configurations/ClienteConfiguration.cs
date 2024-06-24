using Domain.Data.Clientes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cliente> builder)
    {

        builder.ToTable("Clientes");
        builder.HasKey(o => o.ClienteId);
        builder.Property(o => o.ClienteId)
            .HasIdentityOptions(startValue: 100);

        // builder.Property(c => c.ClienteId)
        //     .UseHiLo("clienteseq");
        builder
            .Property("Nome")
            .IsRequired()
            .HasMaxLength(256);
        builder
            .Property("Endereco")
            .HasMaxLength(256);
        builder
            .Property("Telefone")
            .HasMaxLength(20);
        builder
            .Property("Email")
            .HasMaxLength(256);
    }
}