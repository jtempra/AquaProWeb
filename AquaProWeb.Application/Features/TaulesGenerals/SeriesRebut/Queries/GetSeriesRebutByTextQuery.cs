using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.SeriesRebut;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SeriesRebut.Queries
{
    public class GetSeriesRebutByTextQuery : IRequest<ResponseWrapper<List<ReadSerieRebutDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetSeriesRebutByTextQueryHandler : IRequestHandler<GetSeriesRebutByTextQuery, ResponseWrapper<List<ReadSerieRebutDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSeriesRebutByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadSerieRebutDTO>>> Handle(GetSeriesRebutByTextQuery request, CancellationToken cancellationToken)
        {
            var serieRebutDb = await _unitOfWork.ReadRepositoryFor<SerieRebut>().GetByTextAsync(request.Text);

            if (serieRebutDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadSerieRebutDTO>>().Success(serieRebutDb.Adapt<List<ReadSerieRebutDTO>>());
            }

            return new ResponseWrapper<List<ReadSerieRebutDTO>>().Failure("No s'han trobat SeriesRebut!");
        }
    }
}
