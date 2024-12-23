using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.SeriesRebut;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SeriesRebut.Commands
{
    public class CreateSerieRebutCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveSerieRebutDTO CreateSerieRebut { get; set; }
    }

    public class CreateSerieRebutCommandHandler : IRequestHandler<CreateSerieRebutCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSerieRebutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateSerieRebutCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var serieRebut = request.CreateSerieRebut.Adapt<SerieRebut>();

            await _unitOfWork.WriteRepositoryFor<SerieRebut>().AddAsync(serieRebut);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(serieRebut.Id, "SerieRebut creat correctament!");
        }
    }
}
