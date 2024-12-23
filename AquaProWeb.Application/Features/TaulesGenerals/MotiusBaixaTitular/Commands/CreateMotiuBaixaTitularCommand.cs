using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaTitular;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaTitular.Commands
{
    public class CreateMotiuBaixaTitularCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveMotiuBaixaTitularDTO CreateMotiuBaixaTitular { get; set; }
    }

    public class CreateMotiuBaixaTitularCommandHandler : IRequestHandler<CreateMotiuBaixaTitularCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMotiuBaixaTitularCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateMotiuBaixaTitularCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var motiuBaixaTitular = request.CreateMotiuBaixaTitular.Adapt<MotiuBaixaTitular>();

            await _unitOfWork.WriteRepositoryFor<MotiuBaixaTitular>().AddAsync(motiuBaixaTitular);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(motiuBaixaTitular.Id, "Canal de cobrament creat correctament!");
        }
    }
}
