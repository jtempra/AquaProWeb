using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaTitular;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaTitularCompte;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class MotiuBaixaTitularCompteValidator : AbstractValidator<ReadMotiuBaixaTitularCompteDTO>
	{
		public MotiuBaixaTitularCompteValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadMotiuBaixaTitularCompteDTO>.CreateWithOptions((ReadMotiuBaixaTitularCompteDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
