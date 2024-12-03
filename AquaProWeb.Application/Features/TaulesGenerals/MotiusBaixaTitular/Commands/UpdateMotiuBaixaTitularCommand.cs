using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaTitular;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaTitular.Commands
{
    public class UpdateMotiuBaixaTitularCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateMotiuBaixaTitularDTO UpdateMotiuBaixaTitular { get; set; }
    }

    public class UpdateMotiuBaixaTitularCommandHandler : IRequestHandler<UpdateMotiuBaixaTitularCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMotiuBaixaTitularCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateMotiuBaixaTitularCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var motiuBaixaTitularDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaTitular>().GetByIdAsync(request.UpdateMotiuBaixaTitular.Id);

            if (motiuBaixaTitularDb is not null)
            {
                request.UpdateMotiuBaixaTitular.Adapt(motiuBaixaTitularDb);

                await _unitOfWork.WriteRepositoryFor<MotiuBaixaTitular>().UpdateAsync(motiuBaixaTitularDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(motiuBaixaTitularDb.Id, "Canal de cobrament actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El motiu de baixa de Titular no existeix!");

        }
    }
}
