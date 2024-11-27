namespace AquaProWeb.Domain.Entities
{
    public class SubconcepteTarifaPartida
    {
        public int SubconcepteTarifaId { get; set; }
        public SubconcepteTarifa SubconcepteTarifa { get; set; }
        public int PartidaId { get; set; }
        public PartidaTarifa Partida { get; set; }
        public string Observacions { get; set; }
    }
}
