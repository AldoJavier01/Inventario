using MediatR;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.ArticulosVentass.Agregar
{

    public sealed record DetalleArticulosVentasCommand(long IdArticulo) : IRequest<ArticulosStock>;
    public sealed class DetalleArticulosVentasCommandHandler : IRequestHandler<DetalleArticulosVentasCommand, ArticulosStock?>
    {
        private readonly IUnitOfWork _unitWork;


        public DetalleArticulosVentasCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }


        public async Task<ArticulosStock?> Handle(DetalleArticulosVentasCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitWork.ArticulosStockRepository.GetById(request.IdArticulo);
            return result;
        }
    }
}
