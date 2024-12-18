﻿using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaComptador;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaCompte;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class MotiuBaixaCompteValidator : AbstractValidator<ReadMotiuBaixaCompteDTO>
	{
		public MotiuBaixaCompteValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadMotiuBaixaCompteDTO>.CreateWithOptions((ReadMotiuBaixaCompteDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
