using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class IncidenciaContracte : BaseEntity
    {
        public string Incidencia { get; set; }
        public int TipusIncidenciaContracteId { get; set; }
        public TipusIncidenciaContracte Tipus { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
