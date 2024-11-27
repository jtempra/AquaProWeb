using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class UsContracte : BaseEntity
    {
        public string Codi { get; set; }
        public string Us { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
        public ICollection<Contracte> Contractes { get; set; }

    }
}
