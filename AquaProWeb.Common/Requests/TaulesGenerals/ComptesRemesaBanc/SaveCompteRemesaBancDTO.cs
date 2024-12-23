namespace AquaProWeb.Common.Requests.TaulesGenerals.ComptesRemesaBanc
{
    public class SaveCompteRemesaBancDTO
    {
        public int Id { get; set; }
        public string Descripcio { get; set; }
        public string IBAN { get; set; }
        public string BIC { get; set; }
        public string Sufixe { get; set; }
        public Boolean Activa { get; set; } = true;
        public string? Observacions { get; set; }
    }
}
