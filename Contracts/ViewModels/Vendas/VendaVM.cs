using System.ComponentModel.DataAnnotations;


namespace Contracts.ViewModels.Vendas;

public sealed class VendaVM
{
    public int VendaId { get; set; }

    public int ClienteId { get; set; }

    public required DateTime Data { get; set; }

    public ICollection<VendaItemVM>? Items { get; set; }

}