using AquaProWeb.Common.Enums;
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using AquaProWeb.UI.Validations;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.CanalsCobrament
{
    public partial class AddCanalCobramentDialog
    {
        [Parameter]
        public CreateCanalCobramentDTO CreateCanalCobramentDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;

        public CanalCobramentValidator canalCobramentValidator = new();
        private FormaPagament FormesPagament { get; set; }

        private async Task Submit()
        {
            await _form.Validate();

            if (_form.IsValid)
            {
                var response = await _canalCobramentService.AddCanalCobramentAsync(CreateCanalCobramentDto);
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