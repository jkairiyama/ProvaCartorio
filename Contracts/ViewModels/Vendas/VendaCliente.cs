using System.ComponentModel.DataAnnotations;


namespace Contracts.ViewModels.Vendas;

public record VendaClienteVM(
    int VendaId,
    int ClienteId,
    string ClienteNome,
    DateTime Data
);
