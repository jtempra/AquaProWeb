using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.Carrers
{
    public partial class CarrersList
    {
        public List<ReadCarrerDTO> Carrers { get; set; } = [];
        private bool _loading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadCarrersAsync();
        }

        private async Task LoadCarrersAsync()
        {
            var response = await _carrerService.GetAllCarrersAsync();
            if (response.IsSuccessful)
            {
                Carrers = response.Data;
            }
            else
            {
                foreach (var miss in response.Messages)
                {
                    _snackbar.Add(miss, Severity.Error);
                }
            }

            _loading = false;
        }

        private async Task AddCarrerAsync()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<AddCarrerDialog>("Crear Carrer", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                // TODO caldria recarregar la llista de carrers
                _snackbar.Add("Tot correcte!", Severity.Success);
            }
        }

        private async Task UpdateCarrerAsync(int Id)
        {
            var parameters = new DialogParameters();

            // el carrer a editar la podem agafar de la taula o be de la BD, aqui l'agafem de la BD

            var response = await _carrerService.GetCarrerByIdAsync(Id);
            if (response.IsSuccessful)
            {
                var carrer = response.Data;
                parameters.Add(nameof(UpdateCarrerDialog.ReadCarrerDto), carrer);
            }


            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<UpdateCarrerDialog>("Actualitzar Carrer", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadCarrersAsync();
            }
        }
        private async Task DeleteCarrerAsync(int Id, string Nom)
        {
            string miss = $"Seguro que quiere borrar la Calle {Nom}?";
            var parameters = new DialogParameters()
            {
                {nameof(Shared.DeleteConfirmationDialog.Message),miss}
            };

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            var dialog = _dialogService.Show<Shared.DeleteConfirmationDialog>("Esborrar Carrer", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                var response = await _carrerService.DeleteCarrerAsync(Id);
                if (response.IsSuccessful)
                {
                    await LoadCarrersAsync();
                    _snackbar.Add(response.Messages[0], Severity.Success);
                }
                else
                {
                    foreach (var message in response.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }
        }
    }
}
