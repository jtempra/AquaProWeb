using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.SeriesRebut;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SeriesRebut.Queries
{
    public class GetSerieRebutByIdQuery : IRequest<ResponseWrapper<ReadSerieRebutDTO>>
    {
        public int Id { get; set; }
    }

    public class GetSerieRebutByIdQueryHandler : IRequestHandler<GetSerieRebutByIdQuery, ResponseWrapper<ReadSerieRebutDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSerieRebutByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadSerieRebutDTO>> Handle(GetSerieRebutByIdQuery request, CancellationToken cancellationToken)
        {
            var serieRebutDb = await _unitOfWork.ReadRepositoryFor<SerieRebut>().GetByIdAsync(request.Id);

            if (serieRebutDb is not null)
            {
                var SerieRebutDTO = serieRebutDb.Adapt<ReadSerieRebutDTO>();

                return new ResponseWrapper<ReadSerieRebutDTO>().Success(SerieRebutDTO);
            }

            return new ResponseWrapper<ReadSerieRebutDTO>().Failure("SerieRebut no existeix!");
        }
    }
}
