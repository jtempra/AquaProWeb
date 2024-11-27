namespace AquaProWeb.Common.Requests.TaulesGenerals.Poblacions
{
    public class UpdatePoblacioDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string CodiINE { get; set; }
        public string Observacions { get; set; }
        public int ExplotacioId { get; set; }
    }
}
