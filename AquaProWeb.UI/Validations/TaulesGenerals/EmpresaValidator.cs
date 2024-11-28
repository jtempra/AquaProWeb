using AquaProWeb.Common.Requests.TaulesGenerals.Carrers;
using AquaProWeb.Common.Responses.TaulesGenerals.Empreses;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class EmpresaValidator :  AbstractValidator<ReadEmpresaDTO>
	{
		public EmpresaValidator()
		{
				
		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadEmpresaDTO>.CreateWithOptions((ReadEmpresaDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};
	}
}
