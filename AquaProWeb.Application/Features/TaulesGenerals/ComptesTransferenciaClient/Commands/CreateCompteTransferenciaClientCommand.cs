using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesTransferenciaClient;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ComptesTransferenciaClient.Commands
{
    public class CreateCompteTransferenciaClientCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateCompteTransferenciaClientDTO CreateCompteTransferenciaClient { get; set; }
    }

    public class CreateCompteTransferenciaClientCommandHandler : IRequestHandler<CreateCompteTransferenciaClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompteTransferenciaClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateCompteTransferenciaClientCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var compteTransferenciaClient = request.CreateCompteTransferenciaClient.Adapt<CompteTransferenciaClient>();

            await _unitOfWork.WriteRepositoryFor<CompteTransferenciaClient>().AddAsync(compteTransferenciaClient);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(compteTransferenciaClient.Id, "Compte de remesa banc creat correctament!");
        }
    }
}
