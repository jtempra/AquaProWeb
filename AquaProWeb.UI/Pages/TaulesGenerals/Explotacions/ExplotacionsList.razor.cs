
using AquaProWeb.Common.Requests.Explotacions;
using AquaProWeb.Common.Responses.Explotacions;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.Explotacions
{
    public partial class ExplotacionsList
    {
        public List<ReadExplotacioDTO> Explotacions { get; set; } = [];
        private bool _loading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadExplotacionsAsync();
        }

        private async Task LoadExplotacionsAsync()
        {
            var response = await _explotacioService.GetAllExplotacionsAsync();
            if (response.IsSuccessful)
            {
                Explotacions = response.Data;
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

        private async Task AddExplotacioAsync()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<AddExplotacioDialog>("Crear Explotació", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadExplotacionsAsync();
            }
        }

        private async Task UpdateExplotacioAsync(int Id)
        {
            var parameters = new DialogParameters();

            // la explotació a editar la podem agafar de la taula o be de la BD, aqui l'agafem de la taula

            var explotacio = Explotacions.FirstOrDefault(e => e.Id == Id);


            parameters.Add(nameof(UpdateExplotacioDialog.UpdateExplotacioDto), new SaveExplotacioDTO()
            {
                Id = explotacio.Id,
                Codi = explotacio.Codi,
                Nom = explotacio.Nom,
                Observacions = explotacio.Observacions
            });

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<UpdateExplotacioDialog>("Actualitzar Explotació", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadExplotacionsAsync();
            }
        }
        private async Task DeleteExplotacioAsync(int Id, string Nom)
        {
            string miss = $"Seguro que quiere borrar la Explotación {Nom}?";
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

            var dialog = _dialogService.Show<Shared.DeleteConfirmationDialog>("Esborrar Explotació", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                var response = await _explotacioService.DeleteExplotacioAsync(Id);
                if (response.IsSuccessful)
                {
                    await LoadExplotacionsAsync();
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