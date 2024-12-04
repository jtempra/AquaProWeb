using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusDocuments;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusDocument.Queries
{
    public class GetTipusDocumentByTextQuery : IRequest<ResponseWrapper<List<ReadTipusDocumentDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusDocumentByTextQueryHandler : IRequestHandler<GetTipusDocumentByTextQuery, ResponseWrapper<List<ReadTipusDocumentDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusDocumentByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusDocumentDTO>>> Handle(GetTipusDocumentByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusDocumentDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusDocumentDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusDocumentDTO>>().Success(tipusDocumentDb.Adapt<List<ReadTipusDocumentDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusDocumentDTO>>().Failure("No s'han trobat TipusDocument!");
        }
    }
}
