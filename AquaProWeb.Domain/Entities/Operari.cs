using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class Operari : BaseEntity
    {
        public string Nom { get; set; }
        public string Mobil { get; set; }
        public TipusOperari Tipus { get; set; }
        public string Observacions { get; set; }
        public ICollection<ComptadorUbicacio> ComptadorsAlta { get; set; }
        public ICollection<ComptadorUbicacio> ComptadorsBaixa { get; set; }
        public ICollection<AnotacioContracte> Anotacions { get; set; }
        public ICollection<OrdreTreball> OrdresTreballCreador { get; set; }
        public ICollection<OrdreTreball> OrdresTreballResponsable { get; set; }
        public ICollection<OperariOrdre> OrdresTreballOperari { get; set; }
    }
}
