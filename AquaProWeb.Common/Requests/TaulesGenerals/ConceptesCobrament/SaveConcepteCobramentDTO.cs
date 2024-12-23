namespace AquaProWeb.Common.Requests.TaulesGenerals.ConceptesCobrament
{
    public class SaveConcepteCobramentDTO
    {
        public int Id { get; set; }
        public string Concepte { get; set; }
        public string? Descripcio { get; set; }
        public string? Observacions { get; set; }
        public string? CodiComptable { get; set; }
    }
}
