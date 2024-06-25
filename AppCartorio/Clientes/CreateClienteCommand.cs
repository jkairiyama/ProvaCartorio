using System.ComponentModel.DataAnnotations;
using Domain.Data.Clientes;
using MediatR;

namespace AppCartorio.Clientes;

public record CreateClienteCommand
(
    [Required]
    [MaxLength(256)]
    string Nome,

    [Required]
    [MaxLength(256)]
    string Endereco,

    [Required]
    [MaxLength(20)]
    string Telefone,

    [Required]
    [MaxLength(256)]
    [EmailAddress]
    string Email
    ) : IRequest<Cliente>;