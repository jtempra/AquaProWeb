using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class IncidenciaClient : BaseEntity
    {
        public string Incidencia { get; set; }
        public int TipusIncidenciaClientId { get; set; }
        public TipusIncidenciaClient Tipus { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
