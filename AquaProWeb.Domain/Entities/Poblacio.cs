using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class Poblacio : BaseEntity
    {
        public string Nom
        {
            get; set;
        }
        public string CodiINE
        {
            get; set;
        }
        public string Observacions
        {
            get; set;
        }
        public int ExplotacioId
        {
            get; set;
        }
        public Explotacio Explotacio
        {
            get; set;
        }
        public ICollection<Carrer> Carrers
        {
            get; set;
        }
        public ICollection<Ubicacio> Ubicacions
        {
            get; set;
        }

    }
}
