using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaContacte;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaTitular;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class MotiuBaixaTitularValidator : AbstractValidator<ReadMotiuBaixaTitularDTO>
	{
		public MotiuBaixaTitularValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadMotiuBaixaTitularDTO>.CreateWithOptions((ReadMotiuBaixaTitularDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
