using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SeriesRebut.Commands
{
    public class DeleteSerieRebutCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSerieRebutCommandHandler : IRequestHandler<DeleteSerieRebutCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSerieRebutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteSerieRebutCommand Request, CancellationToken cancellationToken)
        {
            var serieRebutDb = await _unitOfWork.ReadRepositoryFor<SerieRebut>().GetByIdAsync(Request.Id);

            if (serieRebutDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<SerieRebut>().DeleteAsync(serieRebutDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "SerieRebut creat correctament!");
            }

            return new ResponseWrapper<int>().Failure("SerieRebut no trobat!");
        }
    }
}
