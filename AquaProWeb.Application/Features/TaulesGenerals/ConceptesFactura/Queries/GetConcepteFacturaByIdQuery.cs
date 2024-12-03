using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ConceptesFactura.Queries
{
    public class GetConcepteFacturaByIdQuery : IRequest<ResponseWrapper<ReadConcepteFacturaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetConcepteFacturaByIdQueryHandler : IRequestHandler<GetConcepteFacturaByIdQuery, ResponseWrapper<ReadConcepteFacturaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetConcepteFacturaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadConcepteFacturaDTO>> Handle(GetConcepteFacturaByIdQuery request, CancellationToken cancellationToken)
        {
            var concepteFacturaDb = await _unitOfWork.ReadRepositoryFor<ConcepteFactura>().GetByIdAsync(request.Id);

            if (concepteFacturaDb is not null)
            {
                var ConcepteFacturaDTO = concepteFacturaDb.Adapt<ReadConcepteFacturaDTO>();

                return new ResponseWrapper<ReadConcepteFacturaDTO>().Success(ConcepteFacturaDTO);
            }

            return new ResponseWrapper<ReadConcepteFacturaDTO>().Failure("El ConcepteFactura no existeix!");
        }
    }
}
