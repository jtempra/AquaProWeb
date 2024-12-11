using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusUbicacio.Commands
{
    public class DeleteTipusUbicacioCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusUbicacioCommandHandler : IRequestHandler<DeleteTipusUbicacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusUbicacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusUbicacioCommand Request, CancellationToken cancellationToken)
        {
            var tipusUbicacioDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusUbicacio>().GetByIdAsync(Request.Id);

            if (tipusUbicacioDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusUbicacio>().DeleteAsync(tipusUbicacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Ubicacio esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusUbicacio no trobat!");
        }
    }
}
