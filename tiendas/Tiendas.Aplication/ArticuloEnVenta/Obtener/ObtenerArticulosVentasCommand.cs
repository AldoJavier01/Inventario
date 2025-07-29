using MediatR;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.ArticulosVentass.Agregar
{

    public sealed record ObtenerArticulosVentasCommand() : IRequest<IEnumerable<ArticulosVentas>>;
    public sealed class ObtenerArticulosVentasCommandHandler : IRequestHandler<ObtenerArticulosVentasCommand, IEnumerable<ArticulosVentas>?>
    {
        private readonly IUnitOfWork _unitWork;


        public ObtenerArticulosVentasCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }


        public async Task<IEnumerable<ArticulosVentas>?> Handle(ObtenerArticulosVentasCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitWork.ArticulosVentasRepository.GetAll();
            return result;
        }
    }
}
