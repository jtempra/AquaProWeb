using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ComptesRemesaBanc.Commands
{
    public class DeleteCompteRemesaBancCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCompteRemesaBancCommandHandler : IRequestHandler<DeleteCompteRemesaBancCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompteRemesaBancCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteCompteRemesaBancCommand Request, CancellationToken cancellationToken)
        {
            var compteRemesaBancDb = await _unitOfWork.ReadRepositoryFor<CompteRemesaBanc>().GetByIdAsync(Request.Id);

            if (compteRemesaBancDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<CompteRemesaBanc>().DeleteAsync(compteRemesaBancDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(compteRemesaBancDb.Id, "Compte remesa banc esborrat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Carrer no trobat!");
        }
    }
}
