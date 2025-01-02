using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.Abonats.Escomeses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Escomeses.Commands
{
    public class UpdateEscomesaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveEscomesaDTO UpdateEscomesa { get; set; }
    }

    public class UpdateEscomesaCommandHandler : IRequestHandler<UpdateEscomesaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEscomesaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateEscomesaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var EscomesaDb = await _unitOfWork.ReadRepositoryFor<Escomesa>().GetByIdAsync(request.UpdateEscomesa.Id);

            if (EscomesaDb is not null)
            {
                request.UpdateEscomesa.Adapt(EscomesaDb);

                await _unitOfWork.WriteRepositoryFor<Escomesa>().UpdateAsync(EscomesaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(EscomesaDb.Id, "Escomesa actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El Escomesa no existeix!");

        }
    }
}
