namespace AquaProWeb.Common.Requests.TaulesGenerals.Paisos
{
    public class SavePaisDTO
    {
        public int Id { get; set; }
        public string Codi { get; set; }
        public string NomPais { get; set; }
        public string Observacions { get; set; } = string.Empty;
    }
}
