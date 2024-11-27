using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class ConcepteCobrament : BaseEntity
    {
        public string Concepte
        {
            get; set;
        }
        public string? Descripcio
        {
            get; set;
        }
        public string? Observacions
        {
            get; set;
        }
        public string? CodiComptable
        {
            get; set;
        }
    }
}
