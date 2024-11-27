using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class TitularCompteContracte : BaseEntity
    {
        public int ClientId
        {
            get; set;
        }
        public Client TitularCompte
        {
            get; set;
        }
        public string IBAN
        {
            get; set;
        }
        public int ContracteId
        {
            get; set;
        }
        public Contracte Contracte
        {
            get; set;
        }
        public DateTime DataAlta
        {
            get; set;
        }
        public DateTime? DataBaixa
        {
            get; set;
        }
        public int? MotiuBaixaTitularCompteId
        {
            get; set;
        }
        public MotiuBaixaTitularCompte MotiuBaixa
        {
            get; set;
        }
        public string Observacions
        {
            get; set;
        }
    }
}
