using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusUbicacio.Queries
{
    public class GetTipusUbicacioByTextQuery : IRequest<ResponseWrapper<List<ReadTipusUbicacioDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusUbicacioByTextQueryHandler : IRequestHandler<GetTipusUbicacioByTextQuery, ResponseWrapper<List<ReadTipusUbicacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusUbicacioByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusUbicacioDTO>>> Handle(GetTipusUbicacioByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusUbicacioDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusUbicacioDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusUbicacioDTO>>().Success(tipusUbicacioDb.Adapt<List<ReadTipusUbicacioDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusUbicacioDTO>>().Failure("No s'han trobat TipusUbicacio!");
        }
    }
}
