using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.TipusVia
{
    public partial class AddTipusViaDialog
    {
        [Parameter]
        public CreateTipusViaDTO CreateTipusViaDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;
        private List<Domain.Entities.TipusVia> TipusVia { get; set; } = [];

        private async Task SaveAsync()
        {
            var response = await _tipusViaService.AddTipusViaAsync(CreateTipusViaDto);
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
