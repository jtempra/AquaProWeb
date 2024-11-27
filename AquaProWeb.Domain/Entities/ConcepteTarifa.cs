using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class ConcepteTarifa : BaseEntity
    {
        public string Descripcio
        {
            get; set;
        }
        public string? Observacions
        {
            get; set;
        }
        public Boolean Actiu { get; set; } = false;
        public int Ordre { get; set; } = 1;
        public string? CodiComptable
        {
            get; set;
        }
        public int EmpresaId
        {
            get; set;
        }
        public Empresa Empresa
        {
            get; set;
        }
        public ICollection<SubconcepteTarifa> SubconceptesTarifa
        {
            get; set;
        }
    }
}
