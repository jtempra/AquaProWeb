using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusDocuments;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusDocument.Queries
{
    public class GetTipusDocumentByIdQuery : IRequest<ResponseWrapper<ReadTipusDocumentDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusDocumentByIdQueryHandler : IRequestHandler<GetTipusDocumentByIdQuery, ResponseWrapper<ReadTipusDocumentDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusDocumentByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusDocumentDTO>> Handle(GetTipusDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusDocumentDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusDocument>().GetByIdAsync(request.Id);

            if (tipusDocumentDb is not null)
            {
                var TipusDocumentDTO = tipusDocumentDb.Adapt<ReadTipusDocumentDTO>();

                return new ResponseWrapper<ReadTipusDocumentDTO>().Success(TipusDocumentDTO);
            }

            return new ResponseWrapper<ReadTipusDocumentDTO>().Failure("TipusDocument no existeix!");
        }
    }
}
