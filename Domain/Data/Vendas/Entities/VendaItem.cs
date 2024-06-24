using System.ComponentModel.DataAnnotations;

namespace Domain.Data.Vendas.Entities;

public sealed class VendaItem
{
    public int VendaItemId { get; private set; }
    public int VendaId { get; private set; }
    public int ProdutoId { get; private set; }
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

}