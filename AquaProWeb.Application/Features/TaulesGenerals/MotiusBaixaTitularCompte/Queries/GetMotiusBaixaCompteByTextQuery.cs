using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaCompte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaCompteCompte.Queries
{
    public class GetMotiusBaixaCompteByTextQuery : IRequest<ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetMotiusBaixaCompteByTextQueryHandler : IRequestHandler<GetMotiusBaixaCompteByTextQuery, ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMotiusBaixaCompteByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>> Handle(GetMotiusBaixaCompteByTextQuery request, CancellationToken cancellationToken)
        {
            var motiuBaixaCompteDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (motiuBaixaCompteDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>().Success(motiuBaixaCompteDb.Adapt<List<ReadMotiuBaixaCompteDTO>>());
            }

            return new ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>().Failure("No s'han trobat Empresas!");
        }
    }
}
