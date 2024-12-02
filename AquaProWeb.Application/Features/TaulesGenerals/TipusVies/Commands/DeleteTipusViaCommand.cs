using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusVies.Commands
{
    public class DeleteTipusViaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusViaCommandHandler : IRequestHandler<DeleteTipusViaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusViaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusViaCommand Request, CancellationToken cancellationToken)
        {
            var tipusViaDb = await _unitOfWork.ReadRepositoryFor<TipusVia>().GetByIdAsync(Request.Id);

            if (tipusViaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<TipusVia>().DeleteAsync(tipusViaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusViaDb.Id, "TipusVia esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("Tipus via no trobada!");
        }
    }
}
