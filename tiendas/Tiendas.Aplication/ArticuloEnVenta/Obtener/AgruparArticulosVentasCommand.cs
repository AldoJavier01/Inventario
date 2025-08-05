using MediatR;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.ArticulosVentass.Agregar
{

    public sealed record AgruparArticulosVentasCommand(long Codigo) : IRequest<IEnumerable<ArticulosVentas>>;
    public sealed class AgruparArticulosVentasCommandHandler : IRequestHandler<AgruparArticulosVentasCommand, IEnumerable<ArticulosVentas>?>
    {
        private readonly IUnitOfWork _unitWork;


        public AgruparArticulosVentasCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }


        public async Task<IEnumerable<ArticulosVentas>?> Handle(AgruparArticulosVentasCommand request, CancellationToken cancellationToken)
        {

            var result = await _unitWork.ArticulosVentasRepository.ObtenerPorCodigo(request.Codigo);

            return result;
        }
    }
}
