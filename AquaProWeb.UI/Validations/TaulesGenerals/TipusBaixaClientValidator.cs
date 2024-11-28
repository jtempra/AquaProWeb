using AquaProWeb.Common.Responses.TaulesGenerals.TipusBaixaClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusCampanyes;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class TipusBaixaClientValidator : AbstractValidator<ReadTipusBaixaClientDTO>
	{
		public TipusBaixaClientValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusBaixaClientDTO>.CreateWithOptions((ReadTipusBaixaClientDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
