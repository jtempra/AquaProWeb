using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusUbicacio.Commands
{
    public class CreateTipusUbicacioCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusUbicacioDTO CreateTipusUbicacio { get; set; }
    }

    public class CreateTipusUbicacioCommandHandler : IRequestHandler<CreateTipusUbicacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusUbicacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusUbicacioCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusUbicacio = request.CreateTipusUbicacio.Adapt<Domain.Entities.TipusUbicacio>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusUbicacio>().AddAsync(tipusUbicacio);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusUbicacio.Id, "TipusUbicacio creat correctament!");
        }
    }
}
