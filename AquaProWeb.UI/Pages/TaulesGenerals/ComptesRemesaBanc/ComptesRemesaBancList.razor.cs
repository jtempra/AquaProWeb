
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.UI.Pages.TaulesGenerals.CanalsCobrament;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.ComptesRemesaBanc
{
    public partial class ComptesRemesaBancList
    {
        public List<ReadCompteRemesaBancDTO> ComptesRemesaBanc { get; set; } = [];
        private bool _loading = true;
        protected override async Task OnInitializedAsync()
        {
	        await LoadComptesRemesaBancAsync();
        }

        private async Task LoadComptesRemesaBancAsync()
        {
            var response = await _compteRemesaBancService.GetAllComptesRemesaBancAsync();
            if (response.IsSuccessful)
            {
	            ComptesRemesaBanc = response.Data;
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

        private async Task AddCompteRemesaAsync()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<AddCompteRemesaBancDialog>("Crear Compte Remesa Banc", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                // TODO caldria recarregar la llista de canals
                _snackbar.Add("Tot correcte!", Severity.Success);
            }
        }

        private async Task UpdateCompteRemesaBancAsync(int Id)
        {
            var parameters = new DialogParameters();

            // el canal a editar la podem agafar de la taula o be de la BD, aqui l'agafem de la taula

            var compte = ComptesRemesaBanc.FirstOrDefault(e => e.Id == Id);


            parameters.Add(nameof(UpdateCompteRemesaBancDialog.UpdateCompteRemesaBancDto), new UpdateCompteRemesaBancDTO()
            {
                Id = compte.Id,
                Descripcio = compte.Descripcio,
                IBAN = compte.IBAN,
                Observacions = compte.Observacions,
                Activa = compte.Activa,
                Sufixe = compte.Sufixe,
                BIC = compte.BIC
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
                await LoadComptesRemesaBancAsync();
            }
        }
        private async Task DeleteCompteRemesaBancAsync(int Id, string Nom)
        {
            string miss = $"Seguro que quiere borrar la cuenta de remesa {Nom}?";
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
                var response = await _compteRemesaBancService.DeleteCompteRemesaBancAsync(Id);
                if (response.IsSuccessful)
                {
                    await LoadComptesRemesaBancAsync();
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