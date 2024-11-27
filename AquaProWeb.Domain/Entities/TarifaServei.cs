using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class TarifaServei : BaseEntity
    {
        public string Tarifa { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
        public int ServeiTarifaId { get; set; }
        public ServeiTarifa ServeiTarifa { get; set; }
        public ICollection<SubconcepteTarifa> Subconceptes { get; set; }
        public ICollection<ContracteTarifaServei> TarifesServeisContracte { get; set; } = new List<ContracteTarifaServei>();
    }
}
