using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class TipusBaixaClient : BaseEntity
    {
        public string TipusBaixa { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }

    }
}
