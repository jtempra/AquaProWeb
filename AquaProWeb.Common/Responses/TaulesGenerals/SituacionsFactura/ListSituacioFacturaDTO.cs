using AquaProWeb.Common.Enums;

namespace AquaProWeb.Common.Responses.TaulesGenerals.SituacionsFactura
{
    public class ListSituacioFacturaDTO
    {
        public int Id { get; set; }
        public EstatFactura Estat { get; set; }
        public string Situacio { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
