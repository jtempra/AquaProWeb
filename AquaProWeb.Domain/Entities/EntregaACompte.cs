using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class EntregaACompte : BaseEntity
    {
        public int ContracteId { get; set; }
        public Contracte Contracte { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal Import { get; set; } = 0m;
        public int ConcepteCobramentId { get; set; }
        public ConcepteCobrament Concepte { get; set; }
        public string Observacions { get; set; }

    }
}
