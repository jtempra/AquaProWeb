
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Responses.TaulesGenerals.CanalsCobrament;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.CanalsCobrament
{
    public partial class CanalsCobramentList
    {
        public List<ReadCanalCobramentDTO> CanalsCobrament { get; set; } = [];
        private bool _loading = true;
        protected override async Task OnInitializedAsync()
        {
            var response = await _canalCobramentService.GetAllCanalsCobramentAsync();
            if (response.IsSuccessful)
            {
                CanalsCobrament = response.Data;
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

        private async Task LoadCanalsCobramentAsync()
        {
            var response = await _canalCobramentService.GetAllCanalsCobramentAsync();
            if (response.IsSuccessful)
            {
                CanalsCobrament = response.Data;
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

        private async Task AddCanalCobramentAsync()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<AddCanalCobramentDialog>("Crear Canal de Cobrament", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                // TODO caldria recarregar la llista de canals
                _snackbar.Add("Tot correcte!", Severity.Success);
            }
        }

        private async Task UpdateCanalCobramentAsync(int Id)
        {
            var parameters = new DialogParameters();

            // el canal a editar la podem agafar de la taula o be de la BD, aqui l'agafem de la taula

            var canal = CanalsCobrament.FirstOrDefault(e => e.Id == Id);


            parameters.Add(nameof(UpdateCanalCobramentDialog.UpdateCanalCobramentDto), new UpdateCanalCobramentDTO()
            {
                Id = canal.Id,
                Canal = canal.Canal,
                FormaPagament = canal.FormaPagament,
                Descripcio = canal.Descripcio,
                Observacions = canal.Observacions,
                BIC = canal.BIC
            });

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<UpdateCanalCobramentDialog>("Actualitzar Poblacio", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadCanalsCobramentAsync();
            }
        }
        private async Task DeleteCanalCobramentAsync(int Id, string Nom)
        {
            string miss = $"Seguro que quiere borrar el canal de cobro {Nom}?";
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

            var dialog = _dialogService.Show<Shared.DeleteConfirmationDialog>("Esborrar canal de cobrament", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                var response = await _canalCobramentService.DeleteCanalCobramentAsync(Id);
                if (response.IsSuccessful)
                {
                    await LoadCanalsCobramentAsync();
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