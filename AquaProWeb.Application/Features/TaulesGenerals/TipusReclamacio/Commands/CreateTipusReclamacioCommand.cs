using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusReclamacions;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusReclamacio.Commands
{
    public class CreateTipusReclamacioCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusReclamacioDTO CreateTipusReclamacio { get; set; }
    }

    public class CreateTipusReclamacioCommandHandler : IRequestHandler<CreateTipusReclamacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusReclamacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusReclamacioCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusReclamacio = request.CreateTipusReclamacio.Adapt<Domain.Entities.TipusReclamacio>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusReclamacio>().AddAsync(tipusReclamacio);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusReclamacio.Id, "TipusReclamacio creat correctament!");
        }
    }
}
