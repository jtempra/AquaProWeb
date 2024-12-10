using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesContractes;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaContracte.Queries
{
    public class GetTipusIncidenciaContracteByTextQuery : IRequest<ResponseWrapper<List<ReadTipusIncidenciaContracteDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusIncidenciaContracteByTextQueryHandler : IRequestHandler<GetTipusIncidenciaContracteByTextQuery, ResponseWrapper<List<ReadTipusIncidenciaContracteDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaContracteByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusIncidenciaContracteDTO>>> Handle(GetTipusIncidenciaContracteByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaContracteDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusIncidenciaContracteDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusIncidenciaContracteDTO>>().Success(tipusIncidenciaContracteDb.Adapt<List<ReadTipusIncidenciaContracteDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusIncidenciaContracteDTO>>().Failure("No s'han trobat TipusIncidenciaContracte!");
        }
    }
}
