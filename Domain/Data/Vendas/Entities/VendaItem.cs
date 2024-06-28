using System.ComponentModel.DataAnnotations;
using Domain.Data.Produtos;

namespace Domain.Data.Vendas.Entities;

public sealed class VendaItem: IEquatable<VendaItem>
{
    public int VendaItemId { get; private set; }
    public int VendaId { get; private set; }
    public int ProdutoId { get; private set; }
    public Produto? Produto { get; }
    public int Quantidade { get; private set; }
    public decimal Preco { get; private set; }

    public VendaItem(
        int vendaId,
        int produtoId,
        int quantidade,
        decimal preco
    )
    {
        VendaId = vendaId;
        ProdutoId = produtoId;
        Quantidade = quantidade;
        Preco = preco;
    }

    public VendaItem(
        int vendaItemid,
        int vendaId,
        int produtoId,
        int quantidade,
        decimal preco)
    : this(
          vendaId,
          produtoId,
          quantidade,
          preco)

    {
        this.VendaItemId = vendaItemid;
    }

    public VendaItem SetQuantidade(int qnty)
    {
        Quantidade = qnty;
        return this;
    }

    public VendaItem SetPreco(decimal preco)
    {
        Preco = preco;
        return this;
    }

    public VendaItem SetProdutoId(int produtoId)
    {
        ProdutoId = produtoId;
        return this;
    }

    public bool Equals(VendaItem? other)
    {
            if (other is null)
                return false;

            return this.VendaItemId == other.VendaItemId;
    }
    public override int GetHashCode()
    {
        return this.VendaItemId.GetHashCode();
    }


}