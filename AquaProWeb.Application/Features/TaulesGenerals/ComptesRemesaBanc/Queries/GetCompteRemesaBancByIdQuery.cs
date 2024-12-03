using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ComptesRemesaBanc.Queries
{
    public class GetCompteTransferenciaClientByIdQuery : IRequest<ResponseWrapper<ReadCompteRemesaBancDTO>>
    {
        public int Id { get; set; }
    }

    public class GetCompteRemesaBancByIdQueryHandler : IRequestHandler<GetCompteTransferenciaClientByIdQuery, ResponseWrapper<ReadCompteRemesaBancDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCompteRemesaBancByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadCompteRemesaBancDTO>> Handle(GetCompteTransferenciaClientByIdQuery request, CancellationToken cancellationToken)
        {
            var compteRemesaBancDb = await _unitOfWork.ReadRepositoryFor<CompteRemesaBanc>().GetByIdAsync(request.Id);

            if (compteRemesaBancDb is not null)
            {
                var CompteRemesaBancDTO = compteRemesaBancDb.Adapt<ReadCompteRemesaBancDTO>();

                return new ResponseWrapper<ReadCompteRemesaBancDTO>().Success(CompteRemesaBancDTO);
            }

            return new ResponseWrapper<ReadCompteRemesaBancDTO>().Failure("El compte de remesa no existeix!");
        }
    }
}
