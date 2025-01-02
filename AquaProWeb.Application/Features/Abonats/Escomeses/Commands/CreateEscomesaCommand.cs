using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.Abonats.Escomeses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Escomeses.Commands
{
    public class CreateEscomesaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveEscomesaDTO CreateEscomesa { get; set; }
    }

    public class CreateEscomesaCommandHandler : IRequestHandler<CreateEscomesaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEscomesaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateEscomesaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var Escomesa = request.CreateEscomesa.Adapt<Escomesa>();

            await _unitOfWork.WriteRepositoryFor<Escomesa>().AddAsync(Escomesa);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(Escomesa.Id, "Escomesa creat correctament!");
        }
    }
}
