using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiendas.Domain.Aggregates;
using Tiendas.Domain.Repositories;

namespace Tiendas.Aplication.TiendaFisica.Agregar
{

    public sealed record AgregarTiendaCommand(string Name,string Addres) : IRequest<long>;
    public sealed class AgregarTiendaCommandHandler : IRequestHandler<AgregarTiendaCommand, long>
    {
        private readonly IUnitOfWork _unitWork;


        public AgregarTiendaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }
        public async Task<long> Handle(AgregarTiendaCommand request, CancellationToken cancellationToken)
        {
            var Tienda = new TiendasFisicas(request.Name, request.Addres);
            _unitWork.TiendaRepository.Add(Tienda);
            await _unitWork.SalvarCambiosAsync(cancellationToken);
            return Tienda.Id;



        }
    }
}
