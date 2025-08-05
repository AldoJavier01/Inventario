using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.TiendasFisiscas.Agregar
{

    public sealed record ObtenerTiendasFisiscaCommand() : IRequest<IEnumerable<TiendasFisicas>>;
    public sealed class ObtenerTiendasFisiscaCommandHandler : IRequestHandler<ObtenerTiendasFisiscaCommand, IEnumerable<TiendasFisicas>?>
    {
        private readonly IUnitOfWork _unitWork;


        public ObtenerTiendasFisiscaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }
       

        public async Task<IEnumerable<TiendasFisicas>?> Handle(ObtenerTiendasFisiscaCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitWork.TiendaRepository.GetAll();
            return result;
        }
    }
}
