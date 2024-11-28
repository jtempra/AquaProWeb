using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaComptador;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaContacte;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class MotiuBaixaContacteValidator : AbstractValidator<ReadMotiuBaixaContacteDTO>
	{
		public MotiuBaixaContacteValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadMotiuBaixaContacteDTO>.CreateWithOptions((ReadMotiuBaixaContacteDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
