using AquaProWeb.Common.Enums;

namespace AquaProWeb.Common.Responses.TaulesGenerals.SituacionsRebut
{
    public class ListSituacioRebutDTO
    {
        public int Id { get; set; }
        public EstatRebut Estat { get; set; }
        public string Situacio { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
