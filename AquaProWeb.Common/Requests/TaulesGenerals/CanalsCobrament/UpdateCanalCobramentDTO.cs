using AquaProWeb.Common.Enums;

namespace AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament
{
    public class UpdateCanalCobramentDTO
    {
        public int Id { get; set; }
        public string Canal { get; set; }
        public FormaPagament FormaPagament { get; set; }
        public string? Descripcio { get; set; }
        public string? Observacions { get; set; }
        public string? BIC { get; set; }
    }
}
