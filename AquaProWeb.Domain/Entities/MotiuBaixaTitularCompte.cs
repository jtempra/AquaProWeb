using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class MotiuBaixaTitularCompte : BaseEntity
    {
        public string Motiu { get; set; }
        public string Observacions { get; set; }
    }
}
