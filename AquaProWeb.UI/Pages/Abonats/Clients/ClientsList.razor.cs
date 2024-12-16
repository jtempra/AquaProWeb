using AquaProWeb.Common.Responses.Abonats.Clients;
using MudBlazor;

namespace AquaProWeb.UI.Pages.Abonats.Clients
{
    public partial class ClientsList
    {
        public List<ReadClientDTO> Clients { get; set; } = [];
        private bool _loading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadClientsAsync();
        }

        private async Task LoadClientsAsync()
        {
            var response = await _clientService.GetAllClientsAsync();
            if (response.IsSuccessful)
            {
                Clients = response.Data;
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

        private async Task AddClientAsync()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<AddClientDialog>("Crear Client", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                // TODO caldria recarregar la llista de carrers
                _snackbar.Add("Tot correcte!", Severity.Success);
            }
        }

        private async Task UpdateClientAsync(int Id)
        {
            var parameters = new DialogParameters();

            // el carrer a editar la podem agafar de la taula o be de la BD, aqui l'agafem de la BD

            var response = await _clientService.GetClientByIdAsync(Id);
            if (response.IsSuccessful)
            {
                var client = response.Data;
                parameters.Add(nameof(UpdateClientDialog.ReadClientDto), client);
            }


            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<UpdateClientDialog>("Actualitzar Client", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadClientsAsync();
            }
        }
        private async Task DeleteClientAsync(int Id, string Nom)
        {
            string miss = $"Seguro que quiere borrar el cliente {Nom}?";
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

            var dialog = _dialogService.Show<Shared.DeleteConfirmationDialog>("Esborrar Client", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                var response = await _clientService.DeleteClientAsync(Id);
                if (response.IsSuccessful)
                {
                    await LoadClientsAsync();
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
