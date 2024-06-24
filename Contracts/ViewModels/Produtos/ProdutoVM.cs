using System.ComponentModel.DataAnnotations;

namespace Contracts.ViewModels.Produtos;

public sealed class ProdutoVM
{
    public ProdutoVM(
        string nome,
        string descricao,
        Decimal preco,
        int estoque)
    {
        this.Nome = nome;
        this.Descricao = descricao;
        this.Preco = preco;
        this.Estoque = estoque;
    }

    public int ProdutoId { get; set; }

    [MaxLength(length: 256, ErrorMessage = "O nome so pode ter 256 carateres.")]
    public required string Nome { get; set; }

    [MaxLength(length: 256, ErrorMessage = "A descrição so pode ter 256 carateres.")]
    public required string Descricao { get; set; }


    [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "O valor do {0} deve estar entre {1} e {2}.")]
    public required decimal Preco { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "O valor do {0} deve estar entre {1} e {2}.")]
    public required int Estoque { get; set; }

}