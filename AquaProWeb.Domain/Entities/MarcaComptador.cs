using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class MarcaComptador : BaseEntity
    {
        public string Marca { get; set; }
        public string Fabricant { get; set; }
        public string Observacions { get; set; }
        public ICollection<Comptador> Comptadors { get; set; }
    }
}
