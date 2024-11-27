using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class SolicitudBaixa : BaseEntity
    {
        public int ContracteId { get; set; }
        public Contracte Contracte { get; set; }
        public DateTime DataSolicitud { get; set; }
        public int TipusBaixaClientId { get; set; }
        public TipusBaixaClient Motiu { get; set; }
        public TipusSolicitant Solicitant { get; set; }
        public SituacioBaixa Situacio { get; set; }
        public DateTime DataSituacio { get; set; }
        public string Observacions { get; set; }
    }
}
