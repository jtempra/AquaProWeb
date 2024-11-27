
using AquaProWeb.Common.Requests.Explotacions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.Explotacions
{
    public partial class UpdateExplotacioDialog
    {
        [Parameter]
        public UpdateExplotacioDTO UpdateExplotacioDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;
        private async Task SaveAsync()
        {
            var response = await _explotacioService.UpdateExplotacioAsync(UpdateExplotacioDto);
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
