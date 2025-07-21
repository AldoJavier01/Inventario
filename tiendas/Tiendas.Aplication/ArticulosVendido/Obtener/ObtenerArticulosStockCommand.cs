using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.ArticulosVendidoss.Agregar
{

    public sealed record ObtenerArticulosVendidosCommand() : IRequest<IEnumerable<ArticulosVendidos>>;
    public sealed class ObtenerArticulosVendidosCommandHandler : IRequestHandler<ObtenerArticulosVendidosCommand, IEnumerable<ArticulosVendidos>?>
    {
        private readonly IUnitOfWork _unitWork;


        public ObtenerArticulosVendidosCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }
       

        public async Task<IEnumerable<ArticulosVendidos>?> Handle(ObtenerArticulosVendidosCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitWork.ArticulosVendidosRepository.GetAll();
            return result;
        }
    }
}
