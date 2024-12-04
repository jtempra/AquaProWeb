using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusClient.Queries
{
    public class GetTipusClientByIdQuery : IRequest<ResponseWrapper<ReadTipusClientDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusClientByIdQueryHandler : IRequestHandler<GetTipusClientByIdQuery, ResponseWrapper<ReadTipusClientDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusClientByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusClientDTO>> Handle(GetTipusClientByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusClientDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusClient>().GetByIdAsync(request.Id);

            if (tipusClientDb is not null)
            {
                var TipusClientDTO = tipusClientDb.Adapt<ReadTipusClientDTO>();

                return new ResponseWrapper<ReadTipusClientDTO>().Success(TipusClientDTO);
            }

            return new ResponseWrapper<ReadTipusClientDTO>().Failure("TipusClient no existeix!");
        }
    }
}
