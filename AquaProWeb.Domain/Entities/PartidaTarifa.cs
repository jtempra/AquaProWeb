using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class PartidaTarifa : BaseEntity
    {
        public string Partida { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
        public ICollection<SubconcepteTarifaPartida> SubconceptesPartida { get; set; }
    }
}
