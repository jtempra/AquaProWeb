using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ComptesTransferenciaClient.Commands
{
    public class DeleteCompteTransferenciaClientCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCompteTransferenciaClientCommandHandler : IRequestHandler<DeleteCompteTransferenciaClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompteTransferenciaClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteCompteTransferenciaClientCommand Request, CancellationToken cancellationToken)
        {
            var compteTransferenciaClientDb = await _unitOfWork.ReadRepositoryFor<CompteTransferenciaClient>().GetByIdAsync(Request.Id);

            if (compteTransferenciaClientDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<CompteTransferenciaClient>().DeleteAsync(compteTransferenciaClientDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(compteTransferenciaClientDb.Id, "Compte remesa banc esborrat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Carrer no trobat!");
        }
    }
}
