namespace AquaProWeb.Domain.Entities
{
    public class OperariOrdre
    {
        public int OrdreTreballId { get; set; }
        public OrdreTreball OrdreTreball { get; set; }
        public int OperariId { get; set; }
        public Operari Operari { get; set; }
    }
}
