using System.ComponentModel.DataAnnotations;

namespace Contracts.ViewModels.Vendas;

public sealed class VendaItemVM
{
    public int VendaItemId { get; set; }

    public int VendaId { get; set; }

    public int ProdutoId { get; set; }


    [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser um numero negativo.")]
    public required int Quantidade { get; set; }

    [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "O valor do {0} deve estar entre {1} e {2}.")]
    public required decimal Preco { get; set; }

}