using MediatR;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.ArticulosStocks.Agregar
{

    public sealed record DetalleArticulosStockCommand(long IdArticulo) : IRequest<ArticulosStock>;
    public sealed class DetalleArticulosVentasCommandHandler : IRequestHandler<DetalleArticulosStockCommand, ArticulosStock?>
    {
        private readonly IUnitOfWork _unitWork;


        public DetalleArticulosVentasCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }


        public async Task<ArticulosStock?> Handle(DetalleArticulosStockCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitWork.ArticulosStockRepository.GetById(request.IdArticulo);
            return result;
        }
    }
}
