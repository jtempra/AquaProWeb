namespace AquaProWeb.Common.Responses.TaulesGenerals.Paisos
{
    public class ReadPaisDTO
    {
        public int Id { get; set; }
        public string Codi { get; set; }
        public string NomPais { get; set; }
        public string Observacions { get; set; } = string.Empty;
    }
}
