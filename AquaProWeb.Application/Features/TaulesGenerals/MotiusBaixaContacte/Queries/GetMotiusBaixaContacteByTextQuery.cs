using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaContacte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaContacte.Queries
{
    public class GetMotiusBaixaContacteByTextQuery : IRequest<ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetMotiusBaixaContacteByTextQueryHandler : IRequestHandler<GetMotiusBaixaContacteByTextQuery, ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMotiusBaixaContacteByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>> Handle(GetMotiusBaixaContacteByTextQuery request, CancellationToken cancellationToken)
        {
            var motiuBaixaContacteDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaContacte>().GetByTextAsync(request.Text);

            if (motiuBaixaContacteDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>().Success(motiuBaixaContacteDb.Adapt<List<ReadMotiuBaixaContacteDTO>>());
            }

            return new ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>().Failure("No s'han trobat Empresas!");
        }
    }
}
