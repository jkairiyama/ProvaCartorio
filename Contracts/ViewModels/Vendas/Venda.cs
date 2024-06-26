using System.ComponentModel.DataAnnotations;


namespace Contracts.ViewModels.Vendas;

public record VendaVM(
    int VendaId,
    int ClienteId,
    string ClienteNome,
    DateTime Data,
    ICollection<ItemVendaVM> Items
);

public record ItemVendaVM(
    int VendaItemId,
    int VendaId,
    int ProdutoId,
    string ProdutoNome,
    int Quantidade,
    decimal Preco,
    decimal Total
);