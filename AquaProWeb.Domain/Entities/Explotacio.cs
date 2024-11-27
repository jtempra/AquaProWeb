using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class Explotacio : BaseEntity
    {
        public string Codi
        {
            get; set;
        }
        public string Nom
        {
            get; set;
        }
        public string Observacions
        {
            get; set;
        }
        public ICollection<Poblacio>? Poblacions
        {
            get; set;
        }
    }
}
