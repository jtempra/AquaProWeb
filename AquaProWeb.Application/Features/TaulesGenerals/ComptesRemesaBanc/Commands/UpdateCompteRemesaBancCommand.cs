using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ComptesRemesaBanc.Commands
{
    public class UpdateCompteRemesaBancCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveCompteRemesaBancDTO UpdateCompteRemesaBanc { get; set; }
    }

    public class UpdateCompteRemesaBancCommandHandler : IRequestHandler<UpdateCompteRemesaBancCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCompteRemesaBancCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateCompteRemesaBancCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var compteRemesaBancDb = await _unitOfWork.ReadRepositoryFor<CompteRemesaBanc>().GetByIdAsync(request.UpdateCompteRemesaBanc.Id);

            if (compteRemesaBancDb is not null)
            {
                request.UpdateCompteRemesaBanc.Adapt(compteRemesaBancDb);

                await _unitOfWork.WriteRepositoryFor<CompteRemesaBanc>().UpdateAsync(compteRemesaBancDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(compteRemesaBancDb.Id, "Compte remesa banc actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El carrer no existeix!");

        }
    }
}
