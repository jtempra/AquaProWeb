using AquaProWeb.Common.Responses.TaulesGenerals.MarquesComptador;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaComptador;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class MotiuBaixaComptadorValidator : AbstractValidator<ReadMotiuBaixaCompteDTO>
	{
		public MotiuBaixaComptadorValidator()
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
