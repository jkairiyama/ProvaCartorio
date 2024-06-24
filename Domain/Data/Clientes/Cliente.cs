using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Domain.Data.Vendas;
using Domain.Logic.Clientes;

namespace Domain.Data.Clientes;

public class Cliente
{
    public int ClienteId { get; private set; }

    [Required]
    public string Nome { get; private set; }

    public string Endereco { get; private set; }

    public string Telefone { get; private set; }

    public string Email { get; private set; }


    public Cliente(
        string nome,
        string endereco,
        string telefone,
        string email
        )
    {
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
        Email = email;
    }

    public Cliente SetNome(string nome)
    {
        Nome = nome;
        return this;
    }

    public Cliente SetEndereco(string endereco)
    {
        Endereco = endereco;
        return this;
    }
    public Cliente SetTelefone(string telefone)
    {
        Telefone = telefone;
        return this;
    }
    public Cliente SetEmail(string email)
    {
        Email = email;
        return this;
    }

}