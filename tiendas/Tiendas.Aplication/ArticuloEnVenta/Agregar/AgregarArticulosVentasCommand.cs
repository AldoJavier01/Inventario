using MediatR;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.ArticulosVentass.Agregar
{

    public sealed record AgregarArticulosVentasCommand(
     long IdTienda,
     long IdArticulo,
     long Cantidad,
     double Price,
     string NombreGestor,
     string SKU,
     string Talla) : IRequest<long>;
    public sealed class AgregarArticulosVentasCommandHandler : IRequestHandler<AgregarArticulosVentasCommand, long>
    {
        private readonly IUnitOfWork _unitWork;


        public AgregarArticulosVentasCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }
        public async Task<long> Handle(AgregarArticulosVentasCommand request, CancellationToken cancellationToken)
        {
            var Articulo = new ArticulosVentas(request.IdTienda, request.IdArticulo, request.Price, request.NombreGestor,request.Talla,request.Cantidad);
            _unitWork.ArticulosVentasRepository.Add(Articulo);
            await _unitWork.SalvarCambiosAsync(cancellationToken);
            return Articulo.Id;



        }
    }
}
