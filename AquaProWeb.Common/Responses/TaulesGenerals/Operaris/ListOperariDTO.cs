using AquaProWeb.Common.Enums;

namespace AquaProWeb.Common.Responses.TaulesGenerals.Operaris
{
    public class ListOperariDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Mobil { get; set; }
        public TipusOperari Tipus { get; set; }
        public string Observacions { get; set; }
    }
}
