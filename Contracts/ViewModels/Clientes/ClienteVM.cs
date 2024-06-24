using System.ComponentModel.DataAnnotations;
using Contracts.ViewModels.Vendas;

namespace Contracts.ViewModels.Clientes;

public class ClienteVM
{


    public int ClienteId { get; set; }

    //[Required]
    [MaxLength(length: 256, ErrorMessage = "O nome so pode ter 256 carateres.")]
    public required string Nome { get; set; }

    [MaxLength(length: 256, ErrorMessage = "O endereco so pode ter 256 carateres.")]
    public required string Endereco { get; set; }

    [MaxLength(length: 20, ErrorMessage = "O telefone so pode ter 20 carateres.")]
    public required string Telefone { get; set; }

    [MaxLength(length: 256, ErrorMessage = "O email so pode ter 256 carateres.")]
    [EmailAddress]
    public required string Email { get; set; }

    public ICollection<VendaVM>? Vendas { get; set; }


}