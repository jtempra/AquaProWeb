using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class ContacteContracte : BaseEntity
    {
        public int ClientId
        {
            get; set;
        }
        public Client Client
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
        public TipusContacte TipusContacte
        {
            get; set;
        }
        public int? MotiuBaixaContacteId
        {
            get; set;
        }
        public MotiuBaixaContacte MotiuBaixa
        {
            get; set;
        }
        public string? Observacions
        {
            get; set;
        }
    }
}
