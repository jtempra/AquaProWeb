using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class SolicitudAlta : BaseEntity
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime DataSolicitud { get; set; }
        public TipusSolicitant Solicitant { get; set; }
        public SituacioAlta Situacio { get; set; }
        public DateTime DataSituacio { get; set; }
        public string Observacions { get; set; }

    }
}
