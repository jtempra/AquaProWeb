using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusDocuments;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusDocument.Queries
{
    public class GetTipusDocumentQuery : IRequest<ResponseWrapper<List<ReadTipusDocumentDTO>>>
    {
    }

    public class GetTipusDocumentQueryHandler : IRequestHandler<GetTipusDocumentQuery, ResponseWrapper<List<ReadTipusDocumentDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusDocumentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusDocumentDTO>>> Handle(GetTipusDocumentQuery request, CancellationToken cancellationToken)
        {
            var tipusDocumentDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (tipusDocumentDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusDocumentDTO>>().Success(tipusDocumentDb.Adapt<List<ReadTipusDocumentDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusDocumentDTO>>().Failure("No hi han TipusDocument!");
        }
    }
}
