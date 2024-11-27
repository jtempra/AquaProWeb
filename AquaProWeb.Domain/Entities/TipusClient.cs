using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class TipusClient : BaseEntity
    {
        public string Tipus { get; set; }
        public string Observacions { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
