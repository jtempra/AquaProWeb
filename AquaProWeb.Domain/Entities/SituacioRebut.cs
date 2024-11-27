using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class SituacioRebut : BaseEntity
    {
        public EstatRebut Estat { get; set; } = EstatRebut.Pendent;
        public string Situacio { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
