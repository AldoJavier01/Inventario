using MediatR;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.ArticulosVentass.Agregar
{

    public sealed record EliminarArticulosVentasCommand(long IdArticulo) : IRequest<long>;
    public sealed class EliminarArticulosVentasCommandHandler : IRequestHandler<EliminarArticulosVentasCommand, long>
    {
        private readonly IUnitOfWork _unitWork;


        public EliminarArticulosVentasCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }


        public async Task<long> Handle(EliminarArticulosVentasCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitWork.ArticulosStockRepository.GetById(request.IdArticulo);
            _unitWork.ArticulosStockRepository.Delete(result);
            await _unitWork.SalvarCambiosAsync(cancellationToken);

            return 200;
        }
    }
}
