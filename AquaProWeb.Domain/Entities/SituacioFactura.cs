using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class SituacioFactura : BaseEntity
    {
        public EstatFactura Estat { get; set; }
        public string Situacio {get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
