using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class MotiuBaixaCompte : BaseEntity
    {
        public string Motiu { get; set; }
        public string Observacions { get; set; }
    }
}
