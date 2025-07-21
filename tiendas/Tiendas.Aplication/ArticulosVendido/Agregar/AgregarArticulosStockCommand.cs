using MediatR;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.ArticulosVendido.Agregar
{

    public sealed record AgregarArticulosVendidoCommand(long IdTienda, long IdArticulo, double Price, string NombreGestor) : IRequest<long>;
    public sealed class AgregarArticulosVendidoCommandHandler : IRequestHandler<AgregarArticulosVendidoCommand, long>
    {
        private readonly IUnitOfWork _unitWork;

        public AgregarArticulosVendidoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }
        public async Task<long> Handle(AgregarArticulosVendidoCommand request, CancellationToken cancellationToken)
        {
            var Articulo = new ArticulosVendidos(request.IdTienda, request.IdArticulo, request.Price, request.NombreGestor);
            _unitWork.ArticulosVendidosRepository.Add(Articulo);
            await _unitWork.SalvarCambiosAsync(cancellationToken);
            return Articulo.Id;

        }
    }
}
