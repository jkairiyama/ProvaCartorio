using System;
using Domain.Data.Clientes;
using Domain.Data.Vendas;

namespace Domain.Repositories.Clientes;

public interface IClienteRepository
{
    Task Save();
    Task Create(Cliente cliente);

    void Remove(Cliente cliente);

    Task Remove(int clienteId);

    void Update(Cliente cliente);

    Task<Cliente?> Get(int clienteId);

    Task<ICollection<Cliente>> Get(string nome);



}


