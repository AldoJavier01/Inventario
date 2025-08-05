using MediatR;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.ArticulosVentass.Agregar
{

    public sealed record EliminarArticuloVentasCommand(long IdArticulo) : IRequest<long>;
    public sealed class EliminarArticulosVentasCommandHandler : IRequestHandler<EliminarArticuloVentasCommand, long>
    {
        private readonly IUnitOfWork _unitWork;


        public EliminarArticulosVentasCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }


        public async Task<long> Handle(EliminarArticuloVentasCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitWork.ArticulosVentasRepository.GetById(request.IdArticulo);
            _unitWork.ArticulosVentasRepository.Delete(result);
            await _unitWork.SalvarCambiosAsync(cancellationToken);

            return 200;
        }
    }
}
