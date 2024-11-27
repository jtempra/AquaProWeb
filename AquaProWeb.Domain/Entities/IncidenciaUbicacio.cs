using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class IncidenciaUbicacio : BaseEntity
    {
        public string Incidencia { get; set; }
        public int TipusIncidenciaUbicacioId { get; set; }
        public TipusIncidenciaUbicacio Tipus { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
