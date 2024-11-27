using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class CompteTransferenciaClient : BaseEntity
    {
        public string Descripcio
        {
            get; set;
        }
        public string IBAN
        {
            get; set;
        }
        public string BIC
        {
            get; set;
        }
        public Boolean Activa { get; set; } = true;
        public string? Observacions
        {
            get; set;
        }
    }
}
