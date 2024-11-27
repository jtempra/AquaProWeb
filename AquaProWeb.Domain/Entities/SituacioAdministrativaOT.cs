using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class SituacioAdministrativaOT : BaseEntity
    {
        public string Situacio
        {
            get; set;
        }
        public string Descripcio
        {
            get; set;
        }
        public string Observacions
        {
            get; set;
        }
    }
}
