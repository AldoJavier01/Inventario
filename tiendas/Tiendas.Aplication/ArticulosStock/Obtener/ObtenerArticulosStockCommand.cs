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

    public sealed record ObtenerArticulosStockCommand() : IRequest<IEnumerable<ArticulosStock>>;
    public sealed class ObtenerArticulosStockCommandHandler : IRequestHandler<ObtenerArticulosStockCommand, IEnumerable<ArticulosStock>?>
    {
        private readonly IUnitOfWork _unitWork;


        public ObtenerArticulosStockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }
       

        public async Task<IEnumerable<ArticulosStock>?> Handle(ObtenerArticulosStockCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitWork.ArticulosStockRepository.GetAll();
            return result;
        }
    }
}
