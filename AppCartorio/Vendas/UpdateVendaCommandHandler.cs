using Domain.Data.Vendas;
using MediatR;
using Domain.Repositories.Vendas;
using Domain.Data.Vendas.Entities;
using Mapster;

namespace AppCartorio.Vendas;

public class UpdateVendaCommandHandler : IRequestHandler<UpdateVendaCommand, Venda>
{
    private readonly IVendaRepository _vendaRepository;

    public UpdateVendaCommandHandler(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public async Task<Venda> Handle(UpdateVendaCommand request, CancellationToken cancellationToken)
    {
        TypeAdapterConfig.GlobalSettings.Default.MapToConstructor(true);//tinha um error (mapster): não tinha default contructor
        var vendaModificada = request.Adapt<Venda>();
        

        var venda = await _vendaRepository.Update(vendaModificada);
        await _vendaRepository.Save();

        return venda;
    }
}
