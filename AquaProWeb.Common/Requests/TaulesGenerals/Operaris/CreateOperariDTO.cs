using AquaProWeb.Common.Enums;

namespace AquaProWeb.Common.Requests.TaulesGenerals.Operaris
{
    public class CreateOperariDTO
    {
        public string Nom { get; set; }
        public string Mobil { get; set; }
        public TipusOperari Tipus { get; set; }
        public string Observacions { get; set; }
    }
}
