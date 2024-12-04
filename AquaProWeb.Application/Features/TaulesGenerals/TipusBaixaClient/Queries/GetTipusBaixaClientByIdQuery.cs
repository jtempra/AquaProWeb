using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusBaixaClients;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusBaixaClient.Queries
{
    public class GetTipusBaixaClientByIdQuery : IRequest<ResponseWrapper<ReadTipusBaixaClientDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusBaixaClientByIdQueryHandler : IRequestHandler<GetTipusBaixaClientByIdQuery, ResponseWrapper<ReadTipusBaixaClientDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusBaixaClientByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusBaixaClientDTO>> Handle(GetTipusBaixaClientByIdQuery request, CancellationToken cancellationToken)
        {
            var TipusBaixaClientDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusBaixaClient>().GetByIdAsync(request.Id);

            if (TipusBaixaClientDb is not null)
            {
                var TipusBaixaClientDTO = TipusBaixaClientDb.Adapt<ReadTipusBaixaClientDTO>();

                return new ResponseWrapper<ReadTipusBaixaClientDTO>().Success(TipusBaixaClientDTO);
            }

            return new ResponseWrapper<ReadTipusBaixaClientDTO>().Failure("TipusBaixaClient no existeix!");
        }
    }
}
