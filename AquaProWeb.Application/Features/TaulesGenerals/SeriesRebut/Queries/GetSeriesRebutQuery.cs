using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.SeriesRebut;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SeriesRebut.Queries
{
    public class GetSeriesRebutQuery : IRequest<ResponseWrapper<List<ReadSerieRebutDTO>>>
    {
    }

    public class GetSeriesRebutQueryHandler : IRequestHandler<GetSeriesRebutQuery, ResponseWrapper<List<ReadSerieRebutDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSeriesRebutQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadSerieRebutDTO>>> Handle(GetSeriesRebutQuery request, CancellationToken cancellationToken)
        {
            var serieRebutDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (serieRebutDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadSerieRebutDTO>>().Success(serieRebutDb.Adapt<List<ReadSerieRebutDTO>>());
            }

            return new ResponseWrapper<List<ReadSerieRebutDTO>>().Failure("No hi han SeriesRebut!");
        }
    }
}
