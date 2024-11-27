using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class MotiuBaixaContacte : BaseEntity
    {
        public string Motiu { get; set; }
        public string Observacions { get; set; }
        //public ICollection<ContacteContracte> ContactesContracte { get; set; }
    }
}
