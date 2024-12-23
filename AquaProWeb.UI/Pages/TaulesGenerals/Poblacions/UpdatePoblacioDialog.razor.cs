
using AquaProWeb.Common.Requests.TaulesGenerals.Poblacions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.Poblacions
{
    public partial class UpdatePoblacioDialog
    {
        [Parameter]
        public SavePoblacioDTO UpdatePoblacioDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;
        private async Task SaveAsync()
        {
            var response = await _poblacioService.UpdatePoblacioAsync(UpdatePoblacioDto);
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