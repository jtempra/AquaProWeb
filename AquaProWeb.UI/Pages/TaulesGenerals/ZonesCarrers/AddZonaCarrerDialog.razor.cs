using AquaProWeb.Common.Requests.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Domain.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.ZonesCarrers
{
    public partial class AddZonaCarrerDialog
    {

        [Parameter]
        public CreateZonaCarrerDTO CreateZonaCarrerDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;
        private List<ZonaCarrers> ZonaCarrer { get; set; } = [];

        private async Task SaveAsync()
        {
            var response = await _zonaCarrerService.AddZonaCarrerAsync(CreateZonaCarrerDto);
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
