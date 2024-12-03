using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ComptesRemesaBanc.Commands
{
    public class CreateCompteTransferenciaClientCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateCompteRemesaBancDTO CreateCompteRemesaBanc { get; set; }
    }

    public class CreateCompteRemesaBancCommandHandler : IRequestHandler<CreateCompteTransferenciaClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompteRemesaBancCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateCompteTransferenciaClientCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var compteRemesaBanc = request.CreateCompteRemesaBanc.Adapt<CompteRemesaBanc>();

            await _unitOfWork.WriteRepositoryFor<CompteRemesaBanc>().AddAsync(compteRemesaBanc);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(compteRemesaBanc.Id, "Compte de remesa banc creat correctament!");
        }
    }
}
