using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Empreses;
using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesConcepteFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.FamiliesConcepteFactura.Queries
{
    public class GetFamiliaConcepteFacturaByIdQuery : IRequest<ResponseWrapper<ReadFamiliaConcepteFacturaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetFamiliaConcepteFacturaByIdQueryHandler : IRequestHandler<GetFamiliaConcepteFacturaByIdQuery, ResponseWrapper<ReadFamiliaConcepteFacturaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFamiliaConcepteFacturaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadFamiliaConcepteFacturaDTO>> Handle(GetFamiliaConcepteFacturaByIdQuery request, CancellationToken cancellationToken)
        {
            var familiaConcepteFacturaDb = await _unitOfWork.ReadRepositoryFor<FamiliaConcepteFactura>().GetByIdAsync(request.Id);

            if (familiaConcepteFacturaDb is not null)
            {
                var FamiliaConcepteFacturaDTO = familiaConcepteFacturaDb.Adapt<ReadFamiliaConcepteFacturaDTO>();

                return new ResponseWrapper<ReadFamiliaConcepteFacturaDTO>().Success(FamiliaConcepteFacturaDTO);
            }

            return new ResponseWrapper<ReadFamiliaConcepteFacturaDTO>().Failure("El FamiliaConcepteFactura no existeix!");
        }
    }
}
