using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesLectures;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaLectura.Queries
{
    public class GetTipusIncidenciaLecturaByTextQuery : IRequest<ResponseWrapper<List<ReadTipusIncidenciaLecturaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusIncidenciaLecturaByTextQueryHandler : IRequestHandler<GetTipusIncidenciaLecturaByTextQuery, ResponseWrapper<List<ReadTipusIncidenciaLecturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaLecturaByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusIncidenciaLecturaDTO>>> Handle(GetTipusIncidenciaLecturaByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaLecturaDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusIncidenciaLecturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusIncidenciaLecturaDTO>>().Success(tipusIncidenciaLecturaDb.Adapt<List<ReadTipusIncidenciaLecturaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusIncidenciaLecturaDTO>>().Failure("No s'han trobat TipusIncidenciaLectura!");
        }
    }
}
