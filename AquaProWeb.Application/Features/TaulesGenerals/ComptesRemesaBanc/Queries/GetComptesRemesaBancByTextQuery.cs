using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ComptesRemesaBanc.Queries
{
    public class GetComptesRemesaBancByTextQuery : IRequest<ResponseWrapper<List<ReadCompteRemesaBancDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetCompteRemesaBancByTextQueryHandler : IRequestHandler<GetComptesRemesaBancByTextQuery, ResponseWrapper<List<ReadCompteRemesaBancDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCompteRemesaBancByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadCompteRemesaBancDTO>>> Handle(GetComptesRemesaBancByTextQuery request, CancellationToken cancellationToken)
        {
            var compteRemesaBancsDb = await _unitOfWork.ReadRepositoryFor<CompteRemesaBanc>().GetByTextAsync(request.Text);

            if (compteRemesaBancsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadCompteRemesaBancDTO>>().Success(compteRemesaBancsDb.Adapt<List<ReadCompteRemesaBancDTO>>());
            }

            return new ResponseWrapper<List<ReadCompteRemesaBancDTO>>().Failure("No s'han trobat comptes de remesa!");
        }
    }
}
