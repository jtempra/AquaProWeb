using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaComptador;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaComptador.Queries
{
    public class GetMotiusBaixaComptadorByTextQuery : IRequest<ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetMotiusBaixaComptadorByTextQueryHandler : IRequestHandler<GetMotiusBaixaComptadorByTextQuery, ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMotiusBaixaComptadorByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>> Handle(GetMotiusBaixaComptadorByTextQuery request, CancellationToken cancellationToken)
        {
            var motiuBaixaComptadorDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaComptador>().GetByTextAsync(request.Text);

            if (motiuBaixaComptadorDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>().Success(motiuBaixaComptadorDb.Adapt<List<ReadMotiuBaixaComptadorDTO>>());
            }

            return new ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>().Failure("No s'han trobat Empresas!");
        }
    }
}
