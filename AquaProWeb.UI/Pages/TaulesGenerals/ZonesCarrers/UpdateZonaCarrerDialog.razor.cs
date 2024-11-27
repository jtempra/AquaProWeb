using AquaProWeb.Common.Requests.TaulesGenerals.ZonesCarrers;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.ZonesCarrers
{
    public partial class UpdateZonaCarrerDialog
    {

        [Parameter]
        public UpdateZonaCarrerDTO UpdateZonaCarrerDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;
        private async Task SaveAsync()
        {
            var response = await _zonaCarrerService.UpdateZonaCarrerAsync(UpdateZonaCarrerDto);
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
