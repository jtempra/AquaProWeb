using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class MotiuBaixaTitular : BaseEntity
    {
        public string Motiu { get; set; }
        public string Observacions { get; set; }

        public ICollection<TitularContracte> TitularsContracte { get; set; }
    }
}
