using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ComptesRemesaBanc.Queries
{
    public class GetComptesRemesaBancQuery : IRequest<ResponseWrapper<List<ReadCompteRemesaBancDTO>>>
    {
    }

    public class GetCompteRemesaBancsQueryHandler : IRequestHandler<GetComptesRemesaBancQuery, ResponseWrapper<List<ReadCompteRemesaBancDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCompteRemesaBancsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadCompteRemesaBancDTO>>> Handle(GetComptesRemesaBancQuery request, CancellationToken cancellationToken)
        {
            var compteRemesaBancsDb = await _unitOfWork.ReadRepositoryFor<CompteRemesaBanc>().GetAllAsync();

            if (compteRemesaBancsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadCompteRemesaBancDTO>>().Success(compteRemesaBancsDb.Adapt<List<ReadCompteRemesaBancDTO>>());
            }

            return new ResponseWrapper<List<ReadCompteRemesaBancDTO>>().Failure("No hi han comptes de remesa!");
        }
    }
}
