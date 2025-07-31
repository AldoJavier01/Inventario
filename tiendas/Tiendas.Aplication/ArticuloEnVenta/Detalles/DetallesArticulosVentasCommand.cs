using MediatR;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.ArticulosVentass.Agregar
{

    public sealed record DetalleArticulosVentasCommand(long IdArticulo) : IRequest<ArticulosVentas>;
    public sealed class DetalleArticulosVentasCommandHandler : IRequestHandler<DetalleArticulosVentasCommand, ArticulosVentas?>
    {
        private readonly IUnitOfWork _unitWork;


        public DetalleArticulosVentasCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }


        public async Task<ArticulosVentas?> Handle(DetalleArticulosVentasCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitWork.ArticulosVentasRepository.GetById(request.IdArticulo);
            return result;
        }
    }
}
