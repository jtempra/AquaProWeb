namespace AquaProWeb.Common.Responses.TaulesGenerals.Poblacions
{
    public class ReadPoblacioDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string CodiINE { get; set; }
        public string Observacions { get; set; }
        public int ExplotacioId { get; set; }
        public ExplotacioDTO Explotacio { get; set; }
    }
}
