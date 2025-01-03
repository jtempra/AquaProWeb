﻿using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.FamiliesConcepteFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Empreses.Commands
{
    public class CreateFamiliaConcepteFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveFamiliaConcepteFacturaDTO CreateFamiliaConcepteFactura { get; set; }
    }

    public class CreateFamiliaConcepteFacturaCommandHandler : IRequestHandler<CreateFamiliaConcepteFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFamiliaConcepteFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateFamiliaConcepteFacturaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var familiaConcepteFactura = request.CreateFamiliaConcepteFactura.Adapt<FamiliaConcepteFactura>();

            await _unitOfWork.WriteRepositoryFor<FamiliaConcepteFactura>().AddAsync(familiaConcepteFactura);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(familiaConcepteFactura.Id, "Empresa creat correctament!");
        }
    }
}
