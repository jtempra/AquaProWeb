using AquaProWeb.Common.Enums;
using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class Avis : BaseEntity
    {
        public string Usuari { get; set; }
        public string Missatge { get; set; }
        public DateTime DataInici { get; set; }
        public DateTime DataFi { get; set; }
        public ImportanciaAvis Importancia { get; set; }
        public Boolean EnviarEmail { get; set; } = false;
        public string Emails { get; set; } = string.Empty;
    }
}
