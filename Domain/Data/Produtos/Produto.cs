using System.ComponentModel.DataAnnotations;

namespace Domain.Data.Produtos;

public sealed class Produto
{

    public int ProdutoId { get; private set; }

    [Required]
    public string Nome { get; private set; }

    public string Descricao { get; private set; }

    public decimal Preco { get; private set; } = 0M;

    public int Estoque { get; private set; } = 0;

    public Produto(
        string nome,
        string descricao,
        decimal preco,
        int estoque
    )
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Estoque = estoque;
    }

    public Produto SetNome(string nome)
    {
        Nome = nome;
        return this;
    }
    public Produto SetDescricao(string descricao)
    {
        Descricao = descricao;
        return this;
    }
    public Produto SetPreco(decimal preco)
    {
        Preco = preco;
        return this;
    }
    public Produto SetEstoque(int estoque)
    {
        Estoque = estoque;
        return this;
    }

}