using AquaProWeb.Common.Requests.Explotacions;
using AquaProWeb.UI.Validations;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.Explotacions
{
    public partial class AddExplotacioDialog
    {
        [Parameter]
        public CreateExplotacioDTO CreateExplotacioDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;

        public ExplotacioValidator explotacioValidator = new();


        private async Task Submit()
        {
            await _form.Validate();

            if (_form.IsValid)
            {
                var response = await _explotacioService.AddExplotacioAsync(CreateExplotacioDto);
                if (response.IsSuccessful)
                {
                    _snackbar.Add(response.Messages[0], Severity.Success);

                    MudDialog.Close();
                }
                else
                {
                    foreach (var miss in response.Messages)
                    {
                        _snackbar.Add(miss, Severity.Error);
                    }
                }
            }
            else
            {
                _snackbar.Add("lalala", Severity.Error);
                MudDialog.Close();
            }
        }

        private void Cancel() => MudDialog.Cancel();

    }
}