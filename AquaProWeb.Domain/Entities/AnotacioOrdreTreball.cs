using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class AnotacioOrdreTreball : BaseEntity
    {
        public string Descripcio
        {
            get; set;
        }
        public int OrdreTreballId
        {
            get; set;
        }
        public DateTime Data
        {
            get; set;
        }
        public int OperariId
        {
            get; set;
        }
        public Operari Operari
        {
            get; set;
        }
        public string Observacions
        {
            get; set;
        }

    }
}
