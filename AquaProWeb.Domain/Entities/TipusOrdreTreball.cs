using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class TipusOrdreTreball : BaseEntity
    {
        public string Tipus { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
        public List<TipusRequerimentTipusOrdreTreball> RequerimentsTipusOrdreTreball { get; set; }

    }
}
