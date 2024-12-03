using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.SeriesRebut;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SeriesRebut.Commands
{
    public class UpdateSerieRebutCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateSerieRebutDTO UpdateSerieRebut { get; set; }
    }

    public class UpdateSerieRebutCommandHandler : IRequestHandler<UpdateSerieRebutCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSerieRebutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateSerieRebutCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var serieRebutDb = await _unitOfWork.ReadRepositoryFor<SerieRebut>().GetByIdAsync(request.UpdateSerieRebut.Id);

            if (serieRebutDb is not null)
            {
                request.UpdateSerieRebut.Adapt(serieRebutDb);

                await _unitOfWork.WriteRepositoryFor<SerieRebut>().UpdateAsync(serieRebutDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(serieRebutDb.Id, "SerieRebut actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("SerieRebut no existeix!");

        }
    }
}
