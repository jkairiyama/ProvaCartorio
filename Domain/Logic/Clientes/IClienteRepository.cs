using System;
using Domain.Data.Clientes;
using Domain.Data.Vendas;

namespace Domain.Logic.Clientes;

public interface IClienteRepository
{
    void Save();
    Task Create(Cliente cliente);

    void Remove(Cliente cliente);

    Task Remove(int clienteId);

    void Update(Cliente cliente);

    Task<Cliente?> Get(int clienteId);

    Task<ICollection<Cliente>> Get(string nome);


}


