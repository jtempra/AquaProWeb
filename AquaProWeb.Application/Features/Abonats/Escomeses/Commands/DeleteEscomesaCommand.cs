using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Escomeses.Commands
{
    public class DeleteEscomesaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteEscomesaCommandHandler : IRequestHandler<DeleteEscomesaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEscomesaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteEscomesaCommand Request, CancellationToken cancellationToken)
        {
            var EscomesaDb = await _unitOfWork.ReadRepositoryFor<Escomesa>().GetByIdAsync(Request.Id);

            if (EscomesaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Escomesa>().DeleteAsync(EscomesaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(EscomesaDb.Id, "Escomesa esborrat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Escomesa no trobat!");
        }
    }
}
