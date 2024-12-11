using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusSuggeriments;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusSuggeriment.Queries
{
    public class GetTipusSuggerimentByIdQuery : IRequest<ResponseWrapper<ReadTipusSuggerimentDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusSuggerimentByIdQueryHandler : IRequestHandler<GetTipusSuggerimentByIdQuery, ResponseWrapper<ReadTipusSuggerimentDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusSuggerimentByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusSuggerimentDTO>> Handle(GetTipusSuggerimentByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusSuggerimentDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusSuggeriment>().GetByIdAsync(request.Id);

            if (tipusSuggerimentDb is not null)
            {
                var TipusSuggerimentDTO = tipusSuggerimentDb.Adapt<ReadTipusSuggerimentDTO>();

                return new ResponseWrapper<ReadTipusSuggerimentDTO>().Success(TipusSuggerimentDTO);
            }

            return new ResponseWrapper<ReadTipusSuggerimentDTO>().Failure("TipusSuggeriment no existeix!");
        }
    }
}
