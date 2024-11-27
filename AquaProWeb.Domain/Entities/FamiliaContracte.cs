using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class FamiliaContracte : BaseEntity
    {
        public string Codi { get; set; }
        public string Familia { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
        public ICollection<Contracte> Contractes { get; set; }
    }
}
