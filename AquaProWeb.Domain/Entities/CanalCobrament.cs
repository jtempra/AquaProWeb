using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class CanalCobrament : BaseEntity
    {
        public string Canal
        {
            get; set;
        }
        public FormaPagament FormaPagament
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
        public string? BIC
        {
            get; set;
        }

    }
}
