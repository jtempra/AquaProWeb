using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaContacte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaContacte.Queries
{
    public class GetMotiuBaixaContacteByIdQuery : IRequest<ResponseWrapper<ReadMotiuBaixaContacteDTO>>
    {
        public int Id { get; set; }
    }

    public class GetMotiuBaixaContacteByIdQueryHandler : IRequestHandler<GetMotiuBaixaContacteByIdQuery, ResponseWrapper<ReadMotiuBaixaContacteDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMotiuBaixaContacteByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadMotiuBaixaContacteDTO>> Handle(GetMotiuBaixaContacteByIdQuery request, CancellationToken cancellationToken)
        {
            var motiuBaixaContacteDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaContacte>().GetByIdAsync(request.Id);

            if (motiuBaixaContacteDb is not null)
            {
                var MotiuBaixaContacteDTO = motiuBaixaContacteDb.Adapt<ReadMotiuBaixaContacteDTO>();

                return new ResponseWrapper<ReadMotiuBaixaContacteDTO>().Success(MotiuBaixaContacteDTO);
            }

            return new ResponseWrapper<ReadMotiuBaixaContacteDTO>().Failure("El MotiuBaixa Contacte no existeix!");
        }
    }
}
