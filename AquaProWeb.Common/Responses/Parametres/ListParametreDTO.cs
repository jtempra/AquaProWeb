namespace AquaProWeb.Common.Responses.Parametres
{
    public class ListParametreDTO
    {
        public int Id { get; set; }
        public string Descripcio { get; set; }
        public double? ValorNumeric { get; set; }
        public string? ValorString { get; set; }
        public DateTime? ValorData { get; set; }
        public string Observacions { get; set; }
    }
}
