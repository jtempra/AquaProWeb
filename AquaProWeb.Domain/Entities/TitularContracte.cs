using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class TitularContracte : BaseEntity
    {
        public int ClientId
        {
            get; set;
        }
        public Client Titular
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
        public int? MotiuBaixaTitularId
        {
            get; set;
        }
        public MotiuBaixaTitular MotiuBaixa
        {
            get; set;
        }
        public string Observacions
        {
            get; set;
        }

    }
}
