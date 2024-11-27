using AquaProWeb.Common.Enums;
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.CanalsCobrament
{
    public partial class UpdateCanalCobramentDialog
    {
        [Parameter]
        public UpdateCanalCobramentDTO UpdateCanalCobramentDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;

        private FormaPagament FormesPagament { get; set; }

        private async Task SaveAsync()
        {
            var response = await _canalCobramentService.UpdateCanalCobramentAsync(UpdateCanalCobramentDto);
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

        private void Cancel() => MudDialog.Cancel();
    }
}
