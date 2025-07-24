using MediatR;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.ArticulosStocks.Editar
{

    public sealed record EditarArticulosStockCommand(
        long Id,
     string Name,
     string Description,
     string Category,
     double Price,
     string Tipos,
     string SKU)
     : IRequest<long>;
    public sealed class EditarArticulosStockCommandHandler : IRequestHandler<EditarArticulosStockCommand, long>
    {
        private readonly IUnitOfWork _unitWork;


        public EditarArticulosStockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }
        public async Task<long> Handle(EditarArticulosStockCommand request, CancellationToken cancellationToken)
        {
            ArticulosStock Articulo = await _unitWork.ArticulosStockRepository.GetById(request.Id);
            if (Articulo == null) { throw new Exception("Articulo no encontrado en Bd"); }

            Articulo.Name = request.Name;
            Articulo.Description = request.Description;
            Articulo.Category = request.Category;
            Articulo.Price = request.Price;
            Articulo.Tipos = request.Tipos;
            Articulo.SKU = request.SKU;

            _unitWork.ArticulosStockRepository.Update(Articulo);
            await _unitWork.SalvarCambiosAsync(cancellationToken);
            return Articulo.Id;
        }




    }
}

