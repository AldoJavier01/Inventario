using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.ArticulosStocks.Agregar
{

    public sealed record AgregarArticulosStockCommand(
     string Name,
     string Description,
     string Category,
     string UrlImgs,
     double Price,
     double Weight,
     
     string Tipos,
     int IdShein,
     string SKU,
     Stream image) : IRequest<long>;
    public sealed class AgregarArticulosStockCommandHandler : IRequestHandler<AgregarArticulosStockCommand, long>
    {
        private readonly IUnitOfWork _unitWork;


        public AgregarArticulosStockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }
        public async Task<long> Handle(AgregarArticulosStockCommand request, CancellationToken cancellationToken)
        {
            using (var memoryStream = new MemoryStream())
            {
                await request.image.CopyToAsync(memoryStream);
                var Articulo = new ArticulosStock(request.Name, request.Description, request.Category, request.UrlImgs, request.Price
                , request.Weight, request.Tipos, request.IdShein, request.SKU, memoryStream.GetBuffer());
                _unitWork.ArticulosStockRepository.Add(Articulo);
                await _unitWork.SalvarCambiosAsync(cancellationToken);
                return Articulo.Id;
            }




        }
    }
}
